using System.Globalization;

namespace _06._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> list = new List<Vehicle>();
            int carHpSum = 0;
            int truckHpSum = 0;
            double averageCarHp = 0;
            double averageTruckHp = 0;
            int carCounter = 0;
            int truckCounter = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] vehicleInformation = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string typeOfVehicle = vehicleInformation[0];
                string model = vehicleInformation[1];
                string colour = vehicleInformation[2];
                int horsePower = int.Parse(vehicleInformation[3]);

                if (typeOfVehicle == "car")
                {
                    carHpSum += horsePower;
                    carCounter++;
                }
                else
                {
                    truckHpSum += horsePower;
                    truckCounter++;
                }
                Vehicle vehicle = new Vehicle
                {
                    TypeOfVehicle = typeOfVehicle,
                    Model = model,
                    Colour = colour,
                    HorsePower = horsePower
                };
                list.Add(vehicle);
            }



            while (true)
            {
                string newInput = Console.ReadLine();

                
                if (newInput == "Close the Catalogue")
                {
                    break;
                }
                foreach (Vehicle vehicle in list)
                {
                    if (vehicle.Model == newInput)
                    {
                        vehicle.VeihicleInfo();
                    }
                }
                
            }

            if (carCounter == 0)
            {
                averageCarHp = 0;
            }
            else
            {
                averageCarHp = (double)carHpSum / carCounter;
            }

            if (truckCounter == 0)
            {
                averageTruckHp = 0;
            }

            else
            {
                averageTruckHp = (double)truckHpSum / truckCounter;
            }      

            Console.WriteLine($"Cars have average horsepower of: {averageCarHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageTruckHp:f2}.");
        }


        public class Vehicle
        {
            public string TypeOfVehicle { get; set; }
            public string Model { get; set; }

            public string Colour { get; set; }
            public int HorsePower { get; set; }

            public void VeihicleInfo()
            {
                if (TypeOfVehicle == "car")
                {
                    Console.WriteLine($"Type: Car");
                }
                else
                {
                    Console.WriteLine($"Type: Truck");
                }

                Console.WriteLine($"Model: {Model}");
                Console.WriteLine($"Color: {Colour}");
                Console.WriteLine($"Horsepower: {HorsePower}");
            }


        }

    }
}