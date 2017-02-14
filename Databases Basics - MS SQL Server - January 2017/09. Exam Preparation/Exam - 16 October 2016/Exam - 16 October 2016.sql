--- Section 0: Database Overview ---

--- Section 1: Data Definition ---
CREATE TABLE Flights
(
FlightID INT PRIMARY KEY,
DepartureTime DATETIME NOT NULL,
ArrivalTime DATETIME NOT NULL,
Status VARCHAR(9) NOT NULL  CHECK(Status = 'Departing' OR Status = 'Delayed' OR Status = 'Arrived' OR Status = 'Cancelled'),
OriginAirportID INT FOREIGN KEY REFERENCES Airports(AirportID),
DestinationAirportID INT FOREIGN KEY REFERENCES Airports(AirportID),
AirlineID INT FOREIGN KEY REFERENCES Airlines(AirlineID)
)

CREATE TABLE Tickets
(
TicketID INT PRIMARY KEY,
Price DECIMAL(8,2) NOT NULL,
Class VARCHAR(6) CHECK(Class = 'First' OR Class = 'Second' OR Class = 'Third'),
Seat VARCHAR(5) NOT NULL,
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID),
FlightID INT FOREIGN KEY REFERENCES Flights(FlightID)
)

--- Section 2: Database Manipulations ---

-- Task 1: Data Insertion
INSERT INTO Flights
VALUES
(1, '2016-10-13 06:00 AM', '2016-10-13 10:00 AM', 'Delayed', 1, 4, 1),
(2, '2016-10-12 12:00 PM', '2016-10-12 12:01 PM', 'Departing', 1, 3, 2),
(3, '2016-10-14 03:00 PM', '2016-10-20 04:00 AM', 'Delayed', 4, 2, 4),
(4, '2016-10-12 01:24 PM', '2016-10-12 4:31 PM', 'Departing', 3, 1, 3),
(5, '2016-10-12 08:11 AM', '2016-10-12 11:22 PM', 'Departing', 4, 1, 1),
(6, '1995-06-21 12:30 PM', '1995-06-22 08:30 PM', 'Arrived', 2, 3, 5),
(7, '2016-10-12 11:34 PM', '2016-10-13 03:00 AM', 'Departing', 2, 4, 2),
(8, '2016-11-11 01:00 PM', '2016-11-12 10:00 PM', 'Delayed', 4, 3, 1),
(9, '2015-10-01 12:00 PM', '2015-12-01 01:00 AM', 'Arrived', 1, 2, 1),
(10, '2016-10-12 07:30 PM', '2016-10-13 12:30 PM', 'Departing', 2, 1, 7)

INSERT INTO Tickets
VALUES
(1,	3000.00, 'First', '233-A',	3, 8),
(2,	1799.90, 'Second', '123-D',	1, 1),
(3,	1200.50, 'Second', '12-Z',	2, 5),
(4,	410.68, 'Third', '45-Q', 2, 8),
(5,	560.00, 'Third', '201-R', 4, 6),
(6,	2100.00, 'Second', '13-T', 1, 9),
(7,	5500.00, 'First', '98-O', 2, 7)

-- Task 2: Update Arrived Flights
UPDATE Flights
SET Flights.AirlineID = 1 
WHERE Status = 'Arrived'

-- Task 3: Update Tickets
UPDATE Tickets
SET Price += (Price * 50) / 100
FROM 
(
	SELECT TOP(1) Rating
	FROM Airlines
	ORDER BY Rating DESC
) AS r
WHERE r.Rating = 200

-- Task 4: Table Creation
CREATE TABLE CustomerReviews
(
ReviewID INT PRIMARY KEY,
ReviewContent VARCHAR(255) NOT NULL,
ReviewGrade INT CHECK(ReviewGrade BETWEEN 0 AND 10),
AirlineID INT FOREIGN KEY REFERENCES Airlines(AirlineID),
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

CREATE TABLE CustomerBankAccounts
(
AccountID INT PRIMARY KEY,
AccountNumber VARCHAR(10) NOT NULL UNIQUE, 
Balance DECIMAL(10, 2),
CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)
)

-- Task 5: Fill the new Tables with Data
INSERT INTO CustomerReviews
VALUES
(1,	'Me is very happy. Me likey this airline. Me good.', 10, 1,	1),
(2,	'Ja, Ja, Ja... Ja, Gut, Gut, Ja Gut! Sehr Gut!', 10, 1, 4),
(3,	'Meh...', 5, 4,	3),
(4,	'Well Ive seen better, but Ive certainly seen a lot worse...', 7, 3, 5)

INSERT INTO CustomerBankAccounts
VALUES
(1,	'123456790', 2569.23, 1),
(2,	'18ABC23672', 14004568.23, 2),
(3,	'F0RG0100N3', 19345.20, 5)

--- Section 3: Querying ---

