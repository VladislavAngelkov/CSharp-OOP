using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;
        private double currentBill;
        private double turnover;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            currentBill= 0;
            turnover = 0;
            IsReserved= false;
            delicacyMenu = new DelicacyRepository();
            cocktailMenu= new CocktailRepository();
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get { return capacity;}
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu
        {
            get { return delicacyMenu;}
        }

        public IRepository<ICocktail> CocktailMenu
        {
            get { return cocktailMenu;}
        }

        public double CurrentBill
        {
            get { return currentBill; }
        }

        public double Turnover
        {
            get { return turnover; }
        }

        public bool IsReserved { get; private set; }

        public void ChangeStatus()
        {
            IsReserved  = !IsReserved;
        }

        public void Charge()
        {
            turnover += currentBill;
            currentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            currentBill+=amount;
        }

        public override string ToString()
        {
            StringBuilder message = new StringBuilder();
            message.AppendLine($"Booth: {BoothId}");
            message.AppendLine($"Capacity: {Capacity}");
            message.AppendLine($"Turnover: {Turnover:f2} lv");
            message.AppendLine("-Cocktail menu:");
            if (this.cocktailMenu.Models.Count>0)
            {
                message.AppendLine(string.Join(Environment.NewLine, CocktailMenu.Models.Select(m => $"--{m.ToString()}")));
            }
            message.AppendLine("-Delicacy menu:");
            message.AppendLine(string.Join(Environment.NewLine, DelicacyMenu.Models.Select(m => $"--{m.ToString()}")));

            return message.ToString().TrimEnd();
        }
    }
}
