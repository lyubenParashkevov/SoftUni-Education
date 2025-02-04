namespace _01_03._The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string pieceName = pieceInfo[0];
                string composer = pieceInfo[1];
                string key = pieceInfo[2];

                pieces.Add(pieceName, new List<string>());
                pieces[pieceName].Add(composer);
                pieces[pieceName].Add(key);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                string[] commands = input.Split('|');
                string command = commands[0];

                if (command == "Add")
                {
                    string pieceName = commands[1];
                    string composer = commands[2];
                    string key = commands[3];

                    if (!pieces.ContainsKey(pieceName))
                    {
                        pieces.Add(pieceName, new List<string>());
                        pieces[pieceName].Add(composer);
                        pieces[pieceName].Add(key);

                        Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{pieceName} is already in the collection!");
                    }
                }
                else if (command == "Remove")
                {
                    string pieceName = commands[1];

                    if (pieces.ContainsKey(pieceName))
                    {
                        pieces.Remove(pieceName);
                        Console.WriteLine($"Successfully removed {pieceName}!");
                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
                else if (command == "ChangeKey")
                {
                    string pieceName = commands[1];
                    string newKey = commands[2];

                    if (pieces.ContainsKey(pieceName))
                    {
                        pieces[pieceName].Remove(pieces[pieceName][1]);
                        pieces[pieceName].Add(newKey);
                        Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");

                    }
                    else
                    {
                        Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
                    }
                }
            }
            foreach (var piece in pieces)
            {
                Console.WriteLine($"{piece.Key} -> Composer: {piece.Value[0]}, Key: {piece.Value[1]}");
            }
        }
    }
}