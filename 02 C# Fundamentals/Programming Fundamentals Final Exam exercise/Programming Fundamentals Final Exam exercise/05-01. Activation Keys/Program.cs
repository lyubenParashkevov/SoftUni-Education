namespace _05_01._Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string text = Console.ReadLine();
            while (true) 
            {
                string input = Console.ReadLine();
                if (input == "Generate")
                {
                    break;
                }
                string[] commands = input.Split(">>>");
                string command = commands[0];
                if (command == "Contains")
                {
                    string substring = commands[1];
                    if (text.Contains(substring))
                    {
                        Console.WriteLine($"{text} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (command == "Flip")
                {
                    int startIndex = int.Parse(commands[2]);
                    int endIndex = int.Parse(commands[3]);
                    if (commands[1] == "Upper")
                    {
                        string substringToRemove = text.Substring(startIndex, endIndex  - startIndex);
                        string substringToInsert = text.Substring(startIndex, endIndex - startIndex).ToUpper();
                        text = text.Replace(substringToRemove, substringToInsert);
                    }
                    else if (commands[1] == "Lower")
                    {
                        string substringToRemove = text.Substring(startIndex, endIndex - startIndex);
                        string substringToInsert = text.Substring(startIndex, endIndex - startIndex).ToLower();
                        text = text.Replace(substringToRemove, substringToInsert);
                    }
                    Console.WriteLine(text);
                }
                else if (command == "Slice")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    text = text.Remove(startIndex, endIndex - startIndex);
                    Console.WriteLine(text);
                }
            }

            Console.WriteLine($"Your activation key is: {text}");
        }
    }
}