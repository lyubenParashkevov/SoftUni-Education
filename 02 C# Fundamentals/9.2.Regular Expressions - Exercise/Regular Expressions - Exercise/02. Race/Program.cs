using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Dictionary<string, int> namesAndDistance = new Dictionary<string, int>();

            foreach (string name in names)
            {
                namesAndDistance.Add(name, 0);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of race")
                {
                    break;
                }

                string namePatern = @"(?<name>[A-Za-z])";
                string numsPatern = @"(?<nums>[0-9])";
                Regex nameRegex = new Regex(namePatern);
                Regex numsRegex = new Regex(numsPatern);

                MatchCollection nameMatches = nameRegex.Matches(input);
                MatchCollection numsMatches = numsRegex.Matches(input);
                string name = string.Join("", nameMatches);
                int distance = numsMatches.Select(x => int.Parse(x.Value)).Sum();

                if (namesAndDistance.ContainsKey(name))
                {
                    namesAndDistance[name] += distance;
                }
            }
            var finalists = namesAndDistance.OrderByDescending(x => x.Value).ToList();
            for (int i = 0; i < finalists.Count; i++)
            {
                if(i == 0)
                {
                    Console.WriteLine($"1st place: {finalists[i].Key}");
                }
                else if(i == 1)
                {
                    Console.WriteLine($"2nd place: {finalists[i].Key}");
                }
                else if
                {
                    Console.WriteLine($"3rd place: {finalists[i].Key}");
                }
            }
        }
    }
}