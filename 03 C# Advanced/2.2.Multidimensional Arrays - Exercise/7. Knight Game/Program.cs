namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;

            char[,] chess = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] chars = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cols; col++)
                {
                    chess[row, col] = chars[col];
                }
            }

            int knightsRemoved = CountAttackedKnights(rows, cols, chess);

            while (true)
            {
                int countMostAttacking = 0;
                int rowMostAttacking = 0;
                int colMostAttacking = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (chess[row, col] == 'K')
                        {
                            int attackedKnights = 0;

                            if (countMostAttacking < attackedKnights)
                            {
                                countMostAttacking = attackedKnights;
                                rowMostAttacking = row;
                                colMostAttacking = col;
                            }

                        }
                    }
                }

                if (countMostAttacking == 0)
                {
                    break;
                }

                else
                {
                    chess[rowMostAttacking, colMostAttacking] = '0';
                    knightsRemoved++;
                }
            }
        }

        static int CountAttackedKnights(int rows, int cols, char[,] chess)
        {

        }
    }
}