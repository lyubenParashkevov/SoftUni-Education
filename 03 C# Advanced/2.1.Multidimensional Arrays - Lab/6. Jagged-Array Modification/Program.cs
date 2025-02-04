namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaged = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                jaged[row] = new int[numbers.Length];

                jaged[row] = numbers;
                Console.WriteLine(jaged.Length);
                Console.WriteLine(jaged[row].Length);

            }


            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "END")
                {
                    break;
                }

                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (command == "Add")
                {
                    if (row < 0 || col < 0 || row >= jaged.Length || col >= jaged[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }

                    jaged[row][col] += value;
                }

                else if (command == "Subtract")
                {

                    if (row < 0 || col < 0 || row >= jaged.Length || col >= jaged[row].Length)
                    {
                        Console.WriteLine("Invalid coordinates");
                        continue;
                    }

                    jaged[row][col] -= value;
                }

            }

            for (int row = 0; row < jaged.Length; row++)
            {
                for (int col = 0; col < jaged[row].Length; col++)
                {
                    Console.Write(jaged[row][col] + " ");
                }
                Console.WriteLine();
            }




        }
    }
}
