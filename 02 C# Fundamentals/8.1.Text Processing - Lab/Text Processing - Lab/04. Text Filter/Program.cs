namespace _04._Text_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] banedWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();   

            foreach (string word in banedWords)
            {
                
               text = text.Replace(word, new string('*',word.Length));
            }

            Console.WriteLine(text);
        }
    }
}