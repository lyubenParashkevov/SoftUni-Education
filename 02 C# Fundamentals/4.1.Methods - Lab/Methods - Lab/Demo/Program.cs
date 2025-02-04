namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int secondNum = int.Parse(Console.ReadLine());
            double result = Calculate(firstNum, @operator, secondNum);
            Console.WriteLine(result);
        }

        static double Calculate(int firstNum, string @operator, int secondNum)
        {
            double result = 0;
            switch(@operator)
            {
                case "+":
                    return firstNum + secondNum;
                    break;
                case "-":
                    return firstNum - secondNum;
                    break;
                case "*":
                    return firstNum * secondNum;
                    break;
                case "/":
                    return (double)firstNum / secondNum;
                    break;
            }
            return result;
        }
    }

}
