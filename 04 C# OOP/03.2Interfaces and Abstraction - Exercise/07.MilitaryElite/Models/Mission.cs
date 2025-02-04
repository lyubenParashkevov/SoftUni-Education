using _07.MilitaryElite.Enums;
using _07.MilitaryElite.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, States states)
        {
            CodeName = codeName;
            States = states;
        }
        public string CodeName { get; private set; }

        public States States { get; private set; }

        public void CompleteMission()
        {
            States  = States.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {States}";
        }
    }
}
