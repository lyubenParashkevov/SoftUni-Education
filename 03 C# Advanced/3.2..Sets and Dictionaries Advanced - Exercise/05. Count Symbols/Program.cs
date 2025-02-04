namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> symbolsAndCount = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                if (!symbolsAndCount.ContainsKey(text[i]))
                {
                    symbolsAndCount.Add(text[i], 0);
                }

                symbolsAndCount[text[i]]++;
            }

            foreach (var symbol in symbolsAndCount)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}