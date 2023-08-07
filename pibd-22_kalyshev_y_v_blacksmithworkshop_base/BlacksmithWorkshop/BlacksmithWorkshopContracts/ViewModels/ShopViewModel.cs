using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksmithWorkshopContracts.Attributes;
using BlacksmithWorkshopDataModels.Models;

namespace BlacksmithWorkshopContracts.ViewModels
{
    public class ShopViewModel : IShopModel
    {
        [Column(visible: false)]
        public int Id { get; set; }
        [Column(title: "Название магазина", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ShopName { get; set; } = string.Empty;
        [Column(title: "Адрес магазина", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string Address { get; set; } = string.Empty;
        [Column(title: "Дата открытия", width: 150, formattedDate: true)]
        public DateTime DateOpening { get; set; } = DateTime.Now;
        [Column(title: "Вместимость магазина", width: 100)]
        public int Capacity { get; set; }
        [Column(visible: false)]
        public Dictionary<int, (IManufactureModel, int)> ListManufacture
        {
            get;
            set;
        } = new();
    }
}
