﻿

using System.Net.NetworkInformation;

namespace Inheritance
{
    public class Person
    {
        private string name;
        private int age;
        public Person(string name, int age) 
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public virtual int Age
        {

            get
            {
                return age;
            }
            set
            {
                if(value >= 0)
                {
                    age = value;
                }
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}
