CREATE DATABASE MinionsDB

USE MinionsDB

-- 1
CREATE TABLE Towns
(
TownID INT PRIMARY KEY,
TownName VARCHAR(50),
CountryName VARCHAR(50)
)

CREATE TABLE Minions
(
MinionId INT PRIMARY KEY,
Name VARCHAR(50),
Age INT,
TownID INT FOREIGN KEY (TownID) REFERENCES Towns(TownID)
)

CREATE TABLE Villains
(
VillainId INT PRIMARY KEY,
Name VARCHAR(100),
EvilnessFactor VARCHAR(10) CHECK (Evilnessfactor = 'good' OR Evilnessfactor = 'bad' OR Evilnessfactor = 'evil' OR Evilnessfactor = 'super evil')
)

CREATE TABLE VilliansMinions
(
VillianId INT FOREIGN KEY REFERENCES Villains(VillainId),
MinionId INT FOREIGN KEY REFERENCES Minions(MinionId)
PRIMARY KEY (VillianId, MinionId)
)

INSERT INTO Towns(TownID, TownName, CountryName)
VALUES 
(1, 'Sofia', 'Bulgaria'),
(2, 'Plovdiv', 'Bulgaria'),
(3, 'Berlin', 'Germany'),
(4, 'Paris', 'France'),
(5, 'Liverpool', 'England'),
(6, 'London', 'England'),
(7, 'Rome', 'Italy'),
(8, 'Faeto', 'Italy'),
(9, 'Imbersago', 'Italy'),
(10, 'Nazzano', 'Italy')

INSERT INTO Minions (MinionId, Name, Age, TownID)
VALUES 
(1, 'Kev', 11, 1),
(2, 'Bobb', 12, 2),
(3, 'Stew', 5, 3),
(4, 'Malk', 3, 4),
(5, 'Tosh', 1, 5),
(6, 'Dean', 11, 6),
(7, 'Wanda', 32, 7),
(8, 'Lonnie', 15, 8),
(9, 'Arturo', 6, 9),
(10, 'Herbert', 77, 10),
(11, 'Carolyn', 31, 3),
(12, 'Delbert', 22, 6),
(13, 'Roger', 45, 8),
(14, 'Jody', 3, 3),
(15, 'Nancy', 3, 9)

INSERT INTO Villains (VillainId, Name, EvilnessFactor)
VALUES
(1, 'Gosho', 'bad'),
(2, 'Tosho', 'good'),
(3, 'Misho', 'evil'),
(4, 'Gogo', 'super evil'),
(5, 'Tiho', 'bad'),
(6, 'Mike', 'bad'),
(7, 'Martha', 'good'),
(8, 'Muriel', 'evil'),
(9, 'Antonia', 'super evil'),
(10,'Denise', 'bad')

INSERT INTO VilliansMinions(VillianId, MinionId)
VALUES 
(1,1),
(2,2),
(3,3),
(4,4),
(5,5),
(6,6),
(7,7),
(8,8),
(9,9),
(10,10),
(1,11),
(2,12),
(3,13),
(4,14),
(5,15)

-- 2
SELECT v.Name, COUNT(vm.MinionId) AS 'Count'
FROM Villains AS v
LEFT JOIN VilliansMinions AS vm
ON vm.VillianId = v.VillainId
GROUP BY v.Name
HAVING COUNT(vm.MinionId) > 1

-- 3
SELECT v.Name
FROM Villains AS v
WHERE v.VillainId = 6

SELECT m.MinionId, m.Name, m.Age
FROM Minions AS m
INNER JOIN VilliansMinions AS vm
ON vm.VillianId = m.MinionId
INNER JOIN Villains AS v
ON v.VillainId = vm.VillianId
WHERE v.VillainId = 6

-- 4

-- 5
UPDATE Towns
SET TownName = UPPER(TownName)
WHERE CountryName = 'England' AND TownName != UPPER(TownName) COLLATE SQL_Latin1_General_CP1_CS_AS

SELECT TownName
FROM Towns

-- 6

-- 7

-- 8
UPDATE Minions
SET Age += 1
WHERE MinionId = 1

-- 9
CREATE PROC usp_GetOlder(@minionId INT)
AS
BEGIN
	UPDATE Minions
	SET Age += 1
	WHERE MinionId = @minionId
END

exec dbo.usp_GetOlder 1
