namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();

            foreach (var word in words.Where(x => x.Length % 2 == 0))
            {
                Console.WriteLine(word);
            }
        }
    }
}