--- Part I – Queries for SoftUni Database ---

-- Problem 1. Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE e.Salary > 35000
END

EXEC usp_GetEmployeesSalaryAbove35000
		  
-- Problem 2. Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@number MONEY)
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE e.Salary >= @number
END

EXEC dbo.usp_GetEmployeesSalaryAboveNumber 35000
			  
-- Problem 3. Town Names Starting With
CREATE PROC usp_GetTownsStartingWith (@starts nvarchar(MAX))
AS
BEGIN
	SELECT t.Name
	FROM Towns AS t
	WHERE LEFT(t.Name, len(@starts)) = @starts
END

EXEC dbo.usp_GetTownsStartingWith 'b'
			  
-- Problem 4. Employees from Town
CREATE PROC usp_GetEmployeesFromTown (@townName nvarchar(MAX))
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	INNER JOIN Addresses AS ad
	ON ad.AddressID = e.AddressID
	INNER JOIN Towns AS t
	ON t.TownID = ad.TownID
	WHERE t.Name = @townName
END

EXEC dbo.usp_GetEmployeesFromTown 'Sofia'
			  
-- Problem 5. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@salary money)
RETURNS varchar(10)
AS
BEGIN
	IF(@salary < 30000)
	BEGIN
		RETURN 'Low'
	END
	ELSE IF(@salary >= 30000 AND @salary <= 50000)
	BEGIN
		RETURN 'Average'
	END
	RETURN 'High'
END

-- OR

CREATE FUNCTION ufn_GetSalaryLevel(@salary money)
RETURNS varchar(50)
AS
BEGIN
DECLARE @result varchar(50)
	IF(@salary < 30000)
	BEGIN
		SET @result = 'Low'
	END
	ELSE IF(@salary >= 30000 AND @salary <= 50000)
	BEGIN
		SET @result = 'Average'
	END
	ELSE
	BEGIN
		SET @result = 'High'
	END
	RETURN @result
END

SELECT e.Salary, dbo.ufn_GetSalaryLevel(Salary) AS 'Salary Level'
FROM Employees AS e
			  
-- Problem 6. Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel (@moneyType nvarchar(MAX))
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees AS e
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @moneyType
END

EXEC dbo.usp_EmployeesBySalaryLevel 'Low'
	  
-- Problem 7. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters varchar(50), @word varchar(50)) 
RETURNS bit
AS
BEGIN

	DECLARE @letter char;
	DECLARE @result bit = 1;
	DECLARE @index int = 1;
	WHILE (@index <= LEN(@word) AND @result = 1)
	BEGIN
		SET @letter = SUBSTRING(@word, @index, 1)
		IF(CHARINDEX(@letter, LOWER(@setOfLetters)) NOT BETWEEN 1 AND LEN(@setOfLetters))
		BEGIN
			SET @result = 0;
		END
		ELSE
		BEGIN
			SET @index += 1
		END		
	END

	RETURN @result
END

-- OR

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters varchar(50), @word varchar(50)) 
RETURNS bit
AS
BEGIN
	DECLARE @lenght int = LEN(@word);
	DECLARE @index int = 1;

	WHILE(@index <= @lenght)
	BEGIN
		DECLARE @char char(1) = SUBSTRING(@word, @index, 1)
		IF(CHARINDEX(@char, @setOfLetters) <= 0)
		BEGIN
			RETURN 0;
		END

		SET @index = @index + 1
	END

	RETURN 1
END

