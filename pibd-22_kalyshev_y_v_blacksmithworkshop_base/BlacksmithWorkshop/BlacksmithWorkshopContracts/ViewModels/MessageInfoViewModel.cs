using BlacksmithWorkshopContracts.Attributes;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.ViewModels
{
	public class MessageInfoViewModel : IMessageInfoModel 
	{
        [Column(visible: false)]
        public string MessageId { get; set; } = string.Empty;
		[Column(visible: false)]
		public int? ClientId { get; set; }
        [Column(title: "Отправитель", width: 150)]
        public string SenderName { get; set; } = string.Empty;
        [Column(title: "Дата письма", width: 150, formattedDate: true)]
        public DateTime DateDelivery { get; set; }
        [Column(title: "Заголовок", width: 150)]
        public string Subject { get; set; } = string.Empty;
        [Column(title: "Текст", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string Body { get; set; } = string.Empty;
        [Column(visible: false)]
        public int Id => throw new NotImplementedException();
        [Column(title: "Прочитано", width: 150)]
        public bool IsRead { get; set; } = false;
        [Column(title: "Ответ", width: 150)]
        public string? ReplyText { get; set; }
    }
}
