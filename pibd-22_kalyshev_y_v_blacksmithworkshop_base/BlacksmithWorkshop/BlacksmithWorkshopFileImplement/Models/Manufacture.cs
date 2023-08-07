using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using BlacksmithWorkshopDataModels.Models;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using System.Runtime.Serialization;

namespace BlacksmithWorkshopFileImplement.Models
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
        public Dictionary<int, int> Components { get; private set; } = new();
        private Dictionary<int, (IComponentModel, int)>? _manufactureComponents = null;
        public Dictionary<int, (IComponentModel, int)> ManufactureComponents
        {
            get
            {
                if (_manufactureComponents == null)
                {
                    var source = DataFileSingleton.GetInstance();
                    _manufactureComponents = Components.ToDictionary(x => x.Key, y =>
                    ((source.Components.FirstOrDefault(z => z.Id == y.Key) as IComponentModel)!, y.Value));
                }
                return _manufactureComponents;
            }
        }
        public static Manufacture? Create(ManufactureBindingModel model)
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
                Components = model.ManufactureComponents.ToDictionary(x => x.Key, x => x.Value.Item2)
            };
        }
        public static Manufacture? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Manufacture()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ManufactureName = element.Element("ManufactureName")!.Value,
                Price = Convert.ToDouble(element.Element("Price")!.Value),
                Components = element.Element("ManufactureComponents")!.Elements("ManufactureComponent")
                .ToDictionary(x => Convert.ToInt32(x.Element("Key")?.Value), x => Convert.ToInt32(x.Element("Value")?.Value))
            };
        }
        public void Update(ManufactureBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            ManufactureName = model.ManufactureName;
            Price = model.Price;
            Components = model.ManufactureComponents.ToDictionary(x => x.Key, x => x.Value.Item2);
            _manufactureComponents = null;
        }
        public ManufactureViewModel GetViewModel => new()
        {
            Id = Id,
            ManufactureName = ManufactureName,
            Price = Price,
            ManufactureComponents = ManufactureComponents
        };
        public XElement GetXElement => new("Manufacture",
        new XAttribute("Id", Id),
        new XElement("ManufactureName", ManufactureName),
        new XElement("Price", Price.ToString()),
        new XElement("ManufactureComponents", Components.Select(x =>
        new XElement("ManufactureComponent",
        new XElement("Key", x.Key),
        new XElement("Value", x.Value)))
        .ToArray()));
    }
}
