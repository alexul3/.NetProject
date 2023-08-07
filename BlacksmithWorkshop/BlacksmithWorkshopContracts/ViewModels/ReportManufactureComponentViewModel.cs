using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.ViewModels
{
    public class ReportManufactureComponentViewModel
    {
        public string ManufactureName { get; set; } = string.Empty;
        public int TotalCount { get; set; }
        public List<(string Component, int Count)> Components { get; set; } = new();
    }
}
