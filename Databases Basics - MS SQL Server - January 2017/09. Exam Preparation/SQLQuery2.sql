--CREATE PROC usp_SubmitReview (@CustomerID INT, @ReviewContent VARCHAR(MAX), @ReviewGrade INT, @AirlineName VARCHAR(MAX))
--AS
--BEGIN
--	DECLARE @check INT = 
--	(
--		SELECT a.AirlineID FROM 
--		Airlines AS a
--		WHERE a.AirlineName = @AirlineName
--	)

--	IF (@check IS NULL)
--	BEGIN
--		RAISERROR('Airline does not exist.', 16, 1)
--	END
--	ELSE
--	BEGIN
--		INSERT INTO CustomerReviews(ReviewID, ReviewContent, ReviewGrade, AirlineID, CustomerID)
--		VALUES
--		(
--			(SELECT ISNULL(MAX(ReviewID) + 1, 1) FROM CustomerReviews),
--			@ReviewContent,
--			@ReviewGrade,
--			@check,
--			@CustomerID
--		)
--	END
--END

--EXEC dbo.usp_SubmitReview 1, 'asdasd', 1, 'Royal Airline'

--------------------------------------------------------------------------------------------------------------------------------

--CREATE PROC usp_PurchaseTicket(@CustomerID INT, @FlightID INT, @TicketPrice DECIMAL(8,2), @Class VARCHAR(20), @Seat VARCHAR(20))
--AS
--BEGIN
--	UPDATE CustomerBankAccounts
--		SET Balance -= @TicketPrice
--		WHERE CustomerID = @CustomerID

--	DECLARE @customerMoneyCheck DECIMAL(10,2) =
--	(
--		SELECT cba.Balance
--		FROM CustomerBankAccounts AS cba
--		WHERE cba.CustomerID = @CustomerID
--	)

--	IF(@customerMoneyCheck < 0 OR @customerMoneyCheck IS NULL)
--	BEGIN
--		RAISERROR('Insufficient bank account balance for ticket purchase.', 16, 1)
--	END
--	ELSE
--	BEGIN
--		INSERT INTO Tickets(TicketID, Price, Class, Seat, CustomerID, FlightID)
--		VALUES
--		(
--			(SELECT ISNULL(MAX(TicketID) + 1, 1) FROM Tickets),
--			@TicketPrice,
--			@Class,
--			@Seat,
--			@CustomerID,
--			@FlightID
--		)

		
--	END
--END

--EXEC dbo.usp_PurchaseTicket 2, 1, 1.00, 'First', 'asd'

--------------------------------------------------------------------------------------------------------------------------------

--CREATE TRIGGER tr_Update_Trigger ON Flights
--FOR UPDATE
--AS
--BEGIN
--	INSERT INTO ArrivedFlights(FlightID, ArrivalTime, Origin, Destination, Passengers)
--	SELECT 
--	FlightID, 
--	ArrivalTime, 
--	orig.AirportName, 
--	dest.AirportName,
--	(SELECT COUNT(*) FROM Tickets WHERE FlightID = i.FlightID) -- moje is s join
--	FROM inserted AS i
--	JOIN Airports AS orig
--	ON orig.AirportID = i.OriginAirportID
--	JOIN Airports AS dest
--	ON dest.AirportID = i.DestinationAirportID
--	WHERE Status = 'Arrived'
--END

--------------------------------------------------------------------------------------------------------------------------------

--CREATE FUNCTION udf_GetRadians(@input FLOAT)
--RETURNS FLOAT
--AS
--BEGIN
--	RETURN (@input * PI()) / 180
--END

--SELECT dbo.udf_GetRadians(22.12) AS Radians

--------------------------------------------------------------------------------------------------------------------------------

--CREATE PROC udp_ChangePassword(@email VARCHAR(MAX), @password VARCHAR(MAX))
--AS
--BEGIN
--	DECLARE @checkEmail VARCHAR(MAX) = 
--	(
--		SELECT Email
--		FROM Credentials
--		WHERE Email = @email
--	)

--	IF(@checkEmail IS NULL)
--	BEGIN
--		RAISERROR('The email does''t exist!', 16, 1)
--	END
--	ELSE
--	BEGIN
--		UPDATE Credentials
--		SET Password = @password
--		WHERE Email = @email
--	END
--END

--------------------------------------------------------------------------------------------------------------------------------

--CREATE TRIGGER tr_Log_Messages ON Messages
--FOR DELETE
--AS
--BEGIN
--	INSERT INTO MessageLogs (Id, Content, SentOn, ChatId, UserId)
--	SELECT d.Id, d.Content, d.SentOn, d.ChatId, d.UserId FROM deleted AS d
--END

--------------------------------------------------------------------------------------------------------------------------------

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