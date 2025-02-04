namespace _03._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inventary = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            
            while (true)
            {
               string input = Console.ReadLine(); 

                if (input == "Craft!")
                {
                    break;
                }
                List<string> items = input.Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToList();
                string item = items[1];

                if (items[0] == "Collect")
                {

                    if (inventary.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        inventary.Add(item);
                    }
                }
                else if (items[0] == "Drop")
                {

                    if (inventary.Contains(item))
                    {
                        inventary.Remove(item);
                    }
                                                                                                         
                }
                else if (items[0] == "Combine Items")
                {
                    string[] toCombine = item.Split(':',StringSplitOptions.RemoveEmptyEntries);
                    string oldItem = toCombine[0];
                    string newItem = toCombine[1];
                    
                    for (int  i = 0;  i < inventary.Count;  i++)
                    {
                        if (inventary[i] == oldItem)
                        {
                            inventary.Add(newItem);
                        }
                    }
                }
                else if (items[0] == "Renew")
                {
                    for (int i = 0; i < inventary.Count; i++)
                    {
                        if (inventary[i] == item)
                        {
                            inventary.RemoveAt(i);
                            inventary.Add(item);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(", ",inventary));
        }
    }
}