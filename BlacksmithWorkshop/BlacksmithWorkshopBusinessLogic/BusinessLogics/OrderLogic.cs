using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlacksmithWorkshopBusinessLogic.MailWorker;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.StorageContracts;
using BlacksmithWorkshopContracts.ViewModels;
using BlacksmithWorkshopDataModels.Enums;
using Microsoft.Extensions.Logging;

namespace BlacksmithWorkshopBusinessLogic.BusinessLogics
{
    public class OrderLogic : IOrderLogic
    {
        private readonly ILogger _logger;
        private readonly IOrderStorage _orderStorage;
		private readonly IShopLogic _shopLogic;
		private readonly IManufactureStorage _manufactureStorage;
        private readonly AbstractMailWorker _abstractMailWorker;
        private readonly IClientStorage _clientStorage;
		public OrderLogic(ILogger<OrderLogic> logger, IOrderStorage orderStorage, IShopLogic shopLogic, IManufactureStorage manufactureStorage, AbstractMailWorker abstractMailWorker, IClientStorage clientStorage)
        {
            _logger = logger;
            _orderStorage = orderStorage;
			_shopLogic = shopLogic;
			_manufactureStorage = manufactureStorage;
            _abstractMailWorker = abstractMailWorker;
            _clientStorage = clientStorage;
		}
        public List<OrderViewModel>? ReadList(OrderSearchModel? model)
        {
            _logger.LogInformation("ReadList. OrderId:{Id}", model?.Id);
            var list = model == null ? _orderStorage.GetFullList() : _orderStorage.GetFilteredList(model);
            if (list == null)
            {
                _logger.LogWarning("ReadList return null list");
                return null;
            }
            _logger.LogInformation("ReadList. Count:{Count}", list.Count);
            return list;
        }
		public OrderViewModel? ReadElement(OrderSearchModel model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model));
			}
			_logger.LogInformation("ReadElement. DateFrom:{DateFrom}. DateTo:{DateTo}. Id:{Id}", model.DateFrom, model.DateTo, model.Id);
			var element = _orderStorage.GetElement(model);
			if (element == null)
			{
				_logger.LogWarning("ReadElement element not found");
				return null;
			}
			_logger.LogInformation("ReadElement find. Id:{Id}", element.Id);
			return element;
		}
		public bool CreateOrder(OrderBindingModel model)
        {
            CheckModel(model);
            if (model.Status != OrderStatus.Неизвестен)
            {
                _logger.LogWarning("Insert operation failed. Order status is incorrect.");
                return false;
            }
            model.Status = OrderStatus.Принят;
            var order = _orderStorage.Insert(model);
            if (order == null)
            {
                _logger.LogWarning("Insert operation failed");
                return false;
            }
            var client = _clientStorage.GetElement(new() { Id = order.ClientId });
            if (client == null)
            {
                _logger.LogWarning("Client not found");
                return false;
            }
            SendMail(client.Email, $"Новый заказ создан. Номер заказа - {order.Id}", $"Заказ №{order.Id} от {order.DateCreate} на сумму {order.Sum:C2} принят.");
            return true;
        }
        public bool TakeOrderInWork(OrderBindingModel model)
        {
			return StatusUpdate(model, OrderStatus.Выполняется);
		}
        public bool DeliveryOrder(OrderBindingModel model)
        {
			return StatusUpdate(model, OrderStatus.Выдан);
		}
        public bool FinishOrder(OrderBindingModel model)
        {
			return StatusUpdate(model, OrderStatus.Готов);
		}
        private void CheckModel(OrderBindingModel model, bool withParams = true)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (!withParams)
            {
                return;
            }
            if (model.ManufactureId < 0)
            {
                throw new ArgumentNullException("Некорректный идентификатор компьютера", nameof(model.ManufactureId));
            }
            if (model.Count <= 0)
            {
                throw new ArgumentNullException("Количество компьютеров в заказе должно быть больше 0", nameof(model.Count));
            }
            if (model.Sum <= 0)
            {
                throw new ArgumentNullException("Сумма заказа должна быть больше 0", nameof(model.Sum));
            }
            _logger.LogInformation("Order. OrderId: {Id}.Sum: {Sum}. ManufactureId: {ManufactureId}", model.Id, model.Sum, model.ManufactureId);
        }
		private bool StatusUpdate(OrderBindingModel model, OrderStatus newStatus)
		{
            var viewModel = _orderStorage.GetElement(new OrderSearchModel { Id = model.Id });
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            if (viewModel.Status + 1 != newStatus && viewModel.Status != OrderStatus.Ожидание)
            {
                _logger.LogWarning("Change status operation failed");
                throw new InvalidOperationException();
            }
            model.Status = newStatus;
            if (model.Status == OrderStatus.Готов || viewModel.Status == OrderStatus.Ожидание)
            {
                model.DateImplement = DateTime.Now;
                var manufacture = _manufactureStorage.GetElement(new() { Id = viewModel.ManufactureId });
                if (manufacture == null)
                {
                    throw new ArgumentNullException(nameof(manufacture));
                }
                if (!_shopLogic.AddManufactures(manufacture, viewModel.Count))
                {
                    model.Status = OrderStatus.Ожидание;
                    _logger.LogWarning($"AddTravels operation failed");
                }
                else
                {
                    model.DateImplement = DateTime.Now;
                }
            }
            else
            {
                model.DateImplement = viewModel.DateImplement;
            }
            if (viewModel.ImplementerId.HasValue)
            {
                model.ImplementerId = viewModel.ImplementerId.Value;
            }
            CheckModel(model, false);
            var order = _orderStorage.Update(model);
            if (order == null)
            {
                _logger.LogWarning("Change status operation failed");
                return false;
            }
            var client = _clientStorage.GetElement(new() { Id = order.ClientId });
            if (client == null)
            {
                _logger.LogWarning("Client not found");
                return false;
            }
            SendMail(client.Email, $"Заказ №{order.Id}", $"Заказ №{order.Id} изменил статус на {order.Status}.");
            return true;
        }
        public void SendMail(string email, string title, string body)
        {
            _abstractMailWorker.MailSendAsync(new()
            {
                MailAddress = email,
                Subject = title,
                Text = body
            });
        }
    }
}
