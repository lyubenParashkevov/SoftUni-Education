namespace _8._Traffic_Jam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            string curentCar = string.Empty;
            Queue<string> cars = new Queue<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    Console.WriteLine($"{counter} cars passed the crossroads.");
                    break;
                }

                else if (input == "green")
                {
                    if (cars.Count == 0)
                        continue;

                    else if (cars.Count >= n)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            curentCar = cars.Dequeue();
                            Console.WriteLine($"{curentCar} passed!");
                            counter++;
                        }
                    }
                    else
                    {
                        for (int i = 0; i <= cars.Count; i++)
                        {
                            curentCar = cars.Dequeue();
                            Console.WriteLine($"{curentCar} passed!");
                            counter++;
                        }
                    }
                }

                else
                {
                    cars.Enqueue(input);
                }
            }
        }
    }
}