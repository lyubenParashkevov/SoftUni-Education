using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }
        public string FirstName 
        {
            get => firstName;
            private set
            {
                //if (value.Length < 3)
                //{
                //    throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
                //}
                this.firstName = value;
            } 
        }
        public string LastName
        {
            get => lastName;
            private set
            {
                //if (value.Length < 3)
                //{
                //    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                //}
                this.lastName = value;
            }
        }
        public int Age
        {
            get => age;
            private set
            {
                //if (value <= 0)
                //{
                //    /throw new ArgumentException("Age cannot be zero or a negative integer!");
                //}
                this.age = value;
            }
        }
        public decimal Salary
        {
            get => this.salary;
            private set
            {
                //if (value <= 650)
                //{
                //    throw new ArgumentException("Salary cannot be less than 650 leva!");
                //}
                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal parcentage)
        {
            if (Age < 30)
            {
                Salary += Salary * (parcentage / 2) / 100;
            }
            else
            {
                Salary += Salary * parcentage / 100;
            }
        }
        
        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";

        }
    }
    
}