-- Task 1: Extract All Tickets
SELECT t.TicketID, t.Price, t.Class, t.Seat
FROM Tickets AS t
ORDER BY t.TicketID ASC

-- Task 2: Extract All Customers 
SELECT c.CustomerID, c.FirstName + ' ' + c.LastName AS 'FullName', c.Gender
FROM Customers AS c
ORDER BY 'FullName' ASC, c.CustomerID ASC

-- Task 3: Extract Delayed Flights
SELECT f.FlightID, f.DepartureTime, f.ArrivalTime
FROM Flights AS f
WHERE f.Status = 'Delayed'
ORDER BY f.FlightID ASC

-- Task 4: Extract Top 5 Most Highly Rated Airlines which have any Flights
SELECT TOP(5) a.AirlineID, a.AirlineName, a.Nationality, a.Rating
FROM Airlines AS a
WHERE a.AirlineID IN(SELECT f.AirlineID FROM Flights AS f)
ORDER BY a.Rating DESC, a.AirlineID ASC

-- Task 5: Extract all Tickets with price below 5000, for First Class
SELECT t.TicketID, a.AirportName AS 'Destination', c.FirstName + ' ' + c.LastName AS 'CustomerName'
FROM Tickets AS t
INNER JOIN Customers AS c
ON c.CustomerID = t.CustomerID
INNER JOIN Flights AS f
ON f.FlightID = t.FlightID
INNER JOIN Airports AS a
ON a.AirportID = f.DestinationAirportID
WHERE t.Price < 5000 AND t.Class = 'First'
ORDER BY t.TicketID ASC

-- Task 6: Extract all Customers which are departing from their Home Town
SELECT c.CustomerID, c.FirstName + ' ' + c.LastName AS 'FullName', tow.TownName
FROM Customers AS c
INNER JOIN Tickets AS t
ON t.CustomerID = c.CustomerID
INNER JOIN Flights AS f
ON f.FlightID = t.FlightID
INNER JOIN Airports AS a
ON a.AirportID = f.OriginAirportID
INNER JOIN Towns AS tow
ON tow.TownID = c.HomeTownID
WHERE a.TownID = c.HomeTownID AND f.Status = 'Departing'
ORDER BY c.CustomerID

-- Task 7: Extract all Customers which will fly
SELECT DISTINCT c.CustomerID, c.FirstName + ' ' + c.LastName AS 'FullName', DATEDIFF(YEAR, c.DateOfBirth, '2016.01.01') AS 'Age'
FROM Customers AS c
INNER JOIN Tickets AS t
ON t.CustomerID = c.CustomerID
INNER JOIN Flights AS f
ON f.FlightID = t.FlightID
WHERE f.Status = 'Departing' 
ORDER BY 'Age' ASC, c.CustomerID ASC

-- Task 8: Extract Top 3 Customers which have Delayed Flights
SELECT TOP(3) c.CustomerID, c.FirstName + ' ' + c.LastName AS 'FullName', t.Price AS 'TicketPrice', a.AirportName
FROM Customers AS c
INNER JOIN Tickets AS t
ON t.CustomerID = c.CustomerID
INNER JOIN Flights AS f
ON f.FlightID = t.FlightID
INNER JOIN Airports AS a
ON a.AirportID = f.DestinationAirportID
WHERE f.Status = 'Delayed'
ORDER BY TicketPrice DESC, c.CustomerID ASC

-- Task 9: Extract the Last 5 Flights, which are departing.
SELECT fl.FlightID, fl.DepartureTime, fl.ArrivalTime, ao.AirportName AS 'Origin', ad.AirportName AS 'Destination'
FROM
(
	SELECT TOP(5) * 
	FROM Flights AS f
	WHERE f.Status = 'Departing' 
	ORDER BY DepartureTime DESC
) AS fl
INNER JOIN Airports AS ao
ON ao.AirportID = fl.OriginAirportID
INNER JOIN Airports AS ad
ON ad.AirportID = fl.DestinationAirportID
ORDER BY fl.DepartureTime ASC, FlightID ASC

-- OR

SELECT * FROM
(
SELECT TOP(5) f.FlightID, f.DepartureTime, f.ArrivalTime,b.AirportName AS Origin, a.AirportName AS Destination
FROM  Flights AS f, Airports AS a, Airports AS b
WHERE a.AirportID = f.DestinationAirportID AND b.AirportID = f.OriginAirportID AND Status = 'Departing' 
ORDER BY f.DepartureTime DESC
) AS asd ORDER BY DepartureTime, FlightID

-- Task 10: Extract all Customers below 21 years, which have already flew at least once
SELECT c.CustomerID, c.FirstName + ' ' + c.LastName AS 'FullName', DATEDIFF(YEAR, c.DateOfBirth, '2016.01.01') AS 'Age'
FROM Customers AS c
WHERE DATEDIFF(YEAR, c.DateOfBirth, '2016.01.01') < 21 AND c.CustomerID IN
(
	SELECT t.CustomerID 
	FROM Tickets AS t
	INNER JOIN Flights AS f
	ON f.FlightID = t.FlightID
	WHERE f.Status = 'Arrived'
)

