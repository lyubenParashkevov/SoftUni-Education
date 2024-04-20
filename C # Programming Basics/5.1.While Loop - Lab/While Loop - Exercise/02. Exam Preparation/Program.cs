using System;

namespace _02._Exam_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countBadMarks = int.Parse(Console.ReadLine());
            
            
            int badMarksSum = 0;
            int numProblems = 0;
            string lastProblem = String.Empty;
            double gradeSum = 0;
            bool isFailed = true;
            
            while (badMarksSum < countBadMarks)
            {
                string problem = Console.ReadLine();
                if("Enough" == problem)
                {
                    isFailed = false;
                    break;
                }
                int grade = int.Parse(Console.ReadLine());
                if (grade <= 4)
                {
                    badMarksSum++;
                }
                gradeSum += grade;
                numProblems++;
                lastProblem = problem;
            }
            if (isFailed)
            {
                Console.WriteLine($"You need a break, {badMarksSum} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {gradeSum / numProblems:f2}");
                Console.WriteLine($"Number of problems: {numProblems}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
