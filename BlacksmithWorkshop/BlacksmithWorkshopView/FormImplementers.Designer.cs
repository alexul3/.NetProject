﻿namespace BlacksmithWorkshopView
{
	partial class FormImplementers
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
			this.dataGridView = new System.Windows.Forms.DataGridView();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonUpd = new System.Windows.Forms.Button();
			this.buttonDel = new System.Windows.Forms.Button();
			this.buttonRef = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView
			// 
			this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView.Location = new System.Drawing.Point(0, 0);
			this.dataGridView.Name = "dataGridView";
			this.dataGridView.RowHeadersWidth = 62;
			this.dataGridView.RowTemplate.Height = 33;
			this.dataGridView.Size = new System.Drawing.Size(619, 449);
			this.dataGridView.TabIndex = 1;
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(651, 12);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(120, 50);
			this.buttonAdd.TabIndex = 2;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
			// 
			// buttonUpd
			// 
			this.buttonUpd.Location = new System.Drawing.Point(651, 79);
			this.buttonUpd.Name = "buttonUpd";
			this.buttonUpd.Size = new System.Drawing.Size(120, 50);
			this.buttonUpd.TabIndex = 3;
			this.buttonUpd.Text = "Изменить";
			this.buttonUpd.UseVisualStyleBackColor = true;
			this.buttonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
			// 
			// buttonDel
			// 
			this.buttonDel.Location = new System.Drawing.Point(651, 146);
			this.buttonDel.Name = "buttonDel";
			this.buttonDel.Size = new System.Drawing.Size(120, 50);
			this.buttonDel.TabIndex = 4;
			this.buttonDel.Text = "Удалить";
			this.buttonDel.UseVisualStyleBackColor = true;
			this.buttonDel.Click += new System.EventHandler(this.ButtonDel_Click);
			// 
			// buttonRef
			// 
			this.buttonRef.Location = new System.Drawing.Point(651, 214);
			this.buttonRef.Name = "buttonRef";
			this.buttonRef.Size = new System.Drawing.Size(120, 50);
			this.buttonRef.TabIndex = 5;
			this.buttonRef.Text = "Обновить";
			this.buttonRef.UseVisualStyleBackColor = true;
			this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
			// 
			// FormImplementers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.buttonRef);
			this.Controls.Add(this.buttonDel);
			this.Controls.Add(this.buttonUpd);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.dataGridView);
			this.Name = "FormImplementers";
			this.Text = "Исполнители";
			this.Load += new System.EventHandler(this.FormImplementers_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DataGridView dataGridView;
		private Button buttonAdd;
		private Button buttonUpd;
		private Button buttonDel;
		private Button buttonRef;
	}
}