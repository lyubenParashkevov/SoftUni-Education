using System;

namespace _04._Cinema_Voucher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ticketNum = 0;
            int productsNum = 0;
            string ticket = "";
            string product = "";
            double ticketPrice = 0;
            double productPrice = 0;
            double budget = double.Parse(Console.ReadLine());

            while (true)
            {

                string input = Console.ReadLine();
                char ch = input[0];
                char ch2 = input[1];
                if (input == "End")
                {
                    Console.WriteLine(ticketNum);
                    Console.WriteLine(productsNum);
                    break;
                }
                else if (input.Length > 8)
                {
                    input = ticket;
                    ticketNum++;
                    ticketPrice = ch + ch2;
                    budget -= ticketPrice;
                }
                else if (input.Length <= 8)
                {
                    input = product;
                    productsNum++;
                    productPrice = ch;
                    budget -= productPrice;
                }
                if (budget < productPrice)
                {
                Console.WriteLine(ticketNum);
                Console.WriteLine(productsNum);
                break;

                }
            }

        }
    }
}
