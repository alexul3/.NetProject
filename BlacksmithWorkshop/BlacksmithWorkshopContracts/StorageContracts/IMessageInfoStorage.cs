using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.StorageContracts
{
	public interface IMessageInfoStorage
	{
		List<MessageInfoViewModel> GetFullList();
		List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model);
		MessageInfoViewModel? GetElement(MessageInfoSearchModel model);
		MessageInfoViewModel? Insert(MessageInfoBindingModel model);
        MessageInfoViewModel? Update(MessageInfoBindingModel model);
    }
}
