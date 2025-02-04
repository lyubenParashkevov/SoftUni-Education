using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string patern = @"!(?<command>[A-Z][a-z]{2,})!:(?<string>[[A-Za-z]{8,}])";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Regex regex = new Regex(patern);
                MatchCollection matches = regex.Matches(input);

                if (regex.IsMatch(input)) 
                {
                    foreach (Match match in matches)
                    {
                        string command = match.Groups["command"].Value.Trim();
                        string text = match.Groups["string"].Value.Trim();
                        string textAsNumbers = string.Empty;
                        for (int j = 1; j < text.Length - 1; j++)
                        {
                            int x = text[j];
                            textAsNumbers += x + " ";
                        }

                        Console.WriteLine($"{command}: {textAsNumbers}");
                    }
                }

                else

                {
                
                    Console.WriteLine("The message is invalid");
                }
            }

        }
    }
}
