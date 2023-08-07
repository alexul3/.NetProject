namespace BlacksmithWorkshopView
{
	partial class FormReportShopManufactures
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			buttonSaveToExcel = new Button();
			dataGridView = new DataGridView();
			ColumnShop = new DataGridViewTextBoxColumn();
			ColumnManufacture = new DataGridViewTextBoxColumn();
			ColumnCount = new DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
			SuspendLayout();
			// 
			// buttonSaveToExcel
			// 
			buttonSaveToExcel.Location = new Point(12, 12);
			buttonSaveToExcel.Name = "buttonSaveToExcel";
			buttonSaveToExcel.Size = new Size(210, 34);
			buttonSaveToExcel.TabIndex = 0;
			buttonSaveToExcel.Text = "Сохранить в Excel";
			buttonSaveToExcel.UseVisualStyleBackColor = true;
			buttonSaveToExcel.Click += ButtonSaveToExcel_Click;
			// 
			// dataGridView
			// 
			dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView.Columns.AddRange(new DataGridViewColumn[] { ColumnShop, ColumnManufacture, ColumnCount });
			dataGridView.Dock = DockStyle.Bottom;
			dataGridView.Location = new Point(0, 63);
			dataGridView.Name = "dataGridView";
			dataGridView.RowHeadersWidth = 62;
			dataGridView.RowTemplate.Height = 33;
			dataGridView.Size = new Size(800, 387);
			dataGridView.TabIndex = 1;
			// 
			// ColumnShop
			// 
			ColumnShop.HeaderText = "Магазин";
			ColumnShop.MinimumWidth = 8;
			ColumnShop.Name = "ColumnShop";
			ColumnShop.Width = 150;
			// 
			// ColumnManufacture
			// 
			ColumnManufacture.HeaderText = "Изделие";
			ColumnManufacture.MinimumWidth = 8;
			ColumnManufacture.Name = "ColumnManufacture";
			ColumnManufacture.Width = 150;
			// 
			// ColumnCount
			// 
			ColumnCount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			ColumnCount.HeaderText = "Количество";
			ColumnCount.MinimumWidth = 8;
			ColumnCount.Name = "ColumnCount";
			// 
			// FormReportShopManufactures
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(dataGridView);
			Controls.Add(buttonSaveToExcel);
			Name = "FormReportShopManufactures";
			Text = "Магазины с изделиями";
			Load += FormReportShopManufactures_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button buttonSaveToExcel;
		private DataGridView dataGridView;
		private DataGridViewTextBoxColumn ColumnShop;
		private DataGridViewTextBoxColumn ColumnManufacture;
		private DataGridViewTextBoxColumn ColumnCount;
	}
}