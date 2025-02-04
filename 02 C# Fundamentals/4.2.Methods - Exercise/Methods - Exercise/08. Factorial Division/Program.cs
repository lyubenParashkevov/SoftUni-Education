namespace _08._Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNum = int.Parse(Console.ReadLine());
            double secondNum = int.Parse(Console.ReadLine());

            DevideFirstResultByTheSecond(firstNum, secondNum);
        }

        static void DevideFirstResultByTheSecond(double firstNum, double secondNum)
        {
            double firstSum = 1;
            double secondSum = 1;
            for (int i = 1; i <= firstNum; i++)
            {
                firstSum *= i;
            }
            for (int i = 1; i <= secondNum; i++)
            {
                secondSum *= i;
            }
            double result = firstSum / secondSum;

            Console.WriteLine($"{result:f2}");
        }
    }
}