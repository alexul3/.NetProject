using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Enums;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
    [DataContract]
    public class Order : IOrderModel
    {
        [DataMember]
        public int Id { get; set; }
        [Required]
        [DataMember]
        public int ManufactureId { get; set; }
        [Required]
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
		[Required]
        [DataMember]
        public int Count { get; set; }
        [Required]
        [DataMember]
        public double Sum { get; set; }
        [Required]
        [DataMember]
        public OrderStatus Status { get; set; }
        [Required]
        [DataMember]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Manufacture Manufacture { get; set; }
        public virtual Client Client { get; set; }
		public virtual Implementer? Implementer { get; set; }
		public static Order? Create(OrderBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Order()
            {
                Id = model.Id,
                ManufactureId  = model.ManufactureId,
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
			if (model.ImplementerId.HasValue)
			{
				ImplementerId = model.ImplementerId;
			}
		}
        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            ManufactureId = ManufactureId,
            ManufactureName = Manufacture.ManufactureName,
            ClientId = ClientId,
            ClientFIO = Client.ClientFIO,
			ImplementerId = ImplementerId,
			ImplementerFIO = Implementer == null ? null : Implementer.ImplementerFIO,
			Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement
        };
    }
}
