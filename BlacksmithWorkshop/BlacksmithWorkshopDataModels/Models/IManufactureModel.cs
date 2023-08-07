using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDataModels.Models
{
    public interface IManufactureModel : IId
    {
        string ManufactureName { get; }
        double Price { get; }
        Dictionary<int, (IComponentModel, int)> ManufactureComponents { get; }
    }
}

