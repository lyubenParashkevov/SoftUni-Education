using System.Numerics;

int n = int.Parse(Console.ReadLine());

string[] commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

char[,] matrix = new char[n, n];
int row = 0;
int col = 0;
int startRow = 0;
int startCol = 0;
int hCount = 0;

for (row = 0; row < n; row++)
{
    char[] chars = Console.ReadLine().ToCharArray();

    for (col = 0; col < n; col++)
    {
        matrix[row, col] = chars[col];

        if (matrix[row, col] == 's')
        {
            startRow = row;
            startCol = col;
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
        if (col - 1 < 0)
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hCount}");
            return;
        }

        col -= 1;

        char curposition = matrix[row, col];
        
        if (curposition == 't')
        {
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            Console.WriteLine($"Hazelnuts collected: {hCount}");
            return;
        }
        
        if (curposition == 'h')
        {
            hCount++;
            matrix[row, col] = '*';
        }
    }

    else if (command == "right")
    {
        if (col + 1 >= matrix.GetLength(1))
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hCount}");
            return;
        }

        col += 1;

        char curposition = matrix[row, col];

        if (curposition == 't')
        {
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            Console.WriteLine($"Hazelnuts collected: {hCount}");
            return;
        }


        if (curposition == 'h')
        {
            hCount++;
            matrix[row, col] = '*';
        }
    }

    else if (command == "down")
    {
        if (row + 1 >= matrix.GetLength(0))
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hCount}");
            return;
        }

        row += 1;

        char curposition = matrix[row, col];

        if (curposition == 't')
        {
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            Console.WriteLine($"Hazelnuts collected: {hCount}");
            return;
        }

        if (curposition == 'h')
        {
            hCount++;
            matrix[row, col] = '*';
        }
    }

    else if (command == "up")
    {
        if (row - 1 < 0)
        {
            Console.WriteLine("The squirrel is out of the field.");
            Console.WriteLine($"Hazelnuts collected: {hCount}");
            return;
        }

        row -= 1;

        char curposition = matrix[row, col];
        
        if (curposition == 't')
        {
            Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
            Console.WriteLine($"Hazelnuts collected: {hCount}");
            return;
        }

        if (curposition == 'h')
        {
            hCount++;
            matrix[row, col] = '*';
        }
    }
}

if (hCount == 3)
{
    Console.WriteLine("Good job! You have collected all hazelnuts!");
    Console.WriteLine($"Hazelnuts collected: {hCount}");
}
else
{
    Console.WriteLine("There are more hazelnuts to collect.");
    Console.WriteLine($"Hazelnuts collected: {hCount}");
}






//static bool OutOfMatrix(char[,] matrix, int row, int col, int hCount)
//{
//    if (row < 0 || row >= matrix.GetLongLength(0) || col < 0 || col >= matrix.GetLength(1))
//    {
//        return true;
//    }
//    return false;
//}
//static void Trap(char curposition, int hCount)
//{
//    if (curposition == 't')
//    {
//        Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
//        Console.WriteLine($"Hazelnuts collected: {hCount}");
//        return;
//    }
//}
//
//static bool GetHazelnut(char curposition, int hCount)
//{
//    if (curposition == 'h')
//    {
//        return true;
//    }
//    return false;
//}

