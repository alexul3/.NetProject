﻿using System;
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
using BlacksmithWorkshopContracts.DI;

namespace BlacksmithWorkshopView
{
    public partial class FormManufacturies : Form
    {
        private readonly ILogger _logger;
        private readonly IManufactureLogic _logic;
        public FormManufacturies(ILogger<FormManufacturies> logger, IManufactureLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }
        private void FormManufacturies_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                dataGridView.FillAndConfigGrid(_logic.ReadList(null));
                _logger.LogInformation("Загрузка изделий");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки изделий");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = DependencyManager.Instance.Resolve<FormManufacture>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = DependencyManager.Instance.Resolve<FormManufacture>();
                form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    _logger.LogInformation("Удаление изделия");
                    try
                    {
                        if (!_logic.Delete(new ManufactureBindingModel { Id = id }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления изделия");
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
