namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();
            {
                car.Make = "VW";
                car.Model = "MK3";
                car.Year = 1992;
                car.FuelQuantity = 100;
                car.FuelConsumption = 2;
                car.Drive(10);

                Console.WriteLine(car.WhoAmI());
            }

        }
    }
}