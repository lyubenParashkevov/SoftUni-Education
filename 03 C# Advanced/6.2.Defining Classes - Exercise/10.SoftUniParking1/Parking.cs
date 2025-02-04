using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniParking
{
    internal class Parking
    {
        public Parking(int capacity)
        {
            Cars = new List<Car>();
            this.capacity = capacity;
        }

        private Dictionary<string, Car> cars;
        private int capacity;

        public List<Car> Cars { get; private set; }
        public int Capacity { get; set; }
        public string AddCar(Car car)
        {
            if (Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (Cars.Count > Capacity)
            {
                return "Parking is full!";
            }

            Cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (Cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                for (int i = 0; i < Cars.Count; i++)
                {
                    if (Cars[i].RegistrationNumber == registrationNumber)
                    {
                        Cars.Remove(Cars[i]);
                        i--;
                    }
                }

                return $"Successfully removed {registrationNumber}";
            }

            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registrationNumber)
        {

            foreach (Car car in cars.Where(c => c.RegistrationNumber == registrationNumber))
            {
                return car;
            }
            return null;
        }
    }
}
