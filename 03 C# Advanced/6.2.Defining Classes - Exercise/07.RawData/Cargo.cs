using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Cargo
    {
        private string type;
        private int weight;

        public Cargo(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
