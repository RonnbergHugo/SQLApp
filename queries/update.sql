-- Update customer name
UPDATE customers
SET name = 'Anna Svensson-Andersson'
WHERE id = 1;

-- Update quantity in an order item
UPDATE orderItems
SET quant = 3
WHERE orderId = 1 AND productId = 2;
