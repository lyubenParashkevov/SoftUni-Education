using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Models.Interfaces
{
    public interface IVehicle
    {

        public double FuelQuantity { get; }
        public double FuelConsumption { get; }

        string Drive(double kilometers);
        void Refuel(double liters);
    }
}
