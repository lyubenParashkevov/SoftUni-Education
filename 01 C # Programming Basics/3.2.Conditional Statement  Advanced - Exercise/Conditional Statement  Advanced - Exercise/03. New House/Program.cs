using System;

namespace _03._New_House
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            string flowerTipe = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            decimal rosesPrice = 5.00m;
            decimal dahliasPrice = 3.80m;
            decimal tulipsPrise = 2.80m;
            decimal narcissusPrise = 3.00m;
            decimal gladiolusPrice = 2.50m;
            decimal finalSum = 0;
            if (flowerTipe == "Roses")
            {
               if (numFlowers > 80)
                {
                    finalSum = numFlowers * rosesPrice;
                    finalSum -= finalSum * 0.10m;
                }
               else
                {
                    finalSum = numFlowers * rosesPrice;
                }
                            
            }
            else if (flowerTipe == "Dahlias")
            {
                if (numFlowers > 90)
                {
                    finalSum = numFlowers * dahliasPrice;
                    finalSum -= finalSum * 0.15m;
                }
                else
                {
                    finalSum = numFlowers * dahliasPrice;
                }
            }
            else if (flowerTipe == "Tulips")
            {
                if (numFlowers > 80)
                {
                    finalSum = numFlowers * tulipsPrise;
                    finalSum -= finalSum * 0.15m;
                }
                else
                {
                    finalSum -= numFlowers * tulipsPrise;
                }
            }
            else if (flowerTipe == "Narcissus")
            {
                if (numFlowers < 120)
                {
                    finalSum = numFlowers * narcissusPrise;
                    finalSum += finalSum * 0.15m;
                }
                else
                {
                finalSum = numFlowers * narcissusPrise;
                }
                
            }
            else if (flowerTipe == "Gladiolus")
            {
                if (numFlowers < 80) 
                {
                    finalSum = numFlowers * gladiolusPrice;
                    finalSum += finalSum * 0.20m;
                }
                else
                {
                    finalSum = numFlowers * gladiolusPrice ;
                }
            }
            if (budget >= finalSum)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {flowerTipe} and {budget - finalSum:f2} leva left.");
            }
            else if (budget < finalSum)
            {
                Console.WriteLine($"Not enough money, you need {finalSum - budget:f2} leva more.");
            }


            
        }
    }
}
