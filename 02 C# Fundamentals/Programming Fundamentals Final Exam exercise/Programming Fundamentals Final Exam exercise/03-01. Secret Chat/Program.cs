namespace _03_01._Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Reveal")
                {
                    break;
                }
                string[] commands = input.Split(":|:");
                string command = commands[0];

                if (command == "InsertSpace")
                {
                    int index = int.Parse(commands[1]);
                    string space = " ";
                    text = text.Insert(index, space);
                    Console.WriteLine(text);
                }
                else if (command == "Reverse")
                {
                    string substring = commands[1];
                    char[] chars = substring.Reverse().ToArray();
                    string reversed = string.Join("", chars);

                    if (text.Contains(substring))
                    {
                        int startindex = text.IndexOf(substring);
                        text = text.Remove(startindex, substring.Length);
                        text = text + reversed;
                        Console.WriteLine(text);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                }
                else if (command == "ChangeAll")
                {
                    string substring = commands[1];
                    string replacement = commands[2];

                    if (text.Contains(substring))
                    {
                        text = text.Replace(substring, replacement);
                        Console.WriteLine(text);
                    }
                }
            }

            Console.WriteLine($"You have a new text message: {text}");
        }
    }
}