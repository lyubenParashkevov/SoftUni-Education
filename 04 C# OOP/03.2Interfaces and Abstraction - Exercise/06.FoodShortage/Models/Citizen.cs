
using FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage.Models
{
    public class Citizen : IBuyer
    {
        private int food = 0;
        
        public Citizen(string name, int age, string id, string birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            BirthDate = birthDate;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public string BirthDate { get; private set; }

        public int Food 
        {
            get => food;
            set
            {
                
                food = value;
            }
                
        }

        public void BuyFood()
        {
            food += 10;
        }
    }
}
