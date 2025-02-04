namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int numToPush = input[0];
            int numToPop = input[1];
            int numToPeek = input[2];

            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < numToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < numToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            bool isTrue = false;

            foreach (int n in stack)
            {
                if (n == numToPeek)
                {
                    isTrue = true;
                }
            }
            if (isTrue)
            {
                Console.WriteLine("true");
            }

            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}