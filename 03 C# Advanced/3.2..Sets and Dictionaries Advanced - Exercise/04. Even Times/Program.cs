namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numsAndCounts = new Dictionary<int, int>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!numsAndCounts.ContainsKey(num))
                {
                    numsAndCounts.Add(num, 0);
                }

                numsAndCounts[num]++;
            }

            foreach (var item in numsAndCounts)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}