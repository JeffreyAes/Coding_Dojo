-- first querie:
INSERT INTO users(first_name, last_name, email, created_at, updated_at)
VALUES("jeffrey", "aeschliman", "email@email.com", NOW(), NOW()), ("john", "smith", "snail@email.com", NOW(), NOW()), ("bob", "ross", "ross@email.com", NOW(), NOW());
SELECT * FROM users;

-- second querie:
SELECT * FROM users
WHERE email = "email@email.com";

-- third querie:
SELECT * FROM users
WHERE id = 3;

-- fourth querie:
UPDATE users
SET last_name = "pancakes"
WHERE id = 3;
SELECT * FROM users

-- fith querie:
DELETE FROM users
WHERE id = 2;
SELECT * FROM users;

-- sixth querie:
SELECT * FROM users
ORDER BY first_name;

-- seventh querie:
SELECT * FROM users
ORDER BY first_name DESC;