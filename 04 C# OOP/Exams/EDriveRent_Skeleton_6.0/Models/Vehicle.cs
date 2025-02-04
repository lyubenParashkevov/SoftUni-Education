using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private string licensePlateNumber;
        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            LicensePlateNumber = licensePlateNumber;
            MaxMileage = maxMileage;
            BatteryLevel = 100;
            IsDamaged = false;
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                brand = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public double MaxMileage { get; private set; }

        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber = value;
            }
        }
        public int BatteryLevel { get; protected set; }

        public bool IsDamaged { get; private set; }

        public virtual void Drive(double mileage) //?
        {
           
            double midResult = MaxMileage / mileage;
            double result = Math.Round(100 / midResult);
            BatteryLevel -= (int)result;
        }
        public void Recharge()
        {
            BatteryLevel = 100;
        }
        public void ChangeStatus()
        {
            if (IsDamaged == true)
            {
                IsDamaged = false;
            }
            else
            {
                IsDamaged = true;
            }
        }

        public override string ToString()   ///?
        {
            if (IsDamaged == false)
            {
                return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: OK";

            }
            else
            {
                return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: damaged";
            }

        }
    }
}
