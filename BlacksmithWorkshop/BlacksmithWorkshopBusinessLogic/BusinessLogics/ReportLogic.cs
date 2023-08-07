using BlacksmithWorkshopBusinessLogic.OfficePackage.HelperModels;
using BlacksmithWorkshopBusinessLogic.OfficePackage;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopContracts.StorageContracts;

namespace ManufactureCompanyBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IManufactureStorage _manufactureStorage;
        private readonly IOrderStorage _orderStorage;
		private readonly IShopStorage _shopStorage;
        private readonly AbstractSaveToExcel _saveToExcel;
        private readonly AbstractSaveToWord _saveToWord;
        private readonly AbstractSaveToPdf _saveToPdf;
        public ReportLogic(IManufactureStorage manufactureStorage, IComponentStorage componentStorage, IOrderStorage orderStorage, IShopStorage shopStorage,

            AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _manufactureStorage = manufactureStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
            _shopStorage = shopStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        public List<ReportManufactureComponentViewModel> GetManufactureComponent()
        {
            var components = _componentStorage.GetFullList();
            var manufactures = _manufactureStorage.GetFullList();
            var list = new List<ReportManufactureComponentViewModel>();

            foreach (var manufacture in manufactures)
            {
                var record = new ReportManufactureComponentViewModel
                {
                    ManufactureName = manufacture.ManufactureName,
                    Components = new List<(string, int)>(),
                    TotalCount = 0
                };
                foreach (var component in components)
                {
                    if (manufacture.ManufactureComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new(component.ComponentName, manufacture.ManufactureComponents[component.Id].Item2));
                        record.TotalCount += manufacture.ManufactureComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }

            return list;
        }

		/// <summary>
		/// Получение списка компонент с указанием, в каких изделиях используются
		/// </summary>
		/// <returns></returns>
		public List<ReportShopManufactureViewModel> GetShopManufacture()
		{
			var shops = _shopStorage.GetFullList();
			var list = new List<ReportShopManufactureViewModel>();

			foreach (var shop in shops)
			{
				var record = new ReportShopManufactureViewModel
				{
					ShopName = shop.ShopName,
					Manufactures = new List<(string, int)>(),
					TotalCount = 0
				};
				foreach (var manufacture in shop.ListManufacture)
				{
					record.Manufactures.Add(new(manufacture.Value.Item1.ManufactureName, manufacture.Value.Item2));
					record.TotalCount += manufacture.Value.Item2;
				}
				list.Add(record);
			}
            return list;
        }

        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderSearchModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
                .Select(x => new ReportOrdersViewModel
                {
                    Id = x.Id,
                    DateCreate = x.DateCreate,
                    ManufactureName = x.ManufactureName,
                    Sum = x.Sum,
                    Status = Convert.ToString(x.Status) ?? string.Empty,
                })
               .ToList();
        }

        /// <summary>
		/// Получение списка заказов за весь период
		/// </summary>
		/// <returns></returns>
		public List<ReportOrdersByDateViewModel> GetOrdersByDate()
		{
			return _orderStorage.GetFullList()
				.GroupBy(x => x.DateCreate.Date)
				.Select(x => new ReportOrdersByDateViewModel
				{
					DateCreate = x.Key,
					Count = x.Count(),
					Sum = x.Sum(x => x.Sum)
				})
				.ToList();
		}

		/// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Manufactures = _manufactureStorage.GetFullList()
            });
        }

        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SaveManufactureComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                ManufactureComponents = GetManufactureComponent()
            });
        }

        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom!.Value,
                DateTo = model.DateTo!.Value,
                Orders = GetOrders(model)
            });
        }
		/// <summary>
		/// Сохранение магазинов в файл-Word
		/// </summary>
		/// <param name="model"></param>
		public void SaveShopsToWordFile(ReportBindingModel model)
		{
			_saveToWord.CreateDocShopTable(new WordInfoShopTable
			{
				FileName = model.FileName,
				Title = "Список магазинов",
				Shops = _shopStorage.GetFullList()
			});
		}
		/// <summary>
		/// Сохранение магазинов с указаеним поездок в файл-Excel
		/// </summary>
		/// <param name="model"></param>
		public void SaveShopManufactureToExcelFile(ReportBindingModel model)
		{
			_saveToExcel.CreateShopReport(new ExcelInfoShop
			{
				FileName = model.FileName,
				Title = "Список магазинов",
				ShopManufactures = GetShopManufacture()
			});
		}
		/// <summary>
		/// Сохранение заказов в файл-Pdf
		/// </summary>
		/// <param name="model"></param>
		public void SaveOrdersByDateToPdfFile(ReportBindingModel model)
		{
			_saveToPdf.CreateDocOrdersByDate(new PdfInfoOrdersByDate
			{
				FileName = model.FileName,
				Title = "Список заказов",
				Orders = GetOrdersByDate()
			});
		}
    }
}
