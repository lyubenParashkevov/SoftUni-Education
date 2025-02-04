namespace _06._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> studentAverageGrade = new Dictionary<string, List<double>>();
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!studentAverageGrade.ContainsKey(studentName))
                {
                    studentAverageGrade.Add(studentName, new List<double>());
                }
                studentAverageGrade[studentName].Add(grade);
            }
            double sum = 0;
            foreach (var student in studentAverageGrade)
            {
                for (int i = 0; i < student.Value.Count; i++)
                {
                    sum += student.Value[i];
                    double averageSum = sum / student.Value.Count;
                    if (averageSum >= 4.50)
                    {
                        Console.WriteLine($"{student.Key} -> {averageSum:f2}");
                    }
                }                
                sum = 0;
            }
        }
    }
}