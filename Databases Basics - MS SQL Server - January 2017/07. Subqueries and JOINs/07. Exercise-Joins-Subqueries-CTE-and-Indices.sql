-- Problem 1. Employee Address
SELECT TOP(5) e.EmployeeID, e.JobTitle, e.AddressID, a.AddressText 
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
ORDER BY e.AddressID ASC

-- Problem 2. Addresses with Towns
SELECT TOP(50) e.FirstName, e.LastName, t.Name, a.AddressText 
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
ORDER BY e.FirstName ASC, e.LastName ASC 

-- Problem 3. Sales Employee
SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID ASC

-- Problem 4. Employee Departments
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.Name
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

-- Problem 5. Employees Without Project
SELECT TOP(3) e.EmployeeID, e.FirstName
FROM Employees AS e
WHERE e.EmployeeID NOT IN (SELECT EmployeeID FROM EmployeesProjects)
ORDER BY e.EmployeeID ASC

-- Problem 6. Employees Hired After
SELECT e.FirstName, e.LastName, e.HireDate, d.Name
FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.HireDate > '1.1.1999' AND (d.Name = 'Sales' OR d.Name = 'Finance')

-- Problem 7. Employees with Project
SELECT TOP(5) e.EmployeeID, e.FirstName, p.Name
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002.08.13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

-- Problem 8. Employee 24
SELECT e.EmployeeID, e.FirstName,
CASE 
WHEN p.StartDate > '01.01.2005' THEN NULL ELSE p.Name 
END AS 'Name'
FROM Employees AS e
JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

-- Problem 9. Employee Manager
SELECT e.EmployeeID, e.FirstName, e.ManagerID, m.FirstName AS 'ManagerName'
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID = 3 OR e.ManagerID = 7
ORDER BY e.EmployeeID ASC

-- Problem 10. Employee Summary
SELECT TOP(50) e.EmployeeID, 
e.FirstName + ' ' + e.LastName AS 'EmployeeName', 
m.FirstName + ' ' + m.LastName AS 'ManagerName',
d.Name AS 'DepartmentName'
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- Problem 11. Min Average Salary
SELECT MIN(m.Salary) FROM 
(
SELECT e.DepartmentID, AVG(e.Salary) AS 'Salary'
FROM Employees AS e
GROUP BY e.DepartmentID
) AS m

-- Problem 12. Highest Peak in Bulgaria
SELECT mc.Countrycode, m.MountainRange, p.PeakName, p.Elevation
FROM MountainsCountries AS mc
JOIN Mountains AS m
ON mc.MountainId = m.Id
JOIN Peaks AS p
ON m.Id = p.MountainId
WHERE p.Elevation > 2835 AND mc.Countrycode = 'BG'
ORDER BY p.Elevation DESC

-- Problem 13. Count Mountain Ranges
SELECT c.Countrycode, COUNT(m.MountainRange)
FROM Countries AS c
JOIN MountainsCountries AS mc
ON c.Countrycode = mc.Countrycode
JOIN Mountains AS m
ON mc.MountainId = m.Id
WHERE c.Countrycode IN ('BG','RU','US')
GROUP BY c.Countrycode

-- Problem 14. Countries with rivers
SELECT TOP(5) c.CountryName, r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON c.Countrycode = cr.Countrycode
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
WHERE c.Continentcode = 'AF'
ORDER BY c.CountryName ASC

-- Problem 15. *Continents and Currencies
SELECT c.Continentcode, cc.Currencycode, Count(cc.Countrycode) AS [CurrencyUsage]
FROM Continents c
JOIN Countries cc
ON c.Continentcode = cc.Continentcode
GROUP BY c.Continentcode, cc.Currencycode
HAVING Count(cc.Countrycode) = 
(
SELECT Max(xxx.currencyxx)
FROM (
		SELECT cx.Continentcode, ccx.Currencycode, Count(ccx.Countrycode) AS [CurrencyXX]
		FROM Continents cx
		JOIN Countries ccx
		ON cx.Continentcode = ccx.Continentcode
		WHERE c.Continentcode = cx.Continentcode
		GROUP BY cx.Continentcode, ccx.Currencycode
	 ) AS xxx
) AND Count(cc.Countrycode) > 1
ORDER  BY c.Continentcode

-- OR

SELECT usages.ContinentCode, usages.CurrencyCode, usages.Usage FROM
(
SELECT c.ContinentCode, c.CurrencyCode, COUNT(*) AS 'Usage'
FROM Countries AS c
GROUP BY c.ContinentCode, c.CurrencyCode
HAVING COUNT(*) > 1
) AS usages
INNER JOIN 
(
	SELECT usages.ContinentCode, MAX(usages.Usage) AS 'maxUsages' FROM
	(
	SELECT c.ContinentCode, c.CurrencyCode, COUNT(*) AS 'Usage'
	FROM Countries AS c
	GROUP BY c.ContinentCode, c.CurrencyCode
	) AS usages
	GROUP BY usages.ContinentCode
) AS maxUsages ON usages.ContinentCode = maxUsages.ContinentCode AND maxUsages.maxUsages = usages.Usage

-- Problem 16. Countries Without any Mountains
SELECT
( 
	SELECT COUNT(Countrycode) 
	FROM Countries
) -
(
	SELECT COUNT(con.Countrycode) 
	FROM 
		(
			SELECT mc.Countrycode
			FROM MountainsCountries AS mc
			GROUP BY mc.Countrycode
		) AS con
) AS 'Countrycode'

-- Problem 17. Highest Peak and Longest River by Country
SELECT TOP(5) c.CountryName, MAX(p.Elevation) AS 'HighestPeakElevation', MAX(r.Length) AS 'LongestRiverLength'
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON c.Countrycode = mc.Countrycode
LEFT JOIN Peaks AS p
ON mc.MountainId = p.MountainId
LEFT JOIN CountriesRivers AS cr
ON c.Countrycode = cr.Countrycode
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY MAX(p.Elevation) DESC, MAX(r.Length) DESC, c.CountryName ASC

-- Problem 18. **Highest Peak Name and Elevation by Country
SELECT TOP(5) c.CountryName,
CASE 
WHEN p.PeakName IS NULL THEN '(no highest peak)' ELSE p.PeakName END AS 'HighestPeakName',
CASE 
WHEN p.Elevation IS NULL THEN 0 ELSE p.Elevation END AS 'HighestPeakElevation',
CASE 
WHEN m.MountainRange IS NULL THEN '(no mountain)' ELSE m.MountainRange END AS 'Mountain'

FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON c.Countrycode = mc.Countrycode
LEFT JOIN Peaks AS p
ON mc.MountainId = p.MountainId
LEFT JOIN Mountains AS m
ON m.Id = mc.MountainId
ORDER BY c.CountryName ASC, p.PeakName ASC

-- OR
SELECT TOP(5)
	c.CountryName AS Country,
	ISNULL(p.PeakName, '(no highest peak)') AS HighestPeakName,
	ISNULL(MAX(p.Elevation), 0) AS HighestPeakElevation,
	ISNULL(m.MountainRange, '(no mountain)') AS Mountain

FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON c.Countrycode = mc.Countrycode
LEFT JOIN Peaks AS p
ON mc.MountainId = p.MountainId
LEFT JOIN Mountains AS m
ON m.Id = mc.MountainId
GROUP BY c.CountryName, p.Elevation, p.PeakName, m.MountainRange
ORDER BY c.CountryName ASC, p.PeakName ASC