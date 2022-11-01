--query 1:
SELECT name, language, percentage FROM countries
JOIN languages ON countries.id = languages.country_id
where language = "Slovene"
ORDER BY percentage DESC

-- query 2:

--query 3:
SELECT cities.name, population FROM cities
WHERE country_id = 136 AND cities.population > 500000
ORDER BY population DESC

--query 4:
SELECT name, language, percentage FROM countries
JOIN languages ON countries.id = languages.country_id
WHERE percentage > 89
ORDER BY percentage DESC

--query 5:
SELECT name, surface_area, population FROM countries
WHERE surface_area > 501 AND population > 100000

--query 6:
SELECT name, government_form, capital, life_expectancy FROM countries
WHERE government_form = "Constitutional Monarchy" AND capital > 200 AND life_expectancy > 75

-- query 7:
SELECT cities.name, district, cities.population, countries.name FROM countries
JOIN cities ON countries.id = cities.country_id
WHERE district = "Buenos Aires" AND cities.population > 500000

--query 8:
SELECT region, COUNT(*) AS countries FROM countries
GROUP BY region
ORDER BY COUNT(*) DESC