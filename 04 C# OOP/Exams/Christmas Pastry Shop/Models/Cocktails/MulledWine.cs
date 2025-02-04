using ChristmasPastryShop.Models.Cocktails.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        private const double MulledWinePrice = 13.5;
        public MulledWine(string cocktailName, string size) : base(cocktailName, size, MulledWinePrice)
        {
        }
    }
}
