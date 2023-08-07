using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StorageContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Implements
{
	public class MessageInfoStorage : IMessageInfoStorage
	{
        public List<MessageInfoViewModel> GetFullList()
        {
            using var context = new BlacksmithWorkshopDatabase();
            return context.MessageInfos
                    .Select(x => x.GetViewModel)
                    .ToList();
        }
        public List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            if (model.ClientId.HasValue && model.Page.HasValue && model.PageSize.HasValue)
            {
                return context.MessageInfos
                    .Where(x => x.ClientId == model.ClientId)
                    .Skip(model.PageSize.Value * model.Page.Value)
                    .Take(model.PageSize.Value)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            else if (model.Page.HasValue && model.PageSize.HasValue)
            {
                return context.MessageInfos
                    .Skip(model.PageSize.Value * model.Page.Value)
                    .Take(model.PageSize.Value)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            return new();
        }
        public MessageInfoViewModel? GetElement(MessageInfoSearchModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            return context.MessageInfos
                    .FirstOrDefault(x => !string.IsNullOrEmpty(x.MessageId) && x.MessageId == model.MessageId)
                    ?.GetViewModel;
        }
        public MessageInfoViewModel? Insert(MessageInfoBindingModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            var newMessage = MessageInfo.Create(model);
            if (newMessage == null)
            {
                return null;
            }
            context.MessageInfos.Add(newMessage);
            context.SaveChanges();
            return newMessage.GetViewModel;
        }
        public MessageInfoViewModel? Update(MessageInfoBindingModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            var message = context.MessageInfos.FirstOrDefault(x => x.MessageId == model.MessageId);
            if (message == null)
            {
                return null;
            }
            message.Update(model);
            context.SaveChanges();
            return message.GetViewModel;
        }
    }
}
