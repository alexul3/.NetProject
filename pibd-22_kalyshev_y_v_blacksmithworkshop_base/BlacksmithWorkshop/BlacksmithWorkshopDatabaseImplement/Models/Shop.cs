using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
    public class Shop : IShopModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string ShopName { get; set; } = string.Empty;
        [DataMember]
        [Required]
        public string Address { get; set; } = string.Empty;
        [DataMember]
        [Required]
        public DateTime DateOpening { get; set; }
        [DataMember]
        [Required]
        public int Capacity { get; set; }
        private Dictionary<int, (IManufactureModel, int)>? _listManufacture = null;
        [NotMapped]
        public Dictionary<int, (IManufactureModel, int)> ListManufacture
        {
            get
            {
                if (_listManufacture == null)
                {
                    _listManufacture = Manufactures.ToDictionary(recST => recST.ManufactureId, recST => (recST.Manufacture as IManufactureModel, recST.Count));
                }
                return _listManufacture;
            }
        }
        [ForeignKey("ShopId")]
        public virtual List<ShopManufacture> Manufactures { get; set; } = new();
        public static Shop Create(BlacksmithWorkshopDatabase context, ShopBindingModel model)
        {
            return new Shop()
            {
                Id = model.Id,
                ShopName = model.ShopName,
                Address = model.Address,
                DateOpening = model.DateOpening,
                Capacity = model.Capacity,
                Manufactures = model.ListManufacture.Select(x => new ShopManufacture
                {
                    Manufacture = context.Manufactures.First(y => y.Id == x.Key),
                    Count = x.Value.Item2
                }).ToList()
            };
        }
        public void Update(ShopBindingModel model)
        {
            ShopName = model.ShopName;
            Address = model.Address;
            DateOpening = model.DateOpening;
            Capacity = model.Capacity;
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
        public void UpdateManufactures(BlacksmithWorkshopDatabase context, ShopBindingModel model)
        {
            var shopManufactures = context.ListManufacture.Where(rec => rec.ShopId == model.Id).ToList();
            if (shopManufactures != null && ListManufacture.Count > 0)
            {   // удалили те, которых нет в модели
                context.ListManufacture.RemoveRange(shopManufactures.Where(rec => !model.ListManufacture.ContainsKey(rec.ManufactureId)));
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateManufacture in shopManufactures)
                {
                    updateManufacture.Count = model.ListManufacture[updateManufacture.ManufactureId].Item2;
                    model.ListManufacture.Remove(updateManufacture.ManufactureId);
                }
                context.SaveChanges();
            }
            var shop = context.Shops.First(x => x.Id == Id);
            foreach (var st in model.ListManufacture)
            {
                context.ListManufacture.Add(new ShopManufacture
                {
                    Shop = shop,
                    Manufacture = context.Manufactures.First(x => x.Id == st.Key),
                    Count = st.Value.Item2
                });
                context.SaveChanges();
            }
            _listManufacture = null;
        }
    }
}
