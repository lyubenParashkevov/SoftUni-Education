using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();   

            while (true)
            {
                string[] studentInfo = Console.ReadLine().Split(' ');

                if (studentInfo[0] == "end")
                {
                    break;
                }
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                string age = studentInfo[2];
                string homeTown = studentInfo[3];

                Student student = new Student(firstName, lastName, age, homeTown);
                students.Add(student);
            }

            string town = Console.ReadLine();

            foreach (Student student in students.Where(x => x.HomeTown == town))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }

        }

        class Student
        {
            public Student()
            {

            }
            public Student(string firstName, string lastName, string age, string homeTown)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Age = age;
                this.HomeTown = homeTown;
            }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Age { get; set;}
            public string HomeTown { get; set; }

        }

    }
}