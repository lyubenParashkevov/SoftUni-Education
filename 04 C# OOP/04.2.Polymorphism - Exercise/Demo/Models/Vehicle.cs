using Demo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class Vehicle : IVehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public void Drive(int distance)
        {
            double curentFuelQuantity = FuelQuantity;

            if ((FuelQuantity -= distance * FuelConsumption) < 0)
            {
                FuelQuantity = curentFuelQuantity;
            }
            else
            {
                FuelQuantity -= distance * FuelConsumption;
            }
            
        }

        public void Refuel(int liters)
        {
            throw new NotImplementedException();
        }
    }
}
