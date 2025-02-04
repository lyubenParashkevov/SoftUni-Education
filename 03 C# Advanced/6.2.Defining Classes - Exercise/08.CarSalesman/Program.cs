
using CarSalesman;
List<Car> cars = new List<Car>();

List<Engine> engines = new List<Engine>();

int numberOfEngines = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfEngines; i++)
{
    string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string engineModel = engineInfo[0];
    int power = int.Parse(engineInfo[1]);
    int displacement = 0;
    string efficiency = string.Empty;

    Engine engine = CreateEngine(engineInfo);
    engines.Add(engine);
}

int numberOfCars = int.Parse(Console.ReadLine());


for (int i = 0; i < numberOfCars; i++)
{
    string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string carModel = carInfo[0];
    string engine = carInfo[1];

    Car car = CreateCar(carInfo, engines);
    cars.Add(car);  
}

foreach (Car car in cars)
{
    Console.WriteLine(car.ToString().Trim());
}

static Engine CreateEngine(string[] engineInfo)
{
    string engineModel = engineInfo[0];
    int power = int.Parse(engineInfo[1]);

    Engine engine = new Engine(engineModel, power);

    if (engineInfo.Length > 2)
    {
        int displacement;

        bool isDigit = int.TryParse(engineInfo[2], out displacement);

        if (isDigit)
        {
            engine.Displacement = displacement;
        }
        else
        {
            engine.Efficiency = engineInfo[2];
        }

        if (engineInfo.Length > 3)
        {
            engine.Efficiency = engineInfo[3];
        }
    }

    return engine;
}
    static Car CreateCar(string[] carInfo, List<Engine> engines)
    {
        Engine engine = engines.Find(x => x.Model == carInfo[1]);

        Car car = new(carInfo[0], engine);

        if (carInfo.Length > 2)
        {
            int weight;

            bool isDigit = int.TryParse(carInfo[2], out weight);

            if (isDigit)
            {
                car.Weight = weight;
            }
            else
            {
                car.Color = carInfo[2];
            }

            if (carInfo.Length > 3)
            {
                car.Color = carInfo[3];
            }
        }

        return car;
    }

