
using System.Collections.Generic;
using System.Diagnostics;

int n = int.Parse(Console.ReadLine());

List<Student> students = new List<Student>();

for (int i = 0; i < n; i++)
{
    string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string name = tokens[0];
    string lastName = tokens[1];
    double grade = double.Parse(tokens[2]);
    Student student = new(name, lastName, grade);
    students.Add(student);
         
}

foreach (Student student in students.OrderByDescending(x => x.Grade))
{
    Console.WriteLine($"{student.Name} {student.LastName} {student.Grade:f2}");
}





public class Student
{
    public Student(string name, string lastName, double grade)
    {
        Name = name;
        LastName = lastName;
        Grade = grade;
    }
    public string Name { get; set; }
    public string LastName { get; set; }
    public double Grade { get; set; }
}