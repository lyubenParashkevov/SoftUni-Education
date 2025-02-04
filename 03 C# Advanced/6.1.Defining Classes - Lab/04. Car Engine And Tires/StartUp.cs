

namespace CarManufacturer;

public class StarтUp
{
    static void Main()
    {

        Tire[] Tires = new Tire[4]
        {
                      new Tire(1, 2.5),
                      new Tire(1, 2.1),
                      new Tire(2, 0.5),
                      new Tire(2, 2.3),
        };

        Engine Engine = new Engine(560, 6300);

        Car Car = new Car("VW", "Golf", 2025, 200, 10, Engine, Tires);

    }
}

