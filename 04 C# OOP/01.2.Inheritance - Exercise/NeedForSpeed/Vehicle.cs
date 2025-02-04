using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public abstract class Vehicle
    {
        private const double DefaultConsumption = 1.25;

        private double fuel;
        public Vehicle(int horsePoewer, double fuel)
        {
            HoresePower = horsePoewer;
            Fuel = fuel;
        }
        public int HoresePower { get; set; }
        public double Fuel { get; set; }
       
    
        public virtual double FuelConsumption { get { return DefaultConsumption; } }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }
    }
}
