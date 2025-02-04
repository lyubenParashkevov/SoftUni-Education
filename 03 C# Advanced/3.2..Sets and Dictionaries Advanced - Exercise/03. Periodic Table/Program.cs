namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> set = new SortedSet<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                foreach (string s in input)
                {
                    set.Add(s);
                }
            }

            Console.WriteLine(string.Join(" ", set));
        }
    }
}