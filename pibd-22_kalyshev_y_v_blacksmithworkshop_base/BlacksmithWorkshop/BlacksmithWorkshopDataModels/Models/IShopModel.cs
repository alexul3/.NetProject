using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDataModels.Models
{
    public class IShopModel
    {
        string ShopName { get; }
        string Address { get; }
        DateTime DateOpening { get; }
        Dictionary<int, (IManufactureModel, int)> ListManufacture { get; }
    }
}
