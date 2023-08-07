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
	public class ImplementerStorage : IImplementerStorage
	{
		private readonly DataFileSingleton source;
		public ImplementerStorage()
		{
			source = DataFileSingleton.GetInstance();
		}
		public ImplementerViewModel? Delete(ImplementerBindingModel model)
		{
			var element = source.Implementers.FirstOrDefault(x => x.Id == model.Id);
			if (element != null)
			{
				source.Implementers.Remove(element);
				source.SaveImplementers();
				return element.GetViewModel;
			}
			return null;
		}
		public ImplementerViewModel? GetElement(ImplementerSearchModel model)
		{
			if (string.IsNullOrEmpty(model.ImplementerFIO) && !model.Id.HasValue)
			{
				return null;
			}
			return source.Implementers
				.FirstOrDefault(x =>
				(!string.IsNullOrEmpty(model.ImplementerFIO) && x.ImplementerFIO == model.ImplementerFIO) ||
					(model.Id.HasValue && x.Id == model.Id))
				?.GetViewModel;
		}
		public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
		{
			if (string.IsNullOrEmpty(model.ImplementerFIO))
			{
				return new();
			}
			return source.Implementers
				.Where(x => x.ImplementerFIO.Contains(model.ImplementerFIO))
				.Select(x => x.GetViewModel)
				.ToList();
		}
		public List<ImplementerViewModel> GetFullList()
		{
			return source.Implementers.Select(x => x.GetViewModel).ToList();
		}
		public ImplementerViewModel? Insert(ImplementerBindingModel model)
		{
			model.Id = source.Implementers.Count > 0 ? source.Implementers.Max(x => x.Id) + 1 : 1;
			var newImplementer = Implementer.Create(model);
			if (newImplementer == null)
			{
				return null;
			}
			source.Implementers.Add(newImplementer);
			source.SaveImplementers();
			return newImplementer.GetViewModel;
		}
		public ImplementerViewModel? Update(ImplementerBindingModel model)
		{
			var implementer = source.Implementers.FirstOrDefault(x => x.Id == model.Id);
			if (implementer == null)
			{
				return null;
			}
			implementer.Update(model);
			source.SaveImplementers();
			return implementer.GetViewModel;
		}
	}
}
