-- Cannot delete an order if orderItems exist
-- Must delete from junction table first

DELETE FROM orderItems
WHERE orderId = 1;

DELETE FROM orders
WHERE id = 1;
