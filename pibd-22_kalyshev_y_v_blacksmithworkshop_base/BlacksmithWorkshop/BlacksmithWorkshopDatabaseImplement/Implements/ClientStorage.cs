using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StorageContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using var context = new BlacksmithWorkshopDatabase();
            return context.Clients
                    .Include(x => x.Orders)
                    .Select(x => x.GetViewModel)
                    .ToList();
        }
        public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
            if (model == null)
            {
                return new();
            }
            if (!string.IsNullOrEmpty(model.Email))
            {
                using var context = new BlacksmithWorkshopDatabase();
                return context.Clients
                    .Include(x => x.Orders)
                    .Where(x => x.Email.Contains(model.Email))
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            return new();
        }
        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            if (model.Id.HasValue)
            {
                return context.Clients
                    .FirstOrDefault(x => (x.Id == model.Id))?.GetViewModel;
            }
            else if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
            {
                return context.Clients
                    .FirstOrDefault(x => (x.Email == model.Email && x.Password == model.Password))?.GetViewModel;
            }
            else if (!string.IsNullOrEmpty(model.Email))
                return context.Clients
                              .FirstOrDefault(x => x.Email == model.Email)
                              ?.GetViewModel;
            return new();
        }
        public ClientViewModel? Insert(ClientBindingModel model)
        {
            var newClient = Client.Create(model);
            if (newClient == null)
            {
                return null;
            }
            using var context = new BlacksmithWorkshopDatabase();
            context.Clients.Add(newClient);
            context.SaveChanges();
            return newClient.GetViewModel;
        }
        public ClientViewModel? Update(ClientBindingModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            var client = context.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
            {
                return null;
            }
            client.Update(model);
            context.SaveChanges();
            return client.GetViewModel;
        }
        public ClientViewModel? Delete(ClientBindingModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            var element = context.Clients
                .Include(x => x.Orders)
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Clients.Remove(element);
                context.SaveChanges();
                return element.GetViewModel;
            }
            return null;
        }
    }
}
