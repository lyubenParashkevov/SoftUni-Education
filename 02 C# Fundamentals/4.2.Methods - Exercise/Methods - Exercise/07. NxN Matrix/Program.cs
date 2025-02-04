namespace _07._NxN_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            PrintNxNMatrix(num);

        }

        static void PrintNxNMatrix(int num)
        {
            int counter = num;
            while (counter > 0)
            {

                for (int i = 1; i <= num; i++)
                {
                    Console.Write(num + " ");
                }
                Console.WriteLine();
                counter--;
            }
        }
    }
}