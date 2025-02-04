namespace _08._Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestList = new();

            SortedDictionary<string, Dictionary<string, int>> rancking = new();

            while (true)
            {
                string[] contests = Console.ReadLine().Split(':');
                string contestName = contests[0];

                if (contestName == "end of contests")
                {
                    break;
                }

                string password = contests[1];

                if (!contestList.ContainsKey(contestName))
                {
                    contestList.Add(contestName, password);
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split("=>");
                string contestName1 = input[0];

                if (contestName1 == "end of submissions")
                {
                    break;
                }
                string password1 = input[1];
                string studentName = input[2];
                int points = int.Parse(input[3]);

                if (contestList.ContainsKey(contestName1) && contestList.ContainsValue(password1))
                {
                    if (!rancking.ContainsKey(studentName))
                    {
                        rancking.Add(studentName, new Dictionary<string, int>());
                    }

                    if (!rancking[studentName].ContainsKey(contestName1))
                    {
                        rancking[studentName].Add(contestName1, 0);

                    }

                    if (rancking[studentName][contestName1] < points)
                    {
                        rancking[studentName][contestName1] = points;
                    }
                }
            }

            int maxPoints = 0;
            string bestStudent = String.Empty;
            int curSum = 0;

            foreach (var student in rancking)
            {
                foreach (var item in student.Value)
                {
                    curSum += item.Value;
                }


                if (maxPoints < curSum)
                {
                    maxPoints = curSum;
                    bestStudent = student.Key;
                    curSum = 0;
                }
                curSum = 0;
            }

            Console.WriteLine($"Best candidate is {bestStudent} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var student in rancking)
            {
                Console.WriteLine(student.Key);

                foreach (var item in student.Value.OrderByDescending(i => i.Value))
                {
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}