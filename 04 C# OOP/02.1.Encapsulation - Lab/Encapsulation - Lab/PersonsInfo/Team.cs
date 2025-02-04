﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    internal class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;
        public Team(string name)
        {
            Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        } 

        public string Name { get; private set; }
        public IReadOnlyCollection<Person> FirstTeam 
        { 
            get
            {
                return this.firstTeam.AsReadOnly();
            }
        }
        public IReadOnlyCollection<Person> ReserveTeam 
        {
            get
            {
                return this.reserveTeam.AsReadOnly();
            }
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }

    }
}
