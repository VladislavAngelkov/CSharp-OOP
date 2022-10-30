using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILLILITERS = 50;
        private const decimal COFFEEPRICE = 3.5M;
        public Coffee(string name, double caffeine) : base(name, COFFEEPRICE, COFFEE_MILLILITERS)
        {
            Caffeine = caffeine;
        }
        public double Caffeine { get; set; }
    }
}
