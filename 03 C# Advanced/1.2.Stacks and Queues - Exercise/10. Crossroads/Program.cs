namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int openTime = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int counter = 0;
            int resetGreenLightDuration = greenLightDuration;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                if (input == "green")
                {
                    greenLightDuration = resetGreenLightDuration;
                    while (cars.Count > 0 && greenLightDuration > 0)
                    {
                        string curentCar = cars.Dequeue();
                        int carLength = curentCar.Length;

                        if (carLength <= greenLightDuration)
                        {
                            greenLightDuration -= carLength;
                            counter++;
                        }

                        else if (carLength > greenLightDuration)
                        {
                            carLength -= greenLightDuration;
                            greenLightDuration = 0;
                            if (carLength <= openTime)
                            {
                                counter++;
                            }
                            else
                            {
                                carLength -= openTime;
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{curentCar} was hit at {curentCar[curentCar.Length - carLength]}.");
                                return;
                            }
                        }
                    }
                }

                else
                {
                    string carName = input;
                    cars.Enqueue(carName);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}