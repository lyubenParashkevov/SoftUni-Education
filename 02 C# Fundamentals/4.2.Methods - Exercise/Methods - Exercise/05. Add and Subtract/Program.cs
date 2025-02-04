namespace _05._Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            SumOfFirstTwoIntegers(firstNum, secondNum, thirdNum);
            Console.WriteLine(SubtractTheThirdInteger(SumOfFirstTwoIntegers(firstNum, secondNum, thirdNum), thirdNum));

        }

        static int SumOfFirstTwoIntegers(int firstNum, int secondNum, int thirdNum)
        {
            int result = firstNum + secondNum;
           return result;
        }
        static int SubtractTheThirdInteger(int result, int thirdNum)
        {
            int finalResult = result - thirdNum;
            return finalResult;
        }
    }
}