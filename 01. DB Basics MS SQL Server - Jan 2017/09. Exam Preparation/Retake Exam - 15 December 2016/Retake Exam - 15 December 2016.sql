--- Section 1. DDL ---

-- 1. Database design 
CREATE TABLE Locations
(
Id INT PRIMARY KEY IDENTITY,
Latitude FLOAT,
Longitude FLOAT
)

CREATE TABLE Credentials
(
Id INT PRIMARY KEY IDENTITY,
Email VARCHAR(30),
Password VARCHAR(20)
)

CREATE TABLE Chats
(
Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(32),
StartDate DATE,
IsActive BIT
)

CREATE TABLE Users
(
Id INT PRIMARY KEY IDENTITY,
Nickname VARCHAR(25),
Gender CHAR(1),
Age INT,
LocationId INT FOREIGN KEY REFERENCES Locations(Id),
CredentialId INT FOREIGN KEY REFERENCES Credentials(Id) UNIQUE 
)

CREATE TABLE Messages
(
Id INT PRIMARY KEY IDENTITY,
Content VARCHAR(200),
SentOn DATE,
ChatId INT FOREIGN KEY REFERENCES Chats(Id),
UserId INT FOREIGN KEY REFERENCES Users(Id)
)

CREATE TABLE UsersChats
(
ChatId INT FOREIGN KEY REFERENCES Chats(Id),
UserId INT FOREIGN KEY REFERENCES Users(Id)
PRIMARY KEY(ChatId, UserId)
)

--- Section 2. DML ---

-- 2. Insert
INSERT Messages
(Content, SentOn, ChatId, UserId)
SELECT
CONCAT(us.Age, '-', us.Gender, '-', l.Latitude, '-', l.Longitude),
CONVERT(DATE, GETDATE()),
[ChatId] = CASE
WHEN us.Gender = 'F' THEN CEILING(SQRT((us.Age * 2)))
WHEN us.Gender = 'M' THEN CEILING(POWER((us.Age / 18), 3))
END,
us.Id
FROM Users AS us
INNER JOIN Locations AS l
ON l.Id = us.LocationId
WHERE us.Id >= 10 AND us.Id <= 20

-- OR

INSERT Messages(Content, ChatId, UserId, SentOn)
SELECT 
CONCAT(u.Age, '-', u.Gender, '-', l.Latitude, '-', l.Longitude),
CASE
WHEN u.Gender = 'F' THEN CEILING(SQRT((u.Age * 2)))
WHEN u.Gender = 'M' THEN CEILING(POWER((u.Age / 18), 3))
END,
u.Id,
CONVERT(DATE, GETDATE())
FROM Users AS u
INNER JOIN Locations AS l
ON l.Id = u.LocationId
WHERE u.Id BETWEEN 10 AND 20

-------
--INSERT INTO Messages(Content, SentOn, ChatId, UserId)
--VALUES
--(
--	(
--		SELECT CONCAT(u.Age,'-' ,u.Gender,'-' ,l.Latitude,'-', l.Longitude)
--		FROM Users As u
--		INNER JOIN Locations AS l
--		ON l.Id = u.LocationId
--	),
--		GETDATE(), 
--	(
--		SELECT u.Id,
--		CASE 
--		WHEN u.Gender = 'F' THEN ROUND(SQRT(u.Age * 2), 2)
--		WHEN u.Gender = 'M' THEN ROUND(POWER(u.Age / 18, 3), 2)
--		END
--		FROM Users AS u
--	),
--	(
--		SELECT u.Id FROM Users AS u
--	)
--)

-- 3. Update
UPDATE c
SET c.StartDate = m.SentOn
FROM Chats AS c
INNER JOIN Messages AS m
ON c.Id = m.ChatId
WHERE c.StartDate > m.SentOn

-- OR

UPDATE Chats
SET StartDate = 
(
	SELECT MIN(m.SentOn) 
	FROM Chats AS c 
	INNER JOIN Messages AS m 
	ON m.ChatId = c.Id 
	WHERE c.Id = Chats.Id
)

WHERE Chats.id IN
(
	SELECT c.Id FROM Chats AS c
	INNER JOIN Messages AS m
	ON m.ChatId = c.Id
	GROUP BY c.Id, c.StartDate
	HAVING c.StartDate > MIN(m.SentOn)
)
      
-- 4. Delete
DELETE FROM Locations
WHERE Id = ANY
(
SELECT l.Id
FROM Locations AS l
LEFT JOIN Users AS u
ON u.LocationId = l.Id
WHERE u.LocationId IS NULL
)

-- OR

DELETE FROM Locations
WHERE Id NOT IN 
(
	SELECT DISTINCT LocationId 
	FROM Users
	WHERE LocationId IS NOT NULL
)


--- Section 3. Querying ---

-- 5. Age Range
SELECT u.Nickname, u.Gender, u.Age
FROM Users AS u
WHERE u.Age BETWEEN 22 AND 37
      
