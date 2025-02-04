namespace _05._Multiplication_Sign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            PrintMultiplicationSign(firstNum, secondNum, thirdNum);
        }
        static void PrintMultiplicationSign(int firstnum, int secondNum, int thirdNum)
        {
            if (firstnum > 0 && secondNum > 0 && thirdNum > 0)
            {
                Console.WriteLine("positive");
            }
            else if (firstnum < 0 && secondNum < 0 && thirdNum > 0 || firstnum < 0 && thirdNum < 0 && secondNum > 0 || secondNum < 0 && thirdNum < 0 && firstnum > 0)
            {
                Console.WriteLine("positive");
            }
            else if (firstnum < 0 || secondNum < 0 || thirdNum < 0)
            {
                Console.WriteLine("negative");
            }
            else if (firstnum == 0 || secondNum == 0 || thirdNum == 0)
            {
                Console.WriteLine("zero");
            }
            
        }
    }
}