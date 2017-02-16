--- Part I – SQL Queries ---

-- Problem 1. All Mountain Peaks
SELECT p.PeakName
FROM Peaks AS p
ORDER BY p.PeakName ASC
              
-- Problem 2. Biggest Countries by Population
SELECT TOP(30) c.CountryName, c.Population
FROM Countries AS c
WHERE c.ContinentCode = 'EU'
ORDER BY c.Population DESC, c.CountryName ASC
              
-- Problem 3. Countries and Currency (Euro / Not Euro)
SELECT c.CountryName AS 'CountryName', c.CountryCode AS 'CountryCode', 
CASE
WHEN c.CurrencyCode = 'EUR' THEN 'Euro' ELSE 'Not Euro' END AS 'Currency'
FROM Countries AS c
ORDER BY c.CountryName ASC
              
-- Problem 4. Countries Holding 'A' 3 or More Times
SELECT c.CountryName AS 'Country Name', c.IsoCode AS 'ISO Code'
FROM Countries AS c
WHERE c.CountryName LIKE '%a%a%a%'
ORDER BY c.IsoCode ASC
              
-- Problem 5. Peaks and Mountains
SELECT p.PeakName AS 'PeakName', m.MountainRange AS 'Mountain', p.Elevation
FROM Peaks AS p
INNER JOIN Mountains AS m
ON m.Id = p.MountainId
ORDER BY p.Elevation DESC, p.PeakName ASC
              
-- Problem 6. Peaks with Their Mountain, Country and Continent
SELECT p.PeakName AS 'PeakName', m.MountainRange AS 'Mountain', c.CountryName, con.ContinentName
FROM Peaks AS p
INNER JOIN Mountains AS m
ON m.Id = p.MountainId
INNER JOIN MountainsCountries AS mc
ON mc.MountainId = m.Id
INNER JOIN Countries AS c
ON c.CountryCode = mc.CountryCode
INNER JOIN Continents AS con
ON con.ContinentCode = c.ContinentCode
ORDER BY p.PeakName ASC, c.CountryName ASC
              
-- Problem 7. *Rivers Passing through 3 or More Countries
SELECT r.RiverName AS 'River', COUNT(c.CountryName) AS 'Countries Count'
FROM Rivers AS r
INNER JOIN CountriesRivers AS cr
ON cr.RiverId = r.Id
INNER JOIN Countries AS c
ON c.CountryCode = cr.CountryCode
GROUP BY r.RiverName
HAVING COUNT(c.CountryName) >= 3
ORDER BY r.RiverName
              
-- Problem 8. Highest, Lowest and Average Peak Elevation
SELECT MAX(p.Elevation) AS 'MaxElevation', MIN(p.Elevation) AS 'MinElevation', AVG(p.Elevation) AS 'AverageElevation'
FROM Peaks AS p
              
-- Problem 9. Rivers by Country
SELECT c.CountryName, con.ContinentName,
CASE 
WHEN COUNT(r.Id) >= 1 THEN COUNT(r.Id) ELSE 0 END AS 'RiversCount',
CASE 
WHEN SUM(r.Length) IS NOT NULL THEN SUM(r.Length) ELSE 0 END AS 'TotalLength'
FROM Rivers AS r
RIGHT JOIN CountriesRivers AS cr ON cr.RiverId = r.Id
RIGHT JOIN Countries AS c ON c.CountryCode = cr.CountryCode
RIGHT JOIN Continents AS con ON con.ContinentCode = c.ContinentCode
GROUP BY c.CountryName, con.ContinentName
ORDER BY 'RiversCount' DESC, 'TotalLength' DESC, c.CountryName ASC
              
-- Problem 10 Count of Countries by Currency
SELECT
cur.CurrencyCode AS 'CurrencyCode', 
cur.Description AS 'Currency',
COUNT(c.CountryCode) AS 'NumberOfCountries'
FROM Countries AS c
RIGHT JOIN Currencies AS cur
ON cur.CurrencyCode = c.CurrencyCode
GROUP BY cur.CurrencyCode, cur.Description
ORDER BY COUNT(c.CountryCode) DESC, cur.Description ASC

