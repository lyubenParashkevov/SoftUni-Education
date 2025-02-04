namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string text = string.Empty;
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                if (command == "1")
                {
                    string substring = commands[1];
                    stack.Push(text);
                    text += substring;

                }
                else if (command == "2")
                {
                    int numToErase = int.Parse(commands[1]);
                    stack.Push(text);
                    text = text.Remove(text.Length - numToErase);
                }
                else if (command == "3")
                {
                    int index = int.Parse(commands[1]) - 1;
                    Console.WriteLine(text[index]);
                }
                else if (command == "4")
                {
                    text = stack.Pop();
                }
            }
        }
    }
}