namespace _3._Merging_Lists
{
    internal class Program
    {
        static void Main(string[] args)

        //76 5 34 2 4 12
        //3 5 2 43 12 3 54 10 23
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> resultList = new List<int>();
            
            int minLength = Math.Min(firstList.Count, secondList.Count);

            for (int i = 0; i < minLength; i++)
            {
                resultList.Add(firstList[i]);
                resultList.Add(secondList[i]);
            }

            if(firstList.Count > secondList.Count)
            {               
               for (int i = minLength; i < firstList.Count; i++)
               {
                   resultList.Add(firstList[i]);
               }
            }
            else
            {
                for (int i = minLength; i < secondList.Count; i++)
                {
                    resultList.Add(secondList[i]);
                }
            }

            Console.WriteLine(string.Join(' ',resultList));
        }
    }
}