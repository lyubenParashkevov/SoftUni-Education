using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double DefaultFuelConsumption = 3;
        public Car(int horsePoewer, double fuel) : base(horsePoewer, fuel)
        {
        }

        public override double FuelConsumption => DefaultFuelConsumption;
    }
}
