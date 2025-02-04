using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string мodel, int power) 
        { 
            this.Model = мodel;
            this.Power = power;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            string displacement = Displacement == 0 ? "n/a" : Displacement.ToString();
            string efficiency = Efficiency ?? "n/a";

            StringBuilder sb = new();

            sb.AppendLine($"{Model}:");
            sb.AppendLine($"    Power: {Power}");
            sb.AppendLine($"    Displacement: {displacement}");
            sb.AppendLine($"    Efficiency: {efficiency}");

            return sb.ToString().TrimEnd();
        }
    }
}
