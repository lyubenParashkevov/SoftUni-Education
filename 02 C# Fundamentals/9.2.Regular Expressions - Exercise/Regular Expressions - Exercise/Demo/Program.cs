using System.Text.RegularExpressions;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string name = string.Empty;
            string distanceAsString = string.Empty;
            int sum = 0;
            Dictionary<string, int> participantsInfo = new Dictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of race")
                {
                    break;
                }

                string namePatern = "[A-Za-z]";
                string distance = "[0-9]";

                Regex regex = new Regex(namePatern);
                Regex regex1 = new Regex(distance);

                MatchCollection matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    name += match;
                }

                MatchCollection matches1 = regex1.Matches(input);
                foreach (Match match in matches1)
                {
                    distanceAsString += match;
                }
                char[] chars = distanceAsString.ToArray();

                for (int i = 0; i < chars.Length; i++)
                {
                    int curNum = (int)chars[i] - '0';
                    sum += curNum;
                }
                if (names.Contains(name))
                {
                    if (!participantsInfo.ContainsKey(name))
                    {
                        participantsInfo.Add(name, 0);
                    }
                    participantsInfo[name] += sum;
                }
                name = string.Empty;
                distanceAsString = string.Empty;
                sum = 0;
            }
            var finalists = participantsInfo.OrderByDescending(Values => Values.Value).ToList();

            for (int i = 0; i < finalists.Count; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine($"1st place: {finalists[i].Key}");
                }
                else if (i == 1)
                {
                    Console.WriteLine($"2nd place: {finalists[i].Key}");
                }
                else if (i == 2)
                {
                    Console.WriteLine($"3rd place: {finalists[i].Key}");
                }
            }
        }
    }
}