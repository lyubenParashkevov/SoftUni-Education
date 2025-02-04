namespace _03._Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string substringWordToRemove = Console.ReadLine();
            string word = Console.ReadLine();

            while (word.Contains(substringWordToRemove))
            {
                

                word = word.Remove(word.IndexOf(substringWordToRemove), substringWordToRemove.Length);
            }
            Console.WriteLine(word);


        }
    }
}