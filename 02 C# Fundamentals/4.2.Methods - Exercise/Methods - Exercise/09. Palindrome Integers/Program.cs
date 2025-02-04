namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    return;
                }

                int rev = 0;
                int num = int.Parse(input);
                int n = num;
              
                while (num > 0)
                {
                    int dig = num % 10;
                    rev = rev * 10 + dig;
                    num = num / 10;
                }
                if (n == rev)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                
            }
        }

        
    }
}