namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string input = "";
            int bestSequenceSum = 0;
            
            int tempCount = 0;
            int count = 0;
            int sum = 0;
            int[] bestSequence = new int[n];
            while (input != "Clone them!")
            {
                input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    Console.WriteLine("Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
                    Console.WriteLine("{ DNA sequence, joined by space}");
                    break;
                }
                int[] numbers = input.Split('!').Select(int.Parse).ToArray();

                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if (numbers[j] == 1)
                    {
                        sum++;
                        if (sum > bestSequenceSum)
                        {
                            bestSequenceSum = sum;
                        }
                    }
                    if (numbers[j] == 1 & numbers[j + 1] == 1)
                    {
                        tempCount++;
                        if(tempCount > count)
                        {
                            count = tempCount;
                        }
                    }
                }


            }
        }
    }
}