--- Part I – SQL Queries ---

-- Problem 1. All Teams
SELECT t.TeamName
FROM Teams AS t
              
-- Problem 2. Biggest Countries by Population
SELECT TOP(50) c.CountryName, c.Population
FROM Countries AS c
ORDER BY c.Population DESC, c.CountryName ASC
              
-- Problem 3. Countries and Currency (Eurzone)
SELECT c.CountryName, c.CountryCode,
CASE
WHEN c.CurrencyCode != 'EUR' OR  c.CurrencyCode IS NULL THEN 'Outside' ELSE 'Inside' END AS 'Eurozone'
FROM Countries AS c
ORDER BY c.CountryName ASC
              
-- Problem 4. Teams Holding Numbers
SELECT t.TeamName AS 'Team Name', t.CountryCode AS 'Country Code'
FROM Teams AS t
WHERE t.TeamName LIKE '%[0-9]%'
ORDER BY t.CountryCode ASC
              
-- Problem 5. International Matches
SELECT hc.CountryName AS 'Home Team', ac.CountryName AS 'Away Team', im.MatchDate AS 'Match Date'
FROM InternationalMatches AS im
JOIN Countries hc ON im.HomeCountryCode = hc.CountryCode
JOIN Countries ac ON im.AwayCountryCode = ac.CountryCode
ORDER BY 'Match Date' DESC
              
-- Problem 6. *Teams with their League and League Country
SELECT t.TeamName AS 'Team Name', 
l.LeagueName AS 'League',
CASE
WHEN l.CountryCode IS NULL THEN 'International' ELSE c.CountryName END AS 'League Country'
FROM Teams AS t
LEFT JOIN Leagues_Teams AS lt
ON lt.TeamId = t.Id
LEFT JOIN Leagues AS l
ON l.Id = lt.LeagueId
LEFT JOIN Countries AS c
ON c.CountryCode = l.CountryCode
ORDER BY t.TeamName ASC, l.LeagueName
              
-- Problem 7. *Teams with more than One Match
SELECT t.TeamName AS 'Team', COUNT(t.TeamName) AS 'Matches Count'
FROM Teams AS t
INNER JOIN TeamMatches AS tm
ON tm.HomeTeamId = t.Id OR tm.AwayTeamId = t.Id
GROUP BY t.TeamName
HAVING COUNT(t.TeamName) > 1
ORDER BY t.TeamName
              
-- Problem 8. Number of Teams and Matches in Leagues
SELECT 
l.LeagueName AS 'League Name', 
COUNT(DISTINCT lt.TeamId) AS 'Teams',
COUNT(DISTINCT tm.Id) AS 'Matches', 
ISNULL(AVG(tm.AwayGoals + tm.HomeGoals), 0) AS 'Average Goals'
FROM Leagues AS l
LEFT JOIN Leagues_Teams AS lt 
ON l.Id = lt.LeagueId
LEFT JOIN TeamMatches AS tm 
ON l.Id = tm.LeagueId
GROUP BY l.LeagueName
ORDER BY 'Teams' DESC, 'Matches' DESC
              
-- Problem 9. Total Goals per Team in all Matches
SELECT t.TeamName,
    (
	SELECT ISNULL(SUM(tm.HomeGoals), 0) 
	FROM TeamMatches AS tm 
	WHERE tm.HomeTeamId = t.Id
	) +
    (
	SELECT ISNULL(SUM(tm.AwayGoals), 0) 
	FROM TeamMatches AS tm 
	WHERE tm.AwayTeamId = t.Id
	) AS 'Total Goals'
FROM Teams AS t
GROUP BY t.Id, t.TeamName
ORDER BY 'Total Goals' DESC, t.TeamName ASC
              
-- Problem 10 Pairs of Matches on the Same Day
SELECT tm1.MatchDate AS 'First Date', tm2.MatchDate AS 'Second Date'
FROM TeamMatches AS tm1
JOIN TeamMatches AS tm2 
ON tm1.Id != tm2.Id
WHERE CAST(tm1.MatchDate AS DATE) = CAST(tm2.MatchDate AS DATE) AND tm1.MatchDate < tm2.MatchDate
ORDER BY tm1.MatchDate DESC, tm2.MatchDate DESC
              
-- Problem 11 Mix of Team Names
SELECT LOWER(t1.TeamName + SUBSTRING(REVERSE(t2.TeamName), 2, 500)) AS Mix
FROM Teams t1, Teams t2
WHERE RIGHT(t1.TeamName, 1) = RIGHT(t2.TeamName, 1)
ORDER BY Mix
              
-- Problem 12 Countries with International and Team Matches
SELECT c.CountryName AS 'Country Name', 
	COUNT(DISTINCT im1.Id) + COUNT(DISTINCT im2.Id) AS 'International Matches',
	COUNT(DISTINCT tm.Id) AS 'Team Matches'
FROM Countries c
LEFT JOIN InternationalMatches im1 ON c.CountryCode = im1.HomeCountryCode
LEFT JOIN InternationalMatches im2 ON c.CountryCode = im2.AwayCountryCode
LEFT JOIN Leagues l ON c.CountryCode = l.CountryCode
LEFT JOIN TeamMatches tm ON l.id = tm.LeagueId
GROUP BY c.CountryName
HAVING COUNT(DISTINCT im1.Id) + COUNT(DISTINCT im2.Id) > 0 OR COUNT(DISTINCT tm.LeagueId) > 0
ORDER BY 'International Matches' DESC, 'Team Matches' DESC, c.CountryName

--- Part II – Changes in the Database ---

-- Problem 13. Non-international Matches

-- Problem 14. Seasonal Matches

--- Part III – Stored Procedures ---

-- Problem 15. Stored Function: Bulgarian Teams with Matches JSON
