namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            char ch = char.Parse(Console.ReadLine());

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == ch)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }

                    
                }
            }
            
            Console.WriteLine($"{ch} does not occur in the matrix");
        }
    }
}