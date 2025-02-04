namespace _06._Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintMidleChar(input);
        }
        static void PrintMidleChar(string input)
        {
            string midleChar = String.Empty;
            int counter = 0;
            
            for (int i = 0; i < input.Length; i++)
            {
                counter++;
            }
            if (counter % 2 == 0)
            {
                midleChar += input[input.Length / 2 - 1];
            }
            if (counter == 2)
            {
                Console.WriteLine(input);
                return;
            }
          
            midleChar += input[input.Length / 2];
            Console.WriteLine(midleChar);

        }
    }
}