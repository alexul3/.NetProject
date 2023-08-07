using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.StorageContracts
{
    public interface IClientStorage
    {
        List<ClientViewModel> GetFullList();
        List<ClientViewModel> GetFilteredList(ClientSearchModel model);
        ClientViewModel? GetElement(ClientSearchModel model);
        ClientViewModel? Insert(ClientBindingModel model);
        ClientViewModel? Update(ClientBindingModel model);
        ClientViewModel? Delete(ClientBindingModel model);
    }
}
