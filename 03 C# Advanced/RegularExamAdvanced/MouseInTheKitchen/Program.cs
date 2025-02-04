

int[] dimentions = Console.ReadLine().Split(",",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int rows = dimentions[0];
int cols = dimentions[1];

int row = 0;
int col = 0;

char[,] matrix = new char[rows, cols];

for (int startRow = 0; startRow < rows; startRow++)   
{
    char[] chars = Console.ReadLine().ToCharArray();

    for (int startCol = 0; startCol < cols; startCol++)
    {
        matrix[startRow, startCol] = chars[startCol];
        if (matrix[startRow, startCol] == 'M')
        {
            row = startRow;
            col = startCol;
        }
    }
}

string command;
bool isThereCheese =  true;
int cCounter = 0;
matrix[row, col] = '*';
while ((command = Console.ReadLine()) != "danger")
{

    switch (command)
    {
        case "left":
            if (col - 1 < 0)
            {
                matrix[row, col] = 'M';
                Console.WriteLine("No more cheese for tonight!");

                for (row = 0; row < rows; row++)   
                {
                    for (col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                return;
            }

            if (matrix[row, col - 1] == '@')
            {
                continue;
            }

            col--;

            if (matrix[row, col] == 'T')
            {
                matrix[row, col] = 'M';
                Console.WriteLine("Mouse is trapped!");

                for (row = 0; row < rows; row++)
                {
                    for (col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                return;
            }
            if (matrix[row, col] == 'C')
            {
                matrix[row, col] = '*';


                int curRow = row;
                int curCol = col;
                for (row = 0; row < rows; row++)
                {
                    for (col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'C')
                        {
                            cCounter++;
                        }
                    }
                }
                row = curRow;
                col = curCol;
                if (cCounter == 0)
                {
                    matrix[row, col] = 'M';
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");

                    for (row = 0; row < rows; row++)
                    {
                        for (col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        Console.WriteLine();
                    }
                    return;
                }
                cCounter = 0;
                

            }



            break;


        case "right":
            if (col + 1 == cols)
            {
                matrix[row, col] = 'M';
                Console.WriteLine("No more cheese for tonight!");

                for (row = 0; row < rows; row++)   
                {
                    for (col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                return;
            }

            if (matrix[row, col + 1] == '@')
            {
                continue;
            }
            col++;

            if (matrix[row, col] == 'T')
            {
                matrix[row, col] = 'M';
                Console.WriteLine("Mouse is trapped!");

                for (row = 0; row < rows; row++)
                {
                    for (col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                return;
            }
            if (matrix[row, col] == 'C')
            {
                matrix[row, col] = '*';


                int curRow = row;
                int curCol = col;
                for (row = 0; row < rows; row++)
                {
                    for (col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'C')
                        {
                            cCounter++;
                        }
                    }
                }
                row = curRow;
                col = curCol;
                if (cCounter == 0)
                {
                    matrix[row, col] = 'M';
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");

                    for (row = 0; row < rows; row++)
                    {
                        for (col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        Console.WriteLine();
                    }
                    return;
                }
                cCounter = 0;


            }

            break;

        case "up":
            if (row - 1 < 0)
            {
                matrix[row, col] = 'M';
                Console.WriteLine("No more cheese for tonight!");

                for (row = 0; row < rows; row++)
                {
                    for (col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                return;
            }

            if (matrix[row - 1, col] == '@')
            {
                continue;
            }

            row--;

            if (matrix[row, col] == 'T')
            {
                matrix[row, col] = 'M';
                Console.WriteLine("Mouse is trapped!");

                for (row = 0; row < rows; row++)
                {
                    for (col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                return;
            }
            if (matrix[row, col] == 'C')
            {
                matrix[row, col] = '*';


                int curRow = row;
                int curCol = col;
                for (row = 0; row < rows; row++)
                {
                    for (col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'C')
                        {
                            cCounter++;
                        }
                    }
                }
                row = curRow;
                col = curCol;
                if (cCounter == 0)
                {
                    matrix[row, col] = 'M';
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");

                    for (row = 0; row < rows; row++)
                    {
                        for (col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        Console.WriteLine();
                    }
                    return;
                }
                cCounter = 0;


            }
            break;

        case "down":
            if (row + 1 == rows)
            {
                matrix[row, col] = 'M';
                Console.WriteLine("No more cheese for tonight!");

                for (row = 0; row < rows; row++)
                {
                    for (col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                return;
            }

            if (matrix[row + 1, col] == '@')
            {
                continue;
            }
            row++;

            if (matrix[row, col] == 'T')
            {
                matrix[row, col] = 'M';
                Console.WriteLine("Mouse is trapped!");

                for (row = 0; row < rows; row++)
                {
                    for (col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                return;
            }
            if (matrix[row, col] == 'C')
            {
                matrix[row, col] = '*';


                int curRow = row;
                int curCol = col;
                for (row = 0; row < rows; row++)
                {
                    for (col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'C')
                        {
                            cCounter++;
                        }
                    }
                }
                row = curRow;
                col = curCol;
                if (cCounter == 0)
                {
                    matrix[row, col] = 'M';
                    Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");

                    for (row = 0; row < rows; row++)
                    {
                        for (col = 0; col < cols; col++)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        Console.WriteLine();
                    }
                    return;
                }
                cCounter = 0;


            }

            break;
    }
}
matrix[row, col] = 'M';
for ( row = 0; row < rows; row++)
{
    for (col = 0; col < cols; col++)
    {
        if (matrix[row, col] == 'C')
        {
            Console.WriteLine("Mouse will come back later!");

            for (row = 0; row < rows; row++)
            {
                for (col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
            
        }
       
    }
}