SELECT dbo.ufn_IsWordComprised ('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised ('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised ('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised ('pppp', 'Guy')
			  
-- Problem 8. *Delete Employees and Departments
BEGIN TRAN
	ALTER TABLE Employees
	DROP CONSTRAINT [FK_Employees_Employees]
	ALTER TABLE Departments
	DROP CONSTRAINT [FK_Departments_Employees]
	ALTER TABLE EmployeesProjects
	DROP CONSTRAINT [FK_EmployeesProjects_Employees]
	DELETE FROM Employees
	WHERE DepartmentID IN(7,8)
	DELETE FROM Departments
	WHERE DepartmentID IN(7,8)
COMMIT

-- OR

ALTER TABLE Departments
ALTER COLUMN ManagerId INT NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN 
(
	SELECT e.EmployeeID
	FROM Employees AS e
	INNER JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name IN ('Production', 'Production Control')
)

UPDATE Employees
SET ManagerID = NULL
WHERE ManagerID IN
(		  
	SELECT e.EmployeeID
	FROM Employees AS e
	INNER JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name IN ('Production', 'Production Control')
)

UPDATE Departments
SET ManagerID = NULL
WHERE ManagerID IN
(
	SELECT e.EmployeeID
	FROM Employees AS e
	INNER JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name IN ('Production', 'Production Control')
)

DELETE FROM Employees
WHERE EmployeeID IN
(
	SELECT e.EmployeeID
	FROM Employees AS e
	INNER JOIN Departments AS d ON d.DepartmentID = e.DepartmentID
	WHERE d.Name IN ('Production', 'Production Control')
)

DELETE FROM Departments
WHERE Name IN ('Production', 'Production Control')

-- Problem 9. Employees with Three Projects
CREATE PROC usp_AssignProject(@emloyeeId int, @projectID int)
AS
BEGIN

	DECLARE @maxEmployeeCount int = 3;
	DECLARE @projectCount int;
	SET @projectCount =
	(
		SELECT COUNT(*)
		FROM EmployeesProjects AS ep
		WHERE ep.EmployeeID = @emloyeeId
	)

	BEGIN TRAN
		INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
		VALUES(@emloyeeId, @projectID)

		if(@projectCount >= @maxEmployeeCount)
		BEGIN
			RAISERROR('The employee has too many projects!', 16, 1)
			ROLLBACK
		END
		ELSE
	COMMIT
END

EXEC dbo.usp_AssignProject 267, 37

--- PART II – Queries for Bank Database ---

-- Problem 10. Find Full Name
CREATE PROC usp_GetHoldersFullName 
AS
BEGIN
	SELECT a.FirstName + ' ' + a.LastName AS 'Full Name'
	FROM AccountHolders AS a
END
			   
-- Problem 11. People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number money)
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
	FROM AccountHolders AS ah
	INNER JOIN Accounts AS ac
	ON ac.AccountHolderId = ah.Id
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(ac.Balance) >= @number
END

-- OR

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@value money)
AS
BEGIN
	SELECT FirstName, LastName 
	FROM AccountHolders
	INNER JOIN
	(
		-- VV nepravilno
		SELECT AccountHolderId, SUM(Balance) AS [Sum]
		FROM Accounts
		GROUP BY AccountHolderId
		HAVING SUM(Balance) > @value
	)AS balances ON AccountHolders. Id = balances.AccountHolderId
END

-- VV pravilno
SELECT ah.FirstName, ah.LastName
FROM AccountHolders AS ah
LEFT JOIN Accounts AS a
ON a.AccountHolderId = ah.Id
GROUP BY FirstName, LastName
HAVING SUM(a.Balance) >= @value
		   
-- Problem 12. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue (@moneySum money, @yearlyInterestRate float, @numberOfYears int)
RETURNS money
AS
BEGIN

	DECLARE @result money
	SET @result = (@moneySum * POWER((1 + @yearlyInterestRate), @numberOfYears))
	RETURN @result;

END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

-- Problem 13. Calculating Interest
CREATE PROC usp_CalculateFutureValueForAccount (@accountID int, @interestRate float)
AS
BEGIN
	DECLARE @newBalance money
	SELECT TOP(1) ah.Id AS 'Account Id', ah.FirstName, ah.LastName, ac.Balance,
	CASE
	WHEN @newBalance IS NULL THEN dbo.ufn_CalculateFutureValue(Balance, 0.1, 5) END AS 'Balance in 5 years'
	FROM AccountHolders AS ah
	INNER JOIN Accounts AS ac
	ON ac.AccountHolderId = ah.Id
	WHERE @accountID = ac.AccountHolderId
END

-- OR

CREATE PROC usp_CalculateFutureValueForAccount (@accountID int, @interestRate float)
AS
BEGIN
	DECLARE @newBalance money
	SELECT TOP(1) ah.Id AS 'Account Id', ah.FirstName, ah.LastName, ac.Balance, dbo.ufn_CalculateFutureValue(Balance, @interestRate, 5) AS 'Balance in 5 years'
	FROM AccountHolders AS ah
	INNER JOIN Accounts AS ac
	ON ac.AccountHolderId = ah.Id
	WHERE @accountID = ac.AccountHolderId
