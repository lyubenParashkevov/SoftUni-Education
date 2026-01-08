

--Problem 1
CREATE DATABASE [Minions]

GO

USE [Minions]

GO

-- Problem 2
CREATE TABLE [Minions](
[Id] INT PRIMARY KEY NOT NULL,
[Name] NVARCHAR(50) NOT NULL,
[Age] INT NULL
)

CREATE TABLE [Towns](
[Id] INT PRIMARY KEY NOT NULL,
[Name] NVARCHAR(90) NOT NULL

)

-- Problem 3
ALTER TABLE [Minions] 
ADD [TownId] INT 

--Problem 4
ALTER TABLE [Minions]
ADD CONSTRAINT [FK_Minions_Towns_Id]
FOREIGN KEY([TownId]) REFERENCES [Towns]([Id])

INSERT INTO [Towns]([Id], [Name])
VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO [Minions]([Id], [Name], [Age], [TownId])
VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

--Problem 5
TRUNCATE TABLE [Minions]

-- Problem 6
DROP TABLE [Minions]
DROP TABLE [Towns]

-- Problem 7
CREATE TABLE [People](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(200) NOT NULL,
[Picture] BINARY(2048),
[Height] FLOAT(2),
[Weight] FLOAT(2),
[Gender] CHAR(1) NOT NULL,
[Birthdate] DATE NOT NULL,
[Biography] NVARCHAR(MAX) 
)


