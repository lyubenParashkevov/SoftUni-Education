using System.Security.Cryptography.X509Certificates;

namespace _01._Company_Roster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] employeeInfo = Console.ReadLine().Split(' ');
                string name = employeeInfo[0];
                double salary = double.Parse(employeeInfo[1]);
                string department = employeeInfo[2];

                Employee employee = new Employee(name, salary, department);
                employees.Add(employee);
            }

            double highestAverageSalary = 0;
            double sum = 0;
            int counter = 0;
            double averageSum = 0;
            string departmentWithHighestAverageSalary = "";
            for (int i = 0; i < employees.Count; i++)
            {
                for (int j = 0; j < employees.Count; j++)
                {
                    if (employees[i].Department == employees[j].Department)
                    {
                        sum += employees[j].Salary;
                        counter++;

                    }
                }
                averageSum = sum / counter;
                
                if (averageSum > highestAverageSalary)
                {
                    highestAverageSalary = averageSum;

                    departmentWithHighestAverageSalary = employees[i].Department;
                }
                sum = 0;
                counter = 0;
                averageSum = 0;
            }

            Console.WriteLine($"Highest Average Salary: {departmentWithHighestAverageSalary}");
            foreach ( Employee employee in employees.Where(e => e.Department == departmentWithHighestAverageSalary).OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }

        }
    }

    class Employee
    {
        public Employee(string name, double salary, string department)
        {
            this.Name = name;
            this.Salary = salary;
            this.Department = department;
        }
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

    }
}