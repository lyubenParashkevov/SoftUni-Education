namespace _11._Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            double secondNum = double.Parse(Console.ReadLine());

            double result = OperationWithNumbers(firstNum, operation, secondNum);
            Console.WriteLine(result);
        }
         
        static double OperationWithNumbers(double firstNum, string operation, double secondNum)
        {
            double result = 0;

            if (operation == "/")
            {
                result = firstNum / secondNum;
               
            }
            else if (operation == "*")
            {
                result = firstNum * secondNum;
                
            }
            else if (operation == "+")
            {
                result = firstNum + secondNum;
                
            }
            else if (operation == "-")
            {
                result = firstNum - secondNum;                 
                
            }
            return result;
        }
    }
}