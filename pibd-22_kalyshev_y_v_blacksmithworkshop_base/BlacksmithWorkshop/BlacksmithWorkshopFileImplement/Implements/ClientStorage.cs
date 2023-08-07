using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StorageContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopFileImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        private readonly DataFileSingleton source;
        public ClientStorage()
        {
            source = DataFileSingleton.GetInstance();
        }
        public List<ClientViewModel> GetFullList()
        {
            return source.Clients
                .Select(x => x.GetViewModel)
                .ToList();
        }
        public List<ClientViewModel> GetFilteredList(ClientSearchModel model)
        {
            if (!string.IsNullOrEmpty(model.Email))
            {
                return source.Clients
                    .Where(x => x.Email.Contains(model.Email))
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            return new();
        }
        public ClientViewModel? GetElement(ClientSearchModel model)
        {
            if (model.Id.HasValue)
            {
                return source.Clients
                    .FirstOrDefault(x => (x.Id == model.Id))?.GetViewModel;
            }
            else if (!string.IsNullOrEmpty(model.Email) && !string.IsNullOrEmpty(model.Password))
            {
                return source.Clients
                    .FirstOrDefault(x => (x.Email == model.Email && x.Password == model.Password))?.GetViewModel;
            }
            return new();
        }
        public ClientViewModel? Insert(ClientBindingModel model)
        {
            model.Id = source.Clients.Count > 0 ? source.Clients.Max(x => x.Id) + 1 : 1;
            var newClient = Client.Create(model);
            if (newClient == null)
            {
                return null;
            }
            source.Clients.Add(newClient);
            source.SaveClients();
            return newClient.GetViewModel;
        }
        public ClientViewModel? Update(ClientBindingModel model)
        {
            var client = source.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (client == null)
            {
                return null;
            }
            client.Update(model);
            source.SaveClients();
            return client.GetViewModel;
        }
        public ClientViewModel? Delete(ClientBindingModel model)
        {
            var client = source.Clients.FirstOrDefault(x => x.Id == model.Id);
            if (client != null)
            {
                source.Clients.Remove(client);
                source.SaveClients();
                return client.GetViewModel;
            }
            return null;
        }
    }
}
