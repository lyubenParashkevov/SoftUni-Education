using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] boxInfo = input.Split(' ');
                string serialNumber = boxInfo[0];
                string itemName = boxInfo[1];
                int itemQuantity = int.Parse(boxInfo[2]);
                double itemPrice = double.Parse(boxInfo[3]);

                Item item = new Item(itemName, itemPrice)
                {
                    Name = itemName,
                    Price = itemPrice
                };

                Box box = new Box(serialNumber, itemQuantity, item)
                {
                    SerialNumber = serialNumber,
                    ItemQuantity = itemQuantity,
                    Item = item,
                    
                };
                boxes.Add(box);

                input = Console.ReadLine();
            }

            foreach (Box box in boxes.OrderByDescending(x => x.PriceForBox(x.ItemQuantity, x.Item.Price)))
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBox(box.ItemQuantity, box.Item.Price):f2}");
            }
        }
        public class Item
        {
            public Item(string itemName, double price)
            {

            }
            public string Name { get; set; }
            public double Price { get; set; }

        }

        public class Box
        {
            public Box(string serialNumber, int itemQuantity, Item item)
            {

            }
            public string SerialNumber { get; set; }

            public int ItemQuantity { get; set; }
            public Item Item { get; set; }

            public double PriceForBox(int itemQuantity, double itemPrice)
            {

                double result = itemQuantity * itemPrice; 
               return result;
            }
        }
        


    }





}
