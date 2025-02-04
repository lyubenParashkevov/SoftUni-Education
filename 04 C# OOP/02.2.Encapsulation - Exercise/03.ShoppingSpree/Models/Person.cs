using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ShoppingSpree.Models
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();

        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public string AddProduct(Product product)
        {
            if (Money < product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }

            bagOfProducts.Add(product);
            Money -= product.Cost;

            return $"{Name} bought {product.Name}";
        }

        public override string ToString()
        {
            string productsToPrint = string.Empty;
            if (bagOfProducts.Count > 0)
            {
                productsToPrint = (string.Join(", ",bagOfProducts.Select(p => p.Name)));
                
            }
            else
            {
                productsToPrint = "Nothing bought";
            }

            return $"{Name} - {productsToPrint}";
        }
    }
}
