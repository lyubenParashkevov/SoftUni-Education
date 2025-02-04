using System.Diagnostics.Metrics;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();    

            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            int startRow = 0;
            int startCol = 0;
            int  row = 0;
            int col = 0;    

            char[,] matrix = new char[rows, cols];

            for (row = 0; row < rows; row ++)
            {
                char[] chars = Console.ReadLine().ToCharArray();

                for (col = 0; col < cols; col++)
                {
                    matrix[row, col] += chars[col];
                    if (matrix[row, col] == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();

            row = startRow;
            col = startCol;

            for (int i = 0; i < commands.Length; i++)
            {
                char command = commands[i];

                if (command == 'L')
                {
                    if (col - 1 >= 0)
                    {
                        col -= 1;

                        if (matrix[row, col] == 'B')
                        {
                            Console.WriteLine($"dead: {row} {col}");
                            return;
                        }
                    }
                }

                else if (command == 'R')
                {
                    if (col + 1 < matrix.GetLongLength(1))
                    {
                        col += 1;

                        if (matrix[row, col] == 'B')
                        {
                            Console.WriteLine($"dead: {row} {col}");
                            return;
                        }
                    }
                }

                else if (command == 'U')
                {
                    if (row - 1 >= 0)
                    {
                        row -= 1;

                        if (matrix[row, col] == 'B')
                        {
                            Console.WriteLine($"dead: {row} {col}");
                            return;
                        }
                    }
                }

                else if(command == 'D')
                {
                    if (row + 1 < matrix.GetLongLength(0))
                    {
                        row += 1;

                        if (matrix[row, col] == 'B')
                        {
                            Console.WriteLine($"dead: {row} {col}");
                            return;
                        }
                    }
                }

                for (row = 0; row < rows; row++)
                {
                    for (col = 0;col < cols;col ++)
                    {
                        if (matrix[row, col] == 'B')
                        {

                        }
                    }
                }
            }

            Console.WriteLine($"won: {row} {col}");
        }
    }
}