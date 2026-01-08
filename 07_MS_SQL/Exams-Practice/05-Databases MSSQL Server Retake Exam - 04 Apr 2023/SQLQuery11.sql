

CREATE DATABASE Accounting

GO

CREATE TABLE Countries(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Addresses(
Id INT PRIMARY KEY IDENTITY,
StreetName NVARCHAR(20) NOT NULL,
StreetNumber INT,
PostCode INT NOT NULL,
City VARCHAR(25) NOT NULL,
CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Vendors(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25) NOT NULL,
NumberVAT NVARCHAR(15) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Clients(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(25) NOT NULL,
NumberVAT NVARCHAR(15) NOT NULL,
AddressId INT FOREIGN KEY REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(10) NOT NULL
)

CREATE TABLE Products(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(35) NOT NULL,
Price DECIMAL(18, 2) NOT NULL,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
VendorId INT FOREIGN KEY REFERENCES Vendors(Id) NOT NULL
)

CREATE TABLE Invoices(
Id INT PRIMARY KEY IDENTITY,
Number INT UNIQUE NOT NULL,
IssueDate DATETIME2 NOT NULL,
DueDate DATETIME2 NOT NULL,
Amount DECIMAL(18, 2) NOT NULL,
Currency VARCHAR(5) NOT NULL,
ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL
)

CREATE TABLE ProductsClients(
ProductId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL,
ClientId INT FOREIGN KEY REFERENCES Clients(Id) NOT NULL,
PRIMARY KEY (ProductId, ClientId)
)

--2--

INSERT INTO Products ([Name], Price, CategoryId, VendorId)
VALUES
	('SCANIA Oil Filter XD01', 78.69, 1, 1),
	('MAN Air Filter XD01',	97.38, 1, 5),
	('DAF Light Bulb 05FG87', 55.00, 2, 13),
	('ADR Shoes 47-47.5', 49.85, 3, 5),
	('Anti-slip pads S', 5.87, 5, 7)

INSERT INTO Invoices (Number, IssueDate, DueDate, Amount, Currency, ClientId)
VALUES
	(1219992181, '2023-03-01', '2023-04-30', 180.96, 'BGN',	3),
	(1729252340, '2022-11-06', '2023-01-04', 158.18, 'EUR',	13),
	(1950101013, '2023-02-17', '2023-04-18', 615.15, 'USD',	19)

	--3--

	UPDATE Invoices
	SET DueDate = '2023-04-01'
	WHERE IssueDate >= '2022-11-01' AND IssueDate < '2022-12-01';

	UPDATE Addresses
	SET StreetName = 'Industriestr',
    StreetNumber = '79',
    PostCode = '2353',
    City = 'Guntramsdorf',
    CountryId = (SELECT Id FROM Countries WHERE [Name] = 'Austria')
    WHERE Id IN (
    SELECT AddressId
    FROM Clients
    WHERE Name LIKE '%CO%'
	);

	 --4--

	DELETE FROM ProductsClients
	WHERE ClientId IN (SELECT Id FROM Clients WHERE NumberVAT LIKE 'IT%')

	DELETE FROM Invoices
	WHERE ClientId IN (SELECT Id FROM Clients WHERE NumberVAT LIKE 'IT%')

	DELETE FROM Clients
	WHERE NumberVAT LIKE 'IT%'

	--5--

	SELECT 
		Number,
		Currency

	FROM Invoices
	ORDER BY Amount DESC, DueDate

	-- 6 --

	SELECT 
		p.Id,
		p.[Name],
		Price,
		c.[Name] AS CategoryName

	FROM Products AS p
	JOIN Categories AS c ON p.CategoryId = c.Id
	WHERE c.[Name] IN ('ADR', 'Others')
	ORDER BY Price DESC

	--7--

	SELECT 
		c.Id,
		c.[Name] AS Client,
		CONCAT(a.StreetName, ' ', a.StreetNumber, ', ', a.City, ', ', a.PostCode, ', ', co.[Name]) AS Address
		
	FROM Clients AS c
	LEFT JOIN ProductsClients AS pc ON c.Id = pc.ClientId
	JOIN Addresses AS a ON c.AddressId = a.Id
	JOIN Countries AS co ON a.CountryId = co.Id
	WHERE pc.ClientId IS NULL
			
	--8--

	SELECT TOP(7)
		Number,
		Amount,
		cl.[Name]
	FROM Invoices AS i
	JOIN Clients AS cl ON i.ClientId = cl.Id
	WHERE (IssueDate < '2023-01-01' AND Currency = 'EUR') OR  (Amount > 500.00 AND cl.NumberVAT LIKE 'DE%')
	ORDER BY Number, Amount DESC

	--9--

SELECT 
    c.[Name] AS Client,
    MAX(p.Price) AS Price,
    c.NumberVAT AS [VAT Number]
FROM Clients AS c 
JOIN ProductsClients AS pc ON c.Id = pc.ClientId   
JOIN Products AS p ON pc.ProductId = p.Id   
WHERE c.[Name] NOT LIKE '%KG'
GROUP BY c.[Name], c.NumberVAT
ORDER BY Price DESC;
    
    
    -- 10--

SELECT 
    c.[Name] AS Client,
	FLOOR(AVG(Price)) AS [Average Price]
FROM Clients AS c
JOIN ProductsClients AS pc ON c.Id = pc.ClientId   
JOIN Products AS p ON pc.ProductId = p.Id 
JOIN Vendors AS v ON p.VendorId = v.Id
WHERE v.NumberVAT LIKE '%FR%'
GROUP BY  c.[Name]
HAVING COUNT(pc.ProductId) > 0
ORDER BY [Average Price], CLient DESC


GO
--11--
   
  CREATE FUNCTION udf_ProductWithClients(@name NVARCHAR(35)) 
  RETURNS INT
  AS
  BEGIN
  DECLARE @NumberOfClients INT

	SELECT  @NumberOfClients =		
		COUNT(*)
	FROM Clients AS c
    JOIN ProductsClients AS pc ON c.Id = pc.ClientId   
	JOIN Products AS p ON pc.ProductId = p.Id
	WHERE p.[Name] = @name
  RETURN @NumberOfClients
  END
   
    GO
  --12--

  CREATE PROC usp_SearchByCountry(@country VARCHAR(10))
  AS
		SELECT 
			v.[Name],
			v.NumberVAT AS VAT,
			CONCAT_WS(' ', a.StreetName, a.StreetNumber) AS [Street Info],
			CONCAT_WS(' ', a.City, a.PostCode) AS [City Info]
		
		FROM Vendors As v
		JOIN Addresses AS a ON v.AddressId = a.Id
		JOIN Countries AS c ON a.CountryId = c.Id
		WHERE c.[Name] = @country
		ORDER BY v.[Name], a.City