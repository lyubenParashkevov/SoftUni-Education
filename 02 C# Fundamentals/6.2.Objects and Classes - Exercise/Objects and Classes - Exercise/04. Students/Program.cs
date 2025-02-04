using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();

            int studentsNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < studentsNumber; i++)
            {
                string[] studentInformation = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string firstName = studentInformation[0];
                string lastName = studentInformation[1];
                double grade = double.Parse(studentInformation[2]);

                Student student = new Student(firstName, lastName, grade);
                list.Add(student);
            }
            foreach (Student student in list.OrderByDescending(student => student.Grade))
            {
                Console.WriteLine(student.ToString());
            }
            


        }

        public class Student
        {
            public Student(string firstName, string lastName, double grade)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Grade = grade;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }

            public override string ToString()
            {
                return $"{FirstName} {LastName}: {Grade:f2}";
            }
        }
    }
}