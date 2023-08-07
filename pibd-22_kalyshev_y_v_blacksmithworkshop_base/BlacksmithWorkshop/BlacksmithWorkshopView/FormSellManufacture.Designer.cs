namespace BlacksmithWorkshopView
{
    partial class FormSellManufacture
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
            this.labelManufacture = new System.Windows.Forms.Label();
            this.comboBoxManufacture = new System.Windows.Forms.ComboBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
            this.SuspendLayout();
            // 
            // labelManufacture
            // 
            this.labelManufacture.AutoSize = true;
            this.labelManufacture.Location = new System.Drawing.Point(38, 15);
            this.labelManufacture.Name = "labelManufacture";
            this.labelManufacture.Size = new System.Drawing.Size(81, 25);
            this.labelManufacture.TabIndex = 1;
            this.labelManufacture.Text = "Изделие";
            // 
            // comboBoxManufacture
            // 
            this.comboBoxManufacture.FormattingEnabled = true;
            this.comboBoxManufacture.Location = new System.Drawing.Point(125, 12);
            this.comboBoxManufacture.Name = "comboBoxManufacture";
            this.comboBoxManufacture.Size = new System.Drawing.Size(277, 33);
            this.comboBoxManufacture.TabIndex = 2;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 69);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(107, 25);
            this.labelCount.TabIndex = 3;
            this.labelCount.Text = "Количество";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(290, 129);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 34);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(172, 129);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(112, 34);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // numericUpDownCount
            // 
            this.numericUpDownCount.Location = new System.Drawing.Point(125, 67);
            this.numericUpDownCount.Name = "numericUpDownCount";
            this.numericUpDownCount.Size = new System.Drawing.Size(277, 31);
            this.numericUpDownCount.TabIndex = 6;
            // 
            // FormSellManufacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 175);
            this.Controls.Add(this.numericUpDownCount);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.comboBoxManufacture);
            this.Controls.Add(this.labelManufacture);
            this.Name = "FormSellManufacture";
            this.Text = "Продажа изделий";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label labelManufacture;
        private ComboBox comboBoxManufacture;
        private Label labelCount;
        private Button buttonCancel;
        private Button buttonSave;
        private NumericUpDown numericUpDownCount;
    }
}