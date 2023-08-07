using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StorageContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopDatabaseImplement.Implements
{
	public class ImplementerStorage : IImplementerStorage
	{
		public List<ImplementerViewModel> GetFullList()
		{
			using var context = new BlacksmithWorkshopDatabase();
			return context.Implementers
					.Select(x => x.GetViewModel)
					.ToList();
		}
		public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
		{
			using var context = new BlacksmithWorkshopDatabase();
			return context.Implementers
					.Select(x => x.GetViewModel)
					.ToList();
		}
		public ImplementerViewModel? GetElement(ImplementerSearchModel model)
		{
			if (!model.Id.HasValue)
			{
				return null;
			}
			using var context = new BlacksmithWorkshopDatabase();
			return context.Implementers
					.FirstOrDefault(x => model.Id.HasValue && x.Id == model.Id)
					?.GetViewModel;
		}
		public ImplementerViewModel? Insert(ImplementerBindingModel model)
		{
			var newImplementer = Implementer.Create(model);
			if (newImplementer == null)
			{
				return null;
			}
			using var context = new BlacksmithWorkshopDatabase();
			context.Implementers.Add(newImplementer);
			context.SaveChanges();
			return context.Implementers
				.FirstOrDefault(x => x.Id == newImplementer.Id)
				?.GetViewModel;
		}
		public ImplementerViewModel? Update(ImplementerBindingModel model)
		{
			using var context = new BlacksmithWorkshopDatabase();
			var implementer = context.Implementers.FirstOrDefault(x => x.Id == model.Id);
			if (implementer == null)
			{
				return null;
			}
			implementer.Update(model);
			context.SaveChanges();
			return context.Implementers
				.FirstOrDefault(x => x.Id == model.Id)
				?.GetViewModel;
		}
		public ImplementerViewModel? Delete(ImplementerBindingModel model)
		{
			using var context = new BlacksmithWorkshopDatabase();
			var implementer = context.Implementers
				.FirstOrDefault(rec => rec.Id == model.Id);
			if (implementer != null)
			{
				context.Implementers.Remove(implementer);
				context.SaveChanges();
				return implementer.GetViewModel;
			}
			return null;
		}
	}
}
