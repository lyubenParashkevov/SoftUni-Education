using System.Diagnostics.Metrics;

namespace _05._Shopping_Spree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] employeeInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = employeeInfo[0];
                double salary = double.Parse(employeeInfo[1]);
                string department = employeeInfo[2];

                Employee employee = new Employee(name, salary, department);
                employees.Add(employee);
            }

            double sum = 0;
            int counter = 0;
            double highestAverageSalary = 0;
            string bestDepartment = "";
            foreach (Employee employee in employees.Where(е => е.Department == ))
            {
                sum += employee.Salalry;
                counter++;
            }
            double curentAverageSalary = (double)sum / counter;
            if (curentAverageSalary > highestAverageSalary)
            {
                highestAverageSalary = curentAverageSalary;
                bestDepartment = employee.Department;
            }
            Console.WriteLine($"Highest Average Salary: {bestDepartment}");

        }
    }

    public class Employee
    {
        public Employee(string name, double salalry, string department)
        {
            this.Name = name;
            this.Salalry = salalry;
            this.Department = department;
        }

        public string Name { get; set; }
        public double Salalry { get; set; }
        public string Department { get; set; }

       // public void HighestAverageSalary(List<Employee> employees)
       // {
       //     double sum = 0;
       //     int counter = 0;
       //     double highestAverageSalary = 0;
       //     string bestDepartment = "";
       //     foreach (Employee employee in employees.Where(е => е.Department == this.Department))
       //     {
       //         sum += employee.Salalry;
       //         counter++;
       //     }
       //     double curentAverageSalary = (double)sum / counter;
       //     if (curentAverageSalary > highestAverageSalary)
       //     {
       //         highestAverageSalary = curentAverageSalary;
       //         bestDepartment = this.Department;
       //     }
       //     Console.WriteLine($"Highest Average Salary: {bestDepartment}");
       //
       // }
    }


}