namespace _03._Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string keyWord = Console.ReadLine();
                string synonime = Console.ReadLine();

                if (!words.ContainsKey(keyWord))
                {
                    words.Add(keyWord, new List<string>());
                    words[keyWord].Add(synonime);
                }
                else
                {
                    words[keyWord].Add(synonime);

                }
            }

            foreach (var keyWord in words)
            {
                Console.WriteLine($"{keyWord.Key} - {string.Join(", ", keyWord.Value)}");
            }

           
        }
    }
}