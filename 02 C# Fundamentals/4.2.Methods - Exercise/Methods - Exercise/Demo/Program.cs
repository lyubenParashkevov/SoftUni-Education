string word = Console.ReadLine();
Print(word);

static void Print(string word)
{
    int counter = 0;
    char[] vowels = new[] { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U', 'Y', 'y'  };

    //foreach (char c in vowels)
    //{
    //    if (word.Contains(c))
    //    {
    //        counter++;
    //    }
    //}

    for (int i = 0; i < word.Length; i++)
    {
        if (vowels.Contains(word[i]))
        {
            counter++;
        }
    }
    Console.WriteLine(counter);
}