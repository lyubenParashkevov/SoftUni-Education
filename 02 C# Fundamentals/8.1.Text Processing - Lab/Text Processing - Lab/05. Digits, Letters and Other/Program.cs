using System.Text;

namespace _05._Digits__Letters_and_Other
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            StringBuilder numbers = new StringBuilder();
            StringBuilder letters = new StringBuilder(); 
            StringBuilder chars = new StringBuilder();
            foreach (var ch in text)
            {
                if (char.IsDigit(ch))
                {
                    numbers.Append(ch);
                }
                else if (char.IsLetter(ch))
                {
                    letters.Append(ch);
                }
                else
                {
                    chars.Append(ch);
                }
            }
            Console.WriteLine(numbers);
            Console.WriteLine(letters);
            Console.WriteLine(chars);        }
    }
}