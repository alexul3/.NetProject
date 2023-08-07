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
    public class ComponentViewModel : IComponentModel
    {
        [Column(visible: false)]
        public int Id { get; set; }
        [Column(title: "Название компонента", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ComponentName { get; set; } = string.Empty;
        [Column(title: "Цена", formattedNumber: true, gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public double Cost { get; set; }
    }
}
