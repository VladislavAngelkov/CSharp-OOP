using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }
        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);
            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (cocktailTypeName != "MulledWine" && cocktailTypeName != "Hibernation")
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booth.CocktailMenu.Models.Any(c=>c.GetType().Name== cocktailTypeName && c.Name == cocktailName && c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            if (cocktailTypeName == "MulledWine")
            {
                ICocktail cocktail = new MulledWine(cocktailName, size);
                booth.CocktailMenu.AddModel(cocktail);
            }
            else
            {
                ICocktail cocktail = new Hibernation(cocktailName, size);
                booth.CocktailMenu.AddModel(cocktail);
            }

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy = null;
            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            double lastBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder message = new StringBuilder();
            message.AppendLine(string.Format("Bill {0} lv", $"{lastBill:f2}"));
            message.AppendLine(string.Format(OutputMessages.BoothIsAvailable, booth.BoothId));

            return message.ToString().Trim();
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth booth = booths.Models
                .Where(b => !b.IsReserved)
                .Where(b => b.Capacity>=countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            booth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            string[] orderArgs = order.Split('/');
            string type = orderArgs[0];
            string name = orderArgs[1];
            int count = int.Parse(orderArgs[2]);
            string size = null;

            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (type != "MulledWine" && type != "Hibernation" && type != "Stolen" && type != "Gingerbread")
            {
                return string.Format(OutputMessages.NotRecognizedType, type);
            }

            

            if (type == "MulledWine" || type == "Hibernation")
            {
                if (!booth.CocktailMenu.Models.Any(c => c.Name == name))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, type, name);
                }

                size = orderArgs[3];

                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.GetType().Name == type && c.Name == name && c.Size == size);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, name);
                }

                booth.UpdateCurrentBill(cocktail.Price * count);

                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, count, name);
            }
            else
            {
                if (!booth.DelicacyMenu.Models.Any(d => d.Name == name))
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, type, name);
                }

                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.GetType().Name == type && d.Name == name);

                if (delicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, type, name);
                }

                booth.UpdateCurrentBill(delicacy.Price * count);

                return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, count, name);
            }


            //if (orderArgs.Count() == 4)
            //{
            //    size = orderArgs[3];

            //    if (type != "MulledWine" && type != "Hibernation")
            //    {
            //        return string.Format(OutputMessages.NotRecognizedType, type);
            //    }

            //    if (!booth.CocktailMenu.Models.Any(c=>c.Name == name))
            //    {
            //        return string.Format(OutputMessages.NotRecognizedItemName, type, name);
            //    }

            //    ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.GetType().Name == type && c.Name == name && c.Size == size);

            //    if (cocktail == null)
            //    {
            //        return string.Format(OutputMessages.CocktailStillNotAdded, size, name);
            //    }

            //    booth.UpdateCurrentBill(cocktail.Price * count);

            //    return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, count, name);
            //}
            //else
            //{
            //    if (type != "Gingerbread" && type != "Stolen")
            //    {
            //        return string.Format(OutputMessages.NotRecognizedType, type);
            //    }

            //    if (!booth.DelicacyMenu.Models.Any(c => c.Name == name))
            //    {
            //        return string.Format(OutputMessages.NotRecognizedItemName, type, name);
            //    }

            //    IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(c => c.GetType().Name == type && c.Name == name);

            //    if (delicacy == null)
            //    {
            //        return string.Format(OutputMessages.DelicacyStillNotAdded, type, name);
            //    }

            //    booth.UpdateCurrentBill(delicacy.Price * count);

            //    return string.Format(OutputMessages.SuccessfullyOrdered, booth.BoothId, count, name);
            //}


        }

        //private bool ValidateSize(string size)
        //{
        //    return size == "Small" || size == "Middle" || size == "Large";
        //}
    }
}
