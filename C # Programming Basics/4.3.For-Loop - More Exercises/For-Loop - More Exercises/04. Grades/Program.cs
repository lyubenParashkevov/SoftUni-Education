using System;

namespace _04._Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double sum = 0;
            int failedCount = 0;
            int midCount = 0;
            int goodCount = 0;
            int topCount = 0;
            int gradeCount = 0;
            int studNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < studNum; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                switch (grade)
                {
                    case < 3:
                        failedCount++;
                        sum += grade;
                        gradeCount++;
                        break;

                    case < 4:
                        midCount++;
                        sum += grade;
                        gradeCount++;
                        break;
                    case < 5:
                        goodCount++;
                        sum += grade;
                        gradeCount++;
                        break;

                    default:
                        topCount++;
                        sum += grade;
                        gradeCount++;
                        break;
                }
            }
            Console.WriteLine($"Top students: {(double)topCount / studNum * 100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(double)goodCount / studNum * 100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(double)midCount / studNum * 100:f2}%");
            Console.WriteLine($"Fail: {(double)failedCount / studNum * 100:f2}%");
            Console.WriteLine($"Average: {sum / studNum:f2}");
        }
    }
}
