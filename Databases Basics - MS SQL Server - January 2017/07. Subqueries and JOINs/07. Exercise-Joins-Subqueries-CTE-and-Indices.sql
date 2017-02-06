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
SELECT e.EmployeeID, e.FirstName
FROM Employees AS e



-- Problem 6. Employees Hired After
SELECT e.EmployeeID, e.FirstName, e.LastName, e.HireDate
FROM Employees AS e
WHERE e.HireDate > '1.1.1999'

-- Problem 7. Employees with Project

-- Problem 8. Employee 24

-- Problem 9. Employee Manager

-- Problem 10. Employee Summary

-- Problem 11. Min Average Salary

-- Problem 12. Highest Peak in Bulgaria

-- Problem 13. Count Mountain Ranges

-- Problem 14. Countries with rivers

-- Problem 15. *Continents and Currencies

-- Problem 16. Countries Without any Mountains

-- Problem 17. Highest Peak and Longest River by Country

-- Problem 18. **Highest Peak Name and Elevation by Country