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
            this.Cloths = new List<Cloth>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Cloths { get; set; }

        public void AddCloth(Cloth cloth)
        {
            if (Cloths.Count < Capacity)
            {
                Cloths.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            foreach (Cloth cloth in Cloths.Where(c => c.Color == color))
            {
                return this.Cloths.Remove(cloth);
                
            }
            return false;
        }

        public Cloth GetSmallestCloth()
        {
            Cloths = Cloths.OrderBy(c => c.Size).ToList();
            var smallestCloth = Cloths.FirstOrDefault();
            return smallestCloth;        
        }

        public Cloth GetCloth(string color)
        {
            foreach (var cloth in Cloths.Where(c => c.Color == color))
            {
                return cloth;
            }
            return default;
        }

        public int GetClothCount()
        {
            return this.Cloths.Count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Type} magazine contains:");

            foreach (var cloth in Cloths.OrderBy(c => c.Size))
            {
                sb.AppendLine(cloth.ToString().Trim());
            }
            return sb.ToString().Trim();
        }
    }
}
