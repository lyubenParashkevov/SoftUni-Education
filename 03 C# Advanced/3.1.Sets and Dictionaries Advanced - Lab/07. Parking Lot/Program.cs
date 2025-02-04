namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();

            while (true)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                if (command == "END")
                {
                    break;
                }

                string carPlate = input[1];

                if (command == "IN")
                {
                    set.Add(carPlate);
                }

                else
                {
                    set.Remove(carPlate);
                }
            }

            if (set.Count > 0)
            {
                foreach (string line in set)
                {
                    Console.WriteLine(line);
                }
            } 
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}