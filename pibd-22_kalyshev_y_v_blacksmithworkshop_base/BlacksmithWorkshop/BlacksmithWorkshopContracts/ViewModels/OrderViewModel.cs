using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlacksmithWorkshopDataModels.Enums;
using System.ComponentModel;
using BlacksmithWorkshopDataModels.Models;
using BlacksmithWorkshopContracts.Attributes;

namespace BlacksmithWorkshopContracts.ViewModels
{
    public class OrderViewModel : IOrderModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }
        [Column(visible: false)]
        public int ManufactureId { get; set; }
        [Column(title: "Изделие", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ManufactureName { get; set; } = string.Empty;
        [Column(visible: false)]
        public int ClientId { get; set; }
        [Column(title: "Клиент", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string ClientFIO { get; set; } = string.Empty;
        [Column(visible: false)]
        public int? ImplementerId { get; set; }
        [Column(title: "ФИО исполнителя", gridViewAutoSize: GridViewAutoSize.Fill, isUseAutoSize: true)]
        public string? ImplementerFIO { get; set; } = string.Empty;
        [Column(title: "Количество", width: 150)]
        public int Count { get; set; }
        [Column(title: "Сумма", width: 150, formattedNumber: true)]
        public double Sum { get; set; }
        [Column(title: "Статус", width: 150)]
        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;
        [Column(title: "Дата создания", width: 150, formattedDate: true)]
        public DateTime DateCreate { get; set; } = DateTime.Now;
        [Column(title: "Дата выполнения", width: 150, formattedDate: true)]
        public DateTime? DateImplement { get; set; }
    }
}
