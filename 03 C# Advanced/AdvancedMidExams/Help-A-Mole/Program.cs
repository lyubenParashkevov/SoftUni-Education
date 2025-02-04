

int n = int.Parse(Console.ReadLine());
int row = 0;
int col = 0;
int specialRow = 0;
int specialCol = 0;
int points = 0;
char[,] matrix = new char[n, n];

for (int startRow = 0; startRow < n; startRow++)
{
    char[] chars = Console.ReadLine().ToCharArray();

    for (int startCol = 0; startCol < n; startCol++)
    {
        matrix[startRow, startCol] = chars[startCol];
        if (matrix[startRow, startCol] == 'M')
        {
            row = startRow;
            col = startCol;
        }
    }
}

matrix[row, col] = '-';

string command;

while ((command = Console.ReadLine()) != "End")
{
    if (points >= 25)
    {
        break;
    }
    switch (command)
    {
        case "left":
            if (col - 1 < 0)
            {
                Console.WriteLine("Don't try to escape the playing field!");
                continue;
            }
            col--;

            if (matrix[row, col] == 'S')
            {
                matrix[row, col] = '-';

                for (row = 0; row < n; row++)
                {
                    for (col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'S')
                        {
                            matrix[row, col] = '-';
                            specialRow = row;
                            specialCol = col;
                            points -= 3;
                            row = specialRow;
                            col = specialCol;
                        }
                    }
                }
                row = specialRow;
                col = specialCol;
            }

            if (matrix[row, col] != '-' && matrix[row, col] != 'S')
            {
                points += int.Parse(matrix[row, col].ToString());
                matrix[row, col] = '-';
            }
           
            break;


        case "right":
            if (col + 1 == n)
            {
                Console.WriteLine("Don't try to escape the playing field!");
                continue;
            }
            col++;

            if (matrix[row, col] == 'S')
            {
                matrix[row, col] = '-';

                for (row = 0; row < n; row++)
                {
                    for (col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'S')
                        {
                            matrix[row, col] = '-';
                            specialRow = row;
                            specialCol = col;
                            points -= 3;
                            
                        }
                    }
                }
                row = specialRow;
                col = specialCol;
            }

            if (matrix[row, col] != '-' && matrix[row, col] != 'S')
            {
                points += int.Parse(matrix[row, col].ToString());
                matrix[row, col] = '-';
            }

            break;


        case "up":
            if (row - 1 < 0)
            {
                Console.WriteLine("Don't try to escape the playing field!");
                continue;
            }
            row--;

            if (matrix[row, col] == 'S')
            {
                matrix[row, col] = '-';

                for (row = 0; row < n; row++)
                {
                    for (col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'S')
                        {
                            matrix[row, col] = '-';
                            specialRow = row;
                            specialCol = col;
                            points -= 3;
                            
                        }
                    }
                }
                row = specialRow;
                col = specialCol;
            }

            if (matrix[row, col] != '-' && matrix[row, col] != 'S')
            {
                points += int.Parse(matrix[row, col].ToString());
                matrix[row, col] = '-';
            }
            break;


        case "down":
            if (row + 1 == n)
            {
                Console.WriteLine("Don't try to escape the playing field!");
                continue;
            }
            row++;

            if (matrix[row, col] == 'S')
            {
                matrix[row, col] = '-';

                for (row = 0; row < n; row++)
                {
                    for (col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'S')
                        {
                            matrix[row, col] = '-';
                            specialRow = row;
                            specialCol = col;
                            points -= 3;
                            
                        }
                    }
                }
                row = specialRow;
                col = specialCol;
            }

            if (matrix[row, col] != '-' && matrix[row, col] != 'S')
            {
                points += int.Parse(matrix[row, col].ToString());
                matrix[row, col] = '-';
            }

            break;
    }
}

matrix[row, col] = 'M';

if (points >= 25)
{
    Console.WriteLine("Yay! The Mole survived another game!");
    Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
}
else
{
    Console.WriteLine("Too bad! The Mole lost this battle!");
    Console.WriteLine($"The Mole lost the game with a total of {points} points.");
}

for (row = 0; row < n; row++)
{
    for (col = 0; col < n; col++)
    {
        Console.Write(matrix[row, col]);
    }
    Console.WriteLine();
}


