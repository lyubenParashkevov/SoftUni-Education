using System.Text.RegularExpressions;

namespace _05_02._Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> emojiInfo = new Dictionary<string, int>();
            string text = Console.ReadLine();
            string emojiPatern = @"(::|\*\*)[A-Z][a-z]{2,}\1";
            string numbersPatern = @"\d";
            int threshold = 1;

            Regex numRegex = new Regex(numbersPatern);
            MatchCollection numMatches = numRegex.Matches(text);
            foreach (Match match in numMatches)
            {
                threshold *= int.Parse(match.Value);
            }

            Regex regex = new Regex(emojiPatern);
            MatchCollection emojies = regex.Matches(text);
            foreach (Match match in emojies)
            {
                int sum = 0;
                string emojiName = match.Value;

                for (int i = 2; i < emojiName.Length - 2; i++)
                {
                    sum += (int)emojiName[i];
                }
                if (sum > threshold)
                {
                    emojiInfo.Add(emojiName, sum);
                }

            }
            //emojiInfo.OrderByDescending(x => x.Value);

            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{emojies.Count} emojis found in the text. The cool ones are:");

            foreach (var item in emojiInfo)
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}