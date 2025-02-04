namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(clothes);

            int rackCapacity = int.Parse(Console.ReadLine());
            int rackNumber = 1;
            int curSum = 0;

            while (stack.Count > 0)
            {
                int curNum = stack.Peek();
                if (curSum + curNum <= rackCapacity)
                {
                    stack.Pop();
                    curSum += curNum;
                }
                else
                {
                    rackNumber++;
                    curSum = 0;
                }
            }

            Console.WriteLine(rackNumber);

        }
    }
}