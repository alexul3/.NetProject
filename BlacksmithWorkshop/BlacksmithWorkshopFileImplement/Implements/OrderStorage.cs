using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StorageContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopFileImplement.Models;

namespace BlacksmithWorkshopFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataFileSingleton source;
        public OrderStorage()
        {
            source = DataFileSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            if (model.Id.HasValue)
            {
                return source.Orders
                    .Where(x => x.Id == model.Id)
                    .Select(x => GetViewModel(x))
                    .ToList();
            }
            else if (model.DateFrom != null && model.DateTo != null)
            {
                return source.Orders
                    .Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo)
                    .Select(x => GetViewModel(x))
                    .ToList();
            }
            else if (model.ClientId.HasValue)
            {
                return source.Orders
                    .Where(x => x.ClientId == model.ClientId)
                    .Select(x => GetViewModel(x))
                    .ToList();
            }
            return new();
        }
        public List<OrderViewModel> GetFullList()
        {
            return source.Orders.Select(x => GetViewModel(x)).ToList();
        }
        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            return source.Orders.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id))?.GetViewModel;
        }
        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = source.Orders.Count > 0 ? source.Orders.Max(x => x.Id) + 1 : 1;
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            source.Orders.Add(newOrder);
            source.SaveOrders();
            return GetViewModel(newOrder);
        }
        public OrderViewModel? Update(OrderBindingModel model)
        {
            var order = source.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            source.SaveOrders();
            return GetViewModel(order);
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            var order = source.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            source.SaveOrders();
            return GetViewModel(order);
        }
        private OrderViewModel GetViewModel(Order order)
        {
            var viewModel = order.GetViewModel;
            foreach (var manufacture in source.Manufactures)
            {
                if (manufacture.Id == order.ManufactureId)
                {
                    viewModel.ManufactureName = manufacture.ManufactureName;
                    break;
                }
            }
            return viewModel;
        }
    }
}
