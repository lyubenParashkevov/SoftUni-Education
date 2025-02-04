namespace _01._String_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string text = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }
                string[] commands = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                if (command == "Translate")
                {
                    char ch = char.Parse(commands[1]);
                    char replacement = char.Parse(commands[2]);

                    if (text.Contains(ch))
                    {
                        text = text.Replace(ch, replacement);
                    }
                    Console.WriteLine(text);
                }
                else if (command == "Includes")
                {
                    string substring = commands[1];
                    if (text.Contains(substring))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }
                else if (command == "Start")
                {
                    string substring = commands[1];
                    if (text.IndexOf(substring) == 0)
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }

                }
                else if (command == "Lowercase")
                {
                    text = text.ToLower();
                    Console.WriteLine(text);
                }
                else if (command == "FindIndex")
                {
                    char ch = char.Parse(commands[1]);
                    Console.WriteLine(text.LastIndexOf(ch));

                }
                else if (command == "Remove")
                {
                    int startIndex = int.Parse(commands[1]);
                    int count = int.Parse(commands[2]);

                    text = text.Remove(startIndex, count);
                    Console.WriteLine(text);
                }

            }
        }
    }
}