END

			   
-- Problem 14. Deposit Money
CREATE PROC usp_DepositMoney(@AccountId int, @moneyAmount money)
AS
BEGIN
	BEGIN TRANSACTION
		UPDATE Accounts
		SET Balance += @moneyAmount
		WHERE Id = @AccountId

		IF(@@ROWCOUNT != 1)
		BEGIN
			ROLLBACK;
			RAISERROR('Ne moje taka', 16, 1)
			RETURN
		END

	COMMIT
END
			   
-- Problem 15. Withdraw Money
CREATE PROC usp_WithdrawMoney(@AccountId int, @moneyAmount money)
AS
BEGIN
	BEGIN TRANSACTION
		UPDATE Accounts
		SET Balance -= @moneyAmount
		WHERE Id = @AccountId

		IF(@@ROWCOUNT != 1)
		BEGIN
			ROLLBACK;
			RAISERROR('Ne moje taka', 16, 1)
			RETURN
		END
		
		IF ((SELECT TOP(1) Balance FROM Accounts WHERE Id = @accountID) < 0) --!!!!!!!!!!!!!!!!!!!!!!
		BEGIN
			ROLLBACK;
			THROW 50001, 'Nqma pari', 1;
			RETURN;		
		END

	COMMIT
END
			   
-- Problem 16. Money Transfer
CREATE PROC usp_TransferMoney(@senderId int, @receiverId int, @amount money)
AS
BEGIN
	BEGIN TRANSACTION
		UPDATE Accounts
		SET Balance -= @amount
		WHERE Id = @senderId
		UPDATE Accounts
		SET Balance += @amount
		WHERE Id = @receiverId

		IF(@@ROWCOUNT != 1)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid account!', 16, 1)
			RETURN
		END		
	COMMIT
END

EXEC dbo.usp_TransferMoney 16,14,345
			   
-- Problem 17. Create Table Logs
CREATE TABLE Logs(
LogId int IDENTITY NOT NULL,
AccountId int,
OldSum money,
NewSum money
CONSTRAINT PK_Logs PRIMARY KEY (LogId)
CONSTRAINT FK_Logs_accounts FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
)

CREATE TRIGGER T_Accounts_After_Update ON Accounts 
AFTER UPDATE
AS
BEGIN
	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT i.Id, d.Balance, i.Balance
	FROM inserted AS i
	INNER JOIN deleted AS d
	ON d.Id = i.Id
END

UPDATE Accounts
SET Balance += 10
WHERE Id = 1

SELECT * FROM Logs
			   
-- Problem 18. Create Table Emails
CREATE TABLE NotificationEmails(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Recipient VARCHAR(100),
Subject VARCHAR(100),
Body VARCHAR(100)
)

CREATE TRIGGER T_Insert_Into_Logs ON Logs
AFTER INSERT
AS
BEGIN
	INSERT INTO NotificationEmails(Recipient, Subject, Body)
	SELECT AccountId,
	'Balance change for account: ' + CONVERT(VARCHAR(50), AccountId),
	'On ' + CONVERT(VARCHAR(50), GETDATE()) + ' your balance was changed from' + CONVERT(VARCHAR(50), OldSum) + 'to' + CONVERT(VARCHAR(50), NewSum)  + '.'
	FROM Logs
END

UPDATE Accounts
SET Balance += 10
WHERE Id = 1

--- PART III – Queries for Diablo Database ---

-- Problem 19. *Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames(@gameName nvarchar(100))
RETURNS @result TABLE(
cashSum MONEY
)
AS
BEGIN
	INSERT INTO @result
	SELECT SUM(res.Cash) AS 'SumCash'
	FROM
	(
		SELECT ug.Cash ,ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS 'Rows'
		FROM UsersGames AS ug
		RIGHT JOIN Games AS g
		ON g.Id = ug.GameId
		WHERE g.Name = @gameName) AS res
	WHERE res.Rows % 2 != 0
	RETURN
END
			   
-- Problem 20. Trigger
CREATE TRIGGER Tr_Dont_Buy ON UserGameItems
INSTEAD OF INSERT
AS
BEGIN
	INSERT INTO UserGameItems 
	SELECT ItemId, UserGameId 
	FROM inserted
	WHERE ItemId IN 
	(
		SELECT Id 
		FROM Items 
		WHERE MinLevel <= 
		(
			SELECT ug.Level 
			FROM UsersGames as ug
			WHERE ug.GameId = UserGameId
	))
END

