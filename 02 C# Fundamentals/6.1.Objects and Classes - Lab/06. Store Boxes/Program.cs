namespace _06._Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Box> boxes = new List<Box>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] items = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string serialNumber = items[0];
                string itemName = items[1];
                int itemQuantity = int.Parse(items[2]);
                decimal itemPrice = decimal.Parse(items[3]);

                Item item = new Item
                {
                    Name = itemName,
                    Price = itemPrice
                };

                Box box = new Box
                {
                    SerialNumber = serialNumber,
                    Item = item,
                    ItemQuantity = itemQuantity,
                    PriceForBox = itemPrice * itemQuantity
                };

                boxes.Add(box);

            }

            foreach (var box in boxes.OrderByDescending(x => x.PriceForBox))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f2}");
            }

        }



        class Box
        {


            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int ItemQuantity { get; set; }
            public decimal PriceForBox { get; set; }
        }

        class Item
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }

    }

}

