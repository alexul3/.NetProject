using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BlacksmithWorkshopDataModels.Models;
using BlacksmithWorkshopContracts.Attributes;

namespace BlacksmithWorkshopContracts.ViewModels
{
    public class ManufactureViewModel : IManufactureModel
    {
        [Column(visible: false)]
        public int Id { get; set; }
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ManufactureName { get; set; } = string.Empty;
        [Column(title: "Цена", width: 150, formattedNumber: true)]
        public double Price { get; set; }
        [Column(visible: false)]
        public Dictionary<int, (IComponentModel, int)> ManufactureComponents
        {
            get;
            set;
        } = new();
    }
}
