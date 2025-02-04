namespace _04._Raw_Data
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ');
                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);
                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Engine engine = new Engine(engineSpeed, enginePower);

                Car car = new Car(model, cargo, engine);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (Car car in cars.Where(car => car.IsFragile(car.Cargo.CargoType, car.Cargo.CargoWeight)))
                {
                    if (car.Cargo.CargoWeight < 1000)
                    {
                        Console.WriteLine(car.Model);
                    }

                }
            }
            else if (command == "flamable")
            {
                foreach (Car car in cars.Where(car => car.IsFlamable(car.Cargo.CargoType, car.Engine.EnginePower)))
                {
                    if (car.Engine.EnginePower > 250)
                    {
                        Console.WriteLine(car.Model);
                    }
                }
            }
        }
    }

    public class Car
    {
        public Car(string model, Cargo cargo, Engine engine)
        {
            Model = model;
            Cargo = cargo;
            Engine = engine;
        }

        public string Model { get; set; }
        public Cargo Cargo { get; set; }
        public Engine Engine { get; set; }

        public bool IsFragile(string cargoType, int cargoWeight)
        {

            return Cargo.CargoType.Equals(cargoType); //&& Cargo.CargoWeight.Equals(cargoWeight < 1000);

        }

        public bool IsFlamable(string cargoType, int enginePower)
        {
            return Cargo.CargoType.Equals(cargoType); //&& Engine.EnginePower.Equals(enginePower > 250);
        }
    }

    public class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoWeight = cargoWeight;
            this.CargoType = cargoType;
        }

        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }

    public class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            this.EngineSpeed = engineSpeed;
            this.EnginePower = enginePower;
        }

        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }
}