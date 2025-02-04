

Dictionary<string, int> products = new Dictionary<string, int>();
string input;
int soldCount = 0;

while ((input = Console.ReadLine()) != "Complete")
{
    string[] commands = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
    string command = commands[0];
    int count = int.Parse(commands[1]);
    string product = commands[2];

    if (command == "Receive")
    {    
        if (count > 0)
        {
            if (!products.ContainsKey(product))
            {
                products.Add(product, 0);
            }
            products[product]+= count;
        }
    }

    else if (command == "Sell")
    {
        if (!products.ContainsKey(product))
        {
            Console.WriteLine($"You do not have any {product}.");
        }
        else if (products[product] < count)
        {
            Console.WriteLine($"There aren't enough {product}. You sold the last {products[product]} of them.");
            soldCount += products[product];
            products[product] = 0;
        }
        else
        {
            products[product] -= count;
            Console.WriteLine($"You sold {count} {product}.");
            soldCount += count;
            if (products[product] == 0)
            {
                products.Remove(product);
            }
        }
    }
}

foreach(var product in products)
{
    Console.WriteLine($"{product.Key}: {product.Value}");
}

Console.WriteLine($"All sold: {soldCount} goods");