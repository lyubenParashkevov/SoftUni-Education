namespace _09._Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            if (input == "int")
            {
                int firstInt = int.Parse(Console.ReadLine());
                int secondInt = int.Parse(Console.ReadLine());

                Console.WriteLine(GetMax(firstInt, secondInt));
            }
            else if (input == "char")
            {
                char firstChar = char.Parse(Console.ReadLine());    
                char secondChar = char.Parse(Console.ReadLine());

                Console.WriteLine(GetMax(firstChar, secondChar));
            }
            else if (input == "string")
            {
                string firstString = Console.ReadLine();
                string secondString = Console.ReadLine();

                Console.WriteLine(GetMax(firstString, secondString));
            }
            
        }
        static int GetMax(int firstInt, int secondInt)
        {
            if (firstInt > secondInt)
            {
                return firstInt;
            }
            else
            {
                return secondInt;
            }
        }
        static char GetMax(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                return firstChar;
            }
           
                return secondChar;
            
        }
        static string GetMax(string firstString, string secondString)
        {
            int result = firstString.CompareTo(secondString);
            if (result > 0)
            {
                return firstString;
            }
            return secondString;
        }
        
            
    }
}