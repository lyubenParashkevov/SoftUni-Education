
using RawData;

List<Car> cars = new List<Car>();

int carsNumber = int.Parse(Console.ReadLine());

for (int i = 0; i < carsNumber; i++)
{
    string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string model = carInfo[0];
    int engineSpeed = int.Parse(carInfo[1]);
    int enginePower = int.Parse(carInfo[2]);
    int cargoWeight = int.Parse(carInfo[3]);
    string cargoType = carInfo[4];
    double tire1Pressure = double.Parse(carInfo[5]);
    int tire1Year = int.Parse(carInfo[6]);
    double tire2Pressure = double.Parse(carInfo[7]);
    int tire2Year = int.Parse(carInfo[8]);
    double tire3Pressure = double.Parse(carInfo[9]);
    int tire3Year = int.Parse(carInfo[10]);
    double tire4Pressure = double.Parse(carInfo[11]);
    int tire4Year = int.Parse(carInfo[12]);

    Engine engine = new Engine(engineSpeed, enginePower);

    Cargo cargo = new Cargo(cargoType, cargoWeight);

    Tire Tire1 = new Tire(tire1Year, tire1Pressure); 
    Tire Tire2 = new Tire(tire2Year, tire2Pressure);
    Tire Tire3 = new Tire(tire3Year, tire3Pressure);
    Tire Tire4 = new Tire(tire4Year, tire4Pressure);

    Tire[] tires = new Tire[4] { Tire1, Tire2, Tire3, Tire4 };

    Car Car = new Car(model, engine, cargo, tires);

    cars.Add(Car);

}

string cargoToCheck = Console.ReadLine();

if (cargoToCheck == "fragile")        
{
    foreach (var car in cars.Where(c => c.Cargo.Type == "fragile").Where(c => c.Tires.Any(t => t.Pressure < 1)))
    {
        Console.WriteLine(car.Model);
    }
}
else if (cargoToCheck == "flammable")    
{
    foreach (var car in cars.Where(c => c.Cargo.Type == "flammable").Where(c => c.Engine.Power > 250))
    {
        Console.WriteLine(car.Model);
    }
}

