namespace BlacksmithWorkshopView
{
    partial class FormMessages
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
            dataGridView = new DataGridView();
            panel = new Panel();
            buttonForward = new Button();
            buttonBack = new Button();
            buttonOpen = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Dock = DockStyle.Fill;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Margin = new Padding(4, 5, 4, 5);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 62;
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(1279, 697);
            dataGridView.TabIndex = 0;
            // 
            // panel
            // 
            panel.Controls.Add(buttonForward);
            panel.Controls.Add(buttonBack);
            panel.Controls.Add(buttonOpen);
            panel.Dock = DockStyle.Right;
            panel.Location = new Point(1096, 0);
            panel.Name = "panel";
            panel.Size = new Size(183, 697);
            panel.TabIndex = 1;
            // 
            // buttonForward
            // 
            buttonForward.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonForward.Location = new Point(106, 651);
            buttonForward.Name = "buttonForward";
            buttonForward.Size = new Size(65, 34);
            buttonForward.TabIndex = 2;
            buttonForward.Text = ">";
            buttonForward.UseVisualStyleBackColor = true;
            buttonForward.Click += ButtonForward_Click;
            // 
            // buttonBack
            // 
            buttonBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonBack.Location = new Point(14, 651);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(65, 34);
            buttonBack.TabIndex = 1;
            buttonBack.Text = "<";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += ButtonBack_Click;
            // 
            // buttonOpen
            // 
            buttonOpen.Location = new Point(14, 12);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(157, 34);
            buttonOpen.TabIndex = 0;
            buttonOpen.Text = "Открыть";
            buttonOpen.UseVisualStyleBackColor = true;
            buttonOpen.Click += ButtonOpen_Click;
            // 
            // FormMessages
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1279, 697);
            Controls.Add(panel);
            Controls.Add(dataGridView);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormMessages";
            Text = "Сообщения";
            Load += FormMessages_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            panel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView;
        private Panel panel;
        private Button buttonOpen;
        private Button buttonForward;
        private Button buttonBack;
    }
}