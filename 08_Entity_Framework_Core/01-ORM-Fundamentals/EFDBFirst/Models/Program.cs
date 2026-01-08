
using EFDBFirst.Data;
using EFDBFirst.Models;

SoftUniContext softUniContext = new SoftUniContext();

List<Employee> employees = softUniContext.Employees.ToList();


Employee employee = new Employee() {FirstName = "Pesho", DepartmentId = 3 };

await softUniContext.Projects.AddAsync(new Project() 
{ Name = "NewProjectName",
StartDate = DateTime.Now
});


Project project = new Project();
var employees2 = softUniContext.Employees.
    Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name
                }).ToList();

foreach (var e in employees2)
{
    Console.WriteLine($"{e.FirstName} {e.LastName} - {e.DepartmentName}");
}