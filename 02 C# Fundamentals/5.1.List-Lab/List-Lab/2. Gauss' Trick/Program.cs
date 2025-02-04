namespace _2._Gauss__Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
           

            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> numbersToPrint = new List<int>();
            int curnum = 0;
            int middleNum = 0;

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                curnum = numbers[i] + numbers[numbers.Count - 1];
                numbers.RemoveAt(i);
                numbers.RemoveAt(numbers.Count - 1);
                numbersToPrint.Add(curnum);
                i = -1;
            }
            if (numbers.Count % 2 != 0)
            {
                middleNum = numbers[numbers.Count / 2];
                numbersToPrint.Add(middleNum);
            }
            Console.WriteLine(string.Join(' ', numbersToPrint));
        }
    }
}