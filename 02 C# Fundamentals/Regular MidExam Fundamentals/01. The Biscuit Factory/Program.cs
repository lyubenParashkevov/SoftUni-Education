namespace _01._The_Biscuit_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int biscutsForDay = int.Parse(Console.ReadLine());
            int workersCount = int.Parse(Console.ReadLine());
            int enemyFabricProduction = int.Parse(Console.ReadLine());
            double sum = 0;
            double thirthDaySum = 0;
            int productionForDay = biscutsForDay * workersCount;
            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                    thirthDaySum = productionForDay * 0.75;
                    sum += Math.Floor(thirthDaySum);
                }
                else
                {
                    sum += productionForDay;
                }
            }
            
            Console.WriteLine($"You have produced {sum} biscuits for the past month.");
             if(sum > enemyFabricProduction)
            {
                double percent = sum - enemyFabricProduction;
                double finalPecent = percent / enemyFabricProduction * 100;
                Console.WriteLine($"You produce {finalPecent:f2} percent more biscuits.");
            } else
            {
                double percent = sum / enemyFabricProduction * 100;
                double finalPecent = 100 - percent;
                Console.WriteLine($"You produce {finalPecent:f2} percent less biscuits.");
            }
        }
    }
}