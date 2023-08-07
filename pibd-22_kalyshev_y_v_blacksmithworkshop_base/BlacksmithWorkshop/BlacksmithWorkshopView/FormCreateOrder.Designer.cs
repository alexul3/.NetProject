namespace BlacksmithWorkshopView
{
	partial class FormCreateOrder
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
			labelManufacture = new Label();
			comboBoxManufacture = new ComboBox();
			labelCount = new Label();
			textBoxCount = new TextBox();
			labelSum = new Label();
			textBoxSum = new TextBox();
			buttonCancel = new Button();
			buttonSave = new Button();
			labelClient = new Label();
			comboBoxClient = new ComboBox();
			SuspendLayout();
			// 
			// labelManufacture
			// 
			labelManufacture.AutoSize = true;
			labelManufacture.Location = new Point(10, 11);
			labelManufacture.Name = "labelManufacture";
			labelManufacture.Size = new Size(59, 15);
			labelManufacture.TabIndex = 0;
			labelManufacture.Text = "Изделие: ";
			// 
			// comboBoxManufacture
			// 
			comboBoxManufacture.FormattingEnabled = true;
			comboBoxManufacture.Location = new Point(101, 9);
			comboBoxManufacture.Margin = new Padding(3, 2, 3, 2);
			comboBoxManufacture.Name = "comboBoxManufacture";
			comboBoxManufacture.Size = new Size(314, 23);
			comboBoxManufacture.TabIndex = 1;
			comboBoxManufacture.SelectedIndexChanged += ComboBoxManufacture_SelectedIndexChanged;
			// 
			// labelCount
			// 
			labelCount.AutoSize = true;
			labelCount.Location = new Point(10, 37);
			labelCount.Name = "labelCount";
			labelCount.Size = new Size(78, 15);
			labelCount.TabIndex = 2;
			labelCount.Text = "Количество: ";
			// 
			// textBoxCount
			// 
			textBoxCount.Location = new Point(101, 34);
			textBoxCount.Margin = new Padding(3, 2, 3, 2);
			textBoxCount.Name = "textBoxCount";
			textBoxCount.Size = new Size(314, 23);
			textBoxCount.TabIndex = 3;
			textBoxCount.TextChanged += TextBoxCount_TextChanged;
			// 
			// labelSum
			// 
			labelSum.AutoSize = true;
			labelSum.Location = new Point(10, 63);
			labelSum.Name = "labelSum";
			labelSum.Size = new Size(51, 15);
			labelSum.TabIndex = 4;
			labelSum.Text = "Сумма: ";
			// 
			// textBoxSum
			// 
			textBoxSum.Location = new Point(101, 60);
			textBoxSum.Margin = new Padding(3, 2, 3, 2);
			textBoxSum.Name = "textBoxSum";
			textBoxSum.ReadOnly = true;
			textBoxSum.Size = new Size(314, 23);
			textBoxSum.TabIndex = 5;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(294, 126);
			buttonCancel.Margin = new Padding(3, 2, 3, 2);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(96, 24);
			buttonCancel.TabIndex = 6;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(192, 126);
			buttonSave.Margin = new Padding(3, 2, 3, 2);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(96, 24);
			buttonSave.TabIndex = 7;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// labelClient
			// 
			labelClient.AutoSize = true;
			labelClient.Location = new Point(10, 91);
			labelClient.Name = "labelClient";
			labelClient.Size = new Size(49, 15);
			labelClient.TabIndex = 8;
			labelClient.Text = "Клиент:";
			// 
			// comboBoxClient
			// 
			comboBoxClient.FormattingEnabled = true;
			comboBoxClient.Location = new Point(101, 88);
			comboBoxClient.Name = "comboBoxClient";
			comboBoxClient.Size = new Size(314, 23);
			comboBoxClient.TabIndex = 9;
			// 
			// FormCreateOrder
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(424, 161);
			Controls.Add(comboBoxClient);
			Controls.Add(labelClient);
			Controls.Add(buttonSave);
			Controls.Add(buttonCancel);
			Controls.Add(textBoxSum);
			Controls.Add(labelSum);
			Controls.Add(textBoxCount);
			Controls.Add(labelCount);
			Controls.Add(comboBoxManufacture);
			Controls.Add(labelManufacture);
			Margin = new Padding(3, 2, 3, 2);
			Name = "FormCreateOrder";
			Text = "Заказ";
			Load += FormCreateOrder_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelManufacture;
		private ComboBox comboBoxManufacture;
		private Label labelCount;
		private TextBox textBoxCount;
		private Label labelSum;
		private TextBox textBoxSum;
		private Button buttonCancel;
		private Button buttonSave;
		private Label labelClient;
		private ComboBox comboBoxClient;
	}
}