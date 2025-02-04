using ClothesMagazine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.Clothes = new List<Cloth>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }


        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                this.Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            foreach (Cloth cloth in this.Clothes)//.Where(c => c.Color == color))
            {
                return this.Clothes.Remove(cloth);
            }
            return false;
        }

        public Cloth GetSmallestCloth()
        {
            Clothes = Clothes.OrderBy(c => c.Size).ToList();

            foreach (Cloth cloth in this.Clothes)
            {
                var smallest = Clothes.FirstOrDefault();
                return smallest;
            }
            return default;
        }

        public Cloth GetCloth(string color)
        {
            foreach (Cloth cloth in this.Clothes.Where(c => c.Color == color))
            {
                return cloth;
            }
            return default;
        }

        public int GetClothCount()
        {
            return this.Clothes.Count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine($"{this.Type} magazine contains:");

            foreach (Cloth cloth in this.Clothes.OrderBy(c => c.Size))
            {
                sb.AppendLine(cloth.ToString().Trim());
            }
            return sb.ToString().Trim();
        }
    }
}

