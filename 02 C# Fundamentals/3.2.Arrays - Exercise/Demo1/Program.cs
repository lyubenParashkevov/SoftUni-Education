namespace Demo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1 2 3 3

            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            
            if (numbers.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;

                for (int j = i; j < numbers.Length; j++)
                {
                    rightSum += numbers[j];
                }
                for (int k = i; k > 0; k--)
                {
                    leftSum += numbers[k];
                    if (k == 0)
                    {
                        leftSum = 0;
                    }
                }
                if(leftSum == rightSum)
                {
                    Console.WriteLine(numbers[i]);
                }
               
            }
            Console.WriteLine("no");
        }
    }
}