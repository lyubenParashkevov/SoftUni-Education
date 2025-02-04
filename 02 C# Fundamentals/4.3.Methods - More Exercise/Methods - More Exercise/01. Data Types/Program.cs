namespace _01._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            string input = Console.ReadLine();
            PrintOutputAcordingToDataType(dataType, input);
        }
         
        static void PrintOutputAcordingToDataType(string dataType, string input)
        {

            if (dataType == "int")
            {
                int number = int.Parse(input);
                Console.WriteLine(number * 2);
            }
            else if (dataType == "real")
            {
                double number = double.Parse(input);
                Console.WriteLine($"{number * 1.5:f2}");
            }
            else if (dataType == "string")
            {
                Console.WriteLine($"${input}$");
            }
        }

    }
}