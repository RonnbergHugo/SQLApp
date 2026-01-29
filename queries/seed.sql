INSERT INTO customers (name) VALUES
('Anna Svensson'),
('Björn Karlsson'),
('Cecilia Lind'),
('Daniel Olsson'),
('Emma Berg'),
('Fredrik Nilsson'),
('Greta Holm'),
('Henrik Persson'),
('Ida Johansson'),
('Jonas Eriksson');

INSERT INTO products (name, description, price) VALUES
('Laptop', '15 inch laptop', 899.99),
('Mouse', 'Wireless mouse', 29.95),
('Keyboard', 'Mechanical keyboard', 129.99),
('Monitor', '27 inch monitor', 349.99),
('USB Cable', 'USB-C cable', 9.95),
('Headphones', 'Noise cancelling', 249.99),
('Webcam', 'HD webcam', 79.99),
('Desk Lamp', 'LED desk lamp', 49.95),
('Chair', 'Office chair', 199.99),
('Notebook', 'Paper notebook', 19.95);

INSERT INTO categories (category) VALUES
('Electronics'),
('Office'),
('Accessories'),
('Furniture'),
('Stationery');

INSERT INTO productCategories (productId, categoryId) VALUES
(1,1),(2,3),(3,3),(4,1),(5,3),
(6,1),(7,1),(8,2),(9,2),(9,4),(10,5);

INSERT INTO orders (address, customerId, orderDate) VALUES
('Main Street 1', 1, GETDATE()),
('Oak Road 12', 2, GETDATE()),
('Pine Ave 5', 3, GETDATE()),
('Maple St 8', 4, GETDATE()),
('River Rd 22', 5, GETDATE()),
('Hill Lane 3', 6, GETDATE()),
('Lake View 9', 7, GETDATE()),
('Forest Path 11', 8, GETDATE()),
('Sunset Blvd 6', 9, GETDATE()),
('Market Sq 4', 10, GETDATE());

INSERT INTO orderItems (orderId, productId, quant) VALUES
(1,1,1),(1,2,2),
(2,3,1),
(3,4,2),(3,5,3),
(4,6,1),
(5,7,1),(5,8,1),
(6,9,1),
(7,10,5);
