using Demo.Core.Interfaces;
using Demo.Models;
using Demo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IBuyer> buyers = new List<IBuyer>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] people = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (people.Length == 3)
                {
                    IBuyer buyer = new Rebel(people[0], int.Parse(people[1]), people[2]);
                    buyers.Add(buyer);
                }

                else
                {
                    IBuyer buyer = new Citizen(people[0], int.Parse(people[1]), people[2], people[3]);
                    buyers.Add(buyer);
                }
            }

            int sum = 0;
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string name = input;

                foreach (var buyer in buyers.Where(b => b.Name == name))
                {
                    buyer.BuyFood();      
                }
            }

            foreach (var buyer in buyers)
            {
                sum += buyer.Food;
            }

            Console.WriteLine(sum);
        }
    }
}
