

-- 01. Employees with Salary Above 35000

CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
	SELECT 
		FirstName,
		LastName
		
	FROM Employees
	WHERE Salary > 35000

EXEC usp_GetEmployeesSalaryAbove35000

GO
-- 02. Employees with Salary Above Number

CREATE OR ALTER PROC usp_GetEmployeesSalaryAboveNumber (@Number DECIMAL(18,4))
AS 
	
	SELECT
		FirstName AS [First Name],
		LastName As [Last Name]
	FROM Employees
	WHERE Salary >= @Number;

--EXEC usp_GetEmployeesSalaryAboveNumber 48100

GO

-- 03. Town Names Starting With

CREATE OR ALTER PROC usp_GetTownsStartingWith (@TownName VARCHAR(50))
AS
	SELECT 
		[Name]
	FROM Towns
	WHERE [Name] LIKE @TownName + '%'

--EXEC usp_GetTownsStartingWith 'b'

GO

-- 04. Employees from Town

CREATE OR ALTER PROC usp_GetEmployeesFromTown ( @TownName VARCHAR(50))
AS
	SELECT 
		FirstName AS [First Name],
		LastName AS [Last Name]

	FROM Employees AS e 
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	WHERE t.[Name] = @TownName

--EXEC usp_GetEmployeesFromTown 'Sofia'

GO

-- 05. Salary Level Function

CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(20)
AS
BEGIN
	DECLARE @salaryLevel VARCHAR(20);
	IF @salary < 30000 SET @salaryLevel = 'Low';

	ELSE IF @salary <= 50000 SET @salaryLevel = 'Average';

	ELSE SET @salaryLevel = 'High';
	RETURN @salaryLevel
  END

GO

SELECT 
	Salary,
	dbo.ufn_GetSalaryLevel(Salary) AS salaryLevel

FROM SoftUni.dbo.Employees;

GO

--06. Employees by Salary Level

CREATE OR ALTER PROC usp_EmployeesBySalaryLevel (@Level VARCHAR(20))
AS
	SELECT
		FirstName AS [First Name],
		LastName AS [Last Name]

	FROM Employees
	WHERE @Level = dbo.ufn_GetSalaryLevel(Salary);

--EXEC usp_EmployeesBySalaryLevel 'High'

GO

-- 07. Define Function           ??????

CREATE OR ALTER FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50))
RETURNS BIT
AS
BEGIN
 DECLARE @i INT = 1;
    DECLARE @char CHAR(1);

    WHILE @i <= LEN(@word)
    BEGIN
        SET @char = SUBSTRING(@word, @i, 1);
        
        -- If the letter is not in @setOfLetters, return false
        IF CHARINDEX(@char, @setOfLetters) = 0
            RETURN 0;

        -- Remove the used letter from @setOfLetters to handle duplicates correctly
        SET @setOfLetters = STUFF(@setOfLetters, CHARINDEX(@char, @setOfLetters), 1, '');
        
        SET @i = @i + 1;
       END	   
    RETURN 1;

END;

GO

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia') AS Result;

GO
