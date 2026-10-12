-- ============================================================
-- PHASE 1: 4-ATTEMPT LOGIN LOCKOUT (users + employees)
-- Run once in phpMyAdmin AFTER school_canteen_db.sql.
-- Safe to re-run (IF NOT EXISTS guarded via helper proc).
-- After 4 failed logins: status='Locked', attempts stay at 4.
-- Unlock:  users:     UPDATE users SET status='Active', login_attempts=0 WHERE username='...';
--          employees: UPDATE employees SET status='Active', login_attempts=0 WHERE username='...';
--          (or use Dashboard Deactivate/Reactivate button for employees)
-- ============================================================

DELIMITER $$
DROP PROCEDURE IF EXISTS phase1_add_column$$
CREATE PROCEDURE phase1_add_column(
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

-- users.login_attempts already exists in fresh installs; no-op there.
CALL phase1_add_column('users', 'login_attempts', '`login_attempts` int(11) NOT NULL DEFAULT 0');

-- employees need the counter.
CALL phase1_add_column('employees', 'login_attempts', '`login_attempts` int(11) NOT NULL DEFAULT 0');

DROP PROCEDURE IF EXISTS phase1_add_column;

-- users.status is already varchar(20): 'Locked' works as-is.
-- employees.status is enum('Active','Inactive'): widen so 'Locked' fits.
ALTER TABLE `employees` MODIFY `status` varchar(20) NOT NULL DEFAULT 'Active';

-- Reset any stale counters (does not unlock anyone).
UPDATE `users` SET `login_attempts` = 0 WHERE `login_attempts` <> 0 AND `status` = 'Active';
UPDATE `employees` SET `login_attempts` = 0 WHERE `login_attempts` <> 0 AND `status` = 'Active';
