namespace BlacksmithWorkshopView
{
    partial class FormShop
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
            buttonSave = new Button();
            buttonCancel = new Button();
            textBoxAddress = new TextBox();
            labelTime = new Label();
            labelAddress = new Label();
            dataGridView = new DataGridView();
            ColumnID = new DataGridViewTextBoxColumn();
            ColumnManufactureName = new DataGridViewTextBoxColumn();
            ColumnCount = new DataGridViewTextBoxColumn();
            labelShop = new Label();
            textBoxShop = new TextBox();
            dateTimePicker = new DateTimePicker();
            numericUpDownCapacity = new NumericUpDown();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapacity).BeginInit();
            SuspendLayout();
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(578, 302);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(120, 22);
            buttonSave.TabIndex = 17;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Location = new Point(703, 302);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(103, 23);
            buttonCancel.TabIndex = 16;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += ButtonCancel_Click;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(159, 27);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(221, 23);
            textBoxAddress.TabIndex = 14;
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Location = new Point(386, 9);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(87, 15);
            labelTime.TabIndex = 13;
            labelTime.Text = "Дата открытия";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(159, 9);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(40, 15);
            labelAddress.TabIndex = 12;
            labelAddress.Text = "Адрес";
            // 
            // dataGridView
            // 
            dataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ColumnID, ColumnManufactureName, ColumnCount });
            dataGridView.Location = new Point(12, 56);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(794, 240);
            dataGridView.TabIndex = 11;
            // 
            // ColumnID
            // 
            ColumnID.HeaderText = "ID";
            ColumnID.MinimumWidth = 8;
            ColumnID.Name = "ColumnID";
            ColumnID.Visible = false;
            ColumnID.Width = 150;
            // 
            // ColumnManufactureName
            // 
            ColumnManufactureName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnManufactureName.HeaderText = "Изделие";
            ColumnManufactureName.MinimumWidth = 8;
            ColumnManufactureName.Name = "ColumnManufactureName";
            // 
            // ColumnCount
            // 
            ColumnCount.HeaderText = "Количество";
            ColumnCount.MinimumWidth = 8;
            ColumnCount.Name = "ColumnCount";
            ColumnCount.Width = 150;
            // 
            // labelShop
            // 
            labelShop.AutoSize = true;
            labelShop.Location = new Point(12, 9);
            labelShop.Name = "labelShop";
            labelShop.Size = new Size(54, 15);
            labelShop.TabIndex = 9;
            labelShop.Text = "Магазин";
            // 
            // textBoxShop
            // 
            textBoxShop.Location = new Point(12, 27);
            textBoxShop.Name = "textBoxShop";
            textBoxShop.Size = new Size(141, 23);
            textBoxShop.TabIndex = 18;
            // 
            // dateTimePicker
            // 
            dateTimePicker.Location = new Point(386, 27);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(207, 23);
            dateTimePicker.TabIndex = 19;
            // 
            // numericUpDownCapacity
            // 
            numericUpDownCapacity.Location = new Point(599, 27);
            numericUpDownCapacity.Name = "numericUpDownCapacity";
            numericUpDownCapacity.Size = new Size(207, 23);
            numericUpDownCapacity.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(599, 9);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 21;
            label1.Text = "Вместимость";
            // 
            // FormShop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(818, 337);
            Controls.Add(label1);
            Controls.Add(numericUpDownCapacity);
            Controls.Add(dateTimePicker);
            Controls.Add(textBoxShop);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            Controls.Add(textBoxAddress);
            Controls.Add(labelTime);
            Controls.Add(labelAddress);
            Controls.Add(dataGridView);
            Controls.Add(labelShop);
            Name = "FormShop";
            Text = "Магазин";
            Load += FormShop_Load;
            Click += FormShop_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapacity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSave;
        private Button buttonCancel;
        private TextBox textBoxAddress;
        private Label labelTime;
        private Label labelAddress;
        private DataGridView dataGridView;
        private Label labelShop;
        private TextBox textBoxShop;
        private DateTimePicker dateTimePicker;
        private DataGridViewTextBoxColumn ColumnID;
        private DataGridViewTextBoxColumn ColumnManufactureName;
        private DataGridViewTextBoxColumn ColumnCount;
        private NumericUpDown numericUpDownCapacity;
        private Label label1;
    }
}