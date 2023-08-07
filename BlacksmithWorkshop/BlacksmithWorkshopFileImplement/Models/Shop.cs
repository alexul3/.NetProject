using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlacksmithWorkshopFileImplement.Models
{
    public class Shop : IShopModel
    {
        public int Id { get; private set; }
        public string ShopName { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public DateTime DateOpening { get; private set; }
        public int Capacity { get; private set; }
        public Dictionary<int, int> ManufacturesCount = new();
        public Dictionary<int, (IManufactureModel, int)>? _manufactures = null;
        public Dictionary<int, (IManufactureModel, int)> ListManufacture
        {
            get
            {
                if (_manufactures == null)
                {
                    var source = DataFileSingleton.GetInstance();
                    _manufactures = ManufacturesCount.ToDictionary(
                        x => x.Key,
                        y => ((source.Manufactures.FirstOrDefault(z => z.Id == y.Key) as IManufactureModel)!,
                            y.Value)
                    );
                }
                return _manufactures;
            }
        }
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
                Capacity = model.Capacity,
                ManufacturesCount = model.ListManufacture.ToDictionary(x => x.Key, x => x.Value.Item2)
            };
        }
        public static Shop? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Shop()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ShopName = element.Element("ShopName")!.Value,
                Address = element.Element("Address")!.Value,
                DateOpening = Convert.ToDateTime(element.Element("DateOpening")!.Value),
                Capacity = Convert.ToInt32(element.Element("Capacity")!.Value),
                ManufacturesCount = element.Element("Manufactures")!.Elements("Manufacture")
                    .ToDictionary(
                        x => Convert.ToInt32(x.Element("Key")?.Value),
                        x => Convert.ToInt32(x.Element("Value")?.Value))
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
            Capacity = model.Capacity;
            ManufacturesCount = model.ListManufacture.ToDictionary(x => x.Key, x => x.Value.Item2);
            _manufactures = null;

        }
        public ShopViewModel GetViewModel => new()
        {
            Id = Id,
            ShopName = ShopName,
            Address = Address,
            DateOpening = DateOpening,
            Capacity = Capacity,
            ListManufacture = ListManufacture
        };
        public XElement GetXElement => new("Shop",
            new XAttribute("Id", Id),
            new XElement("ShopName", ShopName),
            new XElement("Address", Address),
            new XElement("DateOpening", DateOpening.ToString()),
            new XElement("Capacity", Capacity.ToString()),
            new XElement("Manufactures", ManufacturesCount.Select(x =>
            new XElement("Manufacture",
                new XElement("Key", x.Key),
                new XElement("Value", x.Value)))
                .ToArray()));
    }
}
