using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopContracts.DI;
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
using static BlacksmithWorkshopView.FormMessages;

namespace BlacksmithWorkshopView
{
    public partial class FormMessages : Form
    {
        private readonly ILogger _logger;
        private readonly IMessageInfoLogic _logic;
        private readonly int pageSize = 5;
        private int pageNumber = 0;
        public FormMessages(ILogger<FormMessages> logger, IMessageInfoLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }
        private void FormMessages_Load(object sender, EventArgs e)
        {
            LoadData(0);
        }
        private void LoadData(int page)
        {
            try
            {
                dataGridView.FillAndConfigGrid(_logic.ReadList(null));
                _logger.LogInformation("Загрузка сообщений");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки сообщений");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            if (pageNumber != 0)
            {
                pageNumber--;
            }
            LoadData(pageNumber);
        }
        private void ButtonForward_Click(object sender, EventArgs e)
        {
            pageNumber++;
            LoadData(pageNumber);
        }
        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = DependencyManager.Instance.Resolve<FormMessage>();
                if (service is FormMessage form)
                {
                    form.Id = dataGridView.SelectedRows[0].Cells["MessageId"].Value.ToString();
                    form.ShowDialog();
                    LoadData(0);
                }
            }
        }
    }
}
