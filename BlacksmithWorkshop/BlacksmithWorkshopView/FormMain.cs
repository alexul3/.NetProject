using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Extensions.Logging;
using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using BlacksmithWorkshopDataModels.Models;
using BlacksmithWorkshopDataModels.Enums;
using BlacksmithWorkshopContracts.DI;
using BlacksmithWorkshopBusinessLogic.BusinessLogics;

namespace BlacksmithWorkshopView
{
    public partial class FormMain : Form
    {
        private readonly ILogger _logger;
        private readonly IOrderLogic _orderLogic;
        private readonly IReportLogic _reportLogic;
        private readonly IWorkProcess _workProcess;
        private readonly IBackUpLogic _backUpLogic;
        public FormMain(ILogger<FormMain> logger, IOrderLogic orderLogic, IReportLogic reportLogic, IWorkProcess workProcess, IBackUpLogic backUpLogic)
        {
            InitializeComponent();
            _logger = logger;
            _orderLogic = orderLogic;
            _reportLogic = reportLogic;
            _workProcess = workProcess;
            _backUpLogic = backUpLogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                dataGridView.FillAndConfigGrid(_orderLogic.ReadList(null));
                _logger.LogInformation("Загрузка заказов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки заказов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ComponentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormComponents>();
            form.ShowDialog();
        }
        private void GoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormManufacturies>();
            form.ShowDialog();
        }
        private void ClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormClients>();
            form.ShowDialog();
        }
        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }
        private void ButtonIssuedOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ No {id}. Меняется статус на 'Выдан'", id);
                try
                {
                    var operationResult = _orderLogic.DeliveryOrder(new OrderBindingModel
                    {
                        Id = id
                    });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    _logger.LogInformation("Заказ No {id} выдан", id);
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка отметки о выдачи заказа");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ComponentListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveComponentsToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ComponentManufacturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormReportManufactureComponents>();
            form.ShowDialog();
        }
        private void OrderListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormReportOrders>();
            form.ShowDialog();
        }
        private void ImplemntersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormImplementers>();
            form.ShowDialog();
        }
        private void WorkStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _workProcess.DoWork((DependencyManager.Instance.Resolve<IImplementerLogic>() as IImplementerLogic)!, _orderLogic);
            MessageBox.Show("Процесс обработки запущен", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonAddManufactureInShop_Click(object sender, EventArgs e)
        {
            var service = DependencyManager.Instance.Resolve<FormShopManufacture>();
            if (service is FormShopManufacture form)
            {
                form.ShowDialog();
            }
        }
        private void ShopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = DependencyManager.Instance.Resolve<FormShops>();
            if (service is FormShops form)
            {
                form.ShowDialog();
            }
        }
        private void ButtonSellManufacture_Click(object sender, EventArgs e)
        {
            var service = DependencyManager.Instance.Resolve<FormSellManufacture>();
            if (service is FormSellManufacture form)
            {
                form.ShowDialog();
                LoadData();
            }
        }
        private void ShopsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveShopsToWordFile(new ReportBindingModel { FileName = dialog.FileName });
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ShopsCapacityStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = DependencyManager.Instance.Resolve<FormReportShopManufactures>();
            if (service is FormReportShopManufactures form)
            {
                form.ShowDialog();
            }
        }
        private void OrdersByDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = DependencyManager.Instance.Resolve<FormReportOrdersByDate>();
            if (service is FormReportOrdersByDate form)
            {
                form.ShowDialog();
            }
        }
        private void messagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormMessages>();
            form.ShowDialog();
        }
        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_backUpLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        _backUpLogic.CreateBackUp(new BackUpSaveBinidngModel
                        {
                            FolderName = fbd.SelectedPath
                        });
                        MessageBox.Show("Бэкап создан", "Сообщение",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка создания бэкапа", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}
