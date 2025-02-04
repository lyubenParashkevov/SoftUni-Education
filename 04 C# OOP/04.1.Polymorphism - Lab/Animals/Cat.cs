using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Cat : Animal
    {
        
        public Cat(string name, string favoriteFood) : base(name, favoriteFood)
        {
           
        }

        public string Sound = "MEEOW";
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + "MEEOW";
             
        }
    }
}
