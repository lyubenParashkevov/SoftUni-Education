


CREATE DATABASE TouristAgency 

GO

CREATE TABLE Countries(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

 CREATE TABLE Rooms(
 Id INT PRIMARY KEY IDENTITY,
[Type] VARCHAR(40) NOT NULL,
Price DECIMAL(18, 2) NOT NULL,
BedCount INT NOT NULL CHECK (BedCount > 0 AND BedCount <= 10)
 )

 CREATE TABLE Hotels(
 Id INT PRIMARY KEY IDENTITY,
 [Name] VARCHAR(50) NOT NULL,
 DestinationId INT FOREIGN KEY REFERENCES Destinations(Id)
 )

 CREATE TABLE Tourists(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(80) NOT NULL,
PhoneNumber VARCHAR(20) NOT NULL,
Email VARCHAR(80),
CountryId INT FOREIGN KEY REFERENCES Countries(Id)
 )

CREATE TABLE Bookings(
Id INT PRIMARY KEY IDENTITY,
ArrivalDate DATETIME2 NOT NULL,
DepartureDate DATETIME2 NOT NULL,
AdultsCount INT NOT NULL  CHECK (AdultsCount > 0 AND AdultsCount <= 10),
ChildrenCount INT NOT NULL  CHECK (ChildrenCount >= 0 AND ChildrenCount < 10),
TouristId INT FOREIGN KEY REFERENCES Tourists(Id),
HotelId INT FOREIGN KEY REFERENCES Hotels(Id),
RoomId INT FOREIGN KEY REFERENCES Rooms(Id)
)

CREATE TABLE HotelsRooms(
HotelId INT FOREIGN KEY REFERENCES Hotels(Id),
RoomId INT FOREIGN KEY REFERENCES Rooms(Id),
PRIMARY KEY (HotelId,RoomId)
)


--2 --

INSERT INTO Tourists([Name], PhoneNumber, Email, CountryId)
VALUES
('John Rivers',	'653-551-1555', 'john.rivers@example.com', 6),
('Adeline Aglaé', '122-654-8726', 'adeline.aglae@example.com', 2),
('Sergio Ramirez','233-465-2876', 's.ramirez@example.com', 3),
('Johan Müller', '322-876-9826', 'j.muller@example.com', 7),
('Eden Smith', '551-874-2234', 'eden.smith@example.com',	6)




INSERT INTO Bookings (ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId, RoomId)
VALUES
('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)


--3--


UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE ArrivalDate >= '2023-12-01' AND ArrivalDate < '2024-01-01';

UPDATE Tourists
SET Email = NULL
WHERE Name LIKE '%MA%';

--4--
DELETE FROM Bookings
WHERE TouristID IN (SELECT Id FROM Tourists WHERE Name LIKE '%Smith%');


DELETE FROM Tourists
WHERE [Name] LIKE '%Smith%'

--5--

SELECT 
	FORMAT(ArrivalDate, 'yyyy-MM-dd') AS ArrivalDate,
	AdultsCount,
	ChildrenCount

FROM Bookings AS b 

JOIN Rooms AS r ON b.RoomId = r.Id
ORDER BY r.Price DESC, ArrivalDate

-- 6--

 SELECT h.Id, h.[Name]

FROM Hotels AS h
 JOIN HotelsRooms AS hr ON h.Id = hr.HotelId
 JOIN Rooms AS r ON r.Id = hr.RoomId
 JOIN Bookings b ON h.Id = b.HotelId
WHERE r.[Type] = 'VIP Apartment'
GROUP BY h.Id, h.[Name]
ORDER BY COUNT(b.Id) DESC;


-- 7 --

SELECT 
	t.Id,
	t.[Name],
	t.PhoneNumber

FROM Tourists AS t
LEFT JOIN Bookings AS b ON t.Id = b.TouristId
WHERE b.HotelId IS NULL
ORDER BY t.[Name]

SELECT * FROM Tourists

--8--

SELECT TOP(10)
	h.[Name],
	d.[Name],
	c.[Name]
FROM Bookings AS b
JOIN Hotels AS h ON b.HotelId = h.Id
JOIN Destinations AS d ON h.DestinationId = d.Id
JOIN Countries AS c ON d.CountryId = c.Id
WHERE HotelId % 2 != 0 AND ArrivalDate < '2023-12-31'
ORDER BY c.[Name], b.ArrivalDate

--9--

SELECT  
	h.[Name],
	r.Price
FROM Tourists AS t 
JOIN Bookings AS b ON t.Id = b.TouristId
JOIN Hotels AS h ON b.HotelId = h.Id
JOIN Rooms As r ON b.RoomId = r.Id
WHERE t.[Name] NOT LIKE '%ez'
ORDER BY r.Price DESC


-- 10 --

SELECT 
    h.[Name] AS HotelName,
    SUM(r.Price * DATEDIFF(DAY, b.ArrivalDate, b.DepartureDate)) AS TotalRevenue
FROM Bookings b
JOIN Hotels h ON b.HotelId = h.Id
JOIN Rooms r ON b.RoomId = r.Id
GROUP BY h.Name
ORDER BY TotalRevenue DESC;

GO
--11--

CREATE FUNCTION udf_RoomsWithTourists(@name VARCHAR(40))
RETURNS INT
AS
BEGIN

	DECLARE @TotalNumber INT;
	SELECT @TotalNumber = SUM((b.AdultsCount + ChildrenCount))
	
	FROM Bookings AS b 
	JOIN Rooms AS r ON b.RoomId = r.Id
	WHERE r.Type = @name
	RETURN @TotalNumber
END

--SELECT dbo.udf_RoomsWithTourists('Double Room')

GO

-- 12 --

CREATE PROC usp_SearchByCountry(@country VARCHAR(30)) 
AS
	SELECT 
		t.[Name],
		PhoneNumber,
		Email,
		COUNT(*)AS CountOfBookings

	FROM Tourists AS t
	JOIN Countries AS c ON t.CountryId = c.Id
	JOIN Bookings AS b ON t.Id = b.TouristId
	WHERE c.[Name] = @country
	GROUP BY t.[Name], PhoneNumber, Email
	ORDER BY t.[Name], CountOfBookings DESC

	--EXEC usp_SearchByCountry 'Greece'