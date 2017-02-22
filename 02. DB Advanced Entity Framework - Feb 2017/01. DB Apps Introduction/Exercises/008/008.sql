USE MinionsDB

UPDATE Minions
SET Age += 1
WHERE MinionId = @minionsId