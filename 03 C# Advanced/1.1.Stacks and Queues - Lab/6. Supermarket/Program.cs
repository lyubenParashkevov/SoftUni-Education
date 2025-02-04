namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();

            while (true)
            {
                string name = Console.ReadLine();

                if (name == "End")
                {
                    Console.WriteLine($"{names.Count} people remaining.");

                    break;
                }

                else if (name == "Paid")
                {
                    while (names.Count > 0)
                    {
                        Console.WriteLine(names.Dequeue());
                    }                  
                }

                else
                {
                    names.Enqueue(name);
                }
            }
        }
    }
}