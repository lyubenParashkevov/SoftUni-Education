namespace _01._Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal foodKg =decimal.Parse(Console.ReadLine());
            decimal hayKg = decimal.Parse(Console.ReadLine());
            decimal coverKg = decimal.Parse(Console.ReadLine());
            decimal pigKg = decimal.Parse(Console.ReadLine());

            for (int i = 1; i <= 30; i++)
            {
                foodKg -= 0.3m;
                if(foodKg < 0)
                {
                    foodKg = 0;
                }
                if (i % 2 == 0)
                {
                    hayKg -= foodKg * 0.05m;
                }
                if (i % 3 == 0)
                {
                    coverKg -= pigKg / 3;
                }
            }
            if (foodKg > 0 && hayKg > 0 && coverKg > 0)
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodKg:f2}, Hay: {hayKg:f2}, Cover: {coverKg:f2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
        }
    }
}