-- 6. Messages
SELECT m.Content, m.SentOn
FROM Messages AS m
WHERE m.SentOn >= '2014.05.12' AND m.Content LIKE '%just%'
ORDER BY m.Id DESC
      
-- 7. Chats
SELECT c.Title, c.IsActive
FROM Chats AS c
WHERE (c.IsActive = 0  AND LEN(c.Title) < 5 OR SUBSTRING(c.Title, 3, 2) = 'tl')
ORDER BY c.Title DESC

-- OR

SELECT c.Title, c.IsActive
FROM Chats AS c
WHERE (c.IsActive = 0 AND LEN(c.Title) < 5) OR Title LIKE '__tl%'
ORDER BY c.Title DESC
      
-- 8. Chat Messages
SELECT c.Id, c.Title, m.Id
FROM Chats AS c
INNER JOIN Messages AS m
ON c.Id = m.ChatId
WHERE m.SentOn < '2012.03.26' AND c.Title LIKE '%x'
ORDER BY c.Id ASC, m.Id ASC

-- OR

SELECT c.Id, c.Title, m.Id
FROM Chats AS c
INNER JOIN Messages AS m
ON m.ChatId = c.Id
WHERE m.SentOn < '2012.03.26' AND RIGHT(c.Title, 1) = 'x'
ORDER BY c.Id ASC, m.Id ASC 
	  
-- 9. Message Count
SELECT TOP(5) c.Id, COUNT(m.id) AS 'MessageCount'
FROM Chats AS c
RIGHT JOIN Messages AS m
ON c.Id = m.ChatId
WHERE m.Id < 90
GROUP BY c.Id
ORDER BY 'MessageCount' DESC, c.Id ASC

-- OR

SELECT TOP 5 ChatId, COUNT(*) AS TotalMessages 
FROM Messages
WHERE Messages.Id < 90
GROUP BY ChatId
ORDER BY TotalMessages DESC, ChatId ASC


-- 10. Credentials
SELECT u.Nickname, c.Email, c.Password
FROM Users AS u
INNER JOIN Credentials AS c
ON c.Id = u.CredentialId
WHERE c.Email LIKE '%co.uk'
ORDER BY c.Email ASC

-- OR

SELECT u.Nickname, c.Email, c.Password
FROM Users AS u
INNER JOIN Credentials AS c
ON c.Id = u.CredentialId
WHERE RIGHT(RTRIM(c.Email), 5) = 'co.uk'
ORDER BY c.Email ASC
      
-- 11. Locations
SELECT u.id, u.Nickname, u.Age
FROM Users AS u
LEFT JOIN Locations AS l
ON l.Id = u.LocationId
WHERE l.Id IS NULL
      
-- 12. Left Users
SELECT m.Id, m.ChatId, m.UserId
FROM Messages AS m
LEFT JOIN UsersChats AS uc
ON uc.UserId = m.UserId AND uc.ChatId = m.ChatId
WHERE m.ChatId = 17 AND uc.UserId IS NULL
ORDER BY m.Id DESC

-- OR - 20.33 !!!!!!!!!!!!!

SELECT m.Id, m.ChatId, m.UserId
FROM Messages AS m
LEFT JOIN UsersChats AS uc
ON uc.ChatId = m.ChatId
WHERE m.ChatId = 17 AND m.UserId NOT IN (SELECT UserId FROM UsersChats WHERE ChatId = 17)
ORDER BY m.Id DESC
      
-- 13. Users in Bulgaria
SELECT u.Nickname, c.Title, l.Latitude, l.Longitude
FROM Users AS u
INNER JOIN Locations AS l
ON l.Id = u.LocationId
INNER JOIN UsersChats AS uc
ON uc.UserId = u.Id
INNER JOIN Chats AS c
ON c.Id = uc.ChatId
WHERE Latitude BETWEEN 41.139999 AND 44.129999
AND Longitude BETWEEN 22.209999 AND 28.359999
ORDER BY c.Title ASC
      
-- 14. Last Chat
SELECT TOP(1) WITH TIES c.Title, m.Content
FROM Chats AS c
LEFT JOIN Messages AS m
ON m.ChatId = c.Id
ORDER BY c.StartDate DESC

-- OR 21.15 !!!!!!!!!!!!!!!

SELECT TOP(1) c.Title, m.Content
FROM Chats AS c
LEFT JOIN Messages AS m
ON m.ChatId = c.Id 
ORDER BY StartDate DESC, SentOn ASC

--- Section 4. Programmability ---

-- 15. Radians
GO
CREATE FUNCTION udf_GetRadians(@number FLOAT)
RETURNS FLOAT
AS
BEGIN
	DECLARE @result FLOAT = (@number * PI()) / 180;
	RETURN @result
END
SELECT dbo.udf_GetRadians(22.12) AS Radians 

