using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;


        public Family()
        {
            this.people = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person person)
        {
            this.people.Add(person);
        }

        public void GetOver30Members()
        {
            List<Person> oldPeople = new List<Person>();

            foreach (Person person in this.people.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
            
        }
    }
}
