
using SoftUni.Data;
using SoftUni.Models;
using System.Text;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext softUniContext = new SoftUniContext();
        //Console.WriteLine(GetEmployeesFullInformation(softUniContext));
        //Console.WriteLine(GetEmployeesWithSalaryOver50000(softUniContext));
        //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(softUniContext));
        //Console.WriteLine(AddNewAddressToEmployee(softUniContext));
        Console.WriteLine(GetEmployeesInPeriod(softUniContext));



    }

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
                e.Salary
            })
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
        }

        return sb.ToString().Trim();
    }

    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .ToList();

        StringBuilder sb = new();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
        }

        return sb.ToString().Trim();
    }


    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        var employees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .Select(e => new 
            {
                e.FirstName,
                e.LastName,
                e.Department,
                e.Salary
            })
            .ToList();

        StringBuilder sb = new StringBuilder();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
        }

        return sb.ToString().Trim();
    }

    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        Address address = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        var employee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov");

        if (employee != null)
        {
            employee.Address = address;
            context.SaveChanges();
        }

        string[] addresses = context.Employees
            .OrderByDescending(x => x.AddressId)
            .Where(x => x.AddressId != null)
            .Select(x => x.Address.AddressText)
            .Take(10)
            .ToArray();

        return String.Join(Environment.NewLine, addresses);
    }

    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        var employees = context.Employees
           .Select( e => new
           {
               EmployeeFirstName = e.FirstName,
               EmployeeLastName = e.LastName,
               ManagerFirstName = e.Manager.FirstName,
               ManagerLastName = e.Manager.LastName,
               Projects = e.Projects
               .Where(p => p.StartDate.Year >= 2001 &&  p.StartDate.Year <= 2003)
               .Select(p => new
               {
                   ProjectName = p.Name,
                   ProjectStartDate = p.StartDate,
                   ProjectEndDate = p.EndDate,
               })
               .ToList()
           })
           .Take(10)
           .ToList();

        StringBuilder sb = new StringBuilder();

        foreach ( var e in employees )
        {
            sb.AppendLine($"{e.EmployeeFirstName} {e.EmployeeLastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
            
            foreach ( var p in e.Projects)
            {
                sb.AppendLine($"--{p.ProjectName} - {p.ProjectStartDate} - {(p.ProjectEndDate == null ? "not finished" : p.ProjectEndDate)}");
            }
        }

        return sb.ToString().Trim();
            
    }

    
}