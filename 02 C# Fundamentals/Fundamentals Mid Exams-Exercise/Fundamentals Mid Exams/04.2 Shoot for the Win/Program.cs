namespace _04._2_Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int curNum = 0;
            int shootCount = 0;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                int indexToShoot = int.Parse(input);

                if (indexToShoot < 0 || indexToShoot > targets.Length - 1)
                {
                    continue;
                }

                curNum = targets[indexToShoot];
                targets[indexToShoot] = -1;
                shootCount++;

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] == -1)
                    {
                        targets[i] = -1;
                    }
                    else if (targets[i] <= curNum)
                    {
                        targets[i] += curNum;
                    }
                    else if (targets[i] > curNum)
                    {
                        targets[i] -= curNum;
                    }
                            
                }
            }

            Console.WriteLine($"Shot targets: {shootCount} -> {string.Join(' ',targets)}");
        }
    }
}