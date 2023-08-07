using Microsoft.Extensions.Logging;
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
using BlacksmithWorkshopDataModels.Models;

namespace BlacksmithWorkshopBusinessLogic.BusinessLogics
{
    public class ShopLogic : IShopLogic
    {
        private readonly ILogger _logger;
        private readonly IShopStorage _shopStorage;
        public ShopLogic(ILogger<ShopLogic> logger, IShopStorage shopStorage)
        {
            _logger = logger;
            _shopStorage = shopStorage;
        }
        public List<ShopViewModel>? ReadList(ShopSearchModel? model)
        {
            _logger.LogInformation("ReadList. ShopName: {ShopName}. Id: {Id}", model?.ShopName, model?.Id);
            var list = model == null ? _shopStorage.GetFullList() : _shopStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count: {Count}", list.Count);
            return list;
        }
        public ShopViewModel? ReadElement(ShopSearchModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            _logger.LogInformation("ReadElement. ShopName: {ShopName}. Id: {Id}", model.ShopName, model.Id);
            var element = _shopStorage.GetElement(model);
            if (element == null)
            {
                _logger.LogWarning("ReadElement element not found");
                return null;
            }
            _logger.LogInformation("ReadElement find. Id: {Id}", element.Id);
            return element;
        }
        public bool Create(ShopBindingModel model)
        {
            CheckModel(model);
            if (_shopStorage.Insert(model) == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            return true;
        }
        public bool Update(ShopBindingModel model)
        {
            CheckModel(model);
            if (_shopStorage.Update(model) == null)
            {
                _logger.LogWarning("Update operation failed");
                return false;
            }
            return true;
        }
        public bool Delete(ShopBindingModel model)
        {
            CheckModel(model, false);
            _logger.LogInformation("Delete. Id: {Id}", model.Id);
            if (_shopStorage.Delete(model) == null)
            {
                _logger.LogWarning("Delete operation failed");
                return false;
            }
            return true;
        }
        private void CheckModel(ShopBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (string.IsNullOrEmpty(model.ShopName))
            {
                throw new ArgumentNullException("Нет названия магазина", nameof(model.ShopName));
            }
            _logger.LogInformation("Shop. ShopName:{0}. Address:{1}. Id:{2}", model.ShopName, model.Address, model.Id);
            var element = _shopStorage.GetElement(new ShopSearchModel
            {
                ShopName = model.ShopName
            });
            if (element != null && element.Id != model.Id && element.ShopName == model.ShopName)
            {
                throw new InvalidOperationException("Магазин с таким названием уже есть");
            }
        }
		public bool AddManufactureInShop(ShopSearchModel model, IManufactureModel manufacture, int count)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			if (count < 0)
			{
				throw new ArgumentException("Количество поездок должно быть больше 0", nameof(count));
			}
			_logger.LogInformation("AddManufactureInShop. ShopName:{ShopName}. Id:{Id}", model.ShopName, model.Id);
			var shop = _shopStorage.GetElement(model);
			if (shop == null)
			{
				_logger.LogWarning("AddManufactureInShop element not found");
				return false;
			}
			if (shop.Capacity - shop.ListManufacture.Select(x => x.Value.Item2).Sum() < count)
			{
				throw new ArgumentNullException("В магазине не хватает места", nameof(count));
			}
			if (shop.ListManufacture.ContainsKey(manufacture.Id))
			{
				shop.ListManufacture[manufacture.Id] = (manufacture, count + shop.ListManufacture[manufacture.Id].Item2);
				_logger.LogInformation("AddManufactureInShop. Added {count} {manufacture} to '{ShopName}' shop",
					count, manufacture.ManufactureName, shop.ShopName);
			}
			else
			{
				shop.ListManufacture[manufacture.Id] = (manufacture, count);
				_logger.LogInformation("AddManufactureInShop. Added {count} new manufacture {manufacture} to '{ShopName}' shop",
					count, manufacture.ManufactureName, shop.ShopName);
			}
			_shopStorage.Update(new()
			{
				Id = shop.Id,
				Address = shop.Address,
				ShopName = shop.ShopName,
				DateOpening = shop.DateOpening,
				Capacity = shop.Capacity,
				ListManufacture = shop.ListManufacture
			});
			return true;
		}
		public bool AddManufactures(IManufactureModel model, int count)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (count <= 0)
            {
                throw new ArgumentException("Количество изделий должно быть больше 0", nameof(count));
            }
            _logger.LogInformation("AddManufactures. ShopName:{ShopName}. Id:{Id}", model.ManufactureName, model.Id);
            var allFreeQuantity = _shopStorage.GetFullList().Select(x => x.Capacity - x.ListManufacture.Select(x => x.Value.Item2).Sum()).Sum();
            if (allFreeQuantity < count)
            {
                _logger.LogWarning("AddManufactures operation failed.");
                return false;
            }
            foreach (var shop in _shopStorage.GetFullList())
            {
                int freeQuantity = shop.Capacity - shop.ListManufacture.Select(x => x.Value.Item2).Sum();
                if (freeQuantity < count)
                {
                    if (!AddManufactureInShop(new() { Id = shop.Id }, model, freeQuantity))
                    {
                        _logger.LogWarning("AddManufactures operation failed.");
                        return false;
                    }
                    count -= freeQuantity;
                }
                else
                {
                    if (!AddManufactureInShop(new() { Id = shop.Id }, model, count))
                    {
                        _logger.LogWarning("AddManufactures operation failed.");
                        return false;
                    }
                    count = 0;
                }
                if (count == 0)
                {
                    return true;
                }
            }
            _logger.LogWarning("AddManufactures operation failed.");
            return false;
        }
        public bool SellManufactures(IManufactureModel model, int count)
        {
            return _shopStorage.SellManufactures(model, count);
        }
    }
}
