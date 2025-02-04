

int n = int.Parse(Console.ReadLine());

char[,] matrix = new char[n,n];

int startRow = 0;
int startCol = 0;
for (int row = 0; row < n; row++)
{
    char[] chars = Console.ReadLine().ToCharArray();

	for (int col = 0; col < n; col++)
	{
		matrix[row, col] = chars[col];
		if (matrix[row, col] == 'S')
		{
			startRow = row;
			startCol = col;
		}
	}
}

int shipCounter = 0;
int mineCounter = 0;

while (shipCounter < 3 && mineCounter < 3)
{
	string command = Console.ReadLine();

     matrix[startRow, startCol] = '-';
	
	switch(command)
	{
		case "left":
			startCol--;
			
			if (matrix[startRow, startCol] == '*')
			{
				mineCounter++;
                matrix[startRow, startCol] = '-';
			}
			else if (matrix[startRow, startCol] == 'C')
			{
				shipCounter++;
                matrix[startRow, startCol] = '-';
			}
            
			break;

        case "right":
			startCol++;

            if (matrix[startRow, startCol] == '*')
            {
                mineCounter++;
                matrix[startRow, startCol] = '-';
            }
            else if (matrix[startRow, startCol] == 'C')
            {
                shipCounter++;
                matrix[startRow, startCol] = '-';

            }
            break;

        case "up":
			startRow--;

            if (matrix[startRow, startCol] == '*')
            {
                mineCounter++;
                matrix[startRow, startCol] = '-';
            }
            else if (matrix[startRow, startCol] == 'C')
            {
                shipCounter++;
                matrix[startRow, startCol] = '-';
            }
            break;

        case "down":
            startRow++;

            if (matrix[startRow, startCol] == '*')
            {
                mineCounter++;
                matrix[startRow, startCol] = '-';
            }
            else if (matrix[startRow, startCol] == 'C')
            {
                shipCounter++;
                matrix[startRow, startCol] = '-';
            }
            break;
    }
}

matrix[startRow, startCol] = 'S';

if (shipCounter == 3)
{
    Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
}
else
{
    Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{startRow}, {startCol}]!");
}

for (startRow = 0; startRow < n; startRow++)
{
    for (startCol = 0;startCol < n;startCol ++)
    {
        Console.Write(matrix[startRow, startCol]);

    }
    Console.WriteLine();
}