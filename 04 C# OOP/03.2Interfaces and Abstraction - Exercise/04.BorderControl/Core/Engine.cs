using _04.BorderControl.Core.Interfaces;
using _04.BorderControl.Models;
using _04.BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BorderControl.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IWalkable> walkables = new List<IWalkable>();
            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (tokens.Length == 3)
                {
                    IWalkable citizen = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]);
                    walkables.Add(citizen);
                }
                else
                {
                    IWalkable robot = new Robot(tokens[0], tokens[1]);
                    walkables.Add(robot);
                }
            }

            string fakeIdEnd = Console.ReadLine();

            foreach (var walkable in walkables)
            {
                if (walkable.Id.EndsWith(fakeIdEnd))
                {
                    Console.WriteLine(walkable.Id);
                }
            }
        }
    }
}