SELECT cur.CurrencyCode, cur.Description AS 'Currency', COUNT(c.CurrencyCode) AS 'NumberOfCountries'
FROM Currencies AS cur
LEFT JOIN Countries AS c
ON c.CurrencyCode = cur.CurrencyCode
GROUP BY cur.CurrencyCode, cur.Description
ORDER BY COUNT(c.CurrencyCode) DESC, cur.Description ASC
              
-- Problem 11 *Population and Area by Continent
SELECT 
con.ContinentName, 
SUM(CAST(c.AreaInSqKm AS bigint)) AS 'CountriesArea', 
SUM(CAST(c.Population AS bigint)) AS 'CountriesPopulation'
FROM Continents AS con
INNER JOIN Countries AS c
ON c.ContinentCode = con.ContinentCode
GROUP BY con.ContinentName
ORDER BY 'CountriesPopulation' DESC
              
-- Problem 12 Highest Peak and Longest River by Country
SELECT c.CountryName, MAX(p.Elevation) AS 'HighestPeakElevation', MAX(r.Length) AS 'LongestRiverLength'
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains AS m
ON m.Id = mc.MountainId
LEFT JOIN Peaks AS p
ON p.MountainId = m.Id
LEFT JOIN CountriesRivers AS cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers AS r
ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY 'HighestPeakElevation' DESC, 'LongestRiverLength' DESC, c.CountryName ASC
              
-- Problem 13 Mix of Peak and River Names
SELECT p.PeakName, r.RiverName, CONCAT(LOWER(PeakName), LOWER(RIGHT(RiverName,LEN(RiverName)-1 ))) AS 'Mix'
FROM Rivers AS r, Peaks AS p
WHERE LOWER(RIGHT(p.PeakName, 1)) = LOWER(LEFT(r.RiverName, 1))
ORDER BY 'Mix'

-- Problem 14 **Highest Peak Name and Elevation by Country
SELECT
  c.CountryName AS [Country],
  p.PeakName AS [Highest Peak Name],
  p.Elevation AS [Highest Peak Elevation],
  m.MountainRange AS [Mountain]
FROM
  Countries c
  LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
  LEFT JOIN Mountains m ON m.Id = mc.MountainId
  LEFT JOIN Peaks p ON p.MountainId = m.Id
WHERE p.Elevation =
  (SELECT MAX(p.Elevation)
   FROM MountainsCountries mc
     LEFT JOIN Mountains m ON m.Id = mc.MountainId
     LEFT JOIN Peaks p ON p.MountainId = m.Id
   WHERE c.CountryCode = mc.CountryCode)
UNION
SELECT
  c.CountryName AS [Country],
  '(no highest peak)' AS [Highest Peak Name],
  0 AS [Highest Peak Elevation],
  '(no mountain)' AS [Mountain]
FROM
  Countries c
  LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
  LEFT JOIN Mountains m ON m.Id = mc.MountainId
  LEFT JOIN Peaks p ON p.MountainId = m.Id
WHERE 
  (SELECT MAX(p.Elevation)
   FROM MountainsCountries mc
     LEFT JOIN Mountains m ON m.Id = mc.MountainId
     LEFT JOIN Peaks p ON p.MountainId = m.Id
   WHERE c.CountryCode = mc.CountryCode) IS NULL
ORDER BY c.CountryName, [Highest Peak Name]

--- Part II – Changes in the Database ---

-- Problem 15. Monasteries by Country
               
-- Problem 16. Monasteries by Continents and Countries

-- Part III – Stored Procedures

-- Problem 17. Stored Function: Mountain Peaks JSON

--- Part V – Database Schema Design ---

-- Problem 18. Design a Database Schema in MySQL and Write a Query



CREATE TRIGGER tr_name ON Lights FOR UPDATE
AS
INSERT INTO ArrivedFlights(koloni)
INSERT INTO ArrivedFlights
SELECT FlightID, 
ArrivalTime, 
orig.AirportName AS ori, 
dest.AirportName AS des ,
(SELECT COUNT(*) FROM Tickets WHEREFlightID = i.FlightID) AS 'Pas'
FROM inserted As i
JOIN Airports AS orig
ON orig. AirportID = i.OriginAirportsID
JOIN Airports AS dest
ON dest.AirportID = i.DestinationAirportID
WHERE Status = 'Arrived'