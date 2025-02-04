namespace _01._Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
           while (true)
            {
                string input = Console.ReadLine();  

                if (input == "end")
                {
                    break;
                }
                char[] chars = input.Reverse().ToArray();

                    

                Console.WriteLine($"{input} = {string.Join("",chars)}");
            }
        }
    }
}