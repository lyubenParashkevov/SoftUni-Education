using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class CargoVan : Vehicle
    {
        public const double maxMileage = 180;
        public CargoVan(string brand, string model, string licensePlateNumber)
            : base(brand, model, maxMileage, licensePlateNumber)
        {

        }

        public override void Drive(double mileage)
        {
            base.Drive(mileage);
            BatteryLevel -= 5;
        }
    }
}
