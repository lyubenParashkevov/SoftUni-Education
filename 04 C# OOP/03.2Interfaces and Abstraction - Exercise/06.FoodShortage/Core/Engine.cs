
using FoodShortage.Core.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {

            List<IBuyer> buyers = new List<IBuyer>();
           
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] buyerInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (buyerInfo.Length == 4)
                {
                    IBuyer citizen = new Citizen(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2], buyerInfo[3]);
                    buyers.Add(citizen);
                }
                else
                {
                    IBuyer rebel = new Rebel(buyerInfo[0], int.Parse(buyerInfo[1]), buyerInfo[2]);
                    buyers.Add(rebel);
                }
            }

            string name;
            while ((name = Console.ReadLine()) != "End")
            {
                foreach (var buyer in buyers.Where(b => b.Name == name))
                {
                    buyer.BuyFood();
                }
            }
            int sum = 0;
            foreach (var buyer in buyers) 
            {
                sum += buyer.Food;           
            }

            Console.WriteLine(sum);
        }
    }
}
