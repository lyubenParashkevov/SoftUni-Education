


CREATE DATABASE RailwaysDb

GO

USE RailwaysDb

GO

CREATE TABLE Passengers(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE RailwayStations(
Id INT PRIMARY KEY IDENTITY NOT NULL,
[Name] VARCHAR(50) NOT NULL,
TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Trains(
Id INT PRIMARY KEY IDENTITY NOT NULL,
HourOfDeparture	VARCHAR(5) NOT NULL,
HourOfArrival VARCHAR(5) NOT NULL,
DepartureTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL,
ArrivalTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE TrainsRailwayStations(
TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL,
RailwayStationId INT FOREIGN KEY REFERENCES RailwayStations(Id) NOT NULL,
PRIMARY KEY(TrainId, RailwayStationId)
)

CREATE TABLE MaintenanceRecords(
Id INT PRIMARY KEY IDENTITY NOT NULL,
DateOfMaintenance DATE NOT NULL,
Details VARCHAR(2000) NOT NULL,
TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL
)

CREATE TABLE Tickets(
Id INT PRIMARY KEY IDENTITY NOT NULL,
Price DECIMAL(8, 2) NOT NULL,
DateOfDeparture DATE NOT NULL,
DateOfArrival DATE NOT NULL,
TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL,
PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

-- 2 --

INSERT INTO Trains (HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
VALUES
	('07:00', '19:00',	1,	3),
	('08:30', '20:30',	5,	6),
	('09:00', '21:00',	4,	8),
	('06:45', '03:55',	27,	7),
	('10:15', '12:15',	15,	5)


INSERT INTO TrainsRailwayStations (TrainId, RailwayStationId)
VALUES
	(36, 1),
	(36, 4),
	(36, 31),
	(36, 57),
	(36, 7),
	(37, 13),
	(37, 54),
	(37, 60),
	(37, 16),
	(38, 10),
	(38, 50),
	(38, 52),
	(38, 22),
	(39, 68),
	(39, 3),
	(39, 31),
	(39, 19),
	(40, 41),
	(40, 7),
	(40, 52),
	(40, 13)


INSERT INTO Tickets (Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
VALUES
	(90.00,	'2023-12-01', '2023-12-01',	36,	1 ),
	(115.00, '2023-08-02', '2023-08-02', 37, 2 ),
	(160.00, '2023-08-03', '2023-08-03', 38, 3 ),
	(255.00, '2023-09-01', '2023-09-02', 39, 21),
	(95.00,	'2023-09-02', '2023-09-03',	40,	22)

	-- 3 --

UPDATE Tickets
SET DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture)
WHERE DateOfDeparture > '2023-10-31'

UPDATE Tickets
SET DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
WHERE DateOfDeparture > '2023-10-31'

-- 4--

DELETE FROM Tickets WHERE TrainId IN (SELECT id FROM Trains WHERE DepartureTownId = 3);
DELETE FROM TrainsRailwayStations WHERE TrainId IN (SELECT id FROM Trains WHERE DepartureTownId = 3);
DELETE FROM MaintenanceRecords WHERE TrainId IN (SELECT id FROM Trains WHERE DepartureTownId = 3);

DELETE FROM Trains WHERE DepartureTownId = 3;

-- 5 --

SELECT 
	DateOfDeparture,
	Price

FROM Tickets
ORDER BY Price, DateOfDeparture DESC

-- 6 --

SELECT 
	p.[Name] AS PassengerName,
	t.Price AS TicketPrice,
	t.DateOfDeparture,
	t.TrainId

FROM Tickets AS t
JOIN Passengers AS p ON t.PassengerId = p.Id
ORDER BY TicketPrice DESC, PassengerName

-- 7 --



SELECT t.[Name], rs.[Name] AS RailwayStation
FROM RailwayStations rs
LEFT JOIN TrainsRailwayStations ts ON rs.Id = ts.RailwayStationId
JOIN Towns AS t ON rs.TownId = t.Id
WHERE ts.TrainId IS NULL
ORDER BY t.[Name] ASC, rs.[Name] ASC

-- 8 --

SELECT TOP(3)
	tr.Id AS TrainId,
	tr.HourOfDeparture,
	t.Price AS TicketPrice,
	Towns.[Name] AS Destination

FROM Trains AS tr
JOIN Tickets AS t ON tr.Id = t.TrainId
JOIN Towns ON tr.ArrivalTownId = Towns.Id
WHERE t.Price > 50.00 AND tr.HourOfDeparture BETWEEN '08:00' AND '08:59'
ORDER BY t.Price , HourOfDeparture

-- 9 --

SELECT 
	Towns.[Name] AS TownName, 
	COUNT(p.Id) AS PassengersCount

FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Trains AS tr ON t.TrainId = tr.Id
JOIN Towns ON tr.ArrivalTownId = Towns.Id
WHERE t.Price > 76.99
GROUP BY Towns.[Name]
ORDER BY Towns.[Name] ASC;


-- 10 --

SELECT 
	tr.Id AS TrainId,
	t.[Name] AS DepartureTown,
	m.Details
FROM MaintenanceRecords AS m
JOIN Trains AS tr ON m.TrainId = tr.Id
JOIN Towns AS t ON tr.DepartureTownId = t.Id
WHERE m.Details LIKE '%inspection%'
ORDER BY TrainId

GO
-- 11 --

CREATE FUNCTION udf_TownsWithTrains(@name VARCHAR(30))
RETURNS INT
AS
BEGIN 
	DECLARE @TrainCount INT;	
    SELECT @TrainCount = COUNT(*)
    FROM Trains AS tr
	JOIN Towns AS t ON tr.ArrivalTownId = t.Id
	JOIN Towns AS t2 ON tr.DepartureTownId = t2.Id
    WHERE t2.[Name] = @name OR t.[Name] = @name;
    RETURN @TrainCount;
END
 
 SELECT dbo.udf_TownsWithTrains('Paris')

 GO
 -- 12 --



 CREATE PROC usp_SearchByTown(@townName VARCHAR(30)) 
 AS

	SELECT
		p.[Name] AS PassengerName,
		t.DateOfDeparture,
		tr.HourOfDeparture
	FROM Passengers AS p 
	JOIN Tickets AS t ON p.Id = t.PassengerId
	JOIN Trains AS tr ON t.TrainId = tr.Id
	JOIN Towns ON tr.ArrivalTownId = Towns.Id
	WHERE Towns.[Name] = @townName
	ORDER BY DateOfDeparture DESC, PassengerName


EXEC usp_SearchByTown 'Berlin'