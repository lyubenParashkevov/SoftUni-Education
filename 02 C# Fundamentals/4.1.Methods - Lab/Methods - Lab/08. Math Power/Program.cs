namespace _08._Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            Console.WriteLine(GetNumberPower(number, power));          
        }

        private static double GetNumberPower(double number, int power)
        {
            double sum = number;
            for (int i = 2; i <= power; i++)
            {
                sum *= number;
            }            
            return sum;
        }
            
    }
}