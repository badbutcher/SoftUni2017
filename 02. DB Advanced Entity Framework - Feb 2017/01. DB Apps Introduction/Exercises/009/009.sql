CREATE PROC usp_GetOlder(@minionId INT)
AS
BEGIN
	UPDATE Minions
	SET Age += 1
	WHERE MinionId = @minionId
END