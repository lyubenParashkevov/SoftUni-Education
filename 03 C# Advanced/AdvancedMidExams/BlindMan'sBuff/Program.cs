

using System.Numerics;

int[] rowsCols = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int rows = rowsCols[0];
int cols = rowsCols[1];
int startRow = 0;
int startCol = 0;
int row = 0;
int col = 0;

char[,] matrix = new char[rows, cols];

for (row = 0; row < rows; row++)
{
    char[] chars = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (col = 0; col < cols; col++)
    {
        matrix[row, col] = chars[col];
        if (matrix[row, col] == 'B')
        {
            startRow = row;
            startCol = col;
        }
    }
}

row = startRow;
col = startCol;

int moveCounter = 0;
int opponentCounter = 0;


while (opponentCounter < 3)
{
    string command = Console.ReadLine();

    if (command == "Finish")
    {
        break;
    }
    switch (command)
    {

        case "left":
            if (col - 1 < 0 || matrix[row, col - 1] == 'O')
            { continue; }

            else
            {
                col--;
                char curPosition = matrix[row, col];

                if (curPosition == 'P')
                {
                    opponentCounter++;
                    matrix[row, col] = '-';
                }
                moveCounter++;
            }

            break;
        case "right":
            if (col + 1 >= cols || matrix[row, col + 1] == 'O')
            { continue; }

            else
            {
                col++;
                char curPosition = matrix[row, col];
                if (curPosition == 'P')
                {
                    opponentCounter++;
                    matrix[row, col] = '-';
                }
                moveCounter++;
            }

            break;

        case "up":
            if (row - 1 < 0 || matrix[row - 1, col] == 'O')
            { continue; }

            else
            {
                row--;
                char curPosition = matrix[row, col];
                if (curPosition == 'P')
                {
                    opponentCounter++;
                    matrix[row, col] = '-';
                }
                moveCounter++;
            }
            break;

        case "down":
            if (row + 1 >= rows || matrix[row + 1, col] == 'O')
            {
                { continue; }
            }

            else
            {
                row++;
                char curPosition = matrix[row, col];
                if (curPosition == 'P')
                {
                    opponentCounter++;
                    matrix[row, col] = '-';
                }
                moveCounter++;
            }

            break;

    }

}

Console.WriteLine("Game over!");
Console.WriteLine($"Touched opponents: {opponentCounter} Moves made: {moveCounter}");
