using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Linq;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            string input1 = input[0];
            
            string input2 = input[1];
            int sum = 0;
            if (input1.Length == 0 || input2.Length == 0)
            {
                sum = 0;
                Console.WriteLine(sum);
                return;

            }
            int length = Math.Abs(input1.Length - input2.Length);

            if (input1.Length >= input2.Length)
            {
                for (int i = 0; i < input2.Length; i++)
                {
                    sum += input1[i] * input2[i];
                }
                for (int j = input2.Length; j < input1.Length; j++)
                {
                    sum += input2[j];
                }
            } 
            else
            {
                for (int i = 0; i < input1.Length; i++)
                {
                    sum += input1[i] * input2[i];
                }
                for (int j = input1.Length; j < input2.Length; j++)
                {
                    sum += input2[j];
                }
            }

            Console.WriteLine(sum);

        }
    }
}