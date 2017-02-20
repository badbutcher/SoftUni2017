-- 1
CREATE TABLE Countries
(
Id INT IDENTITY PRIMARY KEY,
Name NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers
(
Id INT IDENTITY PRIMARY KEY,
FirstName NVARCHAR(30),
LastName NVARCHAR(30),
Gender CHAR(1) CHECK (Gender = 'F' OR Gender = 'M'),
Age INT,
PhoneNumber VARCHAR(10) CHECK (LEN(PhoneNumber) = 10),
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Distributors
(
Id INT IDENTITY PRIMARY KEY,
Name NVARCHAR(25) UNIQUE,
AddressText NVARCHAR(30),
Summary NVARCHAR(200),
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Products
(
Id INT IDENTITY PRIMARY KEY,
Name NVARCHAR(25) UNIQUE,
Description NVARCHAR(250),
Recipe NVARCHAR(MAX),
Price Decimal(10,2) CHECK (Price >= 0)
)

CREATE TABLE Feedbacks
(
Id INT IDENTITY PRIMARY KEY ,
Description NVARCHAR(255),
Rate Decimal(10,2) CHECK (RATE BETWEEN 0 AND 10),
ProductId INT FOREIGN KEY REFERENCES Products(Id),
CustomerId INT FOREIGN KEY REFERENCES Customers(Id)
)

CREATE TABLE Ingredients
(
Id INT IDENTITY PRIMARY KEY,
Name NVARCHAR(30),
Description NVARCHAR(200),
OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
ProductId INT FOREIGN KEY REFERENCES Products(Id),
IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id),
PRIMARY KEY (ProductId, IngredientId)
)

-- 2 DONE
INSERT INTO Distributors (Name, CountryId, AddressText, Summary)
VALUES
('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId)
VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0139037043', 8),
('Hannah', 'Edmison', 18, 'F', '0043343686', 1),
('Tom', 'Loeza', 31, 'M', '0144876096', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0064215793', 29),
('Hiu', 'Portaro', 25, 'M', '0068277755', 16),
('Josefa', 'Opitz', 43, 'F', '0197887645', 17)

-- 3 DONE
UPDATE Ingredients
SET DistributorId = 35
WHERE Name IN( 'Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

-- 4 DONE
DELETE Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

-- 5 DONE
SELECT p.Name, p.Price, p.Description
FROM Products AS p
ORDER BY p.Price DESC, p.Name ASC

-- 6 DONE
SELECT i.Name, i.Description, i.OriginCountryId
FROM Ingredients AS i
WHERE i.OriginCountryId IN(1,10,20)
ORDER BY i.Id

-- 7 DONE
SELECT TOP(15) i.Name, i.Description, c.Name
FROM Ingredients AS i
INNER JOIN Countries AS c
ON c.Id = i.OriginCountryId
WHERE c.Name IN('Bulgaria', 'Greece')
ORDER BY i.Name, c.Name

-- 8 DONE
SELECT TOP(10) p.Name, p.Description, AVG(fb.Rate) AS 'AverageRate', COUNT(fb.CustomerId) AS 'FeedbacksAmount'
FROM Products AS p
INNER JOIN Feedbacks AS fb
ON fb.ProductId = p.Id
GROUP BY  p.Name, p.Description
ORDER BY AVG(fb.Rate) DESC, COUNT(fb.CustomerId) DESC

-- 9 DONE
SELECT f.ProductId, f.Rate, f.Description, c.Id, c.Age, c.Gender
FROM Feedbacks AS f
INNER JOIN Customers AS c
ON c.Id = f.CustomerId
WHERE f.Rate < 5.00
ORDER BY f.ProductId DESC, f.Rate ASC

-- 10 DONE
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS 'CustomerName', c.PhoneNumber, c.Gender
FROM Customers AS c
LEFT JOIN Feedbacks AS fb
ON fb.CustomerId = c.Id
WHERE fb.CustomerId IS NULL
ORDER BY c.Id ASC

-- 11 DONE
SELECT f.ProductId, CONCAT(cus.FirstName, ' ', cus.LastName) AS 'CustomerName', f.Description
FROM Feedbacks AS f
INNER JOIN Customers AS cus
ON cus.Id = f.CustomerId
WHERE f.CustomerId IN
(
	SELECT f.CustomerId
	FROM Customers AS c
	INNER JOIN Feedbacks AS f
	ON f.CustomerId = c.Id
	GROUP BY f.CustomerId
	HAVING COUNT(f.CustomerId) >= 3
)
ORDER BY f.ProductId ASC, 'CustomerName' ASC, f.Id ASC

-- 12 DONE
SELECT c.FirstName, c.Age, c.PhoneNumber
FROM Customers AS c
INNER JOIN Countries AS con
ON con.Id = c.CountryId
WHERE (c.Age >= 21 AND c.FirstName LIKE '%an%') OR (c.PhoneNumber LIKE '%38' AND con.Name != 'Greece')
ORDER BY c.FirstName ASC, c.Age DESC

-- 13 DONE
SELECT di.Name, ing.Name, pro.Name, AVG(fb.Rate) AS 'AverageRate'
FROM Distributors AS di
INNER JOIN Ingredients AS ing
ON ing.DistributorId = di.Id
INNER JOIN ProductsIngredients AS pri
ON pri.IngredientId = ing.Id
INNER JOIN Products AS pro
ON pro.Id = pri.ProductId
INNER JOIN Feedbacks AS fb
ON fb.ProductId = pro.Id
GROUP BY di.Name, ing.Name, pro.Name
HAVING AVG(fb.Rate) BETWEEN 5.00 AND 8.00
ORDER BY di.Name ASC, ing.Name ASC, pro.Name ASC

-- 14
SELECT con.Name, fb.Rate
FROM Countries AS con
INNER JOIN Customers AS cus
ON cus.CountryId = con.Id
INNER JOIN Feedbacks AS fb
ON fb.CustomerId = cus.Id

SELECT AVG(f.Rate)
FROM Feedbacks AS f
INNER JOIN Customers AS c
ON c.Id = f.CustomerId
GROUP BY f.Id


-- 15
SELECT con.Name, dis.Name
FROM Countries AS con
INNER JOIN Distributors AS dis
ON dis.CountryId = con.Id
INNER JOIN Ingredients AS ing
ON ing.DistributorId = dis.Id
ORDER BY con.Name ASC, dis.Name

SELECT d.Name, COUNT(i.DistributorId)
FROM Distributors AS d
INNER JOIN Ingredients AS i
ON i.DistributorId = d.Id
GROUP BY d.Name
ORDER BY  d.Name


-- 16 DONE
CREATE VIEW v_UserWithCountries AS
SELECT CONCAT(c.FirstName, ' ', c.LastName) AS 'CustomerName', c.Age, c.Gender, con.Name
FROM Customers AS c
INNER JOIN Countries AS con
ON con.Id = c.CountryId

-- 17 DONE
CREATE FUNCTION udf_GetRating(@productName NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @checkRate FLOAT =
	(
		SELECT AVG(fb.Rate)
		FROM Feedbacks AS fb
		INNER JOIN Products AS p
		ON p.Id = fb.ProductId
		WHERE p.Name = @productName
	)
	 
	IF(@checkRate < 5)
	BEGIN
		RETURN 'Bad'
	END
	ELSE IF(@checkRate BETWEEN 5 AND 8)
	BEGIN
		RETURN 'Average'
	END
	ELSE IF(@checkRate > 8)
	BEGIN
		RETURN 'Good'
	END

	RETURN 'No rating'
END

SELECT TOP 5 Id, Name, dbo.f_Feedback_By_Product_Name(Name)
  FROM Products
 ORDER BY Id

-- 18 --insert feedbacks DONE 
CREATE PROC usp_SendFeedback(@customerId INT, @productId INT, @rate FLOAT, @description NVARCHAR(MAX))
AS 
BEGIN
	BEGIN TRAN
	DECLARE @feedbacksCount INT =
	(
		SELECT COUNT(f.CustomerId)
		FROM Feedbacks AS f
		WHERE f.CustomerId = @customerId
		GROUP BY f.CustomerId	
	)

	IF(@feedbacksCount IS NULL OR @feedbacksCount >= 3)
	BEGIN
		ROLLBACK
		RAISERROR ('You are limited to only 3 feedbacks per product!', 16, 1)
	END

	INSERT INTO Feedbacks(CustomerId, ProductId, Rate, Description)
	VALUES(@customerId, @productId, @rate, @description)

	COMMIT
END

EXEC usp_SendFeedback 1, 5, 7.50, 'Average experience';
SELECT COUNT(*) FROM Feedbacks WHERE CustomerId = 1 AND ProductId = 5;


-- 19
ALTER TRIGGER tr_Delete_Products ON Products
AFTER DELETE
AS
BEGIN

	DECLARE @deletedId INT = 
	(
		SELECT d.Id
		FROM deleted AS d
	)

	DELETE FROM Feedbacks
	WHERE ProductId = @deletedId

	UPDATE Feedbacks
	SET CustomerId = NULL
	WHERE CustomerId IN(SELECT Id FROM deleted)

	DELETE FROM ProductsIngredients
	WHERE ProductId = @deletedId
END

BEGIN TRAN
DELETE FROM Products WHERE Id = 7
ROLLBACK

-- 20
