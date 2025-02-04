namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int numToEnqueue = input[0];
            int numToDequeue = input[1];
            int numToPeek = input[2];

            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < numToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
                return;
            }

            bool isTrue = false;

            foreach (int n in queue)
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
                Console.WriteLine(queue.Min());
            }
        }
    }
}