ORDER BY 'Age' DESC, c.CustomerID ASC

--SELECT c.CustomerID, c.FirstName + ' ' + c.LastName AS 'FullName', DATEDIFF(YEAR, c.DateOfBirth, '2016.01.01') AS 'Age'
--FROM Customers AS c
--INNER JOIN Tickets AS t
--ON t.CustomerID = c.CustomerID
--INNER JOIN Flights AS f
--ON f.FlightID = t.FlightID
--WHERE DATEDIFF(YEAR, c.DateOfBirth, '2016.01.01') < 21 AND f.Status = 'Arrived'
--ORDER BY 'Age' DESC, c.CustomerID ASC

-- Task 11: Extract all Airports and the Count of People departing from them
SELECT ap.AirportID, ap.AirportName, COUNT(t.CustomerID) AS 'Passengers'
FROM Airports AS ap
INNER JOIN Flights AS f
ON f.OriginAirportID = ap.AirportID
INNER JOIN Tickets AS t
ON t.FlightID = f.FlightID
WHERE f.Status = 'Departing'
GROUP BY ap.AirportID, ap.AirportName
ORDER BY ap.AirportID

--- Section 4: Programmability ---

-- Task 1: Review Registering Procedure
GO
CREATE PROC usp_SubmitReview(@CustomerID INT, @ReviewContent VARCHAR(255), @ReviewGrade INT, @AirlineName VARCHAR(30))
AS
BEGIN
	DECLARE @airlineId INT = 
	(
		SELECT  a.AirlineID
		FROM Airlines AS a
		WHERE a.AirlineName = @AirlineName
	)

	IF(@airlineId IS NULL)
	BEGIN
		RAISERROR('Airline does not exist.', 16, 1)
		RETURN
	END
	INSERT INTO CustomerReviews(ReviewID, CustomerID, ReviewContent, ReviewGrade, AirlineID)
	VALUES ((SELECT ISNULL(MAX(ReviewID) + 1, 1) FROM CustomerReviews), @CustomerID, @ReviewContent, @ReviewGrade, @airlineId)

END

EXEC dbo.usp_SubmitReview 1, 'asdasfffffffffdasd', 10, 'Royal Airline'

-- Task 2: Ticket Purchase Procedure
GO
CREATE PROC usp_PurchaseTicket(@CustomerID INT, @FlightID INT, @TicketPrice DECIMAL(8, 2), @Class VARCHAR(6), @Seat VARCHAR(5))
AS
BEGIN
	IF (@TicketPrice > ISNULL(
	(
		SELECT Balance
		FROM CustomerBankAccounts 
		WHERE CustomerID = @CustomerID
	),0))
	BEGIN
		RAISERROR('Insufficient bank account balance for ticket purchase.', 16, 1)
		RETURN;
	END

	INSERT INTO Tickets(TicketID, FlightID, Price, Class, Seat, CustomerID )
	VALUES((SELECT ISNULL(MAX(TicketID) + 1, 1) FROM Tickets), @FlightID, @TicketPrice, @Class, @Seat, @CustomerID)

	UPDATE CustomerBankAccounts
	SET Balance -= @TicketPrice
	WHERE CustomerID = @CustomerID
END


--- Section 5 (BONUS): Update Trigger ---
CREATE TABLE ArrivedFlights
(
FlightID INT PRIMARY KEY,
ArrivalTime DATETIME NOT NULL,
Origin VARCHAR(50) NOT NULL,
Destination VARCHAR(50) NOT NULL,
Passengers INT NOT NULL
)

CREATE TRIGGER tr_Update_Status ON Flights
INSTEAD OF UPDATE
AS
BEGIN
	INSERT INTO ArrivedFlights(FlightID, ArrivalTime, Origin, Destination, Passengers)
	SELECT 
	i.FlightID, 
	i.ArrivalTime,
	(SELECT ap.AirportName FROM Airports AS ap WHERE ap.AirportID = i.OriginAirportID) AS 'Origin',
	(SELECT ap.AirportName FROM Airports AS ap WHERE ap.AirportID = i.DestinationAirportID) AS 'Origin',
	(SELECT  COUNT(t.TicketID) FROM Flights AS f 
			INNER JOIN Tickets AS t ON t.FlightID = f.FlightID WHERE f.FlightID = i.FlightID)
		 FROM inserted AS i
			INNER JOIN deleted AS d ON d.FlightID = i.FlightID
			WHERE (d.Status != 'Arrived' AND i.Status = 'Arrived')

END

--SET @AirlineName = 
--	(SELECT AirlineName 
--	FROM Airlines AS a
--	INNER JOIN CustomerReviews AS cr
--	ON cr.AirlineID = a.AirlineID
--	WHERE @AirlineName = a.AirlineName)