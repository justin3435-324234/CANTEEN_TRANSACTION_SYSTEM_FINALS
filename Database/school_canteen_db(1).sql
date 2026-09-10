-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 28, 2026 at 07:13 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `school_canteen_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `audit_logs`
--

CREATE TABLE `audit_logs` (
  `log_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `action` varchar(100) NOT NULL,
  `description` varchar(255) DEFAULT NULL,
  `log_date` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `category_id` int(11) NOT NULL,
  `category_name` varchar(50) NOT NULL,
  `status` varchar(20) NOT NULL DEFAULT 'Active',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`category_id`, `category_name`, `status`, `created_at`) VALUES
(2, 'Ulam / Meals', 'Active', '2026-08-18 17:14:04'),
(3, 'Snacks', 'Active', '2026-08-18 17:14:04'),
(4, 'Drinks', 'Active', '2026-08-18 17:14:04'),
(5, 'Desserts', 'Active', '2026-08-18 17:14:04'),
(6, 'Instant Food', 'Active', '2026-08-18 17:14:04');

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `employee_number` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `full_name` varchar(100) NOT NULL,
  `position` varchar(50) NOT NULL,
  `employee_type` enum('Teacher','Employee') NOT NULL,
  `status` enum('Active','Inactive') NOT NULL DEFAULT 'Active',
  `created_at` datetime NOT NULL DEFAULT current_timestamp(),
  `pin` varchar(4) NOT NULL DEFAULT '1234',
  `deduction_status` varchar(20) NOT NULL DEFAULT 'Pending',
  `period_start` date DEFAULT NULL,
  `period_end` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`employee_number`, `username`, `full_name`, `position`, `employee_type`, `status`, `created_at`, `pin`, `deduction_status`, `period_start`, `period_end`) VALUES
