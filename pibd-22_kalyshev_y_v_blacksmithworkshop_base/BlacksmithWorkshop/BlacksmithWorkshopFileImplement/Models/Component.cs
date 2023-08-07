﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace BlacksmithWorkshopFileImplement.Models
{
    [DataContract]
    public class Component : IComponentModel
    {
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string ComponentName { get; private set; } = string.Empty;
        [DataMember]
        public double Cost { get; set; }
        public static Component? Create(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Component()
            {
                Id = model.Id,
                ComponentName = model.ComponentName,
                Cost = model.Cost
            };
        }
        public static Component? Create(XElement element)
        {
            if (element == null)
            {
                return null;
            }
            return new Component()
            {
                Id = Convert.ToInt32(element.Attribute("Id")!.Value),
                ComponentName = element.Element("ComponentName")!.Value,
                Cost = Convert.ToDouble(element.Element("Cost")!.Value)
            };
        }
        public void Update(ComponentBindingModel model)
        {
            if (model == null)
            {
                return;
            }
            ComponentName = model.ComponentName;
            Cost = model.Cost;
        }
        public ComponentViewModel GetViewModel => new()
        {
            Id = Id,
            ComponentName = ComponentName,
            Cost = Cost
        };
        public XElement GetXElement => new("Component",
        new XAttribute("Id", Id),
        new XElement("ComponentName", ComponentName),
        new XElement("Cost", Cost.ToString()));
    }
}