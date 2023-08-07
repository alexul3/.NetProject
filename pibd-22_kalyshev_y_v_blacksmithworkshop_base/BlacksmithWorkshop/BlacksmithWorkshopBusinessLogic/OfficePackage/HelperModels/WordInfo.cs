using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public List<ManufactureViewModel> Manufactures { get; set; } = new();
    }
}
