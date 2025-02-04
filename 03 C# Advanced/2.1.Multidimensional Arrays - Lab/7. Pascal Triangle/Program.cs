namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] jagedArray = new long[n][];

            jagedArray[0] = new long[1] { 1 };

            for (int row = 1; row < n; row++)
            {
                jagedArray[row] = new long[row + 1];

                for (int col = 0; col < jagedArray[row].Length; col++)
                {
                    if (jagedArray[row -1].Length > col)
                    {
                        jagedArray[row][col] += jagedArray[row - 1][col];
                    }

                    if (col > 0)
                    {
                        jagedArray[row][col] += jagedArray[row - 1][col - 1];
                    }
                }
            }

            for (int row = 0;row < n; row++)
            {
                for (int col = 0; col < jagedArray[row].Length; col++)
                {
                    Console.Write(jagedArray[row][col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}