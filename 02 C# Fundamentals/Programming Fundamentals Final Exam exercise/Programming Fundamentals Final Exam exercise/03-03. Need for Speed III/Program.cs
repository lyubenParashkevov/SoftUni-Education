namespace _03_03._Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> cars = new Dictionary<string, List<int>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine().Split('|');
                string carName = carInfo[0];
                int mileage = int.Parse(carInfo[1]);
                int carFuel = int.Parse(carInfo[2]);
                cars.Add(carName, new List<int> { mileage, carFuel });
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Stop")
                {
                    break;
                }
                string[] commands = input.Split(" : ");
                string command = commands[0];

                if (command == "Drive")
                {
                    string carName = commands[1];
                    int distance = int.Parse(commands[2]);
                    int fuel = int.Parse(commands[3]);

                    if (cars[carName][1] - fuel < 0)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[carName][1] -= fuel;
                        cars[carName][0] += distance;
                        Console.WriteLine($"{carName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        if (cars[carName][0] >= 100000)
                        {
                            cars.Remove(carName);
                            Console.WriteLine($"Time to sell the {carName}!");
                        }
                    }
                }
                else if (command == "Refuel")
                {
                    string carName = commands[1];
                    int fuel = int.Parse(commands[2]);

                    if (cars[carName][1] + fuel > 75)
                    {
                        Console.WriteLine($"{carName} refueled with {75 - cars[carName][1]} liters");
                        cars[carName][1] = 75;
                    }
                    else
                    {
                        cars[carName][1] += fuel;
                        Console.WriteLine($"{carName} refueled with {fuel} liters");
                    }
                }
                else if (command == "Revert")
                {
                    string carName = commands[1];
                    int kilometers = int.Parse(commands[2]);

                    cars[carName][0] -= kilometers;
                    if (cars[carName][0] < 10000)
                    {
                        cars[carName][0] = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{carName} mileage decreased by {kilometers} kilometers");
                    }
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }
    }
}