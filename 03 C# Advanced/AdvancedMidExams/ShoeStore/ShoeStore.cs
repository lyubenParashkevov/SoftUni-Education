using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {

        public ShoeStore(string name, int storageCapacity)
        {
            this.Name = name;
            this.StorageCapacity = storageCapacity;
            this.Shoes = new List<Shoe>();
        }
        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }

        public int Count { get { return Shoes.Count; } }

        public string AddShoe(Shoe shoe)
        {
            if (Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }
            Shoes.Add(shoe);
            return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
        }

        public int RemoveShoes(string material)
        {
            int removedCount = 0;

            for (int i = 0; i < Shoes.Count; i++)
            {
                if (Shoes[i].Material == material)
                {
                    removedCount++;
                    Shoes.RemoveAt(i);
                    i--;
                }
            }
            return removedCount;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> shoeType = new List<Shoe>();
            foreach (Shoe shoe in Shoes.Where(sh => sh.Type == type.ToLower()))
            {
                shoeType.Add(shoe);
            }
            return shoeType;
        }

        public Shoe GetShoeBySize(double size)
        {
            foreach (Shoe shoe in Shoes)
            {
                return Shoes.FirstOrDefault(s => s.Size == size);
            }
            return default;
        }
        public string StockList(double size, string type)
        {
            List<Shoe> shoesBySizeAndType = new List<Shoe>();

            foreach (Shoe shoe in Shoes.Where(s => s.Size == size && s.Type == type))
            {
                    shoesBySizeAndType.Add(shoe);
            }
             
            if (shoesBySizeAndType.Count > 0)
            {

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (Shoe shoe in shoesBySizeAndType)
                {
                    sb.AppendLine(shoe.ToString());
                }
                return sb.ToString().Trim();
            }
            else
            {
                return "No matches found!";
            }
        }
    }
}
