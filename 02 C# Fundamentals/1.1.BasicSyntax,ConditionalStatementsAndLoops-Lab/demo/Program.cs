
int n = int.Parse(Console.ReadLine());
string[] input;

int[] field = new int[n];
int[] bugsPositions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
for (int i = 0; i < bugsPositions.Length; i++)
{
    int index = bugsPositions[i];
    field[index] = 1;
}

while (true)
{
    input = Console.ReadLine().Split(" ");
    if (input[0] == "end") break;

    int bugIndex = int.Parse(input[0]);
    string direction = input[1];
    int step = int.Parse(input[2]);
    int index = bugIndex;
    if (direction == "left")
    {
        if (index - step < 0)
        {
            field[bugIndex] = 0;
            continue;
        }
        for (int i = field.Length -1; i > bugIndex; i--)
        {
            if (field[i - 1] == 0)
            {
                field[i - 1] = 1;
                field[index] = 0;
                break;
            }
        }

    }
    else
    {
        if (index + step >= field.Length)
        {
            field[bugIndex] = 0;
            continue ;
        }
        for (int i = bugIndex; i < field.Length; i++)
        {
            if (field[i + 1] == 0)
            {
                field[i + 1] = 1;
                field[index] = 0;
                break;
            }
        }
    }
}

foreach (var item in field)
{
    Console.Write(item + " ");
}