using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksmithWorkshopDataModels.Models;

namespace BlacksmithWorkshopContracts.BindingModels
{
    public class ShopBindingModel : IShopModel
    {
        public int Id { get; set; }
        public string ShopName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public DateTime DateOpening { get; set; } = DateTime.Now;
        public int Capacity { get; set; }
        public Dictionary<int, (IManufactureModel, int)> ListManufacture
        {
            get;
            set;
        } = new();
    }
}
