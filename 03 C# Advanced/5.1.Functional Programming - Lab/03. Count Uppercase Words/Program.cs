namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpper = w => Char.IsUpper(w[0]);

            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] upperCaseWords = words.Where(isUpper).ToArray();

            foreach (string word in upperCaseWords)
            {
                Console.WriteLine(word);
            }

        }

    }
}