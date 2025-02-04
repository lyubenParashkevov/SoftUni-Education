namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] shopInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string shop = shopInfo[0];
                if (shop == "Revision")
                {
                    break;
                }
                string product = shopInfo[1];
                double price = double.Parse(shopInfo[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product, price);
                }
            }

            foreach (var shop in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}