using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;

namespace BlacksmithWorkshopListImplement.Models
{
    [DataContract]
    public class Manufacture : IManufactureModel
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string ManufactureName { get; private set; } = string.Empty;
        [DataMember]
        public double Price { get; private set; }
        public Dictionary<int, (IComponentModel, int)> ManufactureComponents
        {
            get;
            private set;
        } = new Dictionary<int, (IComponentModel, int)>();
        public static Manufacture? Create(ManufactureBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Manufacture()
            {
                Id = model.Id,
                ManufactureName = model.ManufactureName,
                Price = model.Price,
                ManufactureComponents = model.ManufactureComponents
            };
        }
        public void Update(ManufactureBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ManufactureName = model.ManufactureName;
            Price = model.Price;
            ManufactureComponents = model.ManufactureComponents;
        }
        public ManufactureViewModel GetViewModel => new()
        {
            Id = Id,
            ManufactureName = ManufactureName,
            Price = Price,
            ManufactureComponents = ManufactureComponents
        };
    }
}
