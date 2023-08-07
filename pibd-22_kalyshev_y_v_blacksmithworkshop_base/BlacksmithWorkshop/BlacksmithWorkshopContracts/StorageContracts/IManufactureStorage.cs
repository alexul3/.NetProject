using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;

namespace BlacksmithWorkshopContracts.StorageContracts
{
    public interface IManufactureStorage
    {
        List<ManufactureViewModel> GetFullList();
        List<ManufactureViewModel> GetFilteredList(ManufactureSearchModel model);
        ManufactureViewModel? GetElement(ManufactureSearchModel model);
        ManufactureViewModel? Insert(ManufactureBindingModel model);
        ManufactureViewModel? Update(ManufactureBindingModel model);
        ManufactureViewModel? Delete(ManufactureBindingModel model);
    }
}
