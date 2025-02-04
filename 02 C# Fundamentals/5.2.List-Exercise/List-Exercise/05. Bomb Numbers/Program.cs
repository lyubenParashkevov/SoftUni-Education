namespace _05._Bomb_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            int[] bomb = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = bomb[0];
            int power = bomb[1];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNumber)
                {
                    int bombIndex = numbers.IndexOf(bombNumber);

                    if (i - power < 0)
                    {
                      //  for (int j = bombIndex - power; j <= bombIndex + power; j++)
                        {
                            numbers.RemoveRange();
                            
                        }
                    }
                    else if (i + power > numbers.Count - 1)
                    {
                        for (int j = i - power; j < numbers.Count; j++)
                        {
                            numbers.Remove(numbers[j]);
                        }
                    }
                    else
                    {
                        for (int j = i - power; j <= i + power; j++)
                        {
                            numbers.RemoveAt(numbers[j]);
                        }
                    }

                }
            }
            

            Console.WriteLine(numbers.Sum());
        }
    }
}