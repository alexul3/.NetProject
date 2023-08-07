﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Enums;
using BlacksmithWorkshopDataModels.Models;

namespace BlacksmithWorkshopFileImplement.Models
{
    [DataContract]
    public class Order : IOrderModel
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public int ManufactureId { get; private set; }
        [DataMember]
        public int ClientId { get; private set; }
        [DataMember]
        public string ManufactureName { get; private set; } = string.Empty;
        [DataMember]
        public int Count { get; private set; }
        [DataMember]
        public double Sum { get; private set; }
        [DataMember]
        public OrderStatus Status { get; private set; } = OrderStatus.Неизвестен;
        [DataMember]
        public DateTime DateCreate { get; private set; } = DateTime.Now;
        [DataMember]
        public DateTime? DateImplement { get; private set; }
        public static Order? Create(OrderBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Order
            {
                Id = model.Id,
                ManufactureId = model.ManufactureId,
                ManufactureName = model.ManufactureName,
                ClientId = model.ClientId,
				Count = model.Count,
                Sum = model.Sum,
                Status = model.Status,
                DateCreate = model.DateCreate,
                DateImplement = model.DateImplement
            };
        }
        public static Order? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Order()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ManufactureId = Convert.ToInt32(element.Element("ManufactureId")!.Value),
                ManufactureName = element.Element("ManufactureName")!.Value,
                ClientId = Convert.ToInt32(element.Element("ClientId")!.Value),
                Sum = Convert.ToDouble(element.Element("Sum")!.Value),
                Count = Convert.ToInt32(element.Element("Count")!.Value),
                Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), element.Element("Status")!.Value),
                DateCreate = Convert.ToDateTime(element.Element("DateCreate")!.Value),
                DateImplement = string.IsNullOrEmpty(element.Element("DateImplement")!.Value) ? null : Convert.ToDateTime(element.Element("DateImplement")!.Value)
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
		}
        public OrderViewModel GetViewModel => new()
        {
            Id = Id,
            ManufactureId = ManufactureId,
            ManufactureName = ManufactureName,
            ClientId = ClientId,
			Count = Count,
            Sum = Sum,
            Status = Status,
            DateCreate = DateCreate,
            DateImplement = DateImplement
        };
        public XElement GetXElement => new(
            "Order",
             new XAttribute("Id", Id),
             new XElement("ManufactureId", ManufactureId.ToString()),
             new XElement("ManufactureName", ManufactureName.ToString()),
             new XElement("ClientId", ClientId.ToString()),
             new XElement("Count", Count.ToString()),
             new XElement("Sum", Sum.ToString()),
             new XElement("Status", Status.ToString()),
             new XElement("DateCreate", DateCreate.ToString()),
             new XElement("DateImplement", DateImplement.ToString())
        );
    }
}
