-- query 1:
INSERT INTO users(id, first_name, last_name)
VALUES(1, "Jane", "Amsden"),
(2, "Emily", "Dixon"),
(3, "Theodore", "Dostoevsky"),
(4, "William", "Shapiro"),
(5, "Lao", "ciu");
SELECT * FROM users;

-- query 2:
INSERT INTO books (id, title, num_of_pages)
VALUES(1, "C Sharp", 280),
(2, "Java", 359),
(3, "Python", 260),
(4, "PHP", 288),
(5, "Ruby", 221);
SELECT * FROM books;

-- query 3:
UPDATE books
SET title = "C#"
WHERE id = 1;
SELECT * FROM books

--query 4:
UPDATE users
SET first_name = "Bill"
WHERE id = 4;
SELECT * FROM users;

--query 5:
INSERT INTO favorites(user_id, book_id)
VALUES (1, 1), (1, 2),
(2, 1), (2, 2), (2, 3),
(3, 1), (3, 2), (3, 3), (2, 4),
(4, 1), (4, 2), (4, 3), (4, 4), (4, 5);

--query 6:
SELECT * FROM users
JOIN favorites ON users.id = favorites.book_id
WHERE book_id = 3;

--query 7:
DELETE FROM favorites
WHERE user_id = 1 AND books_id = 3;
SELECT * FROM favorites;

--query 8:
INSERT INTO favorites(user_id, book_id)
VALUES (5, 2);
SELECT * FROM favorites


-- --query 9:
SELECT * FROM books
JOIN favorites ON books.id = favorites.book_id
WHERE favorites.user_id = 3;

--query 10:
SELECT * FROM users
JOIN favorites ON users.id = favorites.book_id
WHERE book_id = 5;
