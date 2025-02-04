namespace _04._1_Counter_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialEnergy = int.Parse(Console.ReadLine());
            int battleCount = 0;
            
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End of battle")
                {
                    break;
                }
                int distance = int.Parse(input);

                if (distance > initialEnergy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {battleCount} won battles and {initialEnergy} energy");
                    return;
                }

                battleCount++;

                initialEnergy -= distance;
                if (battleCount % 3 == 0)

                {
                    initialEnergy += battleCount;
                }
            }

            Console.WriteLine($"Won battles: {battleCount}. Energy left: {initialEnergy}");
        }
    }
}