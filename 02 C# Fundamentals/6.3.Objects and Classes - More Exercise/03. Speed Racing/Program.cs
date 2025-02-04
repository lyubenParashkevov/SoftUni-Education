namespace _03._Speed_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                double fuelAmount = int.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                cars.Add(car);
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ');
                if (commands[0] == "End")
                {
                    break;
                }
                string carModel = commands[1];
                int amountOfKm = int.Parse(commands[2]);
                foreach (Car car in cars.Where(car => car.Model == carModel))
                {
                    car.Drive(carModel, amountOfKm);
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.KmTraveled}");
            }

        }

        public class Car
        {
            public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
            {
                this.Model = model;
                this.FuelAmount = fuelAmount;
                this.FuelConsumptionFor1km = fuelConsumptionFor1km;
            }
            public string Model { get; set; }
            public double FuelAmount { get; set; }
            public double FuelConsumptionFor1km { get; set; }

            public int KmTraveled = 0;

            public void Drive(string carModel, int amountOfKm)
            {
                double fuelForTrip = amountOfKm * FuelConsumptionFor1km;
                if (FuelAmount - fuelForTrip >= 0)
                {
                    FuelAmount -= fuelForTrip;
                    KmTraveled += amountOfKm;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }
        }
    }
}