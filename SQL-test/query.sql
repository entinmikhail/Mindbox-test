SELECT
    p.name AS "product.name",
    c.name AS "category.name"
FROM
    product_category pc
LEFT JOIN
    product p ON pc.product_id = p.product_id
LEFT JOIN
    category c ON pc.category_id = c.category_id;