SELECT MinLevel FROM Items WHERE Id = 2
			   
-- Problem 21. *Massive Shopping
BEGIN TRANSACTION
DECLARE @sum1 MONEY = (SELECT SUM(i.Price)
						FROM Items i
						WHERE MinLevel BETWEEN 11 AND 12)

IF (SELECT Cash FROM UsersGames WHERE Id = 110) < @sum1
ROLLBACK
ELSE BEGIN
		UPDATE UsersGames
		SET Cash = Cash - @sum1
		WHERE Id = 110

		INSERT INTO UserGameItems (UserGameId, ItemId)
		SELECT 110, Id 
		FROM Items 
		WHERE MinLevel BETWEEN 11 AND 12
		COMMIT
	END

BEGIN TRANSACTION
DECLARE @sum2 MONEY = (SELECT SUM(i.Price)
						FROM Items i
						WHERE MinLevel BETWEEN 19 AND 21)

IF (SELECT Cash FROM UsersGames WHERE Id = 110) < @sum2
ROLLBACK
ELSE BEGIN
		UPDATE UsersGames
		SET Cash = Cash - @sum2
		WHERE Id = 110

		INSERT INTO UserGameItems (UserGameId, ItemId)
			SELECT 110, Id 
			FROM Items 
			WHERE MinLevel BETWEEN 19 AND 21
		COMMIT
	END

SELECT i.Name AS 'Item Name' 
FROM UserGameItems ugi
JOIN Items i
ON ugi.ItemId = i.Id
WHERE ugi.UserGameId = 110
		   
-- Problem 22. Number of Users for Email Provider
SELECT e.[Email Provider], COUNT(e.[Email Provider]) AS 'Number Of Users' FROM
(
	SELECT RIGHT(u.Email, LEN(u.Email) - CHARINDEX('@',Email)) AS 'Email Provider'
	FROM Users AS u
) AS e
GROUP BY e.[Email Provider]
ORDER BY COUNT(e.[Email Provider]) DESC, e.[Email Provider] ASC
			   
-- Problem 23. All User in Games
SELECT g.Name AS 'Game', gt.Name AS 'Game Type', u.Username, ug.Level, ug.Cash, c.Name AS 'Character'
FROM UsersGames AS ug
INNER JOIN Games AS g
ON ug.GameId = g.Id
INNER JOIN GameTypes AS gt
ON g.GameTypeId = gt.Id
INNER JOIN Users AS u
ON ug.UserId = u.Id 
INNER JOIN Characters AS c
ON ug.CharacterId =  c.Id 
ORDER BY ug.Level DESC, u.Username ASC, g.Name ASC

-- Problem 24. Users in Games with Their Items
SELECT u.Username, g.Name AS 'Game', COUNT(*) AS 'Items Count', SUM(i.Price) AS 'Items Price'
FROM UsersGames AS ug
INNER JOIN Games AS g
ON ug.GameId = g.Id
INNER JOIN Users AS u
ON ug.UserId = u.Id 
INNER JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
INNER JOIN Items AS i
ON ugi.ItemId = i.Id 
GROUP BY u.Username, g.Name
HAVING COUNT(*) >= 10
ORDER BY 'Items Count' DESC, 'Items Price' DESC, u.Username ASC

-- Problem 25. *User in Games with Their Statistics
SELECT u.Username, g.Name, c.Name, s.Strength, s.Defence, s.Speed, s.Mind, s.Luck
FROM Users AS u
INNER JOIN UsersGames AS ug
ON ug.UserId = u.Id
INNER JOIN Games AS g
ON g.Id = ug.GameId
INNER JOIN Characters AS c
ON c.Id = ug.CharacterId
INNER JOIN [Statistics] AS s
ON s.Id = c.StatisticId
ORDER BY s.Strength DESC, s.Defence DESC, s.Speed DESC, s.Mind DESC, s.Luck DESC
			   
-- Problem 26. All Items with Greater than Average Statistics
SELECT i.Name, i.Price, i.MinLevel, s.Strength, s.Defence, s.Speed, s.Luck, s.Mind
FROM Items AS i
INNER JOIN [Statistics] AS s
ON i.StatisticId = s.Id
WHERE s.Mind > (SELECT AVG(stat.Mind) FROM [Statistics] AS stat) AND
s.Luck > (SELECT AVG(stat.Luck) FROM [Statistics] AS stat) AND
s.Speed > (SELECT AVG(stat.Speed) FROM [Statistics] AS stat)
ORDER BY i.Name ASC
	   
