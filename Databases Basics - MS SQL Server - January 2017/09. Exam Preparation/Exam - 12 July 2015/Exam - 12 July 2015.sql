--- Part I – Preliminary Setup ---

--- Part II – SQL Queries ---

-- Problem 1. All Diablo Characters
SELECT c.Name AS 'Name'
FROM Characters AS c
ORDER BY c.Name ASC
              
-- Problem 2. Games from 2011 and 2012 year
SELECT TOP 50 Name AS 'Game', CONVERT(char(10), Start, 126) AS 'Start'
FROM Games 
WHERE Start BETWEEN '2011-01-01' AND '2012-12-31' 
ORDER BY Start, Name 
              
-- Problem 3. User Email Providers
SELECT u.Username AS 'Username', RIGHT(u.Email, CHARINDEX('@',REVERSE(u.Email))-1) AS 'Email Provider'
FROM Users AS u
ORDER BY 'Email Provider'

              
-- Problem 4. Get users with IPAddress like pattern
SELECT u.Username AS 'Username', u.IpAddress AS 'IP Address'
FROM Users AS u
WHERE u.IpAddress LIKE '___.1%.%.___'
ORDER BY u.Username
              
-- Problem 5. Show All Games with Duration and Part of the Day
SELECT g.Name AS 'Game',
CASE
WHEN DATEPART(HOUR, g.Start) >= 0 AND DATEPART(HOUR, g.Start) < 12 THEN 'Morning'
WHEN DATEPART(HOUR, g.Start) >= 12 AND DATEPART(HOUR, g.Start) < 18 THEN 'Afternoon'
ELSE 'Evening' 
END AS 'Part of the Day',
CASE
WHEN g.Duration <= 3 THEN 'Extra Short'
WHEN g.Duration BETWEEN 4 AND 6 THEN 'Short'
WHEN g.Duration >= 6 THEN 'Long'
ELSE 'Extra Long' 
END AS 'Duration'
FROM Games AS g
ORDER BY g.Name ASC, 'Duration' ASC, 'Part of the Day' ASC
              
-- Problem 6. Number of Users for Email Provider !!!!
SELECT RIGHT(u.Email, CHARINDEX('@',REVERSE(u.Email))-1) AS 'Email Provider',  COUNT(u.Username) AS 'Email Provider'
FROM Users AS u
GROUP BY RIGHT(u.Email, CHARINDEX('@',REVERSE(u.Email))-1)
ORDER BY COUNT(u.Username) DESC, 'Email Provider' ASC
              
-- Problem 7. All User in Games
SELECT g.Name AS 'Game', gt.Name AS 'Game Type', u.Username AS 'Username', ug.Level AS 'Level', ug.Cash AS 'Cash', c.Name AS 'Character'
FROM Games AS g
INNER JOIN GameTypes AS gt
ON gt.Id = g.GameTypeId
INNER JOIN UsersGames AS ug
ON ug.GameId = g.Id
INNER JOIN Users AS u
ON u.Id = ug.UserId
INNER JOIN Characters AS c
ON c.Id = ug.CharacterId
ORDER BY ug.Level DESC, u.Username ASC, g.Name ASC
              
-- Problem 8. Users in Games with Their Items
SELECT u.Username AS 'Username', g.Name AS 'Game', COUNT(i.Id) AS 'Items Count', SUM(i.Price) AS 'Items Price'
FROM UsersGames AS ug
INNER JOIN Users AS u
ON u.Id = ug.UserId
INNER JOIN Games AS g
ON g.Id = ug.GameId
INNER JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
INNER JOIN Items AS i
ON i.Id = ugi.ItemId
GROUP BY u.Username, g.Name
HAVING COUNT(i.Id) >= 10
ORDER BY 'Items Count' DESC, 'Items Price' DESC, u.Username ASC
              
-- Problem 9. *User in Games with Their Statistics
SELECT u.Username, g.Name AS 'Game', c.Name AS 'Character', 
SUM(st.Strength) AS 'Strength', SUM(st.Defence) AS 'Defence', SUM(st.Speed) AS 'Speed', SUM(st.Mind) AS 'Mind', SUM(st.Luck) AS 'Luck'
FROM UsersGames AS ug
INNER JOIN Users AS u
ON u.Id = ug.UserId
INNER JOIN Games AS g
ON g.Id = ug.GameId
INNER JOIN Characters AS c
ON c.Id = ug.CharacterId
INNER JOIN [Statistics] AS st
ON st.Id = c.StatisticId
WHERE u.Username = 'skippingside'
GROUP BY u.Username, g.Name, c.Name
            
-- Problem 10. All Items with Greater than Average Statistics
SELECT i.Name AS 'Name', i.Price AS 'Price', i.MinLevel, st.Strength, st.Defence, st.Speed, st.Luck, st.Mind
FROM Items AS i
INNER JOIN [Statistics] AS st
ON st.Id = i.StatisticId
WHERE st.Speed >
(
SELECT AVG(st.Speed)
FROM [Statistics] AS st
)
AND st.Luck >
(
SELECT AVG(st.Luck)
FROM [Statistics] AS st
)
AND st.Mind >
(
SELECT AVG(st.Mind)
FROM [Statistics] AS st
)
ORDER BY i.Name ASC
             
-- Problem 11. Display All Items with Information about Forbidden Game Type
SELECT i.Name, i.Price, i.MinLevel, gt.Name
FROM Items AS i
INNER JOIN GameTypeForbiddenItems AS fi
ON fi.ItemId = i.Id
INNER JOIN GameTypes AS gt
ON gt.Id = fi.GameTypeId
ORDER BY gt.Name DESC, i.Name ASC

--- Part III – Changes in the Database ---

-- Problem 12. Buy items for user in game
SELECT DISTINCT i.Name, i.Price
FROM UsersGames AS ug
INNER JOIN Users AS u
ON u.Id = ug.UserId
INNER JOIN Games AS g
ON g.Id = ug.GameId
INNER JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
INNER JOIN Items AS i
ON i.Id = ugi.ItemId
WHERE i.Name IN ('Blackguard', 'Bottomless Potion of Amplification', 'Eye of Etlich (Diablo III)', 'Gem of Efficacious Toxin', 'Golden Gorget of Leoric', ' Hellfire Amulet')

-- Problem 13. Massive shopping

--- IV – Stored Procedures / Functions / Triggers ---

-- Problem 14. Scalar Function: Cash in User Games Odd Rows
GO
CREATE FUNCTION fn_CashInUsersGames(@gameName VARCHAR(50))
RETURNS MONEY
AS
BEGIN
	SELECT g.Name, SUM(ug.Cash)
	FROM UsersGames AS ug
	INNER JOIN Games AS g
	ON g.Id = ug.GameId
	WHERE g.Name IN('Bali', 'Lily Stargazer', 'Love in a mist', 'Mimosa', 'Ming fern') 
	AND ug.Id / 2 != 0
	GROUP BY g.Name
	ORDER BY SUM(ug.Cash) DESC
END

-- Problem 15. Trigger
GO
CREATE TRIGGER tr_AddMoney ON UsersGames
INSTEAD OF UPDATE
AS
BEGIN
	SELECT u.Username, ug.Cash
	FROM UsersGames AS ug
	INNER JOIN Users AS u
	ON u.Id = ug.UserId
	INNER JOIN Games AS g
	ON g.Id = ug.GameId
	WHERE u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos') AND g.Name = 'Bali'
END

--- Part V – Database Schema Design ---

-- Problem 16. Design a Database Schema in MySQL and Write a Query