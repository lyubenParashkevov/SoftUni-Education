using System;

namespace _08._Graduation._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int grade = 1;

            double averageMark = 0;
            int badMark = 0;
            double marksSum = 0;
            while (grade <= 12)
            {
                double currMark = double.Parse(Console.ReadLine());
                marksSum += currMark;
                if (currMark < 4)
                {
                    badMark += 1;

                    if (badMark == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {grade} grade");
                        return;
                    }
                }
                else
                {
                    grade++;
                    
                 
                }
                
            }
                
            averageMark = marksSum / 12;
            Console.WriteLine($"{name} graduated. Average grade: {averageMark:f2}");

        }

    }
}