-- 16. Change Password
GO
CREATE PROC udp_ChangePassword(@Email VARCHAR(30), @NewPassword VARCHAR(20))
AS
BEGIN
	DECLARE @emailCheck VARCHAR(30) = 
	(
		SELECT c.Email
		FROM Credentials AS c
		WHERE c.Email = @Email
	)

	IF (@emailCheck IS NULL)
	BEGIN
		RAISERROR ('The email does''t exist!', 16, 1)
	END
	ELSE
	BEGIN
		UPDATE Credentials
		SET Password = @NewPassword
		WHERE @emailCheck = @Email
	END
END

EXEC udp_ChangePassword 'abarnes0@sogou.com','new_pass'

-- OR

GO
CREATE PROC udp_ChangePassword(@Email VARCHAR(30), @NewPassword VARCHAR(20))
AS
BEGIN
	BEGIN TRANSACTION

	UPDATE Credentials
	SET Password = @NewPassword
	WHERE Email = @Email
	--21.29
	IF(@@ROWCOUNT != 1)
	BEGIN
		ROLLBACK;
		RAISERROR ('The email does''t exist!', 16, 1)
	END
	ELSE
	BEGIN
		COMMIT
	END
END

EXEC udp_ChangePassword 'abarnes0@sogou.com','new_pass'

-- 17. Send Message
GO
CREATE PROC udp_SendMessage(@UserId INT, @ChatId INT, @Content VARCHAR(200))
AS
BEGIN
	DECLARE @chatCheck INT = 
	(
		SELECT COUNT(*)
		FROM UsersChats AS uc
		WHERE @ChatId = uc.ChatId AND @UserId = uc.UserId
	)

	IF(@chatCheck != 1)
	BEGIN
		RAISERROR ('There is no chat with that user!', 16, 1)
	END
	ELSE
	BEGIN		
		INSERT INTO Messages (Content, SentOn, UserId, ChatId)
		VALUES(@Content, GETDATE(), @UserId, @ChatId)
	END
END

-- OR

GO
CREATE PROC udp_SendMessage(@UserId INT, @ChatId INT, @Content VARCHAR(200))
AS
BEGIN
	DECLARE @chatsCount INT = 
	(
		SELECT COUNT(*)
		FROM UsersChats AS uc
		WHERE @ChatId = uc.ChatId AND @UserId = uc.UserId
	)

	IF(@chatsCount != 1)
	BEGIN
		RAISERROR ('There is no chat with that user!', 16, 1)
	END
	ELSE
	BEGIN		
		INSERT INTO Messages (UserId, ChatId, Content, SentOn)
		VALUES(@UserId, @ChatId, @Content, GETDATE())
	END
END

EXEC dbo.udp_SendMessage 19, 17, 'Awesome'
       
-- 18. Log Messages ------- 21.40
CREATE TABLE MessageLogs 
(
Id INT,
Content VARCHAR(200),
SentOn DATE,
ChatId INT,
UserId INT
)

GO
CREATE TRIGGER tr_MessageLogs ON Messages
INSTEAD OF DELETE
AS
BEGIN
	INSERT INTO MessageLogs(Id, Content, SentOn, ChatId, UserId)
	SELECT i.Id, i.Content, i.SentOn, i.ChatId, i.UserId
	FROM deleted AS i
END

DELETE FROM Messages
WHERE Messages.Id = 1

-- OR

GO
CREATE TRIGGER tr_MessageLogs ON Messages
AFTER DELETE
AS
BEGIN
	INSERT INTO dbo.MessageLogs(Id, Content, SentOn, ChatId, UserId)
	SELECT * FROM deleted
END

--- Section 5. Bonus ---

-- 19. Delete users
GO
CREATE TRIGGER tr_Users_InsteadOF_Delete ON Users
INSTEAD OF DELETE
AS
BEGIN
	
	UPDATE Users
	SET CredentialId = NULL
	WHERE Id IN(SELECT Id FROM deleted)

	DELETE FROM Credentials 
	WHERE Id IN(SELECT CredentialId FROM deleted)

	DELETE FROM UsersChats 
	WHERE UserId IN(SELECT Id FROM deleted)

	UPDATE Messages
	SET UserId = NULL
	WHERE UserId IN(SELECT Id FROM deleted)

	DELETE FROM Users
	WHERE Users.Id IN(SELECT Id FROM deleted)
END

-- OR

GO
CREATE TRIGGER tr_Users_InsteadOF_Delete ON Users
INSTEAD OF DELETE
AS
BEGIN
	DELETE FROM UsersChats 
	WHERE UserId IN(SELECT Id FROM deleted)

	UPDATE Messages
	SET UserId = NULL
	WHERE UserId IN(SELECT Id FROM deleted)

	DELETE FROM Users
	WHERE Users.Id IN(SELECT Id FROM deleted)
END

DELETE FROM Users
WHERE Users.Id = 1