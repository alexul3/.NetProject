using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.DI;
using BlacksmithWorkshopContracts.SearchModels;
using BlacksmithWorkshopDataModels.Models;
using Microsoft.Extensions.Logging;
using System.Windows.Forms;

namespace BlacksmithWorkshopView
{
    public partial class FormManufacture : Form
    {
        private readonly ILogger _logger;
        private readonly IManufactureLogic _logic;
        private int? _id;
        private Dictionary<int, (IComponentModel, int)> _ManufactureComponents;
        public int Id { set { _id = value; } }
        public FormManufacture(ILogger<FormManufacture> logger, IManufactureLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
            _ManufactureComponents = new Dictionary<int, (IComponentModel, int)>();
        }
        private void FormManufacture_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                _logger.LogInformation("Загрузка изделия");
                try
                {
                    var view = _logic.ReadElement(new ManufactureSearchModel { Id = _id.Value });
                    if (view != null)
                    {
                        textBoxName.Text = view.ManufactureName;
                        textBoxPrice.Text = view.Price.ToString();
                        _ManufactureComponents = view.ManufactureComponents ?? new
                        Dictionary<int, (IComponentModel, int)>();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка загрузки изделия");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void LoadData()
        {
            _logger.LogInformation("Загрузка компонент изделия");
            try
            {
                if (_ManufactureComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in _ManufactureComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1.ComponentName, pc.Value.Item2 });
                    }
                    textBoxPrice.Text = CalcPrice().ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки компонент изделия");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormManufactureComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.ComponentModel == null)
                {
                    return;
                }
                _logger.LogInformation("Добавление нового компонента: {ComponentName} - {Count}", form.ComponentModel.ComponentName, form.Count);
                if (_ManufactureComponents.ContainsKey(form.Id))
                {
                    _ManufactureComponents[form.Id] = (form.ComponentModel, form.Count);
                }
                else
                {
                    _ManufactureComponents.Add(form.Id, (form.ComponentModel, form.Count));
                }
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormManufactureComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = _ManufactureComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.ComponentModel == null)
                    {
                        return;
                    }
                    _logger.LogInformation("Изменение компонента: {ComponentName} - {Count}", form.ComponentModel.ComponentName, form.Count);
                    _ManufactureComponents[form.Id] = (form.ComponentModel, form.Count);
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _logger.LogInformation("Удаление компонента: {ComponentName} - { Count}", dataGridView.SelectedRows[0].Cells[1].Value);
                        _ManufactureComponents?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_ManufactureComponents == null || _ManufactureComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Сохранение изделия");
            try
            {
                var model = new ManufactureBindingModel
                {
                    Id = _id ?? 0,
                    ManufactureName = textBoxName.Text,
                    Price = Convert.ToDouble(textBoxPrice.Text),
                    ManufactureComponents = _ManufactureComponents
                };
                var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения изделия");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private double CalcPrice()
        {
            double price = 0;
            foreach (var elem in _ManufactureComponents)
            {
                price += ((elem.Value.Item1?.Cost ?? 0) * elem.Value.Item2);
            }
            return Math.Round(price * 1.1, 2);
        }
    }
}
