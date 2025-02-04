namespace _10._Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);
            int evenSum = GetSumOfEven(number);
            int oddSum = GetSumOfOdd(number);
            int finalSum = GetMultipleOfEvenAndOdds(evenSum, oddSum);
            Console.WriteLine(finalSum);
        }


        static int GetSumOfEven(int number)
        {
            int evenSum = 0;
            while (number > 0)
            {

                int curNum = number % 10;
                if (curNum % 2 == 0)
                {
                    evenSum += curNum;
                }
                number /= 10;
            }
            return evenSum;
        }

        static int GetSumOfOdd(int number)
        {
            int oddSum = 0;
            while (number > 0)
            {

                int curNum = number % 10;
                if (curNum % 2 != 0)
                {
                    oddSum += curNum;
                }
                number /= 10;
            }
            return oddSum;
        }

        static int GetMultipleOfEvenAndOdds(int evenSum, int oddSum)
        {
            return evenSum * oddSum;
        }

    }
}