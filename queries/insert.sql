-- Create a new customer
INSERT INTO customers (name)
VALUES ('Karin Lund');

-- Create an order for that customer
INSERT INTO orders (address, customerId, orderDate)
VALUES ('New Street 10', 11, GETDATE());

-- Add products to the order
INSERT INTO orderItems (orderId, productId, quant)
VALUES (11, 1, 1),
       (11, 3, 2);
