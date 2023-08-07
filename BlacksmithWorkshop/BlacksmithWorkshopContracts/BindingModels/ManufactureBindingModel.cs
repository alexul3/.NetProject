using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksmithWorkshopDataModels.Models;

namespace BlacksmithWorkshopContracts.BindingModels
{
    public class ManufactureBindingModel : IManufactureModel
    {
        public int Id { get; set; }
        public string ManufactureName { get; set; } = string.Empty;
        public double Price { get; set; }
        public Dictionary<int, (IComponentModel, int)> ManufactureComponents
        {
            get;
            set;
        } = new();
    }
}
