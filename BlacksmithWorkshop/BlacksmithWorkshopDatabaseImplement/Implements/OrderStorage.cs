using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using Microsoft.EntityFrameworkCore;
using BlacksmithWorkshopDatabaseImplement.Models;
using BlacksmithWorkshopContracts.StorageContracts;

namespace BlacksmithWorkshopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public OrderViewModel? Delete(OrderBindingModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                var deletedElement = context.Orders
                    .Include(x => x.Manufacture)
                    .Include(x => x.Client)
					.Include(x => x.Implementer)
					.FirstOrDefault(x => x.Id == model.Id)
                    ?.GetViewModel;
                context.Orders.Remove(element);
                context.SaveChanges();
                return deletedElement;
            }
			return null;
        }
        public OrderViewModel? GetElement(OrderSearchModel model)
        {
			if (!model.Id.HasValue)
			{
				return null;
			}
            using var context = new BlacksmithWorkshopDatabase();
			if (model.Id.HasValue)
			{
				return context.Orders
					.Include(x => x.Manufacture)
					.Include(x => x.Client)
					.Include(x => x.Implementer)
					.FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)
					?.GetViewModel;
			}
			else if (model.ImplementerId.HasValue && model.Status.HasValue)
			{
				return context.Orders
					.Include(x => x.Manufacture)
					.Include(x => x.Client)
					.Include(x => x.Implementer)
					.FirstOrDefault(x => x.ImplementerId == model.ImplementerId && x.Status == model.Status)
					?.GetViewModel;
			}
			return null;
		}
        public List<OrderViewModel> GetFilteredList(OrderSearchModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            if (model.Id.HasValue)
            {
                return context.Orders
                    .Include(x => x.Manufacture)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Where(x => x.Id == model.Id)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            else if (model.DateFrom != null && model.DateTo != null)
            {
                return context.Orders
                    .Include(x => x.Manufacture)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Where(x => x.DateCreate >= model.DateFrom && x.DateCreate <= model.DateTo)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            else if (model.ClientId.HasValue)
            {
                return context.Orders
                    .Include(x => x.Manufacture)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Where(x => x.ClientId == model.ClientId)
                    .Select(x => x.GetViewModel)
                    .ToList();
            }
            else if (model.Status.HasValue && model.ImplementerId.HasValue)
            {
                return context.Orders
                    .Include(x => x.Manufacture)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Where(x => x.Status == model.Status && x.ImplementerId == model.ImplementerId).Select(x => x.GetViewModel).ToList();
            }
            else if (model.Status.HasValue)
            {
                return context.Orders
                    .Include(x => x.Manufacture)
                    .Include(x => x.Client)
                    .Include(x => x.Implementer)
                    .Where(x => x.Status == model.Status).Select(x => x.GetViewModel).ToList();
            }
            else
            {
                return new();
            }
        }
        public List<OrderViewModel> GetFullList()
        {
            using var context = new BlacksmithWorkshopDatabase();
            return context.Orders
				.Include(x => x.Manufacture)
		        .Include(x => x.Client)
				.Include(x => x.Implementer)
				.Select(x => x.GetViewModel)
		        .ToList();
		}
        public OrderViewModel? Insert(OrderBindingModel model)
        {
            var newOrder = Order.Create(model);
            if (newOrder == null)
            {
                return null;
            }
            using var context = new BlacksmithWorkshopDatabase();
            context.Orders.Add(newOrder);
            context.SaveChanges();
            return context.Orders
                .Include(x => x.Manufacture)
                .Include(x => x.Client)
				.Include(x => x.Implementer)
				.FirstOrDefault(x => x.Id == newOrder.Id)
                ?.GetViewModel;
        }
        public OrderViewModel? Update(OrderBindingModel model)
        {
            using var context = new BlacksmithWorkshopDatabase();
            var order = context.Orders.FirstOrDefault(x => x.Id == model.Id);
            if (order == null)
            {
                return null;
            }
            order.Update(model);
            context.SaveChanges();
            return context.Orders
                .Include(x => x.Manufacture)
                .Include(x => x.Client)
				.Include(x => x.Implementer)
				.FirstOrDefault(x => x.Id == model.Id)
                ?.GetViewModel;
        }
    }
}
