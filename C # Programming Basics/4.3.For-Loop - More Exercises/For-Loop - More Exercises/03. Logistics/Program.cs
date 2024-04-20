using System;

namespace _03._Logistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int loadNum = int.Parse(Console.ReadLine());
            
            double price = 0;
            double loadSum = 0;
            double busSum = 0;
            double truckSum = 0;
            double trainSum = 0;
            double averagePrice = 0;
            double busLoad = 0;
            double truckLoad = 0;
            double trainLoad = 0;
            for (int i = 1; i <= loadNum; i++)
            {
                int loadWeight = int.Parse(Console.ReadLine());
                if (loadWeight <= 3)
                {
                    price = 200;
                    busSum += loadWeight * price;
                    busLoad += loadWeight;
                }
                else if (loadWeight <= 11)
                {
                    price = 175;
                    truckSum += loadWeight * price;
                    truckLoad += loadWeight;
                }

                else if (loadWeight >= 12)
                {
                    price = 120;
                    trainSum += loadWeight * price;
                    trainLoad += loadWeight;
                }
                loadSum += loadWeight;
                averagePrice = (busSum + truckSum + trainSum) / loadSum;
                
            }
            Console.WriteLine($"{averagePrice:f2}");
            Console.WriteLine($"{busLoad / loadSum * 100:f2}%");
            Console.WriteLine($"{truckLoad / loadSum * 100:f2}%");
            Console.WriteLine($"{trainLoad / loadSum * 100:f2}%");
        }
    }
}
