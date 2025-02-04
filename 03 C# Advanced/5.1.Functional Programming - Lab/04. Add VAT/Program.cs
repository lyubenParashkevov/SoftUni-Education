namespace _04._Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            double[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            Vat(numbers, v => v * 1.20);

            foreach (double v in numbers)
            {
                Console.WriteLine($"{v:f2}");
            }
        }      

        static double[] Vat(double[] numbers, Func<double, double> operation)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = operation(numbers[i]);
            }
            return numbers;
        } 
    }
}