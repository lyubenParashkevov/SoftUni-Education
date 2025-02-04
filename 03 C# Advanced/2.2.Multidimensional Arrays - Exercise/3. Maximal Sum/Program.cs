namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }
            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < rows - 2; row++)
            {

                for (int col = 0; col < cols - 2; col++)
                {
                    int curSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (curSum > maxSum)
                    {
                        maxSum = curSum;
                        maxRow = row;
                        maxCol = col;
                        
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = maxRow; row < maxRow + 3; row++)
            {
                for (int col = maxCol; col < maxCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}