namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secSet = new HashSet<int>();
            HashSet<int> intersected = new HashSet<int>();

            int[] sets = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int first = sets[0];
            int second = sets[1];

            for (int i = 0; i < first; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }

            for (int i = 0; i < second; i++)
            {
                int num = int.Parse(Console.ReadLine());
                secSet.Add(num);
            }

            firstSet.IntersectWith(secSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}