namespace _4._List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] inputArray = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (inputArray[0] == "Add")
                {
                    numbers.Add(int.Parse(inputArray[1]));
                }

                else if (inputArray[0] == "Insert")
                {
                    if (int.Parse(inputArray[2]) > numbers.Count || int.Parse(inputArray[2]) < 0 || int.Parse(inputArray[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");

                    }
                    else
                    {

                        numbers.Insert(int.Parse(inputArray[2]), int.Parse(inputArray[1]));
                    }
                }

                else if (inputArray[0] == "Remove")
                {
                    if (int.Parse(inputArray[1]) > numbers.Count || int.Parse(inputArray[1]) < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(int.Parse(inputArray[1]));
                    }
                }

                else if (inputArray[1] == "left")
                {
                    for (int i = 0; i < int.Parse(inputArray[2]); i++)
                    {
                        int curNum = numbers[0];
                        for (int j = 0; j < numbers.Count - 1; j++)
                        {
                            numbers[j] = numbers[j + 1];

                        }
                        numbers[numbers.Count - 1] = curNum;
                    }
                }
                else if (inputArray[1] == "right")
                {
                    for (int i = numbers.Count - 1; i > (numbers.Count - 1) - int.Parse(inputArray[2]); i--)
                    {
                        int curNum = numbers[numbers.Count - 1];
                        for (int j = numbers.Count - 1; j > 0; j--)
                        {
                            numbers[j] = numbers[j - 1];
                        }
                        numbers[0] = curNum;
                    }
                }
            }
            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}