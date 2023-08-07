using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement.Models
{
    [DataContract]
    public class MessageInfo : IMessageInfoModel
	{
        [DataMember]
        public string MessageId { get; private set; } = string.Empty;
        [DataMember]
        public int? ClientId { get; private set; }
        [DataMember]
        public string SenderName { get; private set; } = string.Empty;
        [DataMember]
        public DateTime DateDelivery { get; private set; } = DateTime.Now;
        [DataMember]
        public string Subject { get; private set; } = string.Empty;
        [DataMember]
        public string Body { get; private set; } = string.Empty;
        [DataMember]
        public bool IsRead { get; private set; } = false;
        [DataMember]
        public string? ReplyText { get; private set; }
		public static MessageInfo? Create(MessageInfoBindingModel? model)
		{
			if (model == null)
			{
				return null;
			}
			return new MessageInfo()
			{
				MessageId = model.MessageId,
				ClientId = model.ClientId,
				SenderName = model.SenderName,
				DateDelivery = model.DateDelivery,
				Subject = model.Subject,
				Body = model.Body
			};
		}
        public void Update(MessageInfoBindingModel model)
        {
            IsRead = model.IsRead;
            ReplyText = model.ReplyText;
        }
        public MessageInfoViewModel GetViewModel => new()
		{
			MessageId = MessageId,
			ClientId = ClientId,
			SenderName = SenderName,
			DateDelivery = DateDelivery,
			Subject = Subject,
			Body = Body,
            IsRead = IsRead,
            ReplyText = ReplyText
		};
        public int Id => throw new NotImplementedException();
    }
}
