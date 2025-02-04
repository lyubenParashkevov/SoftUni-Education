using System.ComponentModel.DataAnnotations;

List<string> text = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

while (true)
{
    Console.WriteLine(9 / 4);
    string tokens = Console.ReadLine();

    if (tokens == "3:1")
    {
        break;
    }

    string[] commands = tokens.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];
    if (command == "merge")
    {
        int start = int.Parse(commands[1]);
        int end = int.Parse(commands[2]);
        if (end >= text.Count)
        {
            if (text.Count >= 2)
            {
                end = text.Count - 1;
            }
            else
            {
                continue;
            }
        }
        if (start >= text.Count)
        {
            start = 0;
        }
        for (int i = start + 1; i <= end; i++)
        {
            text[start] += text[i];
        }
        text.RemoveRange(start + 1, end - start);

    }
    else    //divide
    {
        int index = int.Parse(commands[1]);
        int divider = int.Parse(commands[2]);
        string word = text[index];
        text.RemoveAt(index);
        string substring = "";

        int subLength = word.Length / divider;

        for (int i = 0; i < divider; i++)
        {
            for (int j = 0; j < subLength; j++)
            {
                substring += word[j];
            }
            word = word.Remove(0, subLength);
            text.Insert(index + i, substring);
            substring = string.Empty;
        }
        if (word.Length > 0)
        {
            text[text.Count - 1] += word;
        }


    }
}

Console.WriteLine(string.Join(" ", text));

//Ivo Johny Tony Bony Mony