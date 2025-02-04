namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Stack<string> stack = new();
            int curentSum = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                stack.Push(input[i]);
            }
            while (stack.Count > 0)
            {
                string item = stack.Pop();
                int number = 0;

                if (item == "+")
                {
                    number = int.Parse(stack.Pop());
                    curentSum += number;
                }

                else if (item == "-")
                {
                    number = int.Parse(stack.Pop());
                    curentSum -= number;
                }

                else
                {
                    number = int.Parse(item);
                    curentSum += number;
                }
            }

            Console.WriteLine(curentSum);

        }
    }
}