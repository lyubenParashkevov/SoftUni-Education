namespace _07._Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> arrays = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

            List<int> numbers = arrays.Select(int.Parse).ToList();
            Console.WriteLine(string.Join(' ',numbers));
        }
    }
}