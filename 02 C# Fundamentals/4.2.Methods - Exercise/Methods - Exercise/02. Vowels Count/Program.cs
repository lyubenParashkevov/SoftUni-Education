namespace _02._Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintNumberOfVowels(input);
        }
        static void PrintNumberOfVowels(string input)
        {
            int counter = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a' || input[i] == 'e' || input[i] == 'o' || input[i] == 'u' || input[i] == 'i' || input[i] == 'y' || input[i] == 'A' || input[i] == 'E' || input[i] == 'O' || input[i] == 'U' || input[i] == 'I' || input[i] == 'Y')
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}