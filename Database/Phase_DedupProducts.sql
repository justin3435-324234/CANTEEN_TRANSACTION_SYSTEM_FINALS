-- ============================================================
-- DEDUP PRODUCTS PATCH — school_canteen_db
-- Run this in phpMyAdmin (SQL tab) AFTER importing
-- Database/school_canteen_db.sql
-- Purpose: block duplicate product names (e.g. adding "Spam"
-- when "Spam" / " spam " / "SPAM" already exists).
-- App code (frmDashboard ProductNameExists + 1062 handler) gives
-- the friendly message; this UNIQUE key is the race-proof backstop.
-- Safe to re-run.
-- ============================================================

-- 1) Inspect existing duplicates BEFORE constraining.
-- If this returns rows, merge/delete them first (keep lowest product_id),
-- otherwise the ALTER below will fail with Duplicate entry.
SELECT LOWER(TRIM(product_name)) AS dup_name,
       COUNT(*) AS cnt,
       GROUP_CONCAT(product_id ORDER BY product_id) AS ids,
       GROUP_CONCAT(CONCAT(product_id, ':', product_name, ':', status) SEPARATOR ' | ') AS detail
FROM `products`
GROUP BY LOWER(TRIM(product_name))
HAVING COUNT(*) > 1;

-- 2) Add UNIQUE key on product_name only if missing.
-- Table collation is utf8mb4_general_ci, so the index is
-- automatically case-insensitive ('Spam' = 'SPAM').
DELIMITER $$
DROP PROCEDURE IF EXISTS dedup_add_unique$$
CREATE PROCEDURE dedup_add_unique()
BEGIN
    DECLARE idx_exists INT DEFAULT 0;
    SELECT COUNT(*) INTO idx_exists
    FROM INFORMATION_SCHEMA.STATISTICS
    WHERE TABLE_SCHEMA = DATABASE()
      AND TABLE_NAME = 'products'
      AND INDEX_NAME = 'uq_products_name';
    IF idx_exists = 0 THEN
        ALTER TABLE `products` ADD UNIQUE KEY `uq_products_name` (`product_name`);
    END IF;
END$$
DELIMITER ;

CALL dedup_add_unique();
DROP PROCEDURE IF EXISTS dedup_add_unique;

-- 3) Verify
SELECT INDEX_NAME, NON_UNIQUE, GROUP_CONCAT(COLUMN_NAME ORDER BY SEQ_IN_INDEX) AS cols
FROM INFORMATION_SCHEMA.STATISTICS
WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = 'products'
GROUP BY INDEX_NAME, NON_UNIQUE
ORDER BY INDEX_NAME;
