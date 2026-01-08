
-- Problem 1  	One-To-One Relationship

USE MyFirstDB

GO

CREATE TABLE Persons(
PersonID INT PRIMARY KEY IDENTITY NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
Salary DECIMAL NOT NULL,
PassportID INT NOT NULL
);

CREATE TABLE Passports(
PassportID INT PRIMARY KEY NOT NULL,
PassportNumber NCHAR(8) NOT NULL
);

ALTER TABLE Passports
ADD CONSTRAINT UQ_Passports_PassportNumber UNIQUE (PassportNumber);

ALTER TABLE Persons
ADD CONSTRAINT UQ_Persons_PassporId UNIQUE (PassportId);

SELECT * FROM Persons
SELECT * FROM Passports


INSERT INTO Persons(FirstName, Salary, PassportID)
VALUES
	('Roberto', 43300.00, 102),
	('Tom',	56100.00, 103),
	('Yana', 60200.00, 101);

INSERT INTO Passports(PassportId, PassportNumber)
VALUES
	(101, 'N34FG21B'),
	(102, 'K65LO4R7'),
	(103, 'ZE657QP2');


ALTER TABLE Persons
ADD CONSTRAINT FK_Persons_Passports
FOREIGN KEY (PassportID) REFERENCES Passports (PassportId);

SELECT FirstName, Passports.PassportNumber
FROM Persons AS p
JOIN Passports  ON
Passports.PassportID = p.PassportID

--Problem 2  One-To-Many Relationship


CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY ,
[Name] NVARCHAR(50) NOT NULL,
EstablishedOn DATETIME NOT NULL
);


CREATE TABLE Models(
ModelID INT PRIMARY KEY,
[Name] VARCHAR(50) NOT NULL,
ManufacturerID INT FOREIGN KEY REFERENCES Manufacturers(ManufacturerID) NOT NULL
);

INSERT INTO Manufacturers ([Name], EstablishedOn)
VALUES
	('BMW',	'07/03/1916'),
	('Tesla',	'01/01/2003'),
	('Lada',	'01/05/1966');

INSERT INTO Models --No need to write (ModelID, [Name], ManufacturerID) when they are  
VALUES
	(101, 'X1',	1),
	(102, 'i6',	1),
	(103, 'Model S', 2),
	(104, 'Model X', 2),
	(105, 'Model 3', 2),
	(106, 'Nova', 3);


	SELECT *
	FROM Manufacturers AS man
	JOIN Models AS m ON m.ManufacturerID = man.ManufacturerID

	-- Problem 3 Many-To-Many Relationship

	CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL
	);

	CREATE TABLE Exams(
	ExamID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL
	);

	CREATE TABLE StudentsExams(
	StudentID INT NOT NULL,
	ExamID INT NOT NULL,
	CONSTRAINT PK_Exams_Students
	PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_StudentId_Students_StudentId
	FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
	CONSTRAINT FK_ExamId_Exams_ExamId
	FOREIGN KEY(ExamID) REFERENCES Exams(ExamID)
	);

	INSERT INTO Students(Name)
	VALUES
		('Mila'),                                      
		('Toni'),
		('Ron');

	INSERT INTO Exams
	VALUES
	    (101, 'SpringMVC'),
		(102, 'Neo4j'),
		(103, 'Oracle 11g')

	INSERT INTO StudentsExams
	VALUES
		(1,	101),
		(1,	102),
		(2,	101),
		(3,	103),
		(2,	102),
		(2,	103);

	SELECT * FROM StudentsExams AS s
	JOIN Exams AS e ON s.ExamID = e.ExamID
	JOIN Students AS st ON s.StudentID = st.StudentID

	-- Problem 4 Self-Referencing
	

	CREATE TABLE Teachers(
	TeacherID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(30) NOT NULL,
	ManagerID INT NULL
    CONSTRAINT FK_TeacherID_ManagerID
	FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)
	);

	INSERT INTO Teachers
	VALUES
		(101, 'John', NULL),
		(102, 'Maya', 106),
		(103, 'Silvia', 106),
		(104, 'Ted', 105),
		(105, 'Mark', 101),
		(106, 'Greta', 101);

	-- Problem 5  Online Store Database
	
	CREATE DATABASE Store;

	--DROP TABLE Cities

	CREATE TABLE Cities(
	CityID INT PRIMARY KEY,           --1
	[Name] VARCHAR(100) NOT NULL
	);
	
	--DROP TABLE Customers

	CREATE TABLE Customers(
	CustomerID INT PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,                    --2
	Birthday DATETIME,
	CityID INT FOREIGN KEY REFERENCES Cities(CityID)
	);

	--DROP TABLE Orders

	CREATE TABLE Orders(
	OrderID INT PRIMARY KEY NOT NULL,
	CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID)  --3
	);

	--DROP TABLE ItemTypes

	CREATE TABLE ItemTypes(
	ItemTypeID INT PRIMARY KEY NOT NULL,  --4
	[Name] VARCHAR(100) NOT NULL	
	);

	--DROP TABLE Items

	CREATE TABLE Items(
	ItemID INT PRIMARY KEY NOT NULL,
	[Name] VARCHAR(100) NOT NULL,           --5
	ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID)NOT NULL
	);

	--DROP TABLE OrderItems

	CREATE TABLE OrderItems(
	OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL,
	ItemID INT FOREIGN KEY REFERENCES Items(ItemID) NOT NULL,
	CONSTRAINT PK_OrderItems PRIMARY KEY(OrderID, ItemID)
	);

	-- Problem 6 University Database

	CREATE DATABASE University

	GO

	CREATE TABLE Subjects(
	SubjectID INT PRIMARY KEY,
	SubjectName VARCHAR(100) NOT NULL
	);

	CREATE TABLE Majors(
	MajorID INT PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL
	);

	CREATE TABLE Students(
	StudentID INT PRIMARY KEY,
	StudentNumber INT NOT NULL,
	StudentName VARCHAR(100) NOT NULL,
	MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
	);

	CREATE TABLE Payments(
	PayentID INT PRIMARY KEY,
	PaymentDate DATETIME NOT NULL,
	PaymentAmount INT NOT NULL,
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
	);

	CREATE TABLE Agenda(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID),
	CONSTRAINT PK_Agenda PRIMARY KEY(StudentID, SubjectID)
	);

	--Problem 9 * Peaks in Rila
	USE Geography

	GO
	
	SELECT MountainRange, PeakName, Elevation  

	FROM Peaks AS p
	JOIN Mountains AS m ON m.Id =p.MountainId
	WHERE MountainId = 17 ORDER BY(Elevation) DESC


	