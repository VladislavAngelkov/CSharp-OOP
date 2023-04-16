using CommandPattern.Enums;
using CommandPattern.Models;
using CommandPattern.Utilities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Utilities
{
    public class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly PriceActions priceAction;
        private readonly int amount;

        public ProductCommand(Product product, PriceActions priceAction, int amount)
        {
            this.product = product;
            this.priceAction = priceAction;
            this.amount = amount;
        }

        public void ExecuteAction()
        {
            if (priceAction==PriceActions.Increase)
            {
                product.IncreasePrice(amount);
            }
            else if (priceAction == PriceActions.Decrease)
            {
                product.DecreasePrice(amount);
            }
        }
    }
}
