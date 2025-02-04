using System.Text.RegularExpressions;

namespace _03_02._Mirror_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string patern = @"(#|@)(?<word1>[A-Za-z]{3,})\1\1(?<word2>[A-Za-z]{3,})\1";
            Regex regex = new Regex(patern);
            MatchCollection matches = regex.Matches(text);
            int pairs = matches.Count;
            List<string> words = new List<string>();
           
            foreach (Match match in matches)
            {
                string firstWord = match.Groups["word1"].Value;
                string secondWord = match.Groups["word2"].Value;
                char[] chars= secondWord.Reverse().ToArray();
                string reversedWord = string.Join("", chars);
                if (firstWord == reversedWord)
                {
                    words.Add($"{firstWord} <=> {secondWord}");
                } 
            }

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                
            }
            else
            {
                Console.WriteLine($"{pairs} word pairs found!");
            }

            if (words.Count > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", words));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }
    }
}