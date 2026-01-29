CREATE VIEW vwPublicCustomerOrders AS
SELECT
    c.id AS CustomerId,
    c.name,
    o.id AS OrderId,
    o.orderDate
FROM customers c
JOIN orders o ON c.id = o.customerId;

CREATE VIEW vwOrderTotals AS
SELECT
    o.id AS OrderId,
    c.name AS CustomerName,
    SUM(oi.quant * p.price) AS TotalAmount
FROM orders o
JOIN customers c ON o.customerId = c.id
JOIN orderItems oi ON o.id = oi.orderId
JOIN products p ON oi.productId = p.id
GROUP BY o.id, c.name;
