-- 1. List all orders with customer name and address
SELECT 
    o.id AS OrderId,
    c.name AS CustomerName,
    o.address,
    o.orderDate
FROM orders o
JOIN customers c ON o.customerId = c.id;

-- 2. Orders with products and quantities
SELECT
    o.id AS OrderId,
    p.name AS ProductName,
    oi.quant,
    p.price,
    (oi.quant * p.price) AS LineTotal
FROM orderItems oi
JOIN orders o ON oi.orderId = o.id
JOIN products p ON oi.productId = p.id
ORDER BY o.id;

-- 3. Total order value per order
SELECT
    o.id AS OrderId,
    SUM(oi.quant * p.price) AS OrderTotal
FROM orders o
JOIN orderItems oi ON o.id = oi.orderId
JOIN products p ON oi.productId = p.id
GROUP BY o.id;

-- 4. Top customers
SELECT 
    c.id,
    c.name,
    COUNT(o.id) AS orderCount
FROM customers c
LEFT JOIN orders o ON c.id = o.customerId
GROUP BY c.id, c.name
ORDER BY orderCount DESC;

-- 5. Top selling products
SELECT 
    p.id,
    p.name,
    SUM(oi.quant) AS TotalSold
FROM products p
JOIN orderItems oi ON p.id = oi.productId
GROUP BY p.id, p.name
ORDER BY TotalSold DESC;
