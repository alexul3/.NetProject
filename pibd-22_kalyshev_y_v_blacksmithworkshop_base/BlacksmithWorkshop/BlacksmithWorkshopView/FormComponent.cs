using Microsoft.Extensions.Logging;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.SearchModels;
using System.Windows.Forms;

namespace BlacksmithWorkshopView
{
    public partial class FormComponent : Form
    {
        private readonly ILogger _logger;
        private readonly IComponentLogic _logic;
        private int? _id;
        public int Id { set { _id = value; } }
        public FormComponent(ILogger<FormComponent> logger, IComponentLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }
        private void FormComponent_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                try
                {
                    _logger.LogInformation("Получение компонента");
                    var view = _logic.ReadElement(new ComponentSearchModel
                    {
                        Id = _id.Value
                    });
                    if (view != null)
                    {
                        textBoxName.Text = view.ComponentName;
                        textBoxCost.Text = view.Cost.ToString();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка получения компонента");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Сохранение компонента");
            try
            {
                var model = new ComponentBindingModel
                {
                    Id = _id ?? 0,
                    ComponentName = textBoxName.Text,
                    Cost = Convert.ToDouble(textBoxCost.Text)
                };
                var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");//При обновлении, может быть, тоже ошибка появиться..
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения компонента");
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
