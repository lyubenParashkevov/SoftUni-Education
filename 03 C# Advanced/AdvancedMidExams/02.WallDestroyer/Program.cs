


int n = int.Parse(Console.ReadLine());

char[,] matrix = new char[n, n];

int row = 0;
int col = 0;
int rodCount = 0;
int holeCount = 0;

for (int startRow = 0; startRow < n; startRow++)
{
    char[] chars = Console.ReadLine().ToCharArray();

    for (int startCol = 0; startCol < n; startCol++)
    {
        matrix[startRow, startCol] = chars[startCol];
        if (matrix[startRow, startCol] == 'V')
        {
            row = startRow;
            col = startCol;
        }
    }
}

matrix[row, col] = '*';
holeCount++;

string command;

while ((command = Console.ReadLine()) != "End")
{
    
    switch (command)
    {
        case "left":
            if (col - 1 < 0)
            {
                continue;
            }

            if (matrix[row, col - 1] == 'R')
            {
                Console.WriteLine("Vanko hit a rod!");
                rodCount++;
                continue;
            }
            col--;

            if (matrix[row, col] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
            }

            else if (matrix[row, col] == '-')
            {
                matrix[row, col] = '*';
                holeCount++;
            }

            if (matrix[row, col] == 'C')
            {
                matrix[row, col] = 'E';
                holeCount++;

                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCount} hole(s).");

                for (row = 0; row < n; row++)
                {
                    for (col = 0; col < n; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                return;
            }

            
            break;
        case "right":
            if (col + 1 == n)
            {
                continue;
            }

            if (matrix[row, col + 1] == 'R')
            {
                Console.WriteLine("Vanko hit a rod!");
                rodCount++;
                continue;
            }
            col++;

            if (matrix[row, col] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
            }

            else if (matrix[row, col] == '-')
            {
                matrix[row, col] = '*';
                holeCount++;
            }

            if (matrix[row, col] == 'C')
            {
                matrix[row, col] = 'E';
                holeCount++;

                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCount} hole(s).");

                for (row = 0; row < n; row++)
                {
                    for (col = 0; col < n; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                return;
            }


            break;


        case "up":
            if (row - 1 < 0)
            {
                continue;
            }

            if (matrix[row - 1, col] == 'R')
            {
                Console.WriteLine("Vanko hit a rod!");
                rodCount++;
                continue;
            }
            row--;

            if (matrix[row, col] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
            }

            else if (matrix[row, col] == '-')
            {
                matrix[row, col] = '*';
                holeCount++;
            }

            if (matrix[row, col] == 'C')
            {
                matrix[row, col] = 'E';
                holeCount++;

                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCount} hole(s).");

                for (row = 0; row < n; row++)
                {
                    for (col = 0; col < n; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                return;
            }


            break;

        case "down":
            if (row + 1 == n)
            {
                continue;
            }

            if (matrix[row + 1, col] == 'R')
            {
                Console.WriteLine("Vanko hit a rod!");
                rodCount++;
                continue;
            }
            row++;

            if (matrix[row, col] == '*')
            {
                Console.WriteLine($"The wall is already destroyed at position [{row}, {col}]!");
            }

            else if (matrix[row, col] == '-')
            {
                matrix[row, col] = '*';
                holeCount++;
            }

            if (matrix[row, col] == 'C')
            {
                matrix[row, col] = 'E';
                holeCount++;

                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCount} hole(s).");

                for (row = 0; row < n; row++)
                {
                    for (col = 0; col < n; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                return;
            }


            break;
    }
}
matrix[row, col] = 'V';

Console.WriteLine($"Vanko managed to make {holeCount} hole(s) and he hit only {rodCount} rod(s).");

for (row = 0; row < n; row++)
{
    for (col = 0; col < n; col++)
    {
        Console.Write(matrix[row, col]);
    }
    Console.WriteLine();
}