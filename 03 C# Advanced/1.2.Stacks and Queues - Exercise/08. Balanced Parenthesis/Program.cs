namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<char> stack = new Stack<char>();


            string input = Console.ReadLine();
            char open1 = '(';
            char close1 = ')';
            char open2 = '[';
            char close2 = ']';
            char open3 = '{';
            char close3 = '}';

            if (input.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == open1 || input[i] == open2 || input[i] == open3)
                {
                    stack.Push(input[i]);
                }

                if (input[i] == close1)
                {
                    if (stack.Peek() == open1)
                    {
                        stack.Pop();
                    }
                }

                else if (input[i] == close2)
                {
                    if (stack.Peek() == open2)
                    {
                        stack.Pop();
                    }
                }

                else if (input[i] == close3)
                {
                    if (stack.Peek() == open3)
                    {
                        stack.Pop();
                    }
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}