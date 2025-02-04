
int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

while (true)
{
    string output = "";
    string type = "";
    string coordinates = "";
    string input = Console.ReadLine();
    if (input == "find")
    {
        break;
    }

    Queue<char> queue = new Queue<char>();
    for (int i = 0; i < input.Length; i++)
    {
        queue.Enqueue(input[i]);
    }
    while (queue.Count > numbers.Length)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            int ch = queue.Dequeue() - numbers[i];
            char ch1 = (char)ch;
            output += ch1;
        }
    }
    for (int i = 0; i <= queue.Count; i++)
    {
        int ch = queue.Dequeue() - numbers[i];
        char ch1 = (char)ch;
        output += ch1;
    }


    for (int i = 0; i < output.Length; i++)
    {
        if (output[i] == '&' && type.Length == 0)
        {
            for (int j = i + 1; j < output.Length; j++)
            {
                if (output[j] == '&')
                {
                    break;
                }
                type += output[j];
            }

        }

        else if (output[i] == '<' && coordinates.Length == 0)
        {
            for (int j = i + 1; j < output.Length; j++)
            {
                if (output[j] == '>')
                {
                    break;
                }
                coordinates += output[j];
            }

        }
    }

    Console.WriteLine($"Found {type} at {coordinates}");
}