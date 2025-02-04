namespace _05._Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
          
            if(product == "coffee")
            {
                Coffee(quantity, product);
            }
            else if (product == "water")
            {
                Water(quantity, product);
            }
            else if (product == "coke")
            {
                Coke(quantity, product);
            }
            else if(product == "snacks")
            {
                Snacks(quantity, product);
            }

        }

        private static void Snacks(int quantity, string product)
        {
            double price = 2.00;
            Console.WriteLine($"{price * quantity:f2}");
        }

        private static void Coke(int quantity, string product)
        {
            double price = 1.40;
            Console.WriteLine($"{price * quantity:f2}");
        }

        private static void Water(int quantity, string product)
        {
            double price = 1.00;
            Console.WriteLine($"{price * quantity:f2}");
        }

        private static void Coffee(int quantity, string product)
        {
            double price = 1.50;
            Console.WriteLine($"{price * quantity:f2}");
        }
    }
}