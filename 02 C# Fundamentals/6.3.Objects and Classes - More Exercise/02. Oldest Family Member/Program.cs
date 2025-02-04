using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Channels;

namespace _02._Oldest_Family_Member
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Family family = new Family();

            List<Person> persons = new List<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] personInfo = Console.ReadLine().Split(' ');
                string name = personInfo[0];
                int age = int.Parse(personInfo[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Console.WriteLine(family.GetOldestMember(persons));
        }
    }

    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }

    public class Family
    {
        public Family()
        {
            this.Persons = new List<Person>();
        }
        public List<Person> Persons { get; set; }

        public void AddMember(Person person)
        {
            Persons.Add(person);
        }


        public Person GetOldestMember(List<Person> Persons)
        {
            Person oldestPerson = this.Persons.OrderByDescending(x => x.Age).FirstOrDefault();
            return oldestPerson;


        }

    }

}