using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
    [DataContract]
    public class MessageInfo : IMessageInfoModel
	{
		[NotMapped]
        public int Id => throw new NotImplementedException();
        [Key]
        [DataMember]
        public string MessageId { get; set; } = string.Empty;
        [DataMember]
        public int? ClientId { get; set; }
		[Required]
        [DataMember]
        public string SenderName { get; set; } = string.Empty;
		[Required]
        [DataMember]
        public DateTime DateDelivery { get; set; } = DateTime.Now;
		[Required]
        [DataMember]
        public string Subject { get; set; } = string.Empty;
		[Required]
        [DataMember]
        public string Body { get; set; } = string.Empty;
        [Required]
        [DataMember]
        public bool IsRead { get; private set; } = false;
        [DataMember]
        public string? ReplyText { get; private set; }
		public virtual Client? Client { get; set; }
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
    }
}
