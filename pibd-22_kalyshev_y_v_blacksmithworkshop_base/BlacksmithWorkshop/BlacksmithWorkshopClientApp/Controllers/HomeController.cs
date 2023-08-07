using BlacksmithWorkshopClientApp.Models;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlacksmithWorkshopClientApp.Controllers
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
			if (APIClient.Client == null)
			{
				return Redirect("~/Home/Enter");
			}
			return View(APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={APIClient.Client.Id}"));
		}
		[HttpGet]
		public IActionResult Privacy()
		{
			if (APIClient.Client == null)
			{
				return Redirect("~/Home/Enter");
			}
			return View(APIClient.Client);
		}
		[HttpPost]
		public void Privacy(string login, string password, string fio)
		{
			if (APIClient.Client == null)
			{
				throw new Exception("Вы как суда попали? Суда вход только авторизованным");
			}
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fio))
			{
				throw new Exception("Введите логин, пароль и ФИО");
			}
			APIClient.PostRequest("api/client/updatedata", new ClientBindingModel
			{
				Id = APIClient.Client.Id,
				ClientFIO = fio,
				Email = login,
				Password = password
			});

			APIClient.Client.ClientFIO = fio;
			APIClient.Client.Email = login;
			APIClient.Client.Password = password;
			Response.Redirect("Index");
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
		public void Enter(string login, string password)
		{
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
			{
				throw new Exception("Введите логин и пароль");
			}
			APIClient.Client = APIClient.GetRequest<ClientViewModel>($"api/client/login?login={login}&password={password}");
			if (APIClient.Client == null)
			{
				throw new Exception("Неверный логин/пароль");
			}
			Response.Redirect("Index");
		}
		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public void Register(string login, string password, string fio)
		{
			if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fio))
			{
				throw new Exception("Введите логин, пароль и ФИО");
			}
			APIClient.PostRequest("api/client/register", new ClientBindingModel
			{
				ClientFIO = fio,
				Email = login,
				Password = password
			});
			Response.Redirect("Enter");
			return;
		}
		[HttpGet]
		public IActionResult Create()
		{
			ViewBag.Manufactures = APIClient.GetRequest<List<ManufactureViewModel>>("api/main/getmanufacturelist");
			return View();
		}
		[HttpPost]
		public void Create(int manufacture, int count)
		{
			if (APIClient.Client == null)
			{
				throw new Exception("Вы как суда попали? Суда вход только авторизованным");
			}
			if (count <= 0)
			{
				throw new Exception("Количество и сумма должны быть больше 0");
			}
			APIClient.PostRequest("api/main/createorder", new OrderBindingModel
			{
				ClientId = APIClient.Client.Id,
				ManufactureId = manufacture,
				Count = count,
				Sum = Calc(count, manufacture)
			});
			Response.Redirect("Index");
		}

		[HttpPost]
		public double Calc(int count, int manufacture)
		{
			var prod = APIClient.GetRequest<ManufactureViewModel>($"api/main/getmanufacture?manufactureId={manufacture}");
			return count * (prod?.Price ?? 1);
		}
        [HttpGet]
        public IActionResult Mails(int page = 0)
        {
            if (APIClient.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            var messages = APIClient.GetRequest<List<MessageInfoViewModel>>($"api/client/getmessages?clientId={APIClient.Client.Id}&page={page}");
            ViewBag.PageIsLast = messages!.Count == 0;
            ViewBag.Page = page;
            return View(messages);
        }
    }
}