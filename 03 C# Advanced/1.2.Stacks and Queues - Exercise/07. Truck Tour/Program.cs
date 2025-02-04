namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> pumps = new Queue<int>();
            Queue<int> distances = new Queue<int>();
            int pumpNumber = int.Parse(Console.ReadLine());
            int petrolSum = 0;
            int distanceSum = 0;
            for (int i = 0; i < pumpNumber; i++)
            {
                int[] quantityAndDistance = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int petrol = quantityAndDistance[0];
                int distance = quantityAndDistance[1];
                pumps.Enqueue(petrol);
                distances.Enqueue(distance);
            }
            int indexCounter = 0;
            int tempCounter = 0;

            while (true)
            {
                tempCounter = indexCounter;

                bool isDone = false;
                for (int i = 0; i < pumpNumber; i++)
                {
                    
                    if (i == pumpNumber - 1)
                    {
                        isDone = true;
                        break;
                    }

                    int curPump = pumps.Dequeue();
                    int curDistance = distances.Dequeue();
                    petrolSum += curPump;
                    distanceSum += curDistance;

                    if (petrolSum < distanceSum)
                    {
                        pumps.Enqueue(curPump);
                        distances.Enqueue(curDistance);

                        petrolSum = 0;
                        distanceSum = 0;
                        indexCounter++;
                        break;
                    }
                    pumps.Enqueue(curPump);
                    distances.Enqueue(curDistance);
                    indexCounter++;

                }

                if (isDone)
                {
                    break;
                }

            }
            Console.WriteLine(tempCounter);
        }
    }
}