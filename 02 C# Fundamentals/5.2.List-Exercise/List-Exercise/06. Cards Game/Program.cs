namespace _06._Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerList = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> secondPlayerList = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            
            while (firstPlayerList.Count > 0 && secondPlayerList.Count > 0)
            {
                if (firstPlayerList[0] > secondPlayerList[0])
                {
                    firstPlayerList.Add(firstPlayerList[0]);
                    firstPlayerList.Add(secondPlayerList[0]);

                    firstPlayerList.RemoveAt(0);
                    secondPlayerList.RemoveAt(0);
                }
                else if (secondPlayerList[0] > firstPlayerList[0])
                {
                    secondPlayerList.Add(secondPlayerList[0]);
                    secondPlayerList.Add(firstPlayerList[0]);

                    firstPlayerList.RemoveAt(0);
                    secondPlayerList.RemoveAt(0);
                }
                else
                {
                    firstPlayerList.RemoveAt(0);
                    secondPlayerList.RemoveAt(0);
                }

                if (firstPlayerList.Count == 0)
                {
                    int sum = secondPlayerList.Sum();
                    Console.WriteLine($"Second player wins! Sum: {sum}");          
                }
                else if (secondPlayerList.Count == 0)
                {
                    int sum = firstPlayerList.Sum();
                    Console.WriteLine($"First player wins! Sum: {sum}");               
                }
            }
        }
    }
}