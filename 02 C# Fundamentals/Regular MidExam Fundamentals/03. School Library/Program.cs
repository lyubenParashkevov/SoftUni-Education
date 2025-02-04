namespace _03._School_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shelfBooks = Console.ReadLine().Split('&', StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Done")
                {
                    break;
                }

                string[] commands = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = commands[0];

                if (command == "Add Book")
                {
                    string bookName = commands[1];
                    if (shelfBooks.Contains(bookName))
                    {
                        continue;
                    }
                    else
                    {
                        shelfBooks.Insert(0, bookName);
                    }
                }
                else if (command == "Take Book")
                {
                    string bookName = commands[1];
                    if (shelfBooks.Contains(bookName))
                    {
                        shelfBooks.Remove(bookName);
                    }
                }
                else if (command == "Swap Books")
                {
                    string firstBook = commands[1];
                    string secondBook = commands[2];
                    int firstIndex = 0;
                    int secondIndex = 0;

                    if (!shelfBooks.Contains(firstBook) || !shelfBooks.Contains(secondBook))
                    {
                        continue;
                    }
                    for (int i = 0; i < shelfBooks.Count; i++)
                    {
                        if (shelfBooks[i] == firstBook)
                        {
                            firstIndex = i;
                        }
                        if (shelfBooks[i] == secondBook)
                        {
                            secondIndex = i;
                        }
                    }
                    string curbook = shelfBooks[firstIndex];
                    shelfBooks[firstIndex] = secondBook;
                    shelfBooks[secondIndex] = curbook;

                }
                else if (command == "Insert Book")
                {
                    string bookName = commands[1];
                    if (!shelfBooks.Contains(bookName))
                    {
                        shelfBooks.Add(bookName);
                    }
                }
                else if (command == "Check Book")
                {
                    int index = int.Parse(commands[1]);
                    if (index < 0 || index > shelfBooks.Count - 1)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(shelfBooks[index]);
                    }
                }
            }

            Console.WriteLine(String.Join(", ", shelfBooks));
        }
    }
}