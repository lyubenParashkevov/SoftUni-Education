using System.Reflection;

namespace _07._Vehicle_Catalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] vehicles = input.Split('/', StringSplitOptions.RemoveEmptyEntries);

                if (vehicles[0] == "Car")
                {
                    Car car = new Car
                    {
                        Brand = vehicles[1],
                        Model = vehicles[2],
                        HorsePower = int.Parse(vehicles[3])
                    };
                    cars.Add(car);

                }
                else
                {
                    Truck truck = new Truck
                    {
                        Brand = vehicles[1],
                        Model = vehicles[2],
                        Weight = int.Parse(vehicles[3])
                    };
                    trucks.Add(truck);
                }
            }
            Console.WriteLine("Cars:");

            foreach (Car car in cars.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");

            foreach (Truck truck in trucks.OrderBy(x => x.Brand))
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }



        // class Catalog
        // {
        //     List<Car> cars { get; set; }
        //     List<Truck> trucks { get; set; }
        //
        //
        // }
        class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }

        }

        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }
    }
}