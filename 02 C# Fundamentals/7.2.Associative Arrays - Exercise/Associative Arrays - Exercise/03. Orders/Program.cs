namespace _03._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> orders = new Dictionary<string, double[]>();

            while (true)
            {

                string input = Console.ReadLine();
                if (input == "buy")
                {
                    break;
                }

                double price = 0;
                string[] productInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string product = productInfo[0];
                price = double.Parse(productInfo[1]);
                int quantity = int.Parse(productInfo[2]);
                


                if (!orders.ContainsKey(product))
                {

                    orders.Add(product, new double[2]);                 
                }
                orders[product][0] = price;
                orders[product][1] += quantity;
                       
            }
            foreach (var item in orders)
            {
                double sum = item.Value[0] * item.Value[1];

                Console.WriteLine($"{item.Key} -> {sum:f2}");
            }

        }
    }

}