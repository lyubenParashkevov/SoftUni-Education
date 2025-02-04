namespace _01._Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Dictionary<char, int> characters = new Dictionary<char, int>();

            char[] chars = Console.ReadLine().ToCharArray();

            foreach (char ch in chars.Where(x => x != ' '))
            {
                if (!characters.ContainsKey(ch))
                {
                    characters.Add(ch, 0);
                }
                characters[ch]++;
            }

            foreach (var item  in characters)
            {
                Console.WriteLine($"{item.Key} -> {item.Value} ");
            }

        }
    }
}