INSERT INTO [People]([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES
('Pesho', NULL, 1.56, 88.6, 'm', '1990-12-23', NULL),
('Misho', NULL, 1.44, 68.63, 'm', '1993-12-23', NULL),
('Peshola', NULL, 1.96, 85.6, 'f', '1990-11-23', NULL),
('Meeshi', NULL, 1.56, 88.7, 'f', '1990-12-14', NULL),
('Pepo', NULL, 1.56, 108.6, 'm', '1990-12-13', NULL)

-- Problem 8
CREATE TABLE [Users](
[Id] BIGINT PRIMARY KEY IDENTITY NOT NULL,
[Username] NVARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
[ProfilePicture] VARBINARY(MAX),
[LastLoginTime] DATETIME2,
[IsDeleted] BIT
)

INSERT INTO [Users]([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES
('Pesho', '1233', NULL, GETDATE(), NULL),
('Gesho', '12334', NULL, GETUTCDATE(), NULL),
('Kesho', '12335', NULL, GETDATE(), NULL),
('Lesho', '12336', NULL, GETDATE(), NULL),
('Tesho', '12337', NULL, GETDATE(), NULL)

-- Problem 9
ALTER TABLE [Users]
DROP [PK__Users__3214EC0751011E67]

ALTER TABLE [Users] 
ADD CONSTRAINT [PK_Komposite_Id_Username] 
PRIMARY KEY([Id], [Username])

-- Problem 10
ALTER TABLE [Users]
ADD CONSTRAINT [CH_Password_Lenght_5]
CHECK(LEN([Password]) >= 5)

-- Problem 11
ALTER TABLE [Users]
ADD CONSTRAINT [DV_LastLoginTime_DefaultValue_CurrentTime]
DEFAULT GETDATE() FOR [LastloginTime]

INSERT INTO [Users]([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES
('Haho', '1233999', NULL, GETDATE(), NULL)


-- Problem 13
CREATE DATABASE [Movies]

GO

USE [Movies]

GO
CREATE TABLE [Directors](
[Id] INT PRIMARY KEY NOT NULL,
[DirectorName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(200)
)

DROP TABLE [Directors]

CREATE TABLE [Directors](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[DirectorName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(200)
)

INSERT INTO [Directors]([DirectorName], [Notes])
VALUES
('Ivan Ivanov', NULL),
('Ivanov Ivan', NULL),
('Ivancho Ivanov', 'супер филм'),
('Pesho Ivanov', NULL),
('Gosho Ivanov', NULL)


CREATE TABLE [Genres](
[Id] INT PRIMARY KEY NOT NULL,
[GenreName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(200)
)

DROP TABLE [Genres]

CREATE TABLE [Genres](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[GenreName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(200)
)

INSERT INTO [Genres]([GenreName], [Notes])
VALUES
('Drama', NULL),
('Horor', NULL),
('Comedy', 'супер категория'),
('Psyho', NULL),
('Thriller', NULL)

CREATE TABLE [Categories](
[Id] INT PRIMARY KEY NOT NULL,
[CategoryName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(200)
)

DROP TABLE [Categories]

CREATE TABLE [Categories](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[CategoryName] NVARCHAR(50) NOT NULL,
[Notes] NVARCHAR(200)
)

INSERT INTO [Categories]([CategoryName], [Notes])
VALUES
('трета', NULL),
('втора', NULL),
('първа', 'най-добрата'),
('пета', NULL),
('четвърта', NULL)

CREATE TABLE [Movies](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[Title] NVARCHAR(50) NOT NULL,
[DirectorId] INT NOT NULL,
[CopyrightYear] INT NOT NULL,
[Length] INT ,
[GenreId] INT NOT NULL,
[CategoryId] INT NOT NULL,
[Rating] NVARCHAR(5) NOT NULL,
[Notes] NVARCHAR(200) 
)

ALTER TABLE [Movies]
ADD CONSTRAINT [FK_Movies_Directors_Id]
FOREIGN KEY([DirectorId]) REFERENCES [Directors]([Id])

ALTER TABLE [Movies]
ADD CONSTRAINT [FK_Movies_Genres_Id]
FOREIGN KEY([GenreId]) REFERENCES [Genres]([Id])

ALTER TABLE [Movies]
ADD CONSTRAINT [FK_Movies_Categories_Id]
FOREIGN KEY([CategoryId]) REFERENCES [Categories]([Id])


INSERT INTO [Movies]([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating], [Notes])
VALUES
('First Movie', 1, 1991, 121, 1, 1, '*', 'бележка 1'),
('Second Movie', 2, 1992, 122, 2, 2, '**', NULL),
('Third Movie', 3, 1993, 123, 3, 3, '***', 'бележка 3'),
('Fourth Movie', 4, 1994, 124, 4, 4, '****', 'бележка 4'),
('Fifth Movie', 5, 1995, NULL, 5, 5, '*****', 'бележка 5')


-- Problem 14
CREATE DATABASE [CarRental]

GO

USE [CarRental]

GO

CREATE TABLE [Categories](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[CategoryName] VARCHAR(20) NOT NULL,
[DailyRate] NVARCHAR(5),
[WeeklyRate] NVARCHAR(5),
[MonthlyRate] NVARCHAR(5),
[WeekendRate] NVARCHAR(5)
)

INSERT INTO [Categories]([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES
('Automobile', '***', NULL, NULL, NULL),
('PickUp', '****', NULL, '*', NULL),
('Truck', '**', NULL, NULL, '**')


CREATE TABLE [Cars](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[PlateNumber] CHAR(6) NOT NULL,
[Manufacturer] NVARCHAR(20),
[Model] NVARCHAR(20) NOT NULL,
[CarYear] INT NOT NULL,
[CategoryId] INT NOT NULL,
[Doors] INT NOT NULL,
[Picture] BINARY(2048),
[Condition] VARCHAR(50),
[Available] BIT NOT NULL
)

INSERT INTO [Cars]
VALUES
('A1234Z', NULL, 'Ford', 1999, 1, 5, NULL, 'Good', 1),
('B1234Y', NULL, 'BMW', 1989, 2, 5, NULL, 'Very Good', 1),
('C1234X', NULL, 'Opel', 1959, 3, 2, NULL, 'Not so Good', 0)

CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[FirstName] VARCHAR(20) NOT NULL,
[LasstName] VARCHAR(20) NOT NULL,
[Title] VARCHAR(20) NOT NULL,
[Notes] VARCHAR(50)
)

INSERT INTO [Employees]([FirstName], [LasstName], [Title], [Notes])
VALUES
('Ivan', 'Ivanov', 'Boss', NULL),
('Pesho', 'Ivanov', 'Security', NULL),
('Gosho', 'Ivanov', 'Receptionist', NULL)


CREATE TABLE [Customers](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[DriverLicenceNumber] CHAR(8) NOT NULL,
[FullName] VARCHAR(20) NOT NULL,
[Adress] VARCHAR(30) NOT NULL,
[City] VARCHAR(30) NOT NULL,
[ZIPCode] CHAR(4) NOT NULL,
[Notes] VARCHAR(100)
)

INSERT INTO [Customers]([DriverLicenceNumber], [FullName], [Adress], [City], [ZIPCode], [Notes])
VALUES
('12345678', ' Ivan Popov', 'Mir str. 67', 'Sofia', '1000', NULL),
('56781234', ' Krum Popov', 'Rosa str. 7', 'Sofia', '1000', NULL),
('12678345', ' Kiro Popov', 'Bor str. 6', 'Sofia', '1000', NULL)


CREATE TABLE [RentalOrders](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[EmployeeId] INT NOT NULL,
[CustomerId] INT NOT NULL,
[CarId] INT NOT NULL,
[TankLevel] INT NOT NULL,
[KilometrageStart] INT NOT NULL,
[KilometrageEnd] INT NOT NULL,
[TotalKilometrage] INT NOT NULL,
[StartDate] DATE NOT NULL,
[EndDate] DATE NOT NULL,
[TotalDays] INT NOT NULL,
[RateApplied] VARCHAR(5),
[TaxRate] VARCHAR(5),
[OrderStatus] BIT,
[Notes] VARCHAR(100)
)


ALTER TABLE [RentalOrders]
ADD CONSTRAINT [FK_EmployeeId_Employees_Id]
FOREIGN KEY([EmployeeId]) REFERENCES [Employees]([Id])

ALTER TABLE [RentalOrders]
ADD CONSTRAINT [FK_CustomerId_Customers_Id]
FOREIGN KEY([CustomerId]) REFERENCES [Customers]([Id])

ALTER TABLE [RentalOrders]
ADD CONSTRAINT [FK_CarId_Cars_Id]
FOREIGN KEY([CarId]) REFERENCES [Cars]([Id])

ALTER TABLE [Cars]
ADD CONSTRAINT [FK_CategoryId_Categories_Id]
FOREIGN KEY([CategoryId]) REFERENCES [Categories]([Id])


INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [TotalKilometrage], [StartDate], [EndDate], [TotalDays], [RateApplied], [TaxRate], [OrderStatus], [Notes])
VALUES
(1, 1,3 , 23, 100, 300, 300-100, '1999-10-09', '1999-10-11', 2, '*', '*', 1, NULL),
(2, 2, 2, 13, 200, 300, 300-200, '1999-10-09', '1999-10-11', 2, '**', '**', 1, NULL),
(3, 3, 1, 20, 400, 700, 300, '1999-11-09', '1999-11-11', 2, '***', '***', 0, NULL)


-- Problem 15		NOT COMPLETED !!!
CREATE DATABASE [Hotel]

GO

USE [Hotel]

GO

CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[FirstName] VARCHAR(20) NOT NULL,
[LastName] VARCHAR(20) NOT NULL,
[Title] VARCHAR(40) NOT NULL,
[Notes] VARCHAR(100)
)

INSERT INTO [Employees]([FirstName], [LastName], [Title], [Notes])
VALUES
('Gosho', 'Goshev', 'Manager', NULL),
('Pesho', 'Peshev', 'Picolo', NULL),
('Misho', 'Mishev', 'Receptionist', NULL)


CREATE TABLE [Customers](
[AccountNumber] INT PRIMARY KEY IDENTITY NOT NULL,
[FirstName] VARCHAR(20) NOT NULL,
[LastName] VARCHAR(20) NOT NULL,
[PhoneNumber] CHAR(8) NOT NULL,
[EmergencyName] VARCHAR(20) NOT NULL,
[EmergencyNumber] CHAR(8) NOT NULL,
[Notes] VARCHAR(100)
)

INSERT INTO [Customers]([FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber], [Notes])
VALUES
('A', 'B','12345678','Em', '87654321', NULL),
('C', 'D','12783456','Em', '87621543', NULL),
('AE', 'F','18234567','Em', '81765432', NULL)


CREATE TABLE [RoomStatus](
[RoomStatus] CHAR(30) NOT NULL,
[Notes] VARCHAR(100)
)

INSERT INTO [RoomStatus]([RoomStatus], [Notes])
VALUES
('Available', 'Good'),
('Available', NULL),
('Not Available', 'Exelent')


CREATE TABLE [RoomTypes](
[RoomType] CHAR(30) NOT NULL,
[Notes] VARCHAR(100)
)

INSERT INTO [RoomTypes]([RoomType], [Notes])
VALUES
('Two beds', 'Good'),
('Three beds', NULL),
('Apartament', 'Exelent')


CREATE TABLE [BedTypes](
[BedType] CHAR(30) NOT NULL,
[Notes] VARCHAR(100)
)

INSERT INTO [BedTypes]([BedType], [Notes])
VALUES
('Two Person', 'Good'),
('One Person', NULL),
('Three Person', 'Exelent')

CREATE TABLE [Rooms](
[RoomNumber] CHAR(3) NOT NULL,
[RoomType] CHAR(30) NOT NULL,
[BedType] CHAR(30) NOT NULL,
[Rate] NCHAR(5),
[RoomStatus] CHAR(30) NOT NULL,
[Notes] VARCHAR(100)
)


--ALTER TABLE [Rooms]
--ADD CONSTRAINT [FK_RoomType_RoomTypes_RoomType]
--FOREIGN KEY ([RoomType]) REFERENCES [RoomTypes]([RoomType])

--ALTER TABLE [Rooms]
--ADD CONSTRAINT [FK_BedType_BedTypes_BedType]
--FOREIGN KEY ([BedType]) REFERENCES [BedTypes]([BedType])

--ALTER TABLE [Rooms]
--ADD CONSTRAINT [FK_RoomStatus_RoomStatus_RoomStatus]
--FOREIGN KEY ([RoomStatus]) REFERENCES [RoomStatus]([RoomStatus])


INSERT INTO [Rooms]([RoomNumber], [RoomType], [BedType], [Rate], [RoomStatus], [Notes])
VALUES
(123, 'Two beds', 'Two Person', '*', 'Available', NULL),
(143, 'Two beds', 'Two Person', '*', 'Available', NULL),
(153, 'Two beds', 'Two Person', '*', 'Available', NULL)


-- Problem 16

CREATE DATABASE [SoftUni]

GO

USE [SoftUni]

GO

CREATE TABLE [Towns](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Addresses](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[AddressText] NVARCHAR(100) NOT NULL,
[TownId] INT FOREIGN KEY REFERENCES [Towns] ([Id])
)

CREATE TABLE [Departments](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY NOT NULL,
[FirstName] NVARCHAR(100) NOT NULL,
[MiddleName] NVARCHAR(100),
[LastName] NVARCHAR(100) NOT NULL,
[JobTitle] NVARCHAR(100) NOT NULL,
[DepartmentId] INT FOREIGN KEY REFERENCES [Departments] ([Id]) NOT NULL,
[HireDate] DATE DEFAULT (GETDATE()) NOT NULL,
[Salary] DECIMAL(18, 2) NOT NULL,
[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)



-- Problem 18
INSERT INTO [Towns]([Name])
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Departments] ([Name])
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')



INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary])
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03/02/2004',4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12/09/2007', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88)

-- Problem 19

SELECT *
FROM [Towns]

SELECT *
FROM [Departments]

SELECT *
FROM [Employees]

-- Problem 20

SELECT *
FROM [Towns]
ORDER BY [Name]

SELECT *
FROM [Departments]
ORDER BY [Name]

SELECT *
FROM [Employees]
ORDER BY [Salary] DESC


-- Problem 21

SELECT [Name]
FROM [Towns]
ORDER BY [Name]

SELECT [Name]
FROM [Departments]
ORDER BY [Name]

SELECT [FirstName], [LastName], [JobTitle], [Salary]
FROM [Employees]
ORDER BY [Salary] DESC


-- Problem 22

UPDATE [Employees]
SET [Salary] = [Salary] * 1.1   

SELECT [Salary]
FROM [Employees]

-- Problem 23 and 24    when complete Problem 15

USE Diablo

GO

SELECT * FROM Items WHERE MinLevel > 20;


