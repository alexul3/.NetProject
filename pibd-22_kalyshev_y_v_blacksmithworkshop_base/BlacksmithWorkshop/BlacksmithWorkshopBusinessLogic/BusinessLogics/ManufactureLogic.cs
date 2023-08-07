using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StorageContracts;
using BlacksmithWorkshopContracts.ViewModels;
using Microsoft.Extensions.Logging;

namespace BlacksmithWorkshopBusinessLogic.BusinessLogics
{
    public class ManufactureLogic : IManufactureLogic
    {
        private readonly ILogger _logger;
        private readonly IManufactureStorage _ManufactureStorage;

        public ManufactureLogic(ILogger<ManufactureLogic> logger, IManufactureStorage ManufactureStorage)
        {
            _logger = logger;
            _ManufactureStorage = ManufactureStorage;
        }

        public List<ManufactureViewModel>? ReadList(ManufactureSearchModel? model)
        {
            _logger.LogInformation("ReadList. ManufactureName:{ManufactureName}.Id:{ Id}", model?.ManufactureName, model?.Id);
            var list = model == null ? _ManufactureStorage.GetFullList() : _ManufactureStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }

        public ManufactureViewModel? ReadElement(ManufactureSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. ManufactureName:{ManufactureName}.Id:{ Id}", model.ManufactureName, model.Id);
            var element = _ManufactureStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
            return element;
        }

        public bool Create(ManufactureBindingModel model)
        {
            CheckModel(model);
            if (_ManufactureStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }

        public bool Update(ManufactureBindingModel model)
        {
            CheckModel(model);
            if (_ManufactureStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }

        public bool Delete(ManufactureBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id:{Id}", model.Id);
            if (_ManufactureStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }

        private void CheckModel(ManufactureBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.ManufactureName))
            {
                throw new ArgumentNullException("Нет названия компьютера", nameof(model.ManufactureName));
            }
            if (model.Price <= 0)
            {
                throw new ArgumentNullException("Цена компьютера должна быть больше 0", nameof(model.Price));
            }
            _logger.LogInformation("Manufacture. ManufactureName:{ManufactureName}.Cost:{ Cost}. Id: { Id}", model.ManufactureName, model.Price, model.Id);
            var element = _ManufactureStorage.GetElement(new ManufactureSearchModel
            {
                ManufactureName = model.ManufactureName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new InvalidOperationException("Компьютер с таким названием уже есть");
            }
        }
    }
}
