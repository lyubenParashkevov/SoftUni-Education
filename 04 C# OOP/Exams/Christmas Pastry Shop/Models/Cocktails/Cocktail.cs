﻿using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;
        public Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size { get; private set; }
        

        public double Price
        {
            get { return price; }
            private set
            {
                if (Size == "Large")
                {
                    price = value;
                }

                else if (Size == "Middle")
                {
                    price = value / 3 * 2;
                }

                else  // size == "Small"
                {
                    price = value / 3;
                }
            }
        }

        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} ({Size}) - {Price:f2} lv");

            return sb.ToString().TrimEnd();
        }
    }
}
