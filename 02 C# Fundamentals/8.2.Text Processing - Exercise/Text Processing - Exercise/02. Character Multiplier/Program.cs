using System.ComponentModel.Design;

namespace _02._Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string firstString = strings[0];
            string secondString = strings[1];
            int diference = Math.Abs(firstString.Length - secondString.Length);
            int sum = 0;
            if (firstString.Length == secondString.Length)
            {

                for (int i = 0; i < secondString.Length; i++)
                {
                    sum += firstString[i] * secondString[i];
                }
                Console.WriteLine(sum);
            }

            else if (firstString.Length >= secondString.Length)
            {
                for (int i = 0; i < secondString.Length; i++)
                {
                    sum += firstString[i] * secondString[i];
                }
               
                for (int j = firstString.Length; j > firstString.Length - diference; j--)
                {
                    sum += firstString[j];
                }
                Console.WriteLine(sum);
            }
            else
            {
                for (int i = 0; i < firstString.Length; i++)
                {
                    sum += firstString[i] * secondString[i];
                }
                

                for (int k = secondString.Length - 1; k > secondString.Length - 1 - diference; k--)
                {
                    sum += secondString[k];
                }
                Console.WriteLine(sum);
            }

        }
    }
}