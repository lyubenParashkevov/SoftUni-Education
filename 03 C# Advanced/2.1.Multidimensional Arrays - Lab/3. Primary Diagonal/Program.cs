namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < cols; row++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                sum += matrix[row, row];
            }
            Console.WriteLine(sum);
        }
    }
}