using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.BusinessLogicsContracts
{
	public interface IMessageInfoLogic
	{
        List<MessageInfoViewModel>? ReadList(MessageInfoSearchModel? model);
        bool Create(MessageInfoBindingModel model);
        MessageInfoViewModel? ReadElement(MessageInfoSearchModel? model);
        bool Update(MessageInfoBindingModel model);
    }
}
