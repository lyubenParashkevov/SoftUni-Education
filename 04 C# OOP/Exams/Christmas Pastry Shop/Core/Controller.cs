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
        IRepository<IBooth> booths = new BoothRepository();
        IRepository<ICocktail> cocktails = new CocktailRepository();
        IRepository<IDelicacy> delicacies = new DelicacyRepository();
        public string AddBooth(int capacity)
        {
            IBooth booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);
            return string.Format(OutputMessages.NewBoothAdded, booths.Models.Count + 1, capacity);
        }
        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            Delicacy delicacy;

            if (delicacies.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            if (delicacyTypeName == nameof(Gingerbread))
            {
                delicacy = new Gingerbread(delicacyName);

            }

            else if (delicacyTypeName == nameof(Stolen))
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(d => d.BoothId == boothId); //?
            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);

        }
        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail;

            if (size != "Large" && size != "Middle" && size != "Small")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (cocktailTypeName == nameof(MulledWine))
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else if (cocktailTypeName == nameof(Hibernation))
            {
                cocktail = new Hibernation(cocktailName, size);
            }

            else
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            IBooth booth = booths.Models.FirstOrDefault(d => d.BoothId == boothId); //?
            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            IBooth selected = booths.Models.Where(b => !b.IsReserved  && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity).ThenByDescending(b => b.BoothId).FirstOrDefault();
            if (selected == null)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            selected.ChangeStatus();
            return string.Format(OutputMessages.BoothReservedSuccessfully, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            string[] items = order.Split("/", StringSplitOptions.RemoveEmptyEntries);
            string itemTypeName = items[0];
            string itemName = items[1];
            int orderedPiecesCount = int.Parse(items[2]);
            string cocktailSize = "";
            if (itemTypeName == nameof(MulledWine) || itemTypeName == nameof(Hibernation))
            {
                cocktailSize = items[3];
            }

            if (itemTypeName != nameof(MulledWine) &&  itemTypeName != nameof(Hibernation))
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }

            if (!cocktails.Models.Any(x => x.Name ==itemName && !delicacies.Models.Any(x => x.Name == itemName)))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
            }

            ICocktail cocktail;
            if (itemTypeName == nameof (MulledWine)) 
            {
                cocktail = cocktails.Models.FirstOrDefault(x => x.Name ==itemName && x.Size == cocktailSize);
                if (cocktail is null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, cocktailSize, itemName);
                }
                booth.UpdateCurrentBill(cocktail.Price * orderedPiecesCount);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, orderedPiecesCount, itemName);
            }
            else //(itemTypeName == nameof(Hibernation))
            {
                cocktail = cocktails.Models.FirstOrDefault(x => x.Name == itemName && x.Size == cocktailSize);
                if (cocktail is null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, cocktailSize, itemName);
                }
                booth.UpdateCurrentBill(cocktail.Price * orderedPiecesCount);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, orderedPiecesCount, itemName);
            }

            IDelicacy delicacy;
            if (itemTypeName == nameof(Gingerbread))
            {
                delicacy = delicacies.Models.FirstOrDefault(x => x.Name == itemName);
                if (delicacy is null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                booth.UpdateCurrentBill(delicacy.Price * orderedPiecesCount);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, orderedPiecesCount, itemName);
            }
            else //(itemTypeName == nameof(Hibernation))
            {
                delicacy = delicacies.Models.FirstOrDefault(x => x.Name == itemName);
                if (delicacy is null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }
                booth.UpdateCurrentBill(delicacy.Price * orderedPiecesCount);
                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, orderedPiecesCount, itemName);
            }

        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            booth.Charge();
            booth.ChangeStatus();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            return sb.ToString().TrimEnd();
        }
        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString();
        }






    }
}
