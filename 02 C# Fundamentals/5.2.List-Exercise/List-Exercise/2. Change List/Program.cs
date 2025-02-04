namespace _2._Change_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] inputArray = input.Split();

                if (inputArray[0] == "Delete")
                {
                    numbers.RemoveAll(x => x == int.Parse(inputArray[1]));
                }
                else if (inputArray[0] == "Insert")
                {
                    numbers.Insert(int.Parse(inputArray[2]), int.Parse(inputArray[1]));
                }

            }
            Console.WriteLine(string.Join(' ',numbers));
        }
    }
}