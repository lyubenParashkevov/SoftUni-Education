namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] rowsAndCols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < rows - 1; row++)
            {
                int curSum = 0;
                
                for (int col = 0; col < cols - 1; col++)
                {
                    int firstNum = matrix[row, col];
                    int secNum = matrix[row, col + 1];
                    int thirdNum = matrix[row + 1, col];
                    int fourthNum = matrix[row + 1, col + 1];

                    curSum = firstNum + secNum + thirdNum + fourthNum;
                    if (curSum > maxSum)
                    {
                        maxSum = curSum;
                         maxRow = row;
                         maxCol = col;
                        curSum = 0;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");
            Console.WriteLine(maxSum);

        }
    }
}