namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submitions = new ();

            SortedDictionary<string, int> studentsAndPoints = new ();

            while (true)
            {

                string[] input = Console.ReadLine().Split('-');
                string studentName = input[0];
                if (studentName == "exam finished")
                {
                    break;
                }

                string language = input[1];
                
                if (!studentsAndPoints.ContainsKey(studentName))
                {
                    studentsAndPoints.Add(studentName, 0);
                }

                if (language == "banned")
                {
                    studentsAndPoints.Remove(studentName);
                    continue;
                }

                int points = int.Parse(input[2]);

                if (studentsAndPoints[studentName] < points)
                {
                    studentsAndPoints[studentName] = points;
                }
              
                if (!submitions.ContainsKey(language))
                {
                    submitions.Add(language, 0);
                }

                submitions[language]++;                    
            }

            Console.WriteLine("Results:");
        
            foreach (var student in studentsAndPoints.OrderByDescending(s => s.Value))
            {            
                    Console.WriteLine($"{student.Key} | {student.Value}");              
            }

            Console.WriteLine("Submissions:");

            foreach (var Item in submitions.OrderByDescending(i => i.Value).ThenBy(i => i.Key))
            {
                Console.WriteLine($"{Item.Key} - {Item.Value}");
            }
        }
    }
}