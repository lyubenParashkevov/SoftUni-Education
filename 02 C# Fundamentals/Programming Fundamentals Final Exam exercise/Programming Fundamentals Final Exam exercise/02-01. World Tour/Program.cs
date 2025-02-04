using System.Text;

namespace _02_01._World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Travel")
                {
                    break;
                }
                string[] commands = input.Split(':');
                string command = commands[0];

                if (command == "Add Stop")
                {
                    int index = int.Parse(commands[1]);
                    string stringToInsert = commands[2];

                    if (index < 0 || index > text.Length - 1)
                    {
                        Console.WriteLine(text);
                    }
                    else
                    {
                        text = text.Insert(index, stringToInsert);

                        Console.WriteLine(text);
                    }
                }
                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if (startIndex < 0 || startIndex > text.Length - 1 || endIndex < 0 || endIndex > text.Length - 1)
                    {
                        Console.WriteLine(text);
                    }
                    else
                    {

                        text = text.Remove(startIndex, endIndex + 1 - startIndex);

                        Console.WriteLine(text);
                    }
                }
                else if (command == "Switch")
                {
                    string oldString = commands[1];
                    string newString = commands[2];
                    if (text.Contains(oldString))
                    {
                        text = text.Replace(oldString, newString);
                        Console.WriteLine(text);

                    }
                    else
                    {
                        Console.WriteLine(text);
                    }
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }
    }
}