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
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.ViewModels;

namespace BlacksmithWorkshopView
{
    public partial class FormShopManufacture : Form
    {
        private readonly ILogger _logger;
        private readonly IShopLogic _shopLogic;
        private readonly IManufactureLogic _manufactureLogic;
        private readonly List<ShopViewModel>? _listShops;
        private readonly List<ManufactureViewModel>? _listManufacture;
        public FormShopManufacture(ILogger<FormShopManufacture> logger, IShopLogic shopLogic, IManufactureLogic manufactureLogic)
        {
            InitializeComponent();
            _shopLogic = shopLogic;
            _manufactureLogic = manufactureLogic;
            _logger = logger;
            _listShops = shopLogic.ReadList(null);
            if (_listShops != null)
            {
                comboBoxShop.DisplayMember = "ShopName";
                comboBoxShop.ValueMember = "Id";
                comboBoxShop.DataSource = _listShops;
                comboBoxShop.SelectedItem = null;
            }

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
            if (comboBoxShop.SelectedValue == null)
            {
                MessageBox.Show("Выберите магазин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxManufacture.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Добавление изделия в магазин");
            try
            {
                var manufacture = _manufactureLogic.ReadElement(new()
                {
                    Id = (int)comboBoxManufacture.SelectedValue
                });
                if (manufacture == null)
                {
                    throw new Exception("Изделие не найдено. Дополнительная информация в логах.");
                }
                var resultOperation = _shopLogic.AddManufactureInShop(
                     model: new() { Id = (int)comboBoxShop.SelectedValue },
                     manufacture: manufacture,
                     count: (int)numericUpDownCount.Value
                );
                if (!resultOperation)
                {
                    throw new Exception("Ошибка при добавлении. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
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
