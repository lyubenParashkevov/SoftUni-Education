using Demo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Citizen : IBirthable, IBuyer
    {
        public Citizen(string name, int age, string id, string birthadate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthadate;
            Food = 0;
        }
    
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
     

        public string Birthdate {  get; set; }

        public int Food { get; set; }

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
