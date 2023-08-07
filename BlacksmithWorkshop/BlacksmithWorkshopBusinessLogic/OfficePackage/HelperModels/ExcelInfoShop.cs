using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels
{
	public class ExcelInfoShop
	{
		public string FileName { get; set; } = string.Empty;
		public string Title { get; set; } = string.Empty;
		public List<ReportShopManufactureViewModel> ShopManufactures { get; set; } = new();
	}
}
