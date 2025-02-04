using System;

namespace _04._Reverse_Array_of_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] toReverse = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

                Array.Reverse(toReverse);
                Console.WriteLine(string.Join(' ',toReverse));
            
        }
    }
}
