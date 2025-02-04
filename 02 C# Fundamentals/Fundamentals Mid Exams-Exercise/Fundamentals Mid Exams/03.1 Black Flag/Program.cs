namespace _03._1_Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int plunderDays = int.Parse(Console.ReadLine());
            int dayProffit = int.Parse(Console.ReadLine());
            double expectedProffit = double.Parse(Console.ReadLine());
            double total = 0;

            for (int i = 1; i <= plunderDays; i++)
            {
                total += dayProffit;

                if (i % 3 == 0)
                {
                    total += dayProffit * 0.5;
                }
                if (i % 5 == 0)
                {
                    total -= total * 0.3;
                }


            }
            if (total >= expectedProffit)
            {
                Console.WriteLine($"Ahoy! {total:f2} plunder gained.");
            }
            else
            {
                double percentSum = total / expectedProffit * 100;

                Console.WriteLine($"Collected only {percentSum:f2}% of the plunder.");
            }

        }
    }
}