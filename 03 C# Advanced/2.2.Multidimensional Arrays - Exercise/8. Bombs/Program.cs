namespace _8._Bombs
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
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] += numbers[col];
                }
            }

            string[] bombs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombs.Length; i++)
            {
                int curRowStart = 0;
                int curRowEnd = 0;
                int curColStart = 0;
                int curColEnd = 0;

                int[] bombCoordinates = bombs[i].Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int bombRow = bombCoordinates[0];
                int bombCol = bombCoordinates[1];

                int bomb = matrix[bombRow, bombCol];
                if (bomb <= 0)
                {
                    break;
                }

                if (bombRow - 1 < 0)
                {
                    curRowStart = 0;
                }
                else
                {
                    curRowStart = bombRow - 1;
                }

                if (bombRow + 1 >= matrix.GetLength(0))
                {
                    curRowEnd = matrix.GetLength(0) - 1;
                }

                else
                {
                    curRowEnd = bombRow + 1;
                }

                for (int row = curRowStart; row <= curRowEnd; row++)
                {

                    if (bombCol - 1 < 0)
                    {
                        curColStart = 0;
                    }
                    else
                    {
                        curColStart = bombCol - 1;
                    }

                    if (bombCol + 1 >= matrix.GetLength(1))
                    {
                        curColEnd = matrix.GetLength(1) - 1;
                    }
                    else
                    {
                        curColEnd = bombCol + 1;
                    }

                    for (int col = curColStart; col <= curColEnd; col++)
                    {
                        if (matrix[row, col] <= 0)
                        {
                            continue;
                        }
                        matrix[row, col] -= bomb;
                    }
                }
            }
            int sum = 0;
            int count = 0;

            foreach (int num  in matrix)
            {
                if (num > 0)
                {
                    sum += num;
                    count++;
                }
            }

            Console.WriteLine($"Alive cells: {count}");

            Console.WriteLine($"Sum: {sum}");

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}