-- Problem 27. Display All Items with Information about Forbidden Game Type
SELECT i.Name AS 'Item', i.Price, i.MinLevel, gt.Name AS 'Forbidden Game Type'
FROM Items AS i
LEFT JOIN GameTypeForbiddenItems AS fi
ON fi.ItemId = i.Id
LEFT JOIN GameTypes AS gt
ON gt.Id = fi.GameTypeId
ORDER BY 'Forbidden Game Type' DESC, 'Item' ASC

-- OR
-- Not correct
SELECT i.Name AS 'Item', i.Price, i.MinLevel,
CASE
WHEN i.Id = fi.ItemId THEN gt.Name END AS 'Forbidden Game Type'
FROM Items AS i
INNER JOIN GameTypeForbiddenItems AS fi
ON fi.ItemId = i.Id
INNER JOIN GameTypes AS gt
ON gt.Id = fi.GameTypeId
ORDER BY 'Forbidden Game Type' DESC, 'Item' ASC
			   
-- Problem 28. Buy Items for User in Game

--- PART IV – Queries for Geography Database ---

-- Problem 29. Peaks and Mountains
SELECT p.PeakName, m.MountainRange, p.Elevation
FROM Mountains AS m
INNER JOIN Peaks as p
ON p.MountainId = m.Id
ORDER BY p.Elevation DESC, p.PeakName ASC
			   
-- Problem 30. Peaks with Their Mountain, Country and Continent
SELECT p.PeakName, m.MountainRange, c.CountryName, con.ContinentName
FROM Mountains AS m
INNER JOIN Peaks as p
ON p.MountainId = m.Id
INNER JOIN MountainsCountries AS mc
ON mc.MountainId = m.Id
INNER JOIN Countries AS c
ON mc.CountryCode = c.CountryCode
INNER JOIN Continents AS con
ON c.ContinentCode = con.ContinentCode
ORDER BY p.PeakName ASC, c.CountryName ASC
			   
-- Problem 31. Rivers by Country
SELECT c.CountryName, con.ContinentName,
ISNULL(COUNT(r.Id), 0) AS 'RiversCount',
ISNULL(SUM(r.Length), 0) AS 'TotalLength'
FROM Countries AS c
LEFT JOIN Continents AS con
ON c.ContinentCode = con.ContinentCode
LEFT JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
GROUP BY c.CountryName, con.ContinentName
ORDER BY 'RiversCount' DESC, 'TotalLength' DESC, c.CountryName ASC
			   
-- Problem 32. Count of Countries by Currency
SELECT cur.CurrencyCode, cur.Description AS 'Currency', COUNT(c.CurrencyCode) AS 'NumberOfCountries'
FROM Countries AS c
RIGHT JOIN Currencies AS cur
ON c.CurrencyCode = cur.CurrencyCode
GROUP BY cur.CurrencyCode, cur.Description
ORDER BY COUNT(c.CurrencyCode) DESC, cur.Description ASC

-- OR

SELECT cur.CurrencyCode, cur.Description AS 'Currency', COUNT(c.CurrencyCode) AS 'NumberOfCountries'
FROM Currencies AS cur
LEFT JOIN Countries AS c
ON c.CurrencyCode = cur.CurrencyCode
GROUP BY cur.CurrencyCode, cur.Description
ORDER BY COUNT(c.CurrencyCode) DESC, cur.Description ASC
			   
-- Problem 33. Population and Area by Continent
SELECT con.ContinentName, SUM(coun.AreaInSqKm), SUM(CAST(coun.Population AS bigint))
FROM Countries AS coun
INNER JOIN Continents AS con
ON coun.ContinentCode = con.ContinentCode
GROUP BY con.ContinentName
ORDER BY SUM(CAST(coun.Population AS bigint)) DESC

-- OR

SELECT con.ContinentName, SUM(coun.AreaInSqKm), SUM(CONVERT(bigint, coun.Population))
FROM Countries AS coun
INNER JOIN Continents AS con
ON coun.ContinentCode = con.ContinentCode
GROUP BY con.ContinentName
ORDER BY SUM(CONVERT(bigint, coun.Population)) DESC
			   
-- Problem 34. Monasteries by Country !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

-- Problem 35. Monasteries by Continents and Countries