('EMP-001', 'john.doe', 'John Doe', 'Staff', 'Employee', 'Active', '2026-08-27 17:00:00', '1234', 'Pending', NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `kiosk_orders`
--

CREATE TABLE `kiosk_orders` (
  `kiosk_order_id` int(11) NOT NULL,
  `order_number` varchar(30) NOT NULL,
  `order_date` datetime NOT NULL DEFAULT current_timestamp(),
  `total_amount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `status` varchar(20) NOT NULL DEFAULT 'Pending'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `kiosk_order_details`
--

CREATE TABLE `kiosk_order_details` (
  `kiosk_order_detail_id` int(11) NOT NULL,
  `kiosk_order_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unit_price` decimal(10,2) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `product_id` int(11) NOT NULL,
  `product_name` varchar(100) NOT NULL,
  `category_id` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL DEFAULT 0.00,
  `stock_quantity` int(11) NOT NULL DEFAULT 0,
  `reorder_level` int(11) NOT NULL DEFAULT 10,
  `status` varchar(20) NOT NULL DEFAULT 'Active',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `product_name`, `category_id`, `price`, `stock_quantity`, `reorder_level`, `status`, `created_at`) VALUES
(102, 'Adobo', 2, 65.00, 9, 5, 'Active', '2026-08-19 18:35:13'),
(103, 'Longganisa', 2, 45.00, 19, 5, 'Active', '2026-08-19 18:35:13'),
(104, 'Spam', 2, 45.00, 19, 5, 'Active', '2026-08-19 18:35:13'),
(105, 'Shanghai', 2, 20.00, 19, 5, 'Active', '2026-08-19 18:35:13'),
(106, 'Rice', 2, 15.00, 27, 5, 'Active', '2026-08-19 18:35:13'),
(107, 'Siomai Big', 3, 10.00, 30, 5, 'Active', '2026-08-19 18:35:13'),
(108, 'Siomai Small', 3, 6.00, 24, 5, 'Active', '2026-08-19 18:35:13'),
(109, 'Siopao', 3, 35.00, 15, 5, 'Active', '2026-08-19 18:35:13'),
(110, 'Turon', 3, 20.00, 29, 5, 'Active', '2026-08-19 18:35:13'),
(111, 'Corndog', 3, 35.00, 10, 5, 'Active', '2026-08-19 18:35:13'),
(112, 'Mineral Water', 4, 15.00, 47, 10, 'Active', '2026-08-19 18:35:13'),
(113, 'Lipton Ice Tea', 4, 25.00, 19, 5, 'Active', '2026-08-19 18:35:13'),
(114, 'Milo', 4, 18.00, 28, 5, 'Active', '2026-08-19 18:35:13'),
(115, 'Kopiko', 4, 18.00, 24, 5, 'Active', '2026-08-19 18:35:13'),
(116, 'Iced Kopiko', 4, 26.00, 16, 5, 'Active', '2026-08-19 18:35:13'),
(117, 'Ice Cream', 5, 20.00, 16, 5, 'Active', '2026-08-19 18:35:13'),
(118, 'Fudgee Bar', 5, 12.00, 24, 5, 'Active', '2026-08-19 18:35:13'),
(119, 'Dowee Donut', 5, 20.00, 28, 5, 'Active', '2026-08-19 18:35:13'),
(120, 'Oreo', 5, 12.00, 28, 5, 'Active', '2026-08-19 18:35:13'),
(121, 'Chocolate Cake', 5, 25.00, 13, 5, 'Active', '2026-08-19 18:35:13'),
(122, 'Cup Noodles Bulalo', 6, 30.00, 9, 5, 'Active', '2026-08-19 18:35:13'),
(123, 'Cup Noodles Seafood', 6, 30.00, 10, 5, 'Active', '2026-08-19 18:35:13'),
(124, 'Pancit Canton', 6, 20.00, 20, 5, 'Active', '2026-08-19 18:35:13'),
(125, 'Lucky Me Noodles', 6, 18.00, 23, 5, 'Active', '2026-08-19 18:35:13'),
(126, 'Lucky Me Pancit Canton', 6, 25.00, 21, 5, 'Active', '2026-08-19 18:35:13');

-- --------------------------------------------------------

--
-- Table structure for table `salary_deductions`
--

CREATE TABLE `salary_deductions` (
  `deduction_id` int(11) NOT NULL,
  `employee_number` varchar(50) NOT NULL,
  `transaction_id` int(11) NOT NULL,
  `deduction_amount` decimal(10,2) NOT NULL,
  `deduction_date` datetime NOT NULL DEFAULT current_timestamp(),
  `deduction_status` enum('Pending','Deducted','Cancelled') NOT NULL DEFAULT 'Pending',
  `remarks` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `stock_movements`
--

CREATE TABLE `stock_movements` (
  `movement_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `movement_type` varchar(30) NOT NULL,
  `quantity` int(11) NOT NULL,
  `remarks` varchar(255) DEFAULT NULL,
  `movement_date` datetime NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

CREATE TABLE `transactions` (
  `transaction_id` int(11) NOT NULL,
  `transaction_date` datetime NOT NULL DEFAULT current_timestamp(),
  `user_id` int(11) NOT NULL,
  `total_amount` decimal(10,2) NOT NULL DEFAULT 0.00,
  `cash_received` decimal(10,2) NOT NULL DEFAULT 0.00,
  `change_amount` decimal(10,2) NOT NULL DEFAULT 0.00
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `transaction_details`
--

CREATE TABLE `transaction_details` (
  `detail_id` int(11) NOT NULL,
  `transaction_id` int(11) NOT NULL,
  `product_id` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `fullname` varchar(100) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` varchar(30) NOT NULL,
  `status` varchar(20) NOT NULL DEFAULT 'Active',
  `login_attempts` int(11) NOT NULL DEFAULT 0,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `fullname`, `username`, `password`, `role`, `status`, `login_attempts`, `created_at`) VALUES
(1, 'System Administrator', 'admin', 'admin123', 'Admin', 'Active', 0, '2026-08-18 16:58:36'),
(2, 'Canteen Cashier', 'cashier1', '1234', 'Cashier', 'Active', 0, '2026-08-18 16:59:28'),
(3, 'Canteen Staff', 'staff1', '1234', 'Staff', 'Active', 0, '2026-08-18 16:59:43');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `audit_logs`
--
ALTER TABLE `audit_logs`
  ADD PRIMARY KEY (`log_id`),
  ADD KEY `fk_audit_user` (`user_id`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`category_id`),
  ADD UNIQUE KEY `category_name` (`category_name`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`employee_number`);

--
-- Indexes for table `kiosk_orders`
--
ALTER TABLE `kiosk_orders`
  ADD PRIMARY KEY (`kiosk_order_id`),
  ADD UNIQUE KEY `order_number` (`order_number`);

--
-- Indexes for table `kiosk_order_details`
--
ALTER TABLE `kiosk_order_details`
  ADD PRIMARY KEY (`kiosk_order_detail_id`),
  ADD KEY `fk_kiosk_order` (`kiosk_order_id`),
  ADD KEY `fk_kiosk_product` (`product_id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`),
  ADD KEY `fk_products_category` (`category_id`);

--
-- Indexes for table `salary_deductions`
--
ALTER TABLE `salary_deductions`
  ADD PRIMARY KEY (`deduction_id`),
  ADD KEY `idx_deduction_transaction` (`transaction_id`),
  ADD KEY `fk_deduction_employee` (`employee_number`);

--
-- Indexes for table `stock_movements`
--
ALTER TABLE `stock_movements`
  ADD PRIMARY KEY (`movement_id`),
  ADD KEY `fk_stock_product` (`product_id`),
  ADD KEY `fk_stock_user` (`user_id`);

--
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`transaction_id`),
  ADD KEY `fk_transactions_user` (`user_id`);

--
-- Indexes for table `transaction_details`
--
ALTER TABLE `transaction_details`
  ADD PRIMARY KEY (`detail_id`),
  ADD KEY `fk_details_transaction` (`transaction_id`),
  ADD KEY `fk_details_product` (`product_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `audit_logs`
--
ALTER TABLE `audit_logs`
  MODIFY `log_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `category_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `kiosk_orders`
--
ALTER TABLE `kiosk_orders`
  MODIFY `kiosk_order_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `kiosk_order_details`
--
ALTER TABLE `kiosk_order_details`
  MODIFY `kiosk_order_detail_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=127;

--
-- AUTO_INCREMENT for table `salary_deductions`
--
ALTER TABLE `salary_deductions`
  MODIFY `deduction_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `stock_movements`
--
ALTER TABLE `stock_movements`
  MODIFY `movement_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=102;

--
-- AUTO_INCREMENT for table `transactions`
--
ALTER TABLE `transactions`
  MODIFY `transaction_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `transaction_details`
--
ALTER TABLE `transaction_details`
  MODIFY `detail_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `audit_logs`
--
ALTER TABLE `audit_logs`
  ADD CONSTRAINT `fk_audit_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON UPDATE CASCADE;

--
-- Constraints for table `kiosk_order_details`
--
ALTER TABLE `kiosk_order_details`
  ADD CONSTRAINT `fk_kiosk_order` FOREIGN KEY (`kiosk_order_id`) REFERENCES `kiosk_orders` (`kiosk_order_id`),
  ADD CONSTRAINT `fk_kiosk_product` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`);

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `fk_products_category` FOREIGN KEY (`category_id`) REFERENCES `categories` (`category_id`) ON UPDATE CASCADE;

--
-- Constraints for table `salary_deductions`
--
ALTER TABLE `salary_deductions`
  ADD CONSTRAINT `fk_deduction_employee` FOREIGN KEY (`employee_number`) REFERENCES `employees` (`employee_number`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_deduction_transaction` FOREIGN KEY (`transaction_id`) REFERENCES `transactions` (`transaction_id`) ON UPDATE CASCADE;

--
-- Constraints for table `stock_movements`
--
ALTER TABLE `stock_movements`
  ADD CONSTRAINT `fk_stock_product` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_stock_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON UPDATE CASCADE;

--
-- Constraints for table `transactions`
--
ALTER TABLE `transactions`
  ADD CONSTRAINT `fk_transactions_user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON UPDATE CASCADE;

--
-- Constraints for table `transaction_details`
--
ALTER TABLE `transaction_details`
  ADD CONSTRAINT `fk_details_product` FOREIGN KEY (`product_id`) REFERENCES `products` (`product_id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_details_transaction` FOREIGN KEY (`transaction_id`) REFERENCES `transactions` (`transaction_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
