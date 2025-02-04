namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            Dictionary<double, int> occurrences = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!occurrences.ContainsKey(numbers[i]))
                {
                    occurrences.Add(numbers[i], 0);
                }
                occurrences[numbers[i]]++;
            }

            foreach (var occurrence in occurrences)
            {
                Console.WriteLine($"{occurrence.Key} - {occurrence.Value} times");
            }
        }
    }
}