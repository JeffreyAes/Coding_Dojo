-- query 1:
INSERT INTO dojos(name, created_at, updated_at)
VALUES("dojo1", NOW(), NOW()), ("dojo2", NOW(), NOW()), ("dojo3.1", NOW(), NOW());
SELECT * FROM dojos;

-- query 2:
SET SQL_SAFE_UPDATES = 0;
DELETE FROM dojos;
SELECT * FROM dojos

-- query 3:
INSERT INTO dojos(name, created_at, updated_at)
VALUES("dojo_1", NOW(), NOW()), ("dojo_2", NOW(), NOW()), ("dojo_3", NOW(), NOW());
SELECT * FROM dojos;

--query 4:
INSERT INTO ninjas(first_name, last_name, age, dojos_id)
VALUES("timmy", "ninjason", 25, 1), 
("bob", "ninja", 31, 1), 
("harold", "smith", 20, 1);
SELECT * FROM ninjas;

-- query 5:
INSERT INTO ninjas(first_name, last_name, age, dojos_id)
VALUES("ninja2", "ninja2", 23, 2), 
("bobby", "ninjart", 21, 2), 
("steve", "johnson", 10, 2);
SELECT * FROM ninjas;

-- query 6:
INSERT INTO ninjas(first_name, last_name, age, dojos_id)
VALUES("ninja3", "ninjump", 54, 3), 
("gilbert", "ninjart", 30, 3), 
("steveo", "thoamas", 19, 3);
SELECT * FROM ninjas;

-- query 7:
SELECT * FROM ninjas
WHERE dojos_id = 1;

-- query 8:
SELECT * FROM ninjas
WHERE dojos_id = 3;

-- query 9:
SELECT dojos_id FROM ninjas
WHERE id = 9
