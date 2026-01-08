using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SoftUni;


public class StartUp
{
    public static void Main(string[] args)
    {

        using SoftUniContext softuniContext = new SoftUniContext();

        string result = RemoveTown(softuniContext);
        Console.WriteLine(result);
    }


    // Problem 3
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary,
            })
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
        }
        return sb.ToString().TrimEnd();

    }

    //Problem 4
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        var employees = context.Employees
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .Where(s => s.Salary > 50000)
            .OrderBy(e => e.FirstName);

        StringBuilder sb = new StringBuilder();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
        }
        return sb.ToString().TrimEnd();
    }


    // Problem 5
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var employees = context.Employees
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary,
                e.Department
            })
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToList();

        StringBuilder sb = new StringBuilder();
        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
        }
        return sb.ToString().TrimEnd();
    }


    // Problem 6
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {

        Address address = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        Employee employee = context.Employees
            .First(e => e.LastName == "Nakov");

        employee.Address = address;
        context.SaveChanges();

        string[] addresses = context.Employees.OrderByDescending(e => e.AddressId)
                  .Where(e => e.AddressId != null)
                  .Select(e => e.Address.AddressText)
                  .Take(10)
                  .ToArray();

        return String.Join(Environment.NewLine, addresses);
    }

    // Problem 7
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Select(e => new
            {
                EmployeeFirstName = e.FirstName,
                EmployeeLastName = e.LastName,
                ManagerFirsName = e.Manager.FirstName == null ? null : e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName == null ? null : e.Manager.LastName,
                Projects = e.EmployeesProjects
                    .Select(ep => ep.Project)
                    .Where(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003)
                    .Select(p => new
                    {
                        ProjectName = p.Name,
                        p.StartDate,
                        p.EndDate
                    })
                    .ToList()

            })
            .Take(10)
            .ToList();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - Manager: {e.ManagerFirsName} {e.ManagerLastName}");

            foreach (var p in e.Projects)
            {
                //string startDateFormated = p.StartDate.ToString("M/d/yyyy h:mm:ss tt");
                //string endDateFormated = p.EndDate.HasValue ? p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";


                sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {(p.EndDate == null ? "not finished" : p.EndDate)}");
                //sb.AppendLine($"--{p.ProjectName} - {startDateFormated} - {endDateFormated}");
            }
        }

        return sb.ToString().TrimEnd();

    }


    // Problem 8
    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var addresses = context.Addresses
            .Select(a => new
            {
                TownName = a.Town.Name == null ? null : a.Town.Name,
                EmployeesCount = a.Employees.Count,
                a.AddressText
            })
            .OrderByDescending(a => a.EmployeesCount)
            .ThenBy(a => a.TownName)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .ToList();

        foreach (var a in addresses)
        {
            sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 9
    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder sb = new();

        var employee = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                Id = e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                       .Select(ep => ep.Project.Name)
                       .OrderBy(projectName => projectName)
                       .ToList()
            })
            .FirstOrDefault();

        sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

        foreach (var p in employee.Projects)
        {
            sb.AppendLine(p);
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 10
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        StringBuilder sb = new();

        var departmentsToPrint = context.Departments
            .Where(d => d.Employees.Count > 5)
            .OrderBy(d => d.Employees.Count)
            .ThenBy(dn => dn)
            .Select(d => new
            {
                DepartmentName = d.Name,
                ManagerFirstName = d.Manager.FirstName,
                ManagerLastName = d.Manager.LastName,
                Employees = d.Employees
                    .Select(e => new
                    {
                        EmployeeFirstName = e.FirstName,
                        EmployeeLastName = e.LastName,
                        e.JobTitle
                    })
                    .OrderBy(e => e.EmployeeFirstName)
                    .ThenBy(e => e.EmployeeLastName)
                    .ToList()
            })
            .ToList();

        foreach (var d in departmentsToPrint)
        {
            sb.AppendLine($"{d.DepartmentName} – {d.ManagerFirstName} {d.ManagerLastName}");

            foreach (var e in d.Employees)
            {
                sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - {e.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    // Problem 11

    public static string GetLatestProjects(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        string dateFormat = "M/d/yyyy h:mm:ss tt";

        var projects = context.Projects
            .OrderBy(p => p.StartDate)

            .Select(pr => new
            {
                pr.Name,
                pr.Description,
                pr.StartDate,
            })
            .ToList()
            .TakeLast(10);
        projects = projects.OrderBy(p => p.Name);

        foreach (var project in projects)
        {
            sb.AppendLine(project.Name);
            sb.AppendLine(project.Description);
            sb.AppendLine(project.StartDate.ToString(dateFormat));
        }

        return sb.ToString().TrimEnd();
    }


    //Problem 12

    public static string IncreaseSalaries(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        string[] targetDepartments = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

        var employees = context.Employees
            .Where(e => targetDepartments.Contains(e.Department.Name))                  
            .ToList();

        foreach (var e in employees)
        {
            e.Salary *= 1.12m;
        }

        context.SaveChanges();

        var selectedEmployees = employees
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .Select(e => $"{e.FirstName} {e.LastName} (${e.Salary:F2})")
            .ToList();
      
         sb.AppendLine(string.Join(Environment.NewLine, selectedEmployees));
        
        return sb.ToString().TrimEnd();

    }


    // Problem 13

    public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            })
            .Where(e => EF.Functions.Like(e.FirstName, "Sa%"))           
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList();

        foreach ( var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
        }

        return sb.ToString().TrimEnd();
    }


    // Problem 14


    public static string DeleteProjectById(SoftUniContext context)
    {

        var employeeProject = context.EmployeesProjects
            .Where(ep => ep.ProjectId == 2)
            .ToList();

        context.EmployeesProjects.RemoveRange(employeeProject);
        
        Project project = context.Projects.Find(2);

        if (project != null)
        {
            context.Projects.Remove(project);
        }

        context.SaveChanges();

        string[] projectToPrint = context.Projects
            .Select(p => p.Name)
            .Take(10)
            .ToArray();

        return string.Join(Environment.NewLine, projectToPrint);
    }

    // Problem 15

    public static string RemoveTown(SoftUniContext context)
    {
       
        var addresses =  context.Addresses
            .Where(a => a.Town.Name == "Seattle")
            .ToList();

        int count = addresses.Count;

        context.Addresses.RemoveRange(addresses);

        Town townToRemove = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

        if (townToRemove != null)
        {
            context.Towns.Remove(townToRemove);
        }

        context.SaveChanges();

        return $"{count} addresses in Seattle were deleted";
    }
}