namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            int curIndex = 0;

            char[,] matrix = new char[rows, cols];

            string snake = Console.ReadLine();

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {

                    for (int col = 0; col < cols; col++)
                    {
                        if (curIndex == snake.Length)
                        {
                            curIndex = 0;
                        }

                        matrix[row,col] = snake[curIndex];

                        curIndex++;
                    }
                }

                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (curIndex == snake.Length)
                        {
                            curIndex = 0;
                        }

                        matrix[row, col] = snake[curIndex];

                        curIndex++;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}