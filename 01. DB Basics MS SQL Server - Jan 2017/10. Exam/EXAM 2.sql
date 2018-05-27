CREATE DATABASE ReportService
GO
USE ReportService
GO

--001 DONE
CREATE TABLE Users
(Id INT IDENTITY PRIMARY KEY, 
Username NVARCHAR(30) NOT NULL UNIQUE, 
Password NVARCHAR(50) NOT NULL,
Name NVARCHAR(50),
Gender CHAR(1) CHECK (Gender = 'M' OR Gender = 'F'),
BirthDate DATETIME,
Age INT,
Email NVARCHAR(50) NOT NULL)

CREATE TABLE Departments
(Id INT IDENTITY PRIMARY KEY, 
Name NVARCHAR(30) NOT NULL)

CREATE TABLE Employees
(Id INT IDENTITY PRIMARY KEY, 
FirstName NVARCHAR(25),
LastName NVARCHAR(25),
Gender CHAR(1) CHECK (Gender = 'M' OR Gender = 'F'),
BirthDate DATETIME,
Age INT,
DepartmentId INT NOT NULL FOREIGN KEY REFERENCES Departments(Id))

CREATE TABLE Status
(Id INT IDENTITY PRIMARY KEY, 
Label NVARCHAR(30) NOT NULL)

CREATE TABLE Categories
(Id INT IDENTITY PRIMARY KEY, 
Name NVARCHAR(50) NOT NULL,
DepartmentId INT FOREIGN KEY REFERENCES Departments(Id))

CREATE TABLE Reports
(Id INT IDENTITY PRIMARY KEY, 
CategoryId INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
StatusId INT NOT NULL FOREIGN KEY REFERENCES Status(Id),
OpenDate DATETIME NOT NULL,
CloseDate DATETIME,
Description NVARCHAR(200),
UserId INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
EmployeeId INT FOREIGN KEY REFERENCES Employees(Id))

--002 DONE
INSERT INTO Employees(FirstName, LastName, Gender, BirthDate, DepartmentId)
VALUES('Marlo',	'O’Malley', 'M', '9/21/1958', '1'),
('Niki', 'Stanaghan', 'F', '11/26/1969', '4'),
('Ayrton', 'Senna', 'M', '03/21/1960 ', '9'),
('Ronnie', 'Peterson', 'M', '02/14/1944', '9'),
('Giovanna', 'Amati', 'F', '07/20/1959', '5')

INSERT INTO Reports(CategoryId, StatusId, OpenDate, CloseDate, Description, UserId, EmployeeId)
VALUES('1', '1', '04/13/2017', NULL, 'Stuck Road on Str.133', '6', '2'),
('6', '3', '09/05/2015', '12/06/2015', 'Charity trail running', '3', '5'),
('14', '2', '09/07/2015', NULL, 'Falling bricks on Str.58', '5', '2'),
('4', '3', '07/03/2017', '07/06/2017', 'Cut off streetlight on Str.11', '1', '1')

--003 DONE
UPDATE Reports
SET StatusId = '2'
WHERE StatusId = '1' AND CategoryId = '4'

--004 DONE
DELETE FROM Reports
WHERE StatusId = '4'

--005 DONE
SELECT Username, Age
FROM Users
ORDER BY Age ASC, Username DESC

--006 DONE
SELECT Description, OpenDate
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC, Description ASC

--007 DONE
SELECT e.FirstName, e.LastName, r.Description, FORMAT(r.OpenDate, 'yyyy-MM-dd') AS OpenDate
FROM Employees AS e
INNER JOIN Reports AS r
ON e.Id = r.EmployeeId
ORDER BY e.Id ASC, r.OpenDate ASC, r.Id

--008 DONE
SELECT c.Name AS CategoryName, COUNT(*) AS ReportsNumber
FROM Categories AS c
INNER JOIN Reports AS r
ON c.Id = r.CategoryId
GROUP BY c.Name
ORDER BY ReportsNumber DESC, CategoryName ASC

--009 DONE
SELECT c.Name, COUNT(*) AS 'Employees Number'
FROM Categories AS c
INNER JOIN Employees AS e
ON c.DepartmentId = e.DepartmentId
GROUP BY c.Name
ORDER BY c.Name

--010 DONE
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS Name, COUNT(DISTINCT r.UserId) AS 'Users Number'
FROM Employees AS e
LEFT JOIN Reports AS r
ON e.Id = r.EmployeeId
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY 'Users Number' DESC, Name ASC

--011 DONE
SELECT r.OpenDate, r.Description, u.Email
FROM Reports AS r
INNER JOIN Users AS u
ON r.UserId = u.Id
JOIN Categories c 
ON c.id = r.CategoryId
JOIN Departments d 
ON d.id = c.Departmentid 
WHERE r.CloseDate IS NULL AND 
LEN(r.Description) > 20 AND 
r.Description LIKE '%str%' AND
d.Id IN (1, 4, 5)
ORDER BY r.OpenDate ASC, u.Email ASC, u.Id ASC 

