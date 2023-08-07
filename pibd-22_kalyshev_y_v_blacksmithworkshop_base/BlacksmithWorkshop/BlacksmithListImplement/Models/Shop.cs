using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;

namespace BlacksmithWorkshopListImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; private set; }
        public string ShopName { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public DateTime DateOpening { get; private set; }
        public int Capacity { get; private set; }
        public Dictionary<int, (IManufactureModel, int)> ListManufacture
        {
            get;
            private set;
        } = new();
        public static Shop? Create(ShopBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpening = model.DateOpening,
                ListManufacture = new()
            };
        }
        public void Update(ShopBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ShopName = model.ShopName;
            Address = model.Address;
            DateOpening = model.DateOpening;
            ListManufacture = model.ListManufacture;
        }
        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            ListManufacture = ListManufacture,
            DateOpening = DateOpening,
        };
    }
}
