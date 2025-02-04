namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> evenNums = new List<int>();

            Queue<int> ints = new Queue<int>(numbers);

            while (ints.Count > 0) 
            {
                int curnum = ints.Dequeue();
                if (curnum % 2 == 0)
                {
                    evenNums.Add(curnum);
                }
                curnum = 0;
            }

            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}