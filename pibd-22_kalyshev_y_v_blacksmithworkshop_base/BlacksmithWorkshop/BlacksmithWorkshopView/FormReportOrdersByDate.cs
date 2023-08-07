using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
using Microsoft.Extensions.Logging;
using Microsoft.Reporting.WinForms;
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
	public partial class FormReportOrdersByDate : Form
	{
		private readonly ReportViewer reportViewer;
		private readonly ILogger _logger;
		private readonly IReportLogic _logic;
		public FormReportOrdersByDate(ILogger<FormReportOrders> logger, IReportLogic logic)
		{
			InitializeComponent();
			_logger = logger;
			_logic = logic;
			reportViewer = new ReportViewer
			{
				Dock = DockStyle.Fill
			};
			reportViewer.LocalReport.LoadReportDefinition(new FileStream("ReportOrdersByDate.rdlc", FileMode.Open));
			Controls.Clear();
			Controls.Add(reportViewer);
			Controls.Add(panel);
		}
		private void ButtonMake_Click(object sender, EventArgs e)
		{
			try
			{
				var dataSource = _logic.GetOrdersByDate();
				var source = new ReportDataSource("DataSetOrders", dataSource);
				reportViewer.LocalReport.DataSources.Clear();
				reportViewer.LocalReport.DataSources.Add(source);

				reportViewer.RefreshReport();
				_logger.LogInformation("Загрузка списка заказов на весь период");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки списка заказов на период");
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void ButtonToPdf_Click(object sender, EventArgs e)
		{
			using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					_logic.SaveOrdersByDateToPdfFile(new ReportBindingModel
					{
						FileName = dialog.FileName
					});
					_logger.LogInformation("Сохранение списка заказов за весь период");
					MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка сохранения списка заказов на период");
					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
