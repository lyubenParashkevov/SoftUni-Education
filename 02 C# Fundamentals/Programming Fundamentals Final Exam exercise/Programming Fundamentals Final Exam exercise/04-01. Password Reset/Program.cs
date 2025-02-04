using System.Text;

namespace _04_01._Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string password = string.Empty;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Done")
                {
                    break;
                }

                string[] commandAndInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commandAndInfo[0];

                if (command == "TakeOdd")
                {
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (i % 2 != 0)
                        {
                            password += text[i];
                        }
                    }
                    Console.WriteLine(password);
                    text = password;
                }
                else if (command == "Cut")
                {
                    int startIndex = int.Parse(commandAndInfo[1]);
                    int length = int.Parse(commandAndInfo[2]);

                    text = text.Remove(startIndex, length);

                    Console.WriteLine(text);

                }
                else if (command == "Substitute")
                {
                    string substring = commandAndInfo[1];
                    string substitute = commandAndInfo[2];
                    if (text.Contains(substring))
                    {
                        text = text.Replace(substring, substitute);
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("Nothing to replace!");
                    }
                }
            }
            Console.WriteLine($"Your password is: {text}");
        }
    }
}