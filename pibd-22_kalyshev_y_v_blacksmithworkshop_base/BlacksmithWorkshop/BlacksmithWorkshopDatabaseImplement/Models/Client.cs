﻿using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BlacksmithWorkshopDatabaseImplement.Models
{
    [DataContract]
    public class Client : IClientModel
    {
        [DataMember]
        public int Id { get; set; }
        [Required]
        [DataMember]
        public string ClientFIO { get; set; } = string.Empty;
        [Required]
        [DataMember]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataMember]
        public string Password { get; set; } = string.Empty;
        [ForeignKey("ClientId")]
        public virtual List<Order> Orders { get; set; } = new();
        public static Client? Create(ClientBindingModel? model)
        {
            if (model == null)
            {
                return null;
            }
            return new Client()
            {
                Id = model.Id,
                ClientFIO = model.ClientFIO,
                Email = model.Email,
                Password = model.Password
            };
        }
        public void Update(ClientBindingModel? model)
        {
            if (model == null)
            {
                return;
            }
            ClientFIO = model.ClientFIO;
            Email = model.Email;
            Password = model.Password;
        }
        public ClientViewModel GetViewModel => new()
        {
            Id = Id,
            ClientFIO = ClientFIO,
            Email = Email,
            Password = Password
        };
    }
}
