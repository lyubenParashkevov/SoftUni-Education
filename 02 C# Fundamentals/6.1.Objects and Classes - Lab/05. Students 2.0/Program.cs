using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Students_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            while (true)
            {

                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] studentsProperties = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = studentsProperties[0];
                string lastName = studentsProperties[1];
                int age = int.Parse(studentsProperties[2]);
                string homeTown = studentsProperties[3];

                bool studentExist = false;

                foreach (var student in students)
                {
                    if (student.FirstName == firstName && student.LastName == lastName)
                    {
                        student.Age = age;
                        student.HomeTown = homeTown;
                        studentExist = true;
                        break;
                    }
                }

                

                if (!studentExist)
                {
                    Student student = new Student
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        HomeTown = homeTown
                    };

                    students.Add(student);
                }
                

                //Student student = new Student(studentsProperties[0], studentsProperties[1], int.Parse(studentsProperties[2]), studentsProperties[3]);

                //students.Add(student);
            }

            string town = Console.ReadLine();

            foreach (Student student in students)
            {
                if (town == student.HomeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }


        }

        public class Student
        {
           // public Student(string firstName, string lastName, int age, string homeTown)
           // {
           //     this.FirstName = firstName;
           //     this.LastName = lastName;
           //     this.Age = age;
           //     this.HomeTown = homeTown;
           // }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string HomeTown { get; set; }
        }
    }
}