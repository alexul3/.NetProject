using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopContracts.BusinessLogicsContracts
{
    public interface IReportLogic
    {
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>
        List<ReportManufactureComponentViewModel> GetManufactureComponent();
        /// <summary>
		/// Получение списка магазинов с изделиями
		/// </summary>
		/// <returns></returns>
		List<ReportShopManufactureViewModel> GetShopManufacture();
		/// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);
        /// <summary>
		/// Получение списка заказов за весь период
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		List<ReportOrdersByDateViewModel> GetOrdersByDate();
		/// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        void SaveComponentsToWordFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        void SaveManufactureComponentToExcelFile(ReportBindingModel model);
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        void SaveOrdersToPdfFile(ReportBindingModel model);
		/// <summary>
		/// Сохранение магазинов в файл-Word
		/// </summary>
		/// <param name="model"></param>
		void SaveShopsToWordFile(ReportBindingModel model);
		/// <summary>
		/// Сохранение магазинов с указаеним изделий в файл-Excel
		/// </summary>
		/// <param name="model"></param>
		void SaveShopManufactureToExcelFile(ReportBindingModel model);
		/// <summary>
		/// Сохранение заказов по дате в файл-Pdf
		/// </summary>
		/// <param name="model"></param>
		public void SaveOrdersByDateToPdfFile(ReportBindingModel model);
    }
}