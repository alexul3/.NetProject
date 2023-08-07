using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StorageContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using BlacksmithWorkshopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopFileImplement.Implements
{
    public class ShopStorage : IShopStorage
    {
        private readonly DataFileSingleton source;

        public ShopStorage()
        {
            source = DataFileSingleton.GetInstance();
        }

        public ShopViewModel? GetElement(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName) && !model.Id.HasValue)
            {
                return null;
            }
            return source.Shops
                .FirstOrDefault(x => (!string.IsNullOrEmpty(model.ShopName) && x.ShopName == model.ShopName) || (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }

        public List<ShopViewModel> GetFilteredList(ShopSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ShopName))
            {
                return new();
            }
            return source.Shops
                .Where(x => x.ShopName.Contains(model.ShopName))
                .Select(x => x.GetViewModel)
                .ToList();
        }

        public List<ShopViewModel> GetFullList()
        {
            return source.Shops.Select(x => x.GetViewModel).ToList();
        }

        public ShopViewModel? Insert(ShopBindingModel model)
        {
            model.Id = source.Shops.Count > 0 ? source.Shops.Max(x => x.Id) + 1 : 1;
            var newShop = Shop.Create(model);
            if (newShop == null)
            {
                return null;
            }
            source.Shops.Add(newShop);
            source.SaveShops();
            return newShop.GetViewModel;
        }

        public ShopViewModel? Update(ShopBindingModel model)
        {
            var shop = source.Shops.FirstOrDefault(x => x.Id == model.Id);
            if (shop == null)
            {
                return null;
            }
            shop.Update(model);
            source.SaveShops();
            return shop.GetViewModel;
        }
        public ShopViewModel? Delete(ShopBindingModel model)
        {
            var element = source.Shops.FirstOrDefault(x => x.Id == model.Id);
            if (element != null)
            {
                source.Shops.Remove(element);
                source.SaveShops();
                return element.GetViewModel;
            }
            return null;
        }
        public bool SellManufactures(IManufactureModel model, int count)
        {
            int availableQuantity = source.Shops.Select(x => x.ListManufacture.FirstOrDefault(y => y.Key == model.Id).Value.Item2).Sum();
            if (availableQuantity < count)
            {
                return false;
            }
            var shops = source.Shops.Where(x => x.ListManufacture.ContainsKey(model.Id));
            foreach (var shop in shops)
            {
                int countInCurrentShop = shop.ListManufacture[model.Id].Item2;
                if (countInCurrentShop <= count)
                {
                    shop.ListManufacture[model.Id] = (shop.ListManufacture[model.Id].Item1, 0);
                    count -= countInCurrentShop;
                }
                else
                {
                    shop.ListManufacture[model.Id] = (shop.ListManufacture[model.Id].Item1, countInCurrentShop - count);
                    count = 0;
                }
                Update(new ShopBindingModel
                {
                    Id = shop.Id,
                    ShopName = shop.ShopName,
                    Address = shop.Address,
                    DateOpening = shop.DateOpening,
                    ListManufacture = shop.ListManufacture,
                    Capacity = shop.Capacity
                });
                if (count == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
