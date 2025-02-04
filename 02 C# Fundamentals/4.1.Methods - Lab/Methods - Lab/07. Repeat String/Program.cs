namespace _07._Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());

             RepeatString(text, n);
        }

        static void RepeatString(string text, int n)
        {           
            for (int i = 1; i <= n; i++)
            {
                Console.Write(text);
                
            }           
        }
    }
}