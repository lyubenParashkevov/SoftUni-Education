using System;

namespace _12._Trade_Commissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            
            

            string town = Console.ReadLine();
            double sellings = double.Parse(Console.ReadLine());
            double comision = 0;

            if (town == "Sofia" && sellings >= 0)
            {
                if (sellings >= 0 && sellings <= 500) comision = sellings * 0.05;
                else if (sellings > 500 && sellings <= 1000) comision = sellings * 0.07;
                else if (sellings > 1000 && sellings <= 10000) comision = sellings * 0.08;
                else comision = sellings * 0.12;
                Console.WriteLine($"{comision:f2}");
            }
            else if (town == "Varna" && sellings >= 0)

            {
                if (sellings >= 0 && sellings <= 500) comision = sellings * 0.045;
                else if (sellings > 500 && sellings <= 1000) comision = sellings * 0.075;
                else if (sellings > 1000 && sellings <= 10000) comision = sellings * 0.10;
                else comision = sellings * 0.13;
                Console.WriteLine($"{comision:f2}");
            }
            else if (town == "Plovdiv" && sellings >= 0)
            {
                if (sellings >= 0 && sellings <= 500) comision = sellings * 0.055;
                else if (sellings > 500 && sellings <= 1000) comision = sellings * 0.08;
                else if (sellings > 1000 && sellings <= 10000) comision = sellings * 0.12;
                else comision = sellings * 0.145;
                Console.WriteLine($"{comision:f2}");
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
