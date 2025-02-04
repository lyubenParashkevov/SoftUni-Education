using System;

namespace _04._Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numStudents = int.Parse(Console.ReadLine());
            double allGradesSum = 0;
            double lowGrades = 0;
            double midGrades = 0;
            double googGrades = 0;
            double excelentGrades = 0;
            int gradeCount = 0; 
            while (true)
            {
                if (numStudents == gradeCount)
                {
                    break;
                }
                double grade = double.Parse(Console.ReadLine());
                allGradesSum += grade; 
                if (grade <= 2.99)
                {
                    lowGrades++;
                }
                else if (grade <= 3.99)
                {
                    midGrades++;
                }
                else if (grade <= 4.99)
                {
                    googGrades++;
                }
                else if (grade >= 5)
                {
                    excelentGrades++;
                }
                gradeCount++;
                
            }
            Console.WriteLine($"Top students: {excelentGrades / gradeCount * 100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {googGrades / gradeCount * 100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {midGrades / gradeCount * 100:f2}%");
            Console.WriteLine($"Fail: {lowGrades / gradeCount * 100:f2}%");
            Console.WriteLine($"Average: {allGradesSum / gradeCount:f2}");
        }
    }
}
