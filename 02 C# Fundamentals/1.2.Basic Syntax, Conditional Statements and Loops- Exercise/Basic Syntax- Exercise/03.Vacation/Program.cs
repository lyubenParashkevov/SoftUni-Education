using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            decimal price = 0;
            decimal sum = 0;

            if (dayOfWeek == "Friday")
            {
                if (groupType == "Students")
                {
                    price = 8.45m;
                    sum = peopleCount * price;
                    if (peopleCount >= 30)
                    {

                        sum -= sum * 0.15m;
                    }
                }
                else if (groupType == "Business")
                {
                    price = 10.90m;
                    sum = peopleCount * price;
                    if (peopleCount >= 100)
                    {
                        peopleCount -= 10;
                        sum = peopleCount * price;
                    }
                }
                else if (groupType == "Regular")
                {
                    price = 15.00m;
                    sum = peopleCount * price;
                    if (peopleCount >= 10 && peopleCount <= 20)
                    {
                        sum -= sum * 0.05m;
                    }
                }
            }

            else if (dayOfWeek == "Saturday")
            {
                if (groupType == "Students")
                {
                    price = 9.80m;
                    sum = peopleCount * price;
                    if (peopleCount >= 30)
                    {
                        sum -= sum * 0.15m;
                    }
                }
                else if (groupType == "Business")
                {
                    price = 15.60m;
                    sum = peopleCount * price;
                    if (peopleCount >= 100)
                    {
                        peopleCount -= 10;
                        sum = peopleCount * price;
                    }
                }
                else if (groupType == "Regular")
                {
                    price = 20.00m;
                    sum = peopleCount * price;
                    if (peopleCount >= 10 && peopleCount <= 20)
                    {
                        sum -= sum * 0.05m;
                    }
                }
            }

            else if (dayOfWeek == "Sunday")
            {
                if (groupType == "Students")
                {
                    price = 10.46m;
                    sum = peopleCount * price;
                    if (peopleCount >= 30)
                    {
                        sum -= sum * 0.15m;
                    }
                }
                else if (groupType == "Business")
                {
                    price = 16.00m;
                    sum = peopleCount * price;
                    if (peopleCount >= 100)
                    {
                        peopleCount -= 10;
                        sum = peopleCount * price;
                    }
                }
                else if (groupType == "Regular")
                {
                    price = 22.50m;
                    sum = peopleCount * price;
                    if (peopleCount >= 10 && peopleCount <= 20)
                    {
                        sum -= sum * 0.05m;
                    }
                }
            }

            Console.WriteLine($"Total price: {sum:f2}");
        }
    }
}
