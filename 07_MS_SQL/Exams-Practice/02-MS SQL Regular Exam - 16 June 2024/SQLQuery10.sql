

CREATE DATABASE LibraryDb;
GO

USE LibraryDb;
GO

CREATE TABLE Contacts (
    Id INT IDENTITY PRIMARY KEY,
    Email NVARCHAR(100) NULL,
    PhoneNumber NVARCHAR(20) NULL,
    PostAddress NVARCHAR(200) NULL,
    Website NVARCHAR(50) NULL
);

CREATE TABLE Authors (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    ContactId INT NOT NULL,
    FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
);

CREATE TABLE Genres (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL
);

CREATE TABLE Books (
    Id INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    YearPublished INT NOT NULL,
    ISBN NVARCHAR(13) UNIQUE NOT NULL,
    AuthorId INT NOT NULL,
    GenreId INT NOT NULL,
    FOREIGN KEY (AuthorId) REFERENCES Authors(Id),
    FOREIGN KEY (GenreId) REFERENCES Genres(Id)
);

CREATE TABLE Libraries (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    ContactId INT NOT NULL,
    FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
);

CREATE TABLE LibrariesBooks (
    LibraryId INT NOT NULL,
    BookId INT NOT NULL,
    PRIMARY KEY (LibraryId, BookId),
    FOREIGN KEY (LibraryId) REFERENCES Libraries(Id),
    FOREIGN KEY (BookId) REFERENCES Books(Id)
);


--2 --

INSERT INTO Contacts (Email, PhoneNumber, PostAddress, Website) VALUES
(NULL, NULL, NULL, NULL),
(NULL, NULL, NULL, NULL),
('stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
('suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com');

INSERT INTO Authors (Name, ContactId) VALUES
('George Orwell', 21),
('Aldous Huxley', 22),
('Stephen King', 23),
('Suzanne Collins', 24);

INSERT INTO Books (Title, YearPublished, ISBN, AuthorId, GenreId) VALUES
('1984', 1949, '9780451524935', 16, 2),
('Animal Farm', 1945, '9780451526342', 16, 2),
('Brave New World', 1932, '9780060850524', 17, 2),
('The Doors of Perception', 1954, '9780060850531', 17, 2),
('The Shining', 1977, '9780307743657', 18, 9),
('It', 1986, '9781501142970', 18, 9),
('The Hunger Games', 2008, '9780439023481', 19, 7),
('Catching Fire', 2009, '9780439023498', 19, 7),
('Mockingjay', 2010, '9780439023511', 19, 7);

INSERT INTO LibrariesBooks (LibraryId, BookId) VALUES
(1, 36),
(1, 37),
(2, 38),
(2, 39),
(3, 40),
(3, 41),
(4, 42),
(4, 43),
(5, 44);

--3--

UPDATE Contacts
SET Website = 'www.' + LOWER(REPLACE(a.Name, ' ', '')) + '.com'
FROM Contacts c
JOIN Authors a ON c.Id = a.ContactId
WHERE c.Website IS NULL;

--4--

DELETE FROM LibrariesBooks WHERE BookId IN (SELECT Id FROM Books WHERE AuthorId = (SELECT Id FROM Authors WHERE Name = 'Alex Michaelides'));
DELETE FROM Books WHERE AuthorId = (SELECT Id FROM Authors WHERE Name = 'Alex Michaelides');
DELETE FROM Authors WHERE Name = 'Alex Michaelides';







--5--

SELECT 
	Title AS BookTitle,
	ISBN,
	YearPublished AS YearReleased

FROM Books
ORDER BY YearReleased DESC , BookTitle


-- 6--

SELECT 
	b.Id,
	Title,
	ISBN,
	g.[Name] AS Genre
	
FROM Books AS b
JOIN Genres AS g ON b.GenreId =  g.Id
WHERE g.[Name] IN ('Biography', 'Historical Fiction')
ORDER BY Genre, Title;


-- 7 --


SELECT 
    l.[Name] AS [Library],
    c.Email
FROM Libraries AS l
JOIN Contacts AS c ON l.ContactId = c.Id
WHERE NOT EXISTS (
    SELECT 1
    FROM LibrariesBooks AS lb
    JOIN Books AS b ON lb.BookId = b.Id
    WHERE lb.LibraryId = l.Id
    AND b.GenreId = 1
)
ORDER BY l.[Name] ASC;

-- 8 -- 

SELECT TOP 3
    b.Title,
    b.YearPublished AS [Year],
    g.[Name] AS Genre
FROM Books AS b
JOIN Genres AS g ON b.GenreId = g.Id
WHERE 
    (b.YearPublished > 2000 AND b.Title LIKE '%a%') 
    OR 
    (b.YearPublished < 1950 AND g.Name LIKE '%Fantasy%')
ORDER BY 
    b.Title ASC, 
    b.YearPublished DESC


	--9--

	SELECT 
    a.[Name] AS Author,
    c.Email,
    c.PostAddress AS Address
FROM Contacts AS c
JOIN Authors AS a ON c.Id = a.ContactId
WHERE c.PostAddress LIKE '%UK%'
ORDER BY a.[Name] ASC;

-- 10--

SELECT 
    a.[Name] AS Author,
    b.Title,
    l.Name AS Library,
    c.PostAddress AS LibraryAddress
FROM Books AS b
JOIN Authors AS a ON b.AuthorId = a.Id
JOIN LibrariesBooks AS lb ON b.Id = lb.BookId
JOIN Libraries AS l ON lb.LibraryId = l.Id
JOIN Contacts AS c ON l.ContactId = c.Id
JOIN Genres AS g ON b.GenreId = g.Id
WHERE g.[Name] = 'Fiction'
  AND c.PostAddress LIKE '%Denver%'
ORDER BY b.Title ASC;


GO
--11--


CREATE FUNCTION udf_AuthorsWithBooks(@name VARCHAR(255))
RETURNS INT
AS
BEGIN
    DECLARE @bookCount INT;
    
    -- Calculate the total number of books by the given author in all libraries
    SELECT @bookCount = COUNT(DISTINCT lb.BookId)
    FROM Books AS b
    JOIN Authors AS a ON b.AuthorId = a.Id
    JOIN LibrariesBooks AS lb ON b.Id = lb.BookId
    WHERE a.[Name] = @name;
    
    -- Return the count of books
    RETURN @bookCount;
END;

SELECT dbo.udf_AuthorsWithBooks('J.K. Rowling') AS TotalBooks;

   -- 12 -- 

   CREATE PROCEDURE usp_SearchByGenre
    @genreName VARCHAR(255)
AS
BEGIN
    -- Select book information for a given genre
    SELECT 
        b.Title,
        b.YearPublished,
        b.ISBN,
        a.[Name] AS Author,
        g.[Name] AS Genre
    FROM Books AS b
    JOIN Authors AS a ON b.AuthorId = a.Id
    JOIN Genres AS g ON b.GenreId = g.Id
    WHERE g.Name = @genreName
    ORDER BY b.Title ASC;
END;