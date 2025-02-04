namespace SpeedRacing;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = carInfo[0];
            double fuelAmount = double.Parse(carInfo[1]);
            double fuelConsumptionPerKm = double.Parse(carInfo[2]);

            Car car = new Car(model, fuelAmount, fuelConsumptionPerKm, 0);

            cars.Add(car);
        }

        while (true)
        {
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commands[0];

            if (command == "End")
            {
                break;
            }

            string model = commands[1];
            int kmToDrive = int.Parse(commands[2]);

            foreach (Car car in cars.Where(c => c.Model == model))
            {
                car.Drive(kmToDrive);
            }
        }

        foreach (Car car in cars)
        {
            Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TraveledDistance}");
        }
    }
}