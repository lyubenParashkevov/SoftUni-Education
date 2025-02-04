using System.ComponentModel.Design;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                jaged[row] = new int[numbers.Length];
                jaged[row] = numbers;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                if (jaged[row].Length == jaged[row + 1].Length)
                {
                    for (int i = 0; i < jaged[row].Length; i++)
                    {
                        jaged[row][i] *= 2;
                    }

                    for (int i = 0; i < jaged[row].Length; i++)
                    {
                        jaged[row + 1][i] *= 2;
                    }
                }

                else
                {
                    for (int i = 0; i < jaged[row].Length; i++)
                    {
                        jaged[row][i] /= 2;
                    }

                    for (int i = 0; i < jaged[row + 1].Length; i++)
                    {
                        jaged[row + 1][i] /= 2;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                if (command == "End")
                {
                    break;
                }

                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (row > 0 && col > 0 && row <= rows && col <= jaged[row].Length)
                {

                    if (command == "Add")
                    {
                        jaged[row][col] += value;
                    }

                    else if (command == "Subtract")
                    {
                        jaged[row][col] -= value;
                    }
                }
            }

            foreach (int[] row in jaged)
            {
                Console.WriteLine(string.Join(' ',row));
            }
        }
    }
}