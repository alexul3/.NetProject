﻿using BlacksmithWorkshopContracts.BindingModels;
using BlacksmithWorkshopContracts.BusinessLogicsContracts;
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
	public partial class FormReportShopManufactures : Form
	{
		private readonly ILogger _logger;
		private readonly IReportLogic _logic;
		public FormReportShopManufactures(ILogger<FormReportShopManufactures> logger, IReportLogic logic)
		{
			InitializeComponent();
			_logger = logger;
			_logic = logic;
		}
		private void FormReportShopManufactures_Load(object sender, EventArgs e)
		{
			try
			{
				var dict = _logic.GetShopManufacture();
				if (dict != null)
				{
					dataGridView.Rows.Clear();
					foreach (var elem in dict)
					{
						dataGridView.Rows.Add(new object[] { elem.ShopName, "", "" });
						foreach (var listElem in elem.Manufactures)
						{
							dataGridView.Rows.Add(new object[] { "", listElem.Item1, listElem.Item2 });
						}
						dataGridView.Rows.Add(new object[] { "Итого", "", elem.TotalCount });
						dataGridView.Rows.Add(Array.Empty<object>());
					}
				}
				_logger.LogInformation("Загрузка списка магазинов с изделиями");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка загрузки списка магазинов с изделиями");

				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void ButtonSaveToExcel_Click(object sender, EventArgs e)
		{
			using var dialog = new SaveFileDialog
			{
				Filter = "xlsx|*.xlsx"
			};
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					_logic.SaveShopManufactureToExcelFile(new ReportBindingModel
					{
						FileName = dialog.FileName
					});
					_logger.LogInformation("Сохранение списка магазинов с изделиями");

					MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Ошибка сохранения списка магазинов с поездками");

					MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
	}
}
