namespace _03._Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string calculation = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
             int secondNum = int.Parse(Console.ReadLine());

            if (calculation == "add")
            {
                Add(firstNum, secondNum);
            }
            else if (calculation == "multiply")
            {
                Multiply(firstNum, secondNum);
            }
            else if (calculation == "subtract")
            {
                Subtract(firstNum, secondNum);

            }
            else if (calculation == "divide")
            {
                Divide(firstNum, secondNum);
            }
        }

        
        private static void Add(double firstNum, double secondNum)
        {
            Console.WriteLine(firstNum + secondNum);
        }

        private static void Multiply(double firstNum, double secondNum)
        {
            Console.WriteLine(firstNum * secondNum);
        }

        private static void Subtract(double firstNum, double secondNum)
        {
            Console.WriteLine(firstNum - secondNum);
        }

        private static void Divide(double firstNum, double secondNum)
        {
            Console.WriteLine(firstNum / secondNum);
        }
    }
}