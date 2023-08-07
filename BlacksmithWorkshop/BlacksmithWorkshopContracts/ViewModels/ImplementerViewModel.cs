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
	/// <summary>
	/// Исполнитель, выполняющий заказы
	/// </summary>
	public class ImplementerViewModel : IImplementerModel
	{
        [Column(visible: false)]
        public int Id { get; set; }
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ImplementerFIO { get; set; } = string.Empty;
        [Column(title: "Пароль", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string Password { get; set; } = string.Empty;
        [Column(title: "Стаж работы", width: 150)]
        public int WorkExperience { get; set; }
        [Column(title: "Квалификация", width: 150)]
        public int Qualification { get; set; }
	}
}
