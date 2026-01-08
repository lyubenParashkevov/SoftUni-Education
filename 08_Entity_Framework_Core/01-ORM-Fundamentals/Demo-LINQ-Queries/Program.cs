


using Demo_LINQ_Queries;
using Microsoft.EntityFrameworkCore;

using SoftUniContext softUniContext = new SoftUniContext();

var employees = softUniContext.Employees.Where(e => e.DepartmentId == 3);

var employees2 = softUniContext.Employees.Where(e => EF.Functions.Like(e.FirstName, "A%")).ToList();

foreach (var employee in employees2)
{
    Console.WriteLine(employee.FirstName);
}