
using BirthdayCelebrations.Core.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            
            List<IBuyer> buyers = new List<IBuyer>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = tokens[0];

                if (type == "Citizen")
                {
                    IBirthable citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], tokens[4]);
                    birthable.Add(citizen);
                }
                else if (type == "Pet")
                {
                    IBirthable pet = new Pet(tokens[1], tokens[2]);
                    birthable.Add(pet);
                }
                else
                {
                    Robot robot = new Robot(tokens[1], tokens[2]);
                }
            }

            
        }
    }
}
