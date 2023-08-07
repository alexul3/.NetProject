using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StorageContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlacksmithWorkshopListImplement.Implements
{
	public class ImplementerStorage : IImplementerStorage
	{
		private readonly DataListSingleton _source;
		public ImplementerStorage()
		{
			_source = DataListSingleton.GetInstance();
		}
		public ImplementerViewModel? Delete(ImplementerBindingModel model)
		{
			for (int i = 0; i < _source.Implementers.Count; ++i)
			{
				if (_source.Implementers[i].Id == model.Id)
				{
					var element = _source.Implementers[i];
					_source.Implementers.RemoveAt(i);
					return element.GetViewModel;
				}
			}
			return null;
		}
		public ImplementerViewModel? GetElement(ImplementerSearchModel model)
		{
			if (model.Id.HasValue)
			{
				foreach (var implementer in _source.Implementers)
				{
					if (implementer.Id == model.Id)
					{
						return implementer.GetViewModel;
					}
				}
			}
			else if (!string.IsNullOrEmpty(model.ImplementerFIO))
			{
				foreach (var implementer in _source.Implementers)
				{
					if (implementer.ImplementerFIO == model.ImplementerFIO)
					{
						return implementer.GetViewModel;
					}
				}
			}
			return null;
		}
		public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
		{
			var result = new List<ImplementerViewModel>();
			if (string.IsNullOrEmpty(model.ImplementerFIO))
			{
				return result;
			}
			foreach (var implementer in _source.Implementers)
			{
				if (implementer.ImplementerFIO.Contains(model.ImplementerFIO))
				{
					result.Add(implementer.GetViewModel);
				}
			}
			return result;
		}
		public List<ImplementerViewModel> GetFullList()
		{
			var result = new List<ImplementerViewModel>();
			foreach (var implementer in _source.Implementers)
			{
				result.Add(implementer.GetViewModel);
			}
			return result;
		}
		public ImplementerViewModel? Insert(ImplementerBindingModel model)
		{
			model.Id = 1;
			foreach (var implementer in _source.Implementers)
			{
				if (model.Id <= implementer.Id)
				{
					model.Id = implementer.Id + 1;
				}
			}
			var newImplementer = Implementer.Create(model);
			if (newImplementer == null)
			{
				return null;
			}
			_source.Implementers.Add(newImplementer);
			return newImplementer.GetViewModel;
		}
		public ImplementerViewModel? Update(ImplementerBindingModel model)
		{
			foreach (var implementer in _source.Implementers)
			{
				if (implementer.Id == model.Id)
				{
					implementer.Update(model);
					return implementer.GetViewModel;
				}
			}
			return null;
		}
	}
}
