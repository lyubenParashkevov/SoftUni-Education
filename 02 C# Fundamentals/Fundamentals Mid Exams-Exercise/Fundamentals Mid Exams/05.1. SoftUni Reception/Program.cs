namespace _05._1._SoftUni_Reception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstWorkerCapacity = int.Parse(Console.ReadLine());
            int secondWorkerCapacity = int.Parse(Console.ReadLine());
            int thirdWorkerCapacity = int.Parse(Console.ReadLine());
            int studrntCount = int.Parse(Console.ReadLine());

            int sumForHour = firstWorkerCapacity + secondWorkerCapacity + thirdWorkerCapacity;
            int hourCounter = 0;
            int restHoursCounter = 0;
            while (studrntCount > 0)
            {
                studrntCount -= sumForHour;
                hourCounter++;
                
                if(hourCounter % 4 == 0)
                {
                    hourCounter++;

                }
            }

            Console.WriteLine($"Time needed: {restHoursCounter + hourCounter}h.");
        }
    }
}