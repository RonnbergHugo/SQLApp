SELECT o.id, c.name, o.orderDate
FROM orders o
JOIN customers c ON o.customerId = c.id;

SELECT p.name, oi.quant, o.id AS OrderId
FROM orderItems oi
JOIN products p ON oi.productId = p.id
JOIN orders o ON oi.orderId = o.id;

SELECT p.name, c.category
FROM products p
JOIN productCategories pc ON p.id = pc.productId
JOIN categories c ON pc.categoryId = c.id;

SELECT c.name, COUNT(o.id) AS OrdersCount
FROM customers c
JOIN orders o ON c.id = o.customerId
GROUP BY c.name;

SELECT o.id, SUM(oi.quant * p.price) AS OrderTotal
FROM orders o
JOIN orderItems oi ON o.id = oi.orderId
JOIN products p ON oi.productId = p.id
GROUP BY o.id;

SELECT c.category, SUM(oi.quant) AS TotalSold
FROM categories c
JOIN productCategories pc ON c.id = pc.categoryId
JOIN orderItems oi ON pc.productId = oi.productId
GROUP BY c.category;

SELECT * FROM orders
WHERE orderDate >= DATEADD(DAY, -7, GETDATE())
ORDER BY orderDate DESC;

SELECT TOP 5
    c.name,
    COUNT(o.id) AS TotalOrders
FROM customers c
JOIN orders o ON c.id = o.customerId
GROUP BY c.name
ORDER BY TotalOrders DESC;
