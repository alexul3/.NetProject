using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.BindingModels
{
	public class MessageInfoBindingModel : IMessageInfoModel
	{
		public string MessageId { get; set; } = string.Empty;
		public int? ClientId { get; set; }
		public string SenderName { get; set; } = string.Empty;
		public string Subject { get; set; } = string.Empty;
		public string Body { get; set; } = string.Empty;
		public DateTime DateDelivery { get; set; }
        public bool IsRead { get; set; } = false;
        public string? ReplyText { get; set; } = string.Empty;
        public int Id => throw new NotImplementedException();
    }
}
