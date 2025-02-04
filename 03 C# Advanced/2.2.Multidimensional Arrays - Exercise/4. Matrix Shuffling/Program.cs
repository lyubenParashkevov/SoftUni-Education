namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "END")
                {
                    break;
                }

                if (commands.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                     continue;
                }

                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int newRow = int.Parse(commands[3]);
                int newCol = int.Parse(commands[4]);

               

                if (commands[0] != "swap" ||  row < 0 || row > matrix.GetLength(0) || col < 0 ||
                    col > matrix.GetLength(1) ||
                    newRow < 0 || newRow > matrix.GetLength(0) || newCol < 0 || newCol > matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                

                else
                {
                    string curCoordinates = matrix[row, col];
                    matrix[row, col] = matrix[newRow, newCol];
                    matrix[newRow, newCol] = curCoordinates;

                }

                for ( row = 0; row < rows; row++)
                {
                    for (col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        
    }
}