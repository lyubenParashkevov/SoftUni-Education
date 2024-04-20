using System;

namespace _04._Train_The_Trainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gradeCount = 0;
            double assessment = 0;
            double gradeSum = 0;
            int jury = int.Parse(Console.ReadLine());
            while (true)
            {
                string presentation = Console.ReadLine();
                double grade = 0;
                
                
                
                double presentationAssessment = 0;
                if (presentation == "Finish")
                {
                    Console.WriteLine($"Student's final assessment is {assessment:f2}.");
                    break;
                }
               
                double presentationGradeSum = 0;
                double presGradeCount = 0;
                while (true) 
                {
                    grade = double.Parse(Console.ReadLine());
                    presentationGradeSum += grade;
                    gradeCount++;
                    presGradeCount++;   
                    presentationAssessment = presentationGradeSum / jury;
                    if (presGradeCount == jury)
                    {
                        Console.WriteLine($"{presentation} - {presentationAssessment:f2}.");
                        break;
                    }
                }
                gradeSum += presentationGradeSum;
                
                assessment = gradeSum / gradeCount;
            
            }
                 


        }
           
    }
}
