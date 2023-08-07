using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Models;
using BlacksmithWorkshopShopApp.Models;

namespace BlacksmithWorkshopShopApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            if (!ApiClient.AuthorizationDone)
            {
                return Redirect("~/Home/Enter");
            }
            return View(ApiClient.GetRequest<List<ShopViewModel>>($"api/shop/getshoplist"));
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }
        [HttpPost]
        public void Enter(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Введите пароль");
            }
            else if (!ApiClient.TryLogin(password))
            {
                throw new Exception("Неверный пароль");
            }
            Response.Redirect("Index");
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public void Create(string shopName, string address, DateTime dateOpening, int capacity)
        {
            if (!ApiClient.AuthorizationDone)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            if (string.IsNullOrEmpty(shopName))
            {
                throw new Exception("Название магазина не указано");
            }
            if (string.IsNullOrEmpty(address))
            {
                throw new Exception("Адрес магазина не указано");
            }
            if (capacity <= 0)
            {
                throw new Exception("Вместимость магазина должна быть больше нуля");
            }
            ApiClient.PostRequest("api/shop/createshop", new ShopBindingModel
            {
                ShopName = shopName,
                Address = address,
                DateOpening = dateOpening,
                Capacity = capacity
            });
            Response.Redirect("Index");
        }
        [HttpGet]
        public Tuple<ShopViewModel, string>? GetShopWithManufactures(int shopId)
        {
            var result = ApiClient.GetRequest<Tuple<ShopViewModel, List<ManufactureViewModel>, List<int>>>
                ($"api/shop/getshopwithmanufactures?shopId={shopId}");
            if (result == null)
            {
                return default;
            }
            string manufactureTable = "";
            for (int i = 0; i < result.Item2.Count; i++)
            {
                var manufacture = result.Item2[i];
                var count = result.Item3[i];
                manufactureTable += "<tr>";
                manufactureTable += $"<td>{manufacture.ManufactureName}</td>";
                manufactureTable += $"<td>{manufacture.Price}</td>";
                manufactureTable += $"<td>{count}</td>";
                manufactureTable += "</tr>";
            }
            return Tuple.Create(result.Item1, manufactureTable);
        }
        [HttpGet]
        public IActionResult Update()
        {
            if (!ApiClient.AuthorizationDone)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Shops = ApiClient.GetRequest<List<ShopViewModel>>($"api/shop/getshoplist");
            return View();
        }
        [HttpPost]
        public void Update(int shop, string shopName, string address, DateTime dateOpening, int capacity)
        {
            if (!ApiClient.AuthorizationDone)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            if (string.IsNullOrEmpty(shopName))
            {
                throw new Exception("Название магазина не указано");
            }
            if (string.IsNullOrEmpty(address))
            {
                throw new Exception("Адрес магазина не указано");
            }
            if (capacity <= 0)
            {
                throw new Exception("Вместимость магазина должна быть больше нуля");
            }
            var listManufacture = ApiClient.GetRequest<Dictionary<int, (IManufactureModel, int)>>($"api/shop/getshopmanufactures?shopId={shop}");
            ApiClient.PostRequest("api/shop/updateshop", new ShopBindingModel
            {
                Id = shop,
                ShopName = shopName,
                Address = address,
                DateOpening = dateOpening.Date,
                Capacity = capacity,
                ListManufacture = listManufacture!
            });
            Response.Redirect("Index");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            if (!ApiClient.AuthorizationDone)
            {
                return Redirect("~/Home/Enter");
            }
            ViewBag.Shops = ApiClient.GetRequest<List<ShopViewModel>>($"api/shop/getshoplist");
            return View();
        }
        [HttpPost]
        public void Delete(int shop)
        {
            if (!ApiClient.AuthorizationDone)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            ApiClient.PostRequest("api/shop/deleteshop", new ShopBindingModel
            {
                Id = shop,
            });
            Response.Redirect("Index");
        }
        [HttpGet]
        public IActionResult AddManufacture()
        {
            ViewBag.Shops = ApiClient.GetRequest<List<ShopViewModel>>("api/shop/getshoplist");
            ViewBag.Manufactures = ApiClient.GetRequest<List<ManufactureViewModel>>("api/main/getmanufacturelist");
            return View();
        }
        [HttpPost]
        public void AddManufacture(int shop, int manufacture, int count)
        {
            if (!ApiClient.AuthorizationDone)
            {
                throw new Exception("Вы как суда попали? Суда вход только авторизованным");
            }
            if (count <= 0)
            {
                throw new Exception("Количество должно быть больше 0");
            }
            ApiClient.PostRequest("api/shop/addmanufactureinshop", Tuple.Create(
                new ShopSearchModel() { Id = shop },
                new ManufactureViewModel() { Id = manufacture },
                count
            ));
            Response.Redirect("Index");
        }
    }
}