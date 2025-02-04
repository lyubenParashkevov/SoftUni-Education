namespace _02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine().Split('!', StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Go Shopping!")
                {
                    break;
                }

                string[] comands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string comand = comands[0];
                string product = comands[1];

                if (comand == "Urgent")
                {
                    bool isThere = true;
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (products[i] == product)
                        {
                            isThere = false;
                        }
                    }
                    if (isThere)
                    {
                        products.Insert(0, product);
                    }
                }
                else if (comand == "Unnecessary")
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (products[i] == product)
                        {
                            products.RemoveAt(i);
                        }                        
                    }
                }
                else if (comand == "Correct") //{oldItem} {newItem}
                {
                    string oldItem = comands[1];
                    string newItem = comands[2];
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (products[i] == oldItem)
                        {
                            products[i] = newItem;
                        }                       
                    }
                }
                else if (comand == "Rearrange")
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        if (products[i] == product)
                        {
                            products.RemoveAt(i);
                            products.Add(product);
                        }
                        
                    }
                }
            }
            Console.WriteLine(string.Join(", ", products));
        }
    }
}