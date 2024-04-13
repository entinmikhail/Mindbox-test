Drop TABLE IF EXISTS category;
Drop TABLE IF EXISTS demo;
Drop TABLE IF EXISTS product;
Drop TABLE IF EXISTS product_category;

CREATE TABLE product 
(
  product_id int primary key,
  name varchar(20) NOT NULL
);

CREATE TABLE category 
(
  category_id int primary key, 
  name varchar(20) NOT NULL
);

CREATE TABLE product_category 
(
  product_id int REFERENCES product(product_id), 
  category_id int REFERENCES category(category_id), 
  CONSTRAINT pair_pkey PRIMARY KEY (product_id, category_id)
);

INSERT INTO product 
VALUES
  (1, 'Apple'),
  (2, 'BMW'),
  (3, 'Pomidor'),
  (4, 'Film');

INSERT INTO category 
VALUES
 (1, 'Fruit'),
 (2, 'Vegetable'),
 (3, 'Edible'),
 (4, 'Inedible'),
 (5, 'Car');

INSERT INTO product_category 
VALUES
 (1, 1),
 (1, 3),
 (2, 4),
 (2, 5),
 (3, 3),
 (3, 2),
 (4, null);
  