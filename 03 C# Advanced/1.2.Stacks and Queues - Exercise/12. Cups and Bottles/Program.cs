namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int wastedWaterSum = 0;
            int curentBotle = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                curentBotle = bottles.Pop();
                int curentCup = cups.Peek();

                if (curentBotle >= curentCup)
                {
                    cups.Dequeue();
                    wastedWaterSum += curentBotle - curentCup;
                }

                else if (curentBotle < curentCup)
                {
                    while (curentCup > 0)
                    {                         
                        if (curentCup > curentBotle)
                        {
                            curentCup -= curentBotle;
                            curentBotle = bottles.Pop();                      
                        }
                        else
                        {
                            curentBotle -= curentCup;
                            curentCup = 0;
                            wastedWaterSum += curentBotle;
                        }
                    }
             
                    cups.Dequeue();
                }
            }

            if (bottles.Count > 0)
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
                Console.WriteLine($"Wasted litters of water: {wastedWaterSum}");
            }
            else if (cups.Count > 0)
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups)}");
                Console.WriteLine($"Wasted litters of water: {wastedWaterSum}");
            }
        }
    }
}