using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int defaultComfort = 5;
        private const decimal defaultPrice = 10;
        public Plant()
            : base(defaultComfort, defaultPrice)
        {
        }
    }
}
