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
	WHERE e.Salary > @number
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

EXEC dbo.usp_GetTownsStartingWith 's'
			  
-- Problem 4. Employees from Town
CREATE PROC usp_GetEmployeesFromTown (@townName nvarchar)
			  
-- Problem 5. Salary Level Function
			  
-- Problem 6. Employees by Salary Level
			  
-- Problem 7. Define Function
			  
-- Problem 8. *Delete Employees and Departments
			  
-- Problem 9. Employees with Three Projects

--- PART II – Queries for Bank Database ---

-- Problem 10. Find Full Name
			   
-- Problem 11. People with Balance Higher Than
			   
-- Problem 12. Future Value Function
			   
-- Problem 13. Calculating Interest
			   
-- Problem 14. Deposit Money
			   
-- Problem 15. Withdraw Money
			   
-- Problem 16. Money Transfer
			   
-- Problem 17. Create Table Logs
			   
-- Problem 18. Create Table Emails

--- PART III – Queries for Diablo Database ---

-- Problem 19. *Scalar Function: Cash in User Games Odd Rows
			   
-- Problem 20. Trigger
			   
-- Problem 21. *Massive Shopping
			   
-- Problem 22. Number of Users for Email Provider
			   
-- Problem 23. All User in Games
			   
-- Problem 24. Users in Games with Their Items
			   
-- Problem 25. *User in Games with Their Statistics
			   
-- Problem 26. All Items with Greater than Average Statistics
			   
-- Problem 27. Display All Items with Information about Forbidden Game Type
			   
-- Problem 28. Buy Items for User in Game

--- PART IV – Queries for Geography Database ---

-- Problem 29. Peaks and Mountains
			   
-- Problem 30. Peaks with Their Mountain, Country and Continent
			   
-- Problem 31. Rivers by Country
			   
-- Problem 32. Count of Countries by Currency
			   
-- Problem 33. Population and Area by Continent
			   
-- Problem 34. Monasteries by Country
			   
-- Problem 35. Monasteries by Continents and Countries




-----1111
--CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000 (@Salary money)
--RETURNS bit
--AS
--BEGIN
--	IF(@Salary > 35000)
--	BEGIN
--		RETURN 1;
--	END
--	RETURN 0;
--END

--SELECT FirstName, LastName
--FROM Employees
--WHERE dbo.usp_GetEmployeesSalaryAbove35000(Salary) = 1
--ORDER BY dbo.usp_GetEmployeesSalaryAbove35000(Salary)