namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mineProffit = new Dictionary<string, int>();
                     
            while (true)
            {
                string resourseType = Console.ReadLine();
                

                if (resourseType == "stop")
                {
                    break;
                }
                
                int quantity = int.Parse(Console.ReadLine());


                if (!mineProffit.ContainsKey(resourseType))
                {
                    mineProffit.Add(resourseType, 0);

                }
                
                mineProffit[resourseType] += quantity;

            }

            foreach (var item in mineProffit)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}