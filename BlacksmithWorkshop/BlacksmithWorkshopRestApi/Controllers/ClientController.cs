using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlacksmithWorkshopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly ILogger _logger;
        private readonly IClientLogic _logic;
		private readonly IMessageInfoLogic _mailLogic;
		public ClientController(IClientLogic logic, IMessageInfoLogic mailLogic, ILogger<ClientController> logger)
        {
            _logger = logger;
            _logic = logic;
			_mailLogic = mailLogic;
		}
        [HttpGet]
        public ClientViewModel? Login(string login, string password)
        {
            try
            {
                return _logic.ReadElement(new ClientSearchModel
                {
                    Email = login,
                    Password = password
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка входа в систему");
                throw;
            }
        }
        [HttpPost]
        public void Register(ClientBindingModel model)
        {
            try
            {
                _logic.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка регистрации");
                throw;
            }
        }
        [HttpPost]
        public void UpdateData(ClientBindingModel model)
        {
            try
            {
                _logic.Update(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обновления данных");
                throw;
            }
        }
        [HttpGet]
        public List<MessageInfoViewModel>? GetMessages(int clientId, int page)
        {
            try
            {
                return _mailLogic.ReadList(new MessageInfoSearchModel
                {
                    ClientId = clientId,
                    Page = page,
                    PageSize = 5
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка получения писем клиента");
                throw;
            }
        }
    }
}
