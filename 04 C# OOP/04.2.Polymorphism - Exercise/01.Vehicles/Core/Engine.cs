using _01.Vehicles.Core.Interfaces;
using _01.Vehicles.Models;
using _01.Vehicles.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Vehicles.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<IVehicle> vehicles = new List<IVehicle>();

            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2])); 
            vehicles.Add(car);
            string[] truckInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IVehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));
            vehicles.Add(truck);

            int n = int.Parse(Console.ReadLine());
            try
            {
                for (int i = 0; i < n; i++)
                {
                    string[] commandInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string command = commandInfo[0];
                    string vehicle = commandInfo[1];


                    if (command == "Drive")
                    {
                        double kilometers = double.Parse(commandInfo[2]);
                        if (vehicle == "Car")
                        {
                            car.Drive(kilometers);
                        }

                        else
                        {
                            truck.Drive(kilometers);
                        }
                    }
                    else if (command == "Refuel")
                    {
                        double liters = double.Parse(commandInfo[2]);

                        if (vehicle == "Car")
                        {
                            car.Refuel(liters);
                        }

                        else
                        {
                            truck.Refuel(liters);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
    }
}
