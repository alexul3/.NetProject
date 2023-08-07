using System;
using System.Collections;
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
    public class ManufactureStorage : IManufactureStorage
    {
        private readonly DataListSingleton _source;
        public ManufactureStorage()
        {
            _source = DataListSingleton.GetInstance();
        }
        public List<ManufactureViewModel> GetFullList()
        {
            var result = new List<ManufactureViewModel>();
            foreach (var Manufacture in _source.Manufactures)
            {
                result.Add(Manufacture.GetViewModel);
            }
            return result;
        }
        public List<ManufactureViewModel> GetFilteredList(ManufactureSearchModel model)
        {
            var result = new List<ManufactureViewModel>();
            if (string.IsNullOrEmpty(model.ManufactureName))
            {
                return result;
            }
            foreach (var Manufacture in _source.Manufactures)
            {
                if (Manufacture.ManufactureName.Contains(model.ManufactureName))
                {
                    result.Add(Manufacture.GetViewModel);
                }
            }
            return result;
        }
        public ManufactureViewModel? GetElement(ManufactureSearchModel model)
        {
            if (string.IsNullOrEmpty(model.ManufactureName) && !model.Id.HasValue)
            {
                return null;
            }
            foreach (var Manufacture in _source.Manufactures)
            {
                if ((!string.IsNullOrEmpty(model.ManufactureName) && Manufacture.ManufactureName == model.ManufactureName) ||
                (model.Id.HasValue && Manufacture.Id == model.Id))
                {
                    return Manufacture.GetViewModel;
                }
            }
            return null;
        }
        public ManufactureViewModel? Insert(ManufactureBindingModel model)
        {
            model.Id = 1;
            foreach (var Manufacture in _source.Manufactures)
            {
                if (model.Id <= Manufacture.Id)
                {
                    model.Id = Manufacture.Id + 1;
                }
            }
            var newManufacture = Manufacture.Create(model);
            if (newManufacture == null)
            {
                return null;
            }
            _source.Manufactures.Add(newManufacture);
            return newManufacture.GetViewModel;
        }
        public ManufactureViewModel? Update(ManufactureBindingModel model)
        {
            foreach (var Manufacture in _source.Manufactures)
            {
                if (Manufacture.Id == model.Id)
                {
                    Manufacture.Update(model);
                    return Manufacture.GetViewModel;
                }
            }
            return null;
        }
        public ManufactureViewModel? Delete(ManufactureBindingModel model)
        {
            for (int i = 0; i < _source.Manufactures.Count; ++i)
            {
                if (_source.Manufactures[i].Id == model.Id)
                {
                    var element = _source.Manufactures[i];
                    _source.Manufactures.RemoveAt(i);
                    return element.GetViewModel;
                }
            }
            return null;
        }
    }
}
