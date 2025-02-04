namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            char[,] matrix = new char[rows, cols];

            int row = 0;
            int col = 0;
            int startRow = 0;
            int startCol = 0;
            int finishRow = 0;
            int finishCol = 0;
            int counterC = 0;

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (row = 0; row < rows; row++)
            {
                char[] chars = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                    
                    

                for (col = 0; col < cols; col++)
                {
                    matrix[row, col] += chars[col];

                    if (matrix[row, col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }

                    if ((matrix[row, col] == 'c'))
                    {
                        counterC++;
                    }
                }
            }

            row = startRow;
            col = startCol;

            for (int i = 0; i < commands.Length; i++)
            {
                   
                string command = commands[i];

                if (command == "left")
                {
                    if (col - 1 >= 0)
                    {
                        col -= 1;

                        if (matrix[row, col] == 'c')
                        {
                            matrix[row, col] = '*';
                            counterC--;
                        }
                    }
                }

                else if (command == "right")
                {
                    if (col + 1 < matrix.GetLongLength(1))
                    {
                        col += 1;

                        if (matrix[row, col] == 'c')
                        {
                            matrix[row, col] = '*';
                            counterC--;
                        }
                    }
                }

                else if (command == "up")
                {
                    if (row - 1 >= 0)
                    {
                        row -= 1;

                        if (matrix[row, col] == 'c')
                        {
                            matrix[row, col] = '*';
                            counterC--;
                        }
                    }
                }

                else if (command == "down")
                {
                    if (row + 1 < matrix.GetLongLength(0))
                    {
                        row += 1;

                        if (matrix[row, col] == 'c')
                        {
                            matrix[row, col] = '*';
                            counterC--;
                        }
                    }
                }

                if (counterC == 0)
                {
                    Console.WriteLine($"You collected all coals! ({row}, {col})");
                    return;
                }

                if (matrix[row, col] == 'e')
                {
                    Console.WriteLine($"Game over! ({row}, {col})");
                    return;
                }
            }

            Console.WriteLine($"{counterC} coals left. ({row}, {col})");
        }
    }
}