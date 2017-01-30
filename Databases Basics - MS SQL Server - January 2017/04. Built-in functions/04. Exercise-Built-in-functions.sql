--- Part I – Queries for SoftUni Database ---

-- Problem 1. Find Names of All Employees by First Name
SELECT FirstName, LastName 
FROM Employees
WHERE LEFT(FirstName, 2) = 'sa'

--OR

SELECT FirstName, LastName 
FROM Employees
WHERE FirstName LIKE 'sa%'

-- Problem 2. Find Names of All employees by Last Name 
SELECT FirstName, LastName 
FROM Employees
WHERE LastName LIKE '%ei%'

-- Problem 3. Find First Names of All Employees
SELECT FirstName 
FROM Employees
WHERE DepartmentID = 3 
	OR DepartmentID = 10 
	OR DATEPART(YEAR, HireDate) < 1995 
	OR DATEPART(YEAR, HireDate) > 2005

-- Problem 4. Find All Employees Except Engineers
SELECT FirstName, LastName 
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

-- Problem 5. Find Towns with Name Length
SELECT Name
FROM Towns
WHERE LEN(Name) = 5 
	OR LEN(Name) = 6
ORDER BY Name ASC

-- Problem 6. Find Towns Starting With
SELECT TownID, Name
FROM Towns
WHERE Name LIKE('M%')
	OR Name LIKE('K%') 
	OR Name LIKE('B%') 
	OR Name LIKE('E%')
ORDER BY Name ASC

-- Problem 7. Find Towns Not Starting With
SELECT TownID, Name
FROM Towns
WHERE Name NOT LIKE('R%') 
	AND Name NOT LIKE('B%') 
	AND Name NOT LIKE('D%')
ORDER BY Name ASC

-- Problem 8. Create View Employees Hired After 2000 Year
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName 
FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000

-- Problem 9. Length of Last Name
SELECT FirstName, LastName 
FROM Employees
WHERE LEN(LastName) = 5

--- Part II – Queries for Geography Database ---

-- Problem 10. Countries Holding ‘A’ 3 or More Times
SELECT CountryName, IsoCode
FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(CountryName, 'a', '')) >= 3
ORDER BY IsoCode ASC

-- OR

SELECT CountryName, IsoCode 
FROM Countries
WHERE CountryName LIKE ('%a%a%a%')
ORDER BY IsoCode

-- Problem 11. Mix of Peak and River Names
SELECT PeakName, RiverName, CONCAT(LOWER (PeakName), LOWER(RIGHT (RiverName, LEN(RiverName) - 1 ))) AS 'Mix'
FROM Peaks, Rivers
WHERE RIGHT(PeakName,1) = LEFT(RiverName,1) 
ORDER BY Mix

SELECT PeakName, RiverName, LOWER(PeakName + RiverName) AS 'Mix'
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1) 
ORDER BY Mix

--- Part III – Queries for Diablo Database ---

-- Problem 12. Games from 2011 and 2012 year
SELECT TOP(50) Name, FORMAT(Start,'yyyy-MM-dd') AS 'S'
FROM Games
WHERE DATEPART(YEAR, Start) = 2011 
	OR DATEPART(YEAR, Start) = 2012 
ORDER BY Start ASC, Name ASC

-- Problem 13. User Email Providers
SELECT Username, RIGHT(Email, LEN(Email) - CHARINDEX('@',Email)) AS 'Email Provider'
FROM Users
ORDER BY 'Email Provider' ASC, Username ASC

-- OR

SELECT CountryName, IsoCode 
FROM Countries
WHERE CountryName LIKE ('%a%a%a%')
ORDER BY IsoCode

-- Problem 14. Get Users with IPAdress Like Pattern
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username ASC

-- Problem 15. Show All Games with Duration and Part of the Day
SELECT Name,
CASE
	WHEN DATEPART(HOUR,Start) >= 0 AND DATEPART(HOUR,Start) < 12 THEN 'Morning'
	WHEN DATEPART(HOUR,Start) >= 12 AND DATEPART(HOUR,Start) < 18 THEN 'Afternoon'
	WHEN DATEPART(HOUR,Start) >= 18 AND DATEPART(HOUR,Start) < 24 THEN 'Evening'
	END AS 'Part of the Day',
CASE
	WHEN Duration BETWEEN 0 AND 3 THEN 'Extra Short'
	WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long '
	ELSE 'Extra Long' 
	END AS 'Duration'
	FROM Games
ORDER BY Name ASC, 'Duration' ASC, 'Part of the Day' ASC

--- Part IV – Date Functions Queries ---

-- Problem 16. Orders Table
SELECT ProductName, OrderDate,
	DATEADD(day, 3, OrderDate) AS 'Pay Due', 
	DATEADD(MONTH, 1, OrderDate) AS 'Deliver Due'
FROM Orders

-- Problem 17. People Table
-- I don't have the table "People" so i will use this one.
SELECT FirstName, 
DATEDIFF(YEAR, RegistrationDate, GETDATE()) AS 'Age in Years',
DATEDIFF(MONTH, RegistrationDate, GETDATE()) AS 'Age in Months',
DATEDIFF(DAY, RegistrationDate, GETDATE()) AS 'Age in Days',
DATEDIFF(MINUTE, RegistrationDate, GETDATE()) AS 'Age in Minutes'
FROM Users
