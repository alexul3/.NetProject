using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlacksmithWorkshopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopController
    {
        private readonly ILogger _logger;
        private readonly IShopLogic _logic;
        public ShopController(IShopLogic logic, ILogger<ShopController> logger)
        {
            _logger = logger;
            _logic = logic;
        }
        [HttpGet]
        public List<ShopViewModel>? GetShopList()
        {
            try
            {
                return _logic.ReadList(null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения списка магазинов");
                throw;
            }
        }
        [HttpGet]
        public Tuple<ShopViewModel, List<ManufactureViewModel>, List<int>>? GetShopWithManufactures(int shopId)
        {
            try
            {
                var shop = _logic.ReadElement(new() { Id = shopId });
                if (shop == null)
                {
                    return null;
                }
                var tuple = Tuple.Create(shop,
                    shop.ListManufacture.Select(x => new ManufactureViewModel()
                    {
                        Id = x.Value.Item1.Id,
                        Price = x.Value.Item1.Price,
                        ManufactureName = x.Value.Item1.ManufactureName,
                    }).ToList(),
                    shop.ListManufacture.Select(x => x.Value.Item2).ToList());
                return tuple;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения магазина с поездками");
                throw;
            }
        }
        [HttpGet]
        public Dictionary<int, (IManufactureModel, int)>? GetListManufacture(int shopId)
        {
            try
            {
                var shop = _logic.ReadElement(new() { Id = shopId });
                if (shop == null)
                {
                    return null;
                }
                return shop.ListManufacture;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения поездок магазина");
                throw;
            }
        }
        [HttpPost]
        public void CreateShop(ShopBindingModel model)
        {
            try
            {
                _logic.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка создания магазина");
                throw;
            }
        }
        [HttpPost]
        public void UpdateShop(ShopBindingModel model)
        {
            try
            {
                _logic.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления магазина");
                throw;
            }
        }
        [HttpPost]
        public void DeleteShop(ShopBindingModel model)
        {
            try
            {
                _logic.Delete(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка удаления магазина");
                throw;
            }
        }
        [HttpPost]
        public void AddManufactureInShop(Tuple<ShopSearchModel, ManufactureViewModel, int> shopManufactureWithCount)
        {
            try
            {
                _logic.AddManufactureInShop(shopManufactureWithCount.Item1, shopManufactureWithCount.Item2, shopManufactureWithCount.Item3);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка добавления поездки в магазин");
                throw;
            }
        }
    }
}
