using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Enums;
using BlacksmithWorkshopDataModels.Models;

namespace BlacksmithWorkshopListImplement.Models
{
    [DataContract]
    public class Order : IOrderModel
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public int ManufactureId { get; private set; }
        [DataMember]
        public string ManufactureName { get; private set; } = string.Empty;
        [DataMember]
        public int ClientId { get; private set; }
        [DataMember]
        public int? ImplementerId { get; private set; }
        [DataMember]
        public int Count { get; private set; }
        [DataMember]
        public double Sum { get; private set; }
        [DataMember]
        public OrderStatus Status { get; set; } = OrderStatus.Неизвестен;
        [DataMember]
        public DateTime DateCreate { get; set; } = DateTime.Now;
        [DataMember]
        public DateTime? DateImplement { get; set; }
        public static Order? Create(OrderBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Order()
            {
                Id = model.Id,
                ManufactureId = model.ManufactureId,
                ManufactureName = model.ManufactureName,
                ClientId = model.ClientId,
                ImplementerId = model.ImplementerId,
				Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement
            };
        }

        public void Update(OrderBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            Status = model.Status;
            DateImplement = model.DateImplement;
            ImplementerId = model.ImplementerId;
		}
        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            ManufactureId = ManufactureId,
            ManufactureName = ManufactureName,
            ClientId = ClientId,
            ImplementerId = ImplementerId,
            Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement
        };
    }
}
