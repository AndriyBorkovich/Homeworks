-- creating DB
CREATE DATABASE HW3DB

-- creating tables
CREATE TABLE Groups
(
	gr_id int NOT NULL PRIMARY KEY,
	gr_name varchar(50) NOT NULL,
	gr_temp decimal NOT NULL
);
GO
CREATE TABLE Analysis
(
	an_id int NOT NULL PRIMARY KEY,
	an_name varchar(50) NOT NULL,
	an_cost money NOT NULL,
	an_price money NOT NULL,
	an_group int NOT NULL FOREIGN KEY REFERENCES Groups(gr_id)
);
GO
CREATE TABLE Orders
(
	ord_id int NOT NULL PRIMARY KEY,
	ord_datetime datetime NOT NULL,
	ord_an int NOT NULL FOREIGN KEY REFERENCES Analysis(an_id)
);

-- add values to tables
INSERT INTO Groups
VALUES (1, 'Laboratory', 25.0),
(2, 'Radiology', 22.5),
(3, 'Cardiology', 21.0),
(4, 'Neurology', 20.5);

INSERT INTO Analysis
VALUES (1, 'Complete Blood Count Analysis', 10.50, 19.99, 1),
(2, 'X-Ray Analysis', 15.75, 29.99, 2),
(3, 'Urinalysis', 22.30, 42.99, 1),
(4, 'Electrocardiogram', 17.50, 34.99, 3),
(5, 'CT Scan Analysis', 18.50, 44.99, 4),
(6, 'MRI Scan Analysis', 100.00, 200.00, 4);


INSERT INTO Orders
VALUES (1, '2023-02-02 13:30:00', 6),
(2, '2020-02-23 09:15:00', 3),
(3, '2021-02-06 14:45:14', 2),
(4, '2020-02-11 09:00:00', 3),
(5, '2020-02-12 13:00:00', 1),
(6, '2020-02-08 12:22:01', 1),
(7, '2020-02-12 19:32:11', 5);

-- print all tables
SELECT * FROM Analysis
SELECT * FROM Groups
SELECT * FROM Orders

-- task1
SELECT an.an_name, an.an_price
FROM Analysis AS an
INNER JOIN dbo.Orders AS ord
on an.an_id = ord.ord_an
WHERE ord.ord_datetime between '2020-02-05 00:00:00' AND '2020-02-11 23:59:59'

--task 2
SELECT gr_name, YEAR(ord_datetime) AS ord_year, MONTH(ord_datetime) AS ord_month, COUNT(*) AS num_tests
FROM Orders
JOIN Analysis ON Orders.ord_an = Analysis.an_id
JOIN Groups ON Analysis.an_group = Groups.gr_id
GROUP BY gr_name, YEAR(ord_datetime), MONTH(ord_datetime)
ORDER BY num_tests asc;
