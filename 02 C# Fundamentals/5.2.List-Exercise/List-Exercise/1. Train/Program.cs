namespace _1._Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int wagonCapasity = int.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }

                string[] passengers = input.Split();
                if (passengers.Length > 1)
                {
                    wagons.Add(int.Parse(passengers[1]));
                }
                else if (passengers.Length == 1)
                {
                    int peopleToAdd = int.Parse(passengers[0]);
                    for (int i = 0; i < wagons.Count; i++)
                    {

                        if (wagons[i] + peopleToAdd <= wagonCapasity)
                        {
                            wagons[i] += peopleToAdd;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine(String.Join(" ", wagons));
        }
    }
}