--012 DONE
SELECT DISTINCT c.Name
FROM Users AS u
INNER JOIN Reports AS r
ON u.Id = r.UserId
INNER JOIN Categories AS c
ON c.Id = r.CategoryId
WHERE DAY(u.BirthDate) = DAY(r.OpenDate) AND MONTH(u.BirthDate) = MONTH(r.OpenDate)
ORDER BY c.Name ASC

--013 DONE
SELECT DISTINCT u.Username
FROM Users AS u
INNER JOIN Reports AS r
ON u.Id = r.UserId
INNER JOIN Categories AS c
ON r.CategoryId = c.Id
WHERE u.Username LIKE '[0-9]_%' AND CAST(r.CategoryId AS NVARCHAR) = LEFT(u.Username, 1) OR
u.Username LIKE '%_[0-9]' AND CAST(r.CategoryId AS NVARCHAR) = RIGHT(u.Username, 1)
ORDER BY u.Username ASC

--014 DONE
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS Name, CONCAT(COUNT(r.CloseDate), '/', COUNT(r.OpenDate)) AS 'Closed Open Reports' 
FROM Employees AS e
INNER JOIN Reports AS r
ON e.Id = r.EmployeeId
WHERE YEAR(r.OpenDate) = 2016 OR YEAR(r.CloseDate) = 2016 
GROUP BY CONCAT(e.FirstName, ' ', e.LastName), e.Id
ORDER BY Name ASC, e.Id ASC

--015 DONE
SELECT d.Name AS 'Department Name', ISNULL(CAST(AVG(DATEDIFF(DAY, r.OpenDate, r.CloseDate)) AS VARCHAR),'no info') AS 'Average Duration' 
FROM Departments AS d
INNER JOIN Categories AS c
ON d.Id = c.DepartmentId
INNER JOIN Reports AS r
ON c.Id = r.CategoryId
GROUP BY d.Name
ORDER BY 'Department Name'

--016 DONE
WITH CTE_TotalReportsByDepartment (DepartmentId, Count) AS
(
	SELECT d.Id, COUNT(r.Id)
	FROM Departments AS d
	INNER JOIN Categories AS c
	ON d.Id = c.DepartmentId
	INNER JOIN Reports AS r
	ON r.CategoryId = c.Id
	GROUP BY d.Id
)

SELECT d.Name AS 'Department Name', c.Name AS 'Category Name',CAST(ROUND(CEILING(CAST(COUNT(r.Id) AS DECIMAL(7,2)) * 100)/tr.Count, 0) AS INT) AS [Percentage]
FROM Reports AS r
INNER JOIN Categories AS c
ON r.CategoryId = c.Id
INNER JOIN Departments AS d
ON c.DepartmentId = d.Id
INNER JOIN CTE_TotalReportsByDepartment AS tr 
ON  d.Id = tr.DepartmentId
GROUP BY d.Name, c.Name, tr.Count

--017 DONE
CREATE FUNCTION udf_GetReportsCount(@employeeId INT, @statusId INT)
RETURNS INT
AS
BEGIN
	DECLARE @count INT;

	SELECT @count = COUNT(*)
	FROM Reports AS r
	WHERE r.EmployeeId = @employeeId AND r.StatusId = @statusId

	RETURN @count;
END

SELECT Id, FirstName, Lastname, dbo.udf_GetReportsCount(Id, 2) AS ReportsCount
FROM Employees
ORDER BY Id

--018
CREATE PROC usp_AssignEmployeeToReport(@employeeId INT, @reportId INT)
AS
BEGIN
	DECLARE @employeeDepartmentId int = 
	(SELECT DepartmentId
	FROM Employees
	WHERE Id = @employeeId)
 					   
	DECLARE @reportDepartmentId int = 
	(SELECT c.DepartmentId
	FROM Reports AS r
	INNER JOIN Categories AS c 
	ON c.Id = r.CategoryId
	WHERE r.Id = @reportId)

	IF(@employeeDepartmentId = @reportDepartmentId)
	BEGIN
		UPDATE Reports
		SET EmployeeId = @employeeId 
		WHERE Id = @reportId
		COMMIT
	END
	ELSE
	BEGIN
		ROLLBACK
		RAISERROR('Employee doesn''t belong to the appropriate department!', 16, 1)
		RETURN
	END
END
GO

EXEC usp_AssignEmployeeToReport 17, 2;
SELECT EmployeeId FROM Reports WHERE id = 2

--019 DONE
CREATE TRIGGER tr_ReportsUpdate ON Reports AFTER UPDATE
AS
BEGIN
UPDATE Reports
SET StatusId = (
	SELECT Id 
	FROM Status AS s
	WHERE s.Id = 3)
WHERE Id = (
	SELECT i.Id
	FROM inserted AS i
	WHERE i.CloseDate IS NOT NULL);
END

UPDATE Reports
SET CloseDate = GETDATE()
WHERE EmployeeId = 5;
