namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songList = new Queue<string>(songs);

            while (songList.Count > 0)
            {
                string[] commands = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                switch (command)
                {
                    case "Play":
                        songList.Dequeue();
                        break;

                    case "Add":
                        
                        string songName = string.Join(" ", commands.Skip(1));
                        if (!songList.Contains(songName)) 
                        {
                            songList.Enqueue(songName);
                        }

                        else
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                            break;

                    case "Show":
                        Console.WriteLine($"{string.Join(", ", songList)}");
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}