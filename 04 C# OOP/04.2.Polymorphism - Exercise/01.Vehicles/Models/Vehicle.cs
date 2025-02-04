using _01.Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private double increaseCoeficient;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double increaseCoeficient) 
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.increaseCoeficient = increaseCoeficient;
        }
        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        

        public string Drive(double kilometers)
        {
            double consumption = FuelConsumption + increaseCoeficient;

            if (FuelQuantity < kilometers * consumption)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= consumption;

            return $"{this.GetType().Name} travelled {kilometers} km";
        }

        public virtual void Refuel(double liters) => FuelQuantity += liters;

        public override string ToString()
        => $"{this.GetType().Name}: {FuelQuantity:F2}";
    }
}
