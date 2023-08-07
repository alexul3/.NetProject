using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.SearchModels
{
	public class MessageInfoSearchModel
	{
		public int? ClientId { get; set; }
		public string? MessageId { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
