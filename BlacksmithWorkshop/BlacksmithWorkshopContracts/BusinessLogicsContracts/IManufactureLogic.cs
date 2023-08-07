using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
namespace BlacksmithWorkshopContracts.BusinessLogicsContracts
{
    public interface IManufactureLogic
    {
        List<ManufactureViewModel>? ReadList(ManufactureSearchModel? model);
        ManufactureViewModel? ReadElement(ManufactureSearchModel model);
        bool Create(ManufactureBindingModel model);
        bool Update(ManufactureBindingModel model);
        bool Delete(ManufactureBindingModel model);
    }
}