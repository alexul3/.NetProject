using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopContracts.ViewModels;
using Microsoft.Extensions.Logging;

namespace BlacksmithWorkshopView
{
	public partial class FormCreateOrder : Form
	{
		private readonly ILogger _logger;
		private readonly IManufactureLogic _logicM;
		private readonly IOrderLogic _logicO;
		private readonly IClientLogic _logicC;
		public FormCreateOrder(ILogger<FormCreateOrder> logger, IManufactureLogic logicM, IOrderLogic logicO, IClientLogic logicC)
		{
			InitializeComponent();
			_logger = logger;
			_logicM = logicM;
			_logicO = logicO;
			_logicC = logicC;
		}
		private void FormCreateOrder_Load(object sender, EventArgs e)
		{
			_logger.LogInformation("Загрузка поездок для заказа");
			try
			{
				var list = _logicM.ReadList(null);
				if (list != null)
				{
					comboBoxManufacture.DisplayMember = "ManufactureName";
					comboBoxManufacture.ValueMember = "Id";
					comboBoxManufacture.DataSource = list;
					comboBoxManufacture.SelectedItem = null;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки списка поездок");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			_logger.LogInformation("Загрузка списка клиентов");
			try
			{
				var list = _logicC.ReadList(null);
				if (list != null)
				{
					comboBoxClient.DisplayMember = "ClientFIO";
					comboBoxClient.ValueMember = "Id";
					comboBoxClient.DataSource = list;
					comboBoxClient.SelectedItem = null;
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки списка клиентов");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void CalcSum()
		{
			if (comboBoxManufacture.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
			{
				try
				{
					int id = Convert.ToInt32(comboBoxManufacture.SelectedValue);
					var Manufacture = _logicM.ReadElement(new ManufactureSearchModel { Id = id });
					int count = Convert.ToInt32(textBoxCount.Text);
					textBoxSum.Text = Math.Round(count * (Manufacture?.Price ?? 0), 2).ToString();
					_logger.LogInformation("Расчет суммы заказа");
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка расчета суммы заказа");
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void TextBoxCount_TextChanged(object sender, EventArgs e)
		{
			CalcSum();
		}
		private void ComboBoxManufacture_SelectedIndexChanged(object sender, EventArgs e)
		{
			CalcSum();
		}
		private void ButtonSave_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxCount.Text))
			{
				MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxManufacture.SelectedValue == null)
			{
				MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (comboBoxClient.SelectedValue == null)
			{
				MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			_logger.LogInformation("Создание заказа");
			try
			{
				var operationResult = _logicO.CreateOrder(new OrderBindingModel
				{
					ManufactureId = Convert.ToInt32(comboBoxManufacture.SelectedValue),
					ManufactureName = comboBoxManufacture.Text,
					ClientId = Convert.ToInt32(comboBoxClient.SelectedValue),
					Count = Convert.ToInt32(textBoxCount.Text),
					Sum = Convert.ToDouble(textBoxSum.Text)
				});
				if (!operationResult)
				{
					throw new Exception("Ошибка при создании заказа. Дополнительная информация в логах.");
				}
				MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
				DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка создания заказа");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void ButtonCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
