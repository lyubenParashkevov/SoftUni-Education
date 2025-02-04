namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int primaryDiagonal = 0;
            int secondaryDiagonal = 0;
            int difference = 0;

            for (int row = 0;row < rows; row++)
            {
                primaryDiagonal += matrix[row, row];
            }

            for (int row = 0; row < rows ; row++)
            {
                secondaryDiagonal += matrix[row, n - 1 -row];
            }

            difference = Math.Abs(primaryDiagonal - secondaryDiagonal);
            Console.WriteLine(difference);
        }
    }
}