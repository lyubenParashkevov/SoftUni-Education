

using AcademicRecordsApp.Data;

AcademicRecordsDBContext dbContext = new AcademicRecordsDBContext();

string[] students = dbContext
        .Students
        .Select(s => s.FullName)
        .ToArray();

Console.WriteLine(String.Join(Environment.NewLine, students));