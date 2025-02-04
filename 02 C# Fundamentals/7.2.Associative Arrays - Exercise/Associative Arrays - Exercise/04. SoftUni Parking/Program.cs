namespace _04._SoftUni_Parking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkingRegister = new Dictionary<string, string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] commandAndInfo = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = commandAndInfo[0];
                string username = "";
                string licensePlateNumber = "";

                if (command == "register")
                {
                     username = commandAndInfo[1];
                     licensePlateNumber = commandAndInfo[2];

                    if (!parkingRegister.ContainsKey(username))
                    {
                        parkingRegister.Add(username, licensePlateNumber);

                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlateNumber}");
                    }
                }

                else if (command == "unregister")
                {
                     username = commandAndInfo[1];
                    

                    if (!parkingRegister.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                    }
                    else
                    {
                        parkingRegister.Remove(username);

                        Console.WriteLine($"{username} unregistered successfully");
                    }

                }
            }
            foreach (var user in parkingRegister)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }

        }
    }
}