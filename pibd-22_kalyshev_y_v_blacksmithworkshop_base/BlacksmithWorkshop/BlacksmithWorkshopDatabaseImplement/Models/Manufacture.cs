using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
    [DataContract]
    public class Manufacture : IManufactureModel
    {
        [DataMember]
        public int Id { get; set; }
        [Required]
        [DataMember]
        public string ManufactureName { get; set; } = string.Empty;
        [Required]
        [DataMember]
        public double Price { get; set; }
        private Dictionary<int, (IComponentModel, int)>? _manufactureComponents = null;
        [NotMapped]
        public Dictionary<int, (IComponentModel, int)> ManufactureComponents
        {
            get
            {
                if (_manufactureComponents == null)
                {
                    _manufactureComponents = Components
                    .ToDictionary(recPC => recPC.ComponentId, recPC =>
                    (recPC.Component as IComponentModel, recPC.Count));
                }
                return _manufactureComponents;
            }
        }
        [ForeignKey("ManufactureId")]
        public virtual List<ManufactureComponent> Components { get; set; } = new();
        [ForeignKey("ManufactureId")]
        public virtual List<Order> Orders { get; set; } = new();
        public static Manufacture Create(BlacksmithWorkshopDatabase context, ManufactureBindingModel model)
        {
            return new Manufacture()
            {
                Id = model.Id,
                ManufactureName = model.ManufactureName,
                Price = model.Price,
                Components = model.ManufactureComponents.Select(x => new ManufactureComponent
                {
                    Component = context.Components.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList()
            };
        }
        public void Update(ManufactureBindingModel model)
        {
            ManufactureName = model.ManufactureName;
            Price = model.Price;
        }
        public ManufactureViewModel GetViewModel => new()
        {
            Id = Id,
            ManufactureName = ManufactureName,
            Price = Price,
            ManufactureComponents = ManufactureComponents
        };
        public void UpdateComponents(BlacksmithWorkshopDatabase context, ManufactureBindingModel model)
        {
            var manufactureComponents = context.ManufactureComponents.Where(rec =>
            rec.ManufactureId == model.Id).ToList();
            if (manufactureComponents != null && manufactureComponents.Count > 0)
            { // удалили те, которых нет в модели
                context.ManufactureComponents.RemoveRange(manufactureComponents.Where(rec
                => !model.ManufactureComponents.ContainsKey(rec.ComponentId)));
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in manufactureComponents)
                {
                    updateComponent.Count = model.ManufactureComponents[updateComponent.ComponentId].Item2;
                    model.ManufactureComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            var manufacture = context.Manufactures.First(x => x.Id == Id);
            foreach (var pc in model.ManufactureComponents)
            {
                context.ManufactureComponents.Add(new ManufactureComponent
                {
                    Manufacture = manufacture,
                    Component = context.Components.First(x => x.Id == pc.Key),
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            _manufactureComponents = null;
        }
    }
}