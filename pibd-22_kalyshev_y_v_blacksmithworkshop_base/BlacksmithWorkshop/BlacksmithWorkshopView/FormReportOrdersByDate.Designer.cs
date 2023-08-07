namespace BlacksmithWorkshopView
{
	partial class FormReportOrdersByDate
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
			panel = new Panel();
			buttonToPDF = new Button();
			buttonMake = new Button();
			panel.SuspendLayout();
			SuspendLayout();
			// 
			// panel
			// 
			panel.Controls.Add(buttonToPDF);
			panel.Controls.Add(buttonMake);
			panel.Dock = DockStyle.Top;
			panel.Location = new Point(0, 0);
			panel.Name = "panel";
			panel.Size = new Size(800, 58);
			panel.TabIndex = 0;
			// 
			// buttonToPDF
			// 
			buttonToPDF.Location = new Point(618, 12);
			buttonToPDF.Name = "buttonToPDF";
			buttonToPDF.Size = new Size(170, 34);
			buttonToPDF.TabIndex = 6;
			buttonToPDF.Text = "В PDF";
			buttonToPDF.UseVisualStyleBackColor = true;
			buttonToPDF.Click += ButtonToPdf_Click;
			// 
			// buttonMake
			// 
			buttonMake.Location = new Point(12, 12);
			buttonMake.Name = "buttonMake";
			buttonMake.Size = new Size(170, 34);
			buttonMake.TabIndex = 5;
			buttonMake.Text = "Сформировать";
			buttonMake.UseVisualStyleBackColor = true;
			buttonMake.Click += ButtonMake_Click;
			// 
			// FormReportOrdersByDate
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(panel);
			Name = "FormReportOrdersByDate";
			Text = "Заказы по датам";
			panel.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel panel;
		private Button buttonMake;
		private Button buttonToPDF;
	}
}