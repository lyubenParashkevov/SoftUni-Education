using System.ComponentModel.Design;
using System.Text;

namespace _06._Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            var input = Console.ReadLine().ToList();

            for (int i = 0; i < input.Count-1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    input.RemoveAt(i);
                   i--;
                }
            }
            Console.WriteLine(string.Join("",input));

        }
    }
}