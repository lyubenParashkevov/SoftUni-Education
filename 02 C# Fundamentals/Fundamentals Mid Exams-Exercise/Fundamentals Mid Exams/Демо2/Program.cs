namespace Демо2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(">>>");
                if (commands[0] == "Generate")
                {
                    break;
                }

                string command = commands[0];

                if (command == "Contains")
                {
                    string substring = commands[1];
                    Console.WriteLine(Contains(string.Empty, key, substring));

                }

                else if (command == "Flip")
                {
                    string upperOrLower = commands[1];
                    int startIndex = int.Parse(commands[2]);
                    int endIndex = int.Parse(commands[3]);
                    Console.WriteLine(Flip(string.Empty, key, startIndex, endIndex, upperOrLower));
                    
                }

                else if (command == "Slice")
                {
                    
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    Console.WriteLine(Slice(string.Empty, key, startIndex, endIndex));
                }
            }
            Console.WriteLine($"Your activation key is: {key}");
        }

        static string Slice(string empty, string key, int startIndex, int endIndex)
        {
            key = key.Remove(startIndex, endIndex - startIndex);
            return key;
        }
        static string Contains(string empty, string key, string substring)
        {
            if (key.Contains(substring))
            {
                return $"{key} contains {substring}";
            }
            else
            {
                return "Substring not found!";
            }
        }

        static string Flip(string empty, string key, int startIndex, int endIndex, string upperOrLower)
        {
            string substring = key.Substring(startIndex, endIndex - startIndex);
            if (upperOrLower == "Upper")
            {
                if (key.Contains(substring))
                {
                    substring = substring.ToUpper();
                }
            }
            else
            {
                if (key.Contains(substring))
                {
                    substring = substring.ToLower();
                }
            }
            return key;

        }

       
    }
}