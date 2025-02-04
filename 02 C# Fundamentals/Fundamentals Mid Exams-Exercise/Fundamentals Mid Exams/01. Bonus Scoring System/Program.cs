namespace _01._Bonus_Scoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int studentsNumber = int.Parse(Console.ReadLine());
            int lecturesNumber = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());
            int maxBonus = int.MinValue;
            for (int i = 0; i < studentsNumber; i++)
            {
                int attedndance = int.Parse(Console.ReadLine());
                if (attedndance > maxBonus)
                {
                    maxBonus = attedndance;
                }
            }
            double studentAttendance = (double)maxBonus / lecturesNumber * (5 + additionalBonus);
            
            Console.WriteLine($"Max Bonus: {Math.Ceiling(studentAttendance)}.");
            Console.WriteLine($"The student has attended {maxBonus} lectures.");
        }
    }
}