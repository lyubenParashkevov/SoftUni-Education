using System.Xml.Linq;

namespace _03._Followers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> folowers = new Dictionary<string, List<int>>();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Log out")
                {
                    break;
                }
                string[] commands = input.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                

                if (command == "New follower")
                {
                    string username = commands[1];
                    if (!folowers.ContainsKey(username))
                    {
                        folowers.Add(username, new List<int>());
                        folowers[username].Add(0);
                        folowers[username].Add(0);
                    }
                }
                else if (command == "Like")
                {
                    string username = commands[1];
                    int likeCount = int.Parse(commands[2]);

                    if (!folowers.ContainsKey(username))
                    {
                        folowers.Add(username, new List<int>());
                        folowers[username].Add(0);
                        folowers[username].Add(0);
                    }
                    folowers[username][0] += likeCount;

                }
                else if (command == "Comment")
                {
                    string username = commands[1];
                    if (!folowers.ContainsKey(username))
                    {
                        folowers.Add(username, new List<int>());
                        folowers[username].Add(0);
                        folowers[username].Add(1);
                    }
                    else
                    {
                        folowers[username][1] += 1;
                    }
                }
                else if (command == "Blocked")
                {
                    string username = commands[1];
                    if (folowers.ContainsKey(username))
                    {
                        folowers.Remove(username);
                    }
                    else
                    {
                        Console.WriteLine($"{username} doesn't exist.");
                    }
                }
            }

            Console.WriteLine($"{folowers.Count} followers");

            foreach (var username in folowers)
            {
                Console.WriteLine($"{username.Key}: {username.Value[0] + username.Value[1]}");
            }
        }
    }
}