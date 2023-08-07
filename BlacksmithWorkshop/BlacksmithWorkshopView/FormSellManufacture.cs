using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlacksmithWorkshopView
{
    public partial class FormSellManufacture : Form
    {
        private readonly ILogger _logger;
        private readonly IShopLogic _shopLogic;
        private readonly IManufactureLogic _manufactureLogic;
        private readonly List<ManufactureViewModel>? _listManufacture;
        public FormSellManufacture(ILogger<FormSellManufacture> logger, IShopLogic shopLogic, IManufactureLogic manufactureLogic)
        {
            InitializeComponent();
            _logger = logger;
            _shopLogic = shopLogic;
            _manufactureLogic = manufactureLogic;
            _listManufacture = manufactureLogic.ReadList(null);
            if (_listManufacture != null)
            {
                comboBoxManufacture.DisplayMember = "ManufactureName";
                comboBoxManufacture.ValueMember = "Id";
                comboBoxManufacture.DataSource = _listManufacture;
                comboBoxManufacture.SelectedItem = null;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxManufacture.SelectedValue == null)
            {
                MessageBox.Show("Выберите поездку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(numericUpDownCount.Text))
            {
                MessageBox.Show("Заполните количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Продажа поездок");
            try
            {
                var manufacture = _manufactureLogic.ReadElement(new()
                {
                    Id = (int)comboBoxManufacture.SelectedValue
                });
                if (manufacture == null)
                {
                    throw new Exception("Поездка не найдена. Дополнительная информация в логах.");
                }
                var operationResult = _shopLogic.SellManufactures(
                    model: manufacture,
                    count: (int)numericUpDownCount.Value
                );
                if (!operationResult)
                {
                    throw new Exception("Ошибка при продаже поездки. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения поездки");
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
