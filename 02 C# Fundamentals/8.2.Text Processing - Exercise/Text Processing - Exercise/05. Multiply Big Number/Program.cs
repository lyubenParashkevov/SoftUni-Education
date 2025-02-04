namespace _05._Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());

            bigNumber.TrimStart('0');

            int[] resultNumbers = new int[bigNumber.Length + 1];   

            for (int i = bigNumber.Length-1; i >= 0; i--) 
            {
                int digit = bigNumber[i] - '0';
                int product = digit * number;

                resultNumbers[i + 1] += product;

                if (resultNumbers[i + 1] >= 10)
                {
                    resultNumbers[i] += resultNumbers[i + 1] / 10;
                    resultNumbers[i + 1] %= 10;

                }
            }
            string result = string.Concat(resultNumbers).TrimStart('0');
            Console.WriteLine(result);
        }
    }
}