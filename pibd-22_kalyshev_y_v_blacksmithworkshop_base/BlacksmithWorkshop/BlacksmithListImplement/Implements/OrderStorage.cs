using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StorageContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopListImplement.Models;

namespace BlacksmithWorkshopListImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly DataListSingleton _source;
        public OrderStorage()
        {
            _source = DataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            var result = new List<OrderViewModel>();
            foreach (var Order in _source.Orders)
            {
                result.Add(Order.GetViewModel);
            }
            return result;
        }
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            var result = new List<OrderViewModel>();
            if (model.Id.HasValue)
            {
                foreach (var order in _source.Orders)
                {
                    if (order.Id == model.Id)
                    {
                        result.Add(order.GetViewModel);
                    }
                }
            }
            else if (model.DateFrom != null && model.DateTo != null)
            {
                foreach (var order in _source.Orders)
                {
                    if (order.DateCreate >= model.DateFrom && order.DateCreate <= model.DateTo)
                    {
                        result.Add(order.GetViewModel);
                    }
                }
            }
            else if (model.ClientId.HasValue)
            {
                foreach (var order in _source.Orders)
                {
                    if (order.ClientId == model.ClientId)
                    {
                        result.Add(order.GetViewModel);
                    }
                }
            }
            return result;
        }
        public OrderViewModel? GetElement(OrderSearchModel model)
        {
            if (!model.Id.HasValue)
            {
                return null;
            }
            foreach (var Order in _source.Orders)
            {
                if (model.Id.HasValue && Order.Id == model.Id)
                {
                    return Order.GetViewModel;
                }
            }
			if (model.Id.HasValue)
			{
				foreach (var Order in _source.Orders)
				{
					if (Order.Id == model.Id)
					{
						return Order.GetViewModel;
					}
				}
			}
			else if (model.ImplementerId.HasValue && model.Status.HasValue)
			{
				foreach (var Order in _source.Orders)
				{
					if (Order.ImplementerId == model.ImplementerId && Order.Status == model.Status)
					{
						return Order.GetViewModel;
					}
				}
			}
			return null;
		}
        public OrderViewModel? Insert(OrderBindingModel model)
        {
            model.Id = 1;
            foreach (var Order in _source.Orders)
            {
                if (model.Id <= Order.Id)
                {
                    model.Id = Order.Id + 1;
                }
            }
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            _source.Orders.Add(newOrder);
            return newOrder.GetViewModel;
        }
        public OrderViewModel? Update(OrderBindingModel model)
        {
            foreach (var Order in _source.Orders)
            {
                if (Order.Id == model.Id)
                {
                    Order.Update(model);
                    return Order.GetViewModel;
                }
            }
            return null;
        }
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            for (int i = 0; i < _source.Orders.Count; ++i)
            {
                if (_source.Orders[i].Id == model.Id)
                {
                    var element = _source.Orders[i];
                    _source.Orders.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}
