namespace _3._House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] inputArray = input.Split();
                string name = inputArray[0];
                if (input == ($"{name} is going!"))
                {
                    if(names.Any(x => x == name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        names.Add(name);
                    }
                } 
                else if(input == ($"{name} is not going!"))
                {
                    if (names.Any(x => x == name))
                    {
                        names.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }

            }
            for (int i = 0; i < names.Count; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}