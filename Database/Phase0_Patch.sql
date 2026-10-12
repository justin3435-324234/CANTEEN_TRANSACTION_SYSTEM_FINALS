-- ============================================================
-- PHASE 0 DB PATCH — school_canteen_db
-- Run this in phpMyAdmin (SQL tab) AFTER importing
-- Database/school_canteen_db(1).sql
-- Safe to re-run: every statement is IF NOT EXISTS guarded
-- via stored-procedure helper (MariaDB 10.4 compatible).
-- ============================================================

-- Helper: add column only if missing
DELIMITER $$
DROP PROCEDURE IF EXISTS phase0_add_column$$
CREATE PROCEDURE phase0_add_column(
    IN p_table VARCHAR(64), IN p_col VARCHAR(64), IN p_def TEXT)
BEGIN
    DECLARE col_exists INT DEFAULT 0;
    SELECT COUNT(*) INTO col_exists
    FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_SCHEMA = DATABASE()
      AND TABLE_NAME = p_table
      AND COLUMN_NAME = p_col;
    IF col_exists = 0 THEN
        SET @ddl = CONCAT('ALTER TABLE `', p_table, '` ADD COLUMN ', p_def);
        PREPARE stmt FROM @ddl;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END$$
DELIMITER ;

-- 1) transactions: checkout needs these (POS cash/salary, receipts, dashboard)
CALL phase0_add_column('transactions', 'transaction_number', '`transaction_number` varchar(30) NULL');
CALL phase0_add_column('transactions', 'payment_method', '`payment_method` varchar(20) NOT NULL DEFAULT ''Cash''');
CALL phase0_add_column('transactions', 'status', '`status` varchar(20) NOT NULL DEFAULT ''Completed''');
CALL phase0_add_column('transactions', 'employee_number', '`employee_number` varchar(50) NULL');
CALL phase0_add_column('transactions', 'kiosk_order_id', '`kiosk_order_id` int(11) NULL');

-- 2) kiosk_orders: pending-orders grid needs order type + payment
CALL phase0_add_column('kiosk_orders', 'order_type', '`order_type` varchar(20) NOT NULL DEFAULT ''DineIn''');
CALL phase0_add_column('kiosk_orders', 'payment_method', '`payment_method` varchar(20) NOT NULL DEFAULT ''Cash''');
-- Phase 4: kiosk salary orders link to an employee (authenticated at the kiosk).
CALL phase0_add_column('kiosk_orders', 'employee_number', '`employee_number` varchar(50) NULL');

-- 3) employees: no running-balance column (no SD limits per spec).
-- Fresh installs use school_canteen_db.sql (no sd_remaining); upgrades that
-- already have the column drop it explicitly below.

-- All-caps guard: triggers normalize deduction_status to UPPER on write and
-- reject anything outside PENDING/COMPLETE. (A plain CHECK does NOT work here:
-- the column uses a case-insensitive collation, so 'Pending' would pass it.)
-- Re-runnable: DROP + CREATE each time.
DELIMITER $$
DROP TRIGGER IF EXISTS `trg_employees_bi`$$
CREATE TRIGGER `trg_employees_bi` BEFORE INSERT ON `employees`
FOR EACH ROW
BEGIN
    SET NEW.`deduction_status` = UPPER(TRIM(NEW.`deduction_status`));
    IF NEW.`deduction_status` NOT IN ('PENDING','COMPLETE') THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'employees.deduction_status must be PENDING or COMPLETE';
    END IF;
END$$
DROP TRIGGER IF EXISTS `trg_employees_bu`$$
CREATE TRIGGER `trg_employees_bu` BEFORE UPDATE ON `employees`
FOR EACH ROW
BEGIN
    SET NEW.`deduction_status` = UPPER(TRIM(NEW.`deduction_status`));
    IF NEW.`deduction_status` NOT IN ('PENDING','COMPLETE') THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'employees.deduction_status must be PENDING or COMPLETE';
    END IF;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS phase0_add_column;

-- 4) Low-stock rule: an item is LOW when 0 < stock <= 10 (uniform threshold).
UPDATE `products` SET `reorder_level` = 10 WHERE `reorder_level` <> 10;

-- 5) Backfill + uniqueness (run once; IGNORE keeps it re-runnable)
UPDATE `transactions`
SET `transaction_number` = CONCAT('TRN-', DATE_FORMAT(transaction_date, '%Y%m%d-'), LPAD(transaction_id, 4, '0'))
WHERE `transaction_number` IS NULL OR `transaction_number` = '';

-- Unique index on transaction_number (only if not already unique)
-- phpMyAdmin: if this errors with "Duplicate key", inspect data first.
-- ALTER TABLE `transactions` ADD UNIQUE KEY `uq_transaction_number` (`transaction_number`);

-- 5) Verify
SELECT 'transactions' AS tbl, COUNT(*) AS row_count FROM `transactions`
UNION ALL SELECT 'transaction_details', COUNT(*) FROM `transaction_details`
UNION ALL SELECT 'kiosk_orders', COUNT(*) FROM `kiosk_orders`
UNION ALL SELECT 'employees', COUNT(*) FROM `employees`
UNION ALL SELECT 'products', COUNT(*) FROM `products`;
