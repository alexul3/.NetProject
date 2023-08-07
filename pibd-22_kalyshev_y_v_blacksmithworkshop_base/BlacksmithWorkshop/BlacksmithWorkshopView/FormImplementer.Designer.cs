namespace BlacksmithWorkshopView
{
	partial class FormImplementer
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
			labelFIO = new Label();
			textBoxFIO = new TextBox();
			labelPassword = new Label();
			textBoxPassword = new TextBox();
			textBoxWorkExperience = new TextBox();
			labelWorkExperience = new Label();
			labelQualification = new Label();
			textBoxQualification = new TextBox();
			buttonCancel = new Button();
			buttonSave = new Button();
			SuspendLayout();
			// 
			// labelFIO
			// 
			labelFIO.AutoSize = true;
			labelFIO.Location = new Point(12, 15);
			labelFIO.Name = "labelFIO";
			labelFIO.Size = new Size(56, 25);
			labelFIO.TabIndex = 0;
			labelFIO.Text = "ФИО:";
			// 
			// textBoxFIO
			// 
			textBoxFIO.Location = new Point(158, 12);
			textBoxFIO.Name = "textBoxFIO";
			textBoxFIO.Size = new Size(422, 31);
			textBoxFIO.TabIndex = 1;
			// 
			// labelPassword
			// 
			labelPassword.AutoSize = true;
			labelPassword.Location = new Point(12, 63);
			labelPassword.Name = "labelPassword";
			labelPassword.Size = new Size(78, 25);
			labelPassword.TabIndex = 2;
			labelPassword.Text = "Пароль:";
			// 
			// textBoxPassword
			// 
			textBoxPassword.Location = new Point(158, 60);
			textBoxPassword.Name = "textBoxPassword";
			textBoxPassword.Size = new Size(422, 31);
			textBoxPassword.TabIndex = 3;
			// 
			// textBoxWorkExperience
			// 
			textBoxWorkExperience.Location = new Point(158, 108);
			textBoxWorkExperience.Name = "textBoxWorkExperience";
			textBoxWorkExperience.Size = new Size(108, 31);
			textBoxWorkExperience.TabIndex = 4;
			// 
			// labelWorkExperience
			// 
			labelWorkExperience.AutoSize = true;
			labelWorkExperience.Location = new Point(12, 111);
			labelWorkExperience.Name = "labelWorkExperience";
			labelWorkExperience.Size = new Size(122, 25);
			labelWorkExperience.TabIndex = 5;
			labelWorkExperience.Text = "Стаж работы:";
			// 
			// labelQualification
			// 
			labelQualification.AutoSize = true;
			labelQualification.Location = new Point(321, 111);
			labelQualification.Name = "labelQualification";
			labelQualification.Size = new Size(134, 25);
			labelQualification.TabIndex = 6;
			labelQualification.Text = "Квалификация:";
			// 
			// textBoxQualification
			// 
			textBoxQualification.Location = new Point(472, 108);
			textBoxQualification.Name = "textBoxQualification";
			textBoxQualification.Size = new Size(108, 31);
			textBoxQualification.TabIndex = 7;
			// 
			// buttonCancel
			// 
			buttonCancel.Location = new Point(468, 175);
			buttonCancel.Name = "buttonCancel";
			buttonCancel.Size = new Size(112, 34);
			buttonCancel.TabIndex = 8;
			buttonCancel.Text = "Отмена";
			buttonCancel.UseVisualStyleBackColor = true;
			buttonCancel.Click += ButtonCancel_Click;
			// 
			// buttonSave
			// 
			buttonSave.Location = new Point(350, 175);
			buttonSave.Name = "buttonSave";
			buttonSave.Size = new Size(112, 34);
			buttonSave.TabIndex = 9;
			buttonSave.Text = "Сохранить";
			buttonSave.UseVisualStyleBackColor = true;
			buttonSave.Click += ButtonSave_Click;
			// 
			// FormImplementer
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(598, 221);
			Controls.Add(buttonSave);
			Controls.Add(buttonCancel);
			Controls.Add(textBoxQualification);
			Controls.Add(labelQualification);
			Controls.Add(labelWorkExperience);
			Controls.Add(textBoxWorkExperience);
			Controls.Add(textBoxPassword);
			Controls.Add(labelPassword);
			Controls.Add(textBoxFIO);
			Controls.Add(labelFIO);
			Name = "FormImplementer";
			Text = "FormImplementer";
			Load += FormCondition_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label labelFIO;
		private TextBox textBoxFIO;
		private Label labelPassword;
		private TextBox textBoxPassword;
		private TextBox textBoxWorkExperience;
		private Label labelWorkExperience;
		private Label labelQualification;
		private TextBox textBoxQualification;
		private Button buttonCancel;
		private Button buttonSave;
	}
}