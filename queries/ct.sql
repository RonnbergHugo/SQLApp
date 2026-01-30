USE eHandel
CREATE TABLE customers (
id INTEGER IDENTITY(1, 1) PRIMARY KEY,
name VARCHAR(31) NOT NULL
);

CREATE TABLE orders (
id INTEGER IDENTITY(1, 1) PRIMARY KEY,
address VARCHAR(63),
customerId INTEGER,
orderDate DATETIME DEFAULT GETDATE(),
FOREIGN KEY (customerId) REFERENCES customers(id)
);

CREATE TABLE products (
id INTEGER IDENTITY(1, 1) PRIMARY KEY,
name VARCHAR(31) UNIQUE,
description VARCHAR(255),
price DECIMAL(8, 2) NOT NULL
	CHECK (price >= 0)
);

CREATE TABLE categories (
id INTEGER IDENTITY(1, 1) PRIMARY KEY,
category VARCHAR(31) UNIQUE
);

CREATE TABLE orderItems (
orderId INTEGER,
productId INTEGER,
quant INTEGER DEFAULT 1,
PRIMARY KEY (orderId, productId),
FOREIGN KEY (orderId) REFERENCES orders(id),
FOREIGN KEY (productId) REFERENCES products(id)
);

CREATE TABLE productCategories (
productId INTEGER,
categoryId INTEGER,
PRIMARY KEY (productId, categoryId),
FOREIGN KEY (productId) REFERENCES products(id),
FOREIGN KEY (categoryId) REFERENCES categories(id)
);
