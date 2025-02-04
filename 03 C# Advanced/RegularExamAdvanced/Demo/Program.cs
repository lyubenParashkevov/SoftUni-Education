

Queue<int> coffee = new Queue<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Stack<int> milk = new Stack<int>(Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse));

Dictionary<string, int> drinks = new Dictionary<string, int>
{
    { "Cortado", 0 },  // 50
    { "Espresso", 0 },  // 75
    { "Capuccino", 0 }, // 100
    { "Americano", 0 }, // 150
    { "Latte", 0 }      // 200
};
////////////////////////////////////////////////////////////
///

int[] rowsCols = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();


char[,] matrix = new char[rows, cols];     ///когато масива от входа е със спейсове
for (int row = 0; row < rows; row++)
{
    char[] chars = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
        .Select(char.Parse)
        .ToArray();

    for (int col = 0; col < cols; col++)
    {
        matrix[row, col] = chars[col];
        if (matrix[row, col] == 'B')
        {
            startRow = row;
            startCol = col;
        }
    }
}


int n = int.Parse(Console.ReadLine());
int row = 0;
int col = 0;

for (int startRow = 0; startRow < n; startRow++)   /// стандартен вход
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
            col--;

            break;


        case "right":
            if (col + 1 == n)
            {
                continue;
            }     
            col++;

            break;

        case "up":
            if (row - 1 < 0)
            {
                continue;
            }           
            row--;
          
            break;

        case "down":
            if (row + 1 == n)
            {
                continue;
            }
           
            row++;

            break;
    }
}

for (row = 0; row < n; row++)   ////финално принтиране на матрицата
{
    for (col = 0; col < n; col++)
    {
        Console.Write(matrix[row, col]);
    }
    Console.WriteLine();
}
