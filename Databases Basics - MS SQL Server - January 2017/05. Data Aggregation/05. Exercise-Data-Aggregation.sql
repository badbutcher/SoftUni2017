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
--SELECT Age AS 'AgeGroup', COUNT(Id) AS 'WizardCount'
--FROM WizzardDeposits 
--WHERE Age BETWEEN 11 AND 20
--GROUP BY Age

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
SELECT DepartmentID, AVG(Salary) AS 'AverageSalary'
FROM Employees
WHERE ManagerID != 42 
GROUP BY DepartmentID

-- Problem 16. Employees Maximum Salaries

-- Problem 17. Employees Count Salaries

-- Problem 18. *3rd Highest Salary

-- Problem 19. **Salary Challenge