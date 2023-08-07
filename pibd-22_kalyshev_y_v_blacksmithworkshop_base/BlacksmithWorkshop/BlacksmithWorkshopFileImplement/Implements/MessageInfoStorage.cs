using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StorageContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopFileImplement.Implements
{
	public class MessageInfoStorage : IMessageInfoStorage
	{
		private readonly DataFileSingleton _source;
		public MessageInfoStorage()
		{
			_source = DataFileSingleton.GetInstance();
		}
		public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
		{
			if (!string.IsNullOrEmpty(model.MessageId))
			{
				return _source.MessageInfos
							  .FirstOrDefault(x => x.MessageId == model.MessageId)
							  ?.GetViewModel;
			}
			return null;
		}
		public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
		{
			if (model.ClientId.HasValue)
			{
				return _source.MessageInfos
						.Where(x => x.ClientId == model.ClientId)
						.Select(x => x.GetViewModel)
						.ToList();
			}
			return new();
		}
		public List<MessageInfoViewModel> GetFullList()
		{
			return _source.MessageInfos.Select(x => x.GetViewModel).ToList();
		}
		public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
		{
			var newMessage = MessageInfo.Create(model);
			if (newMessage == null)
			{
				return null;
			}
			_source.MessageInfos.Add(newMessage);
			_source.SaveClients();
			return newMessage.GetViewModel;
		}
        public MessageInfoViewModel? Update(MessageInfoBindingModel model)
        {
            var message = _source.MessageInfos.FirstOrDefault(x => x.MessageId == model.MessageId);
            if (message == null)
            {
                return null;
            }
            message.Update(model);
            _source.SaveMessageInfos();
            return message.GetViewModel;
        }
    }
}
