-- Problem 1. Records’ Count
SELECT COUNT(Id) 
FROM WizzardDeposits

-- Problem 2. Longest Magic Wand
SELECT MAX(MagicWandSize) 
FROM WizzardDeposits

-- Problem 3. Longest Magic Wand per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize) AS 'LongestMagicWand'
FROM WizzardDeposits
GROUP BY DepositGroup

-- Problem 4. *Smallest Deposit Group per Magic Wand Size
SELECT DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
HAVING AVG(MagicWandSize) <
(
	SELECT AVG(MagicWandSize) FROM WizzardDeposits
)

-- OR

SELECT DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
HAVING AVG(MagicWandSize) = 
(
	SELECT MIN(wizzardsWandsSizes.AVGMagicWandSize) 
	FROM
	(
		SELECT DepositGroup, AVG(MagicWandSize) AS AVGMagicWandSize 
		FROM WizzardDeposits
		GROUP BY DepositGroup
	) AS wizzardsWandsSizes
)

-- OR

SELECT TOP 1 WITH TIES DepositGroup, AVG(MagicWandSize)
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

-- Problem 5. Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) AS 'TotalSum'
FROM WizzardDeposits
GROUP BY DepositGroup

-- Problem 6. Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS 'TotalSum'
FROM WizzardDeposits 
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- Problem 7. Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS 'TotalSum'
FROM WizzardDeposits 
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY 'TotalSum' DESC

-- Problem 8. Deposit Charge
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS 'MinDepositCharge'
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator ASC, DepositGroup ASC

-- Problem 9. Age Groups
SELECT
CASE 
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
WHEN Age > 60 THEN '[61+]' 
END AS 'AgeGroup',COUNT(Id) AS WizardCount
FROM WizzardDeposits
GROUP BY CASE
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
WHEN Age > 60 THEN '[61+]'
END

-- OR

SELECT ageGroups.AgeGroup, COUNT(*) FROM
(
SELECT
CASE 
WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
WHEN Age > 60 THEN '[61+]' 
END AS AgeGroup
FROM WizzardDeposits
) AS ageGroups
GROUP BY ageGroups.AgeGroup

-- Problem 10. First Letter
SELECT SUBSTRING(FirstName,1,1) AS 'FirstLetter'
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY SUBSTRING(FirstName,1,1)
ORDER BY FirstLetter

-- Problem 11. Average Interest
SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest)
FROM WizzardDeposits
WHERE  DepositStartDate > '1985.01.01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

--SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS 'AverageInterest',
--CASE
--WHEN IsDepositExpired = 0 THEN AVG(DepositInterest) / 2 ELSE AVG(DepositInterest) END AS 'AverageInterest'
--FROM WizzardDeposits
--WHERE  DepositStartDate > '1985.01.01'
--GROUP BY DepositGroup, IsDepositExpired
--ORDER BY DepositGroup DESC, IsDepositExpired ASC

-- Problem 12. *Rich Wizard, Poor Wizard
SELECT SUM(wiz1.DepositAmount - wiz2.DepositAmount) as 'Difference'
FROM WizzardDeposits AS wiz1
	JOIN WizzardDeposits wiz2
	ON wiz2.Id = wiz1.id + 1

-- OR

DECLARE @currentDeposit DECIMAL(8,2)
DECLARE @previuosDeposit DECIMAL(8,2)
DECLARE @totalSum DECIMAL(8,2) = 0

DECLARE wizardCursor CURSOR FOR SELECT DepositAmount FROM WizzardDeposits
OPEN wizardCursor
FETCH NEXT FROM wizardCursor INTO @currentDeposit

WHILE @@FETCH_STATUS = 0
BEGIN
IF(@previuosDeposit IS NOT NULL)
BEGIN
SET @totalSum += (@previuosDeposit - @currentDeposit)
END

SET @previuosDeposit = @currentDeposit
FETCH NEXT FROM wizardCursor INTO @currentDeposit
END

CLOSE wizardCursor
DEALLOCATE wizardCursor

SELECT @totalSum

-- OR

SELECT SUM(wizardDep.Dif) FROM
(
SELECT
FirstName,
DepositAmount,
LEAD(FirstName) OVER (ORDER BY Id) AS GuestWizard,
LEAD(DepositAmount) OVER (ORDER BY Id) AS GuestDeposit,
DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS Dif
FROM WizzardDeposits
) AS wizardDep


-- Problem 13. Departments Total Salaries
SELECT DepartmentID, SUM(Salary) AS 'MinimumSalary'
FROM Employees
GROUP BY DepartmentID

-- Problem 14. Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary) AS 'AverageSalary'
FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '2000.01.01'
GROUP BY DepartmentID

-- Problem 15. Employees Average Salaries
SELECT DepartmentID, Salary, ManagerID
INTO EmployeesAverageSalaries
FROM Employees;

DELETE
FROM EmployeesAverageSalaries
WHERE ManagerID = 42 

UPDATE EmployeesAverageSalaries
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS 'AverageSalary'
FROM EmployeesAverageSalaries
WHERE Salary > 30000
GROUP BY DepartmentID

-- Problem 16. Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS 'MaxSalary'
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

-- Problem 17. Employees Count Salaries
SELECT COUNT(Salary) AS 'Count'
FROM Employees
GROUP BY ManagerID
HAVING ManagerID IS NULL

-- Problem 18. *3rd Highest Salary
SELECT salaries.DepartmentID, salaries.Salary FROM
(
SELECT 
DepartmentID, 
MAX(Salary) AS Salary,
DENSE_RANK() OVER (PARTITION BY DepartmentId ORDER BY Salary DESC) AS Rank
FROM Employees
GROUP BY DepartmentID, Salary
) AS salaries
WHERE Rank = 3

-- Problem 19. **Salary Challenge
SELECT TOP(10) FirstName, LastName, DepartmentID 
FROM Employees AS e
WHERE Salary > (
				SELECT AVG(Salary) FROM Employees AS emp
				WHERE e.DepartmentID = emp.DepartmentID
				GROUP BY DepartmentID
			   )