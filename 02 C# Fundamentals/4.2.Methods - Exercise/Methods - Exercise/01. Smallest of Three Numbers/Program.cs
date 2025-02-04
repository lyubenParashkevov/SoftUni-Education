namespace _01._Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            Console.WriteLine(SmallestOfTreeNumbers(firstNum, secondNum, thirdNum));
        }
        static int SmallestOfTreeNumbers(int firstNum, int secondNum, int thirdNum)
        {
            int smallestNum = 0;
            if (firstNum <= secondNum && firstNum <= thirdNum)
            {
                smallestNum = firstNum;
            }
            else if(secondNum <= firstNum && secondNum <= thirdNum)
            {
                smallestNum = secondNum;
            }
            else if (thirdNum <= firstNum && thirdNum <= secondNum)
            {
                smallestNum = thirdNum;
            }
            return smallestNum;
        }
    }
}