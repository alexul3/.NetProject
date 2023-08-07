namespace BlacksmithWorkshopView
{
    partial class FormMessage
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
            labelSender = new Label();
            textBoxSender = new TextBox();
            labelSubject = new Label();
            textBoxSubject = new TextBox();
            labelBody = new Label();
            textBoxBody = new TextBox();
            textBoxReply = new TextBox();
            labelReply = new Label();
            buttonSend = new Button();
            SuspendLayout();
            // 
            // labelSender
            // 
            labelSender.AutoSize = true;
            labelSender.Location = new Point(12, 9);
            labelSender.Name = "labelSender";
            labelSender.Size = new Size(117, 25);
            labelSender.TabIndex = 0;
            labelSender.Text = "Отправитель";
            // 
            // textBoxSender
            // 
            textBoxSender.Location = new Point(12, 37);
            textBoxSender.Name = "textBoxSender";
            textBoxSender.Size = new Size(347, 31);
            textBoxSender.TabIndex = 1;
            // 
            // labelSubject
            // 
            labelSubject.AutoSize = true;
            labelSubject.Location = new Point(12, 86);
            labelSubject.Name = "labelSubject";
            labelSubject.Size = new Size(99, 25);
            labelSubject.TabIndex = 2;
            labelSubject.Text = "Заголовок";
            // 
            // textBoxSubject
            // 
            textBoxSubject.Location = new Point(12, 114);
            textBoxSubject.Name = "textBoxSubject";
            textBoxSubject.Size = new Size(347, 31);
            textBoxSubject.TabIndex = 3;
            // 
            // labelBody
            // 
            labelBody.AutoSize = true;
            labelBody.Location = new Point(12, 167);
            labelBody.Name = "labelBody";
            labelBody.Size = new Size(152, 25);
            labelBody.TabIndex = 4;
            labelBody.Text = "Текст сообщения";
            // 
            // textBoxBody
            // 
            textBoxBody.Location = new Point(12, 195);
            textBoxBody.Multiline = true;
            textBoxBody.Name = "textBoxBody";
            textBoxBody.Size = new Size(347, 243);
            textBoxBody.TabIndex = 5;
            // 
            // textBoxReply
            // 
            textBoxReply.Location = new Point(430, 37);
            textBoxReply.Multiline = true;
            textBoxReply.Name = "textBoxReply";
            textBoxReply.Size = new Size(358, 361);
            textBoxReply.TabIndex = 6;
            // 
            // labelReply
            // 
            labelReply.AutoSize = true;
            labelReply.Location = new Point(430, 9);
            labelReply.Name = "labelReply";
            labelReply.Size = new Size(112, 25);
            labelReply.TabIndex = 7;
            labelReply.Text = "Текст ответа";
            // 
            // buttonSend
            // 
            buttonSend.Location = new Point(430, 404);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new Size(358, 34);
            buttonSend.TabIndex = 8;
            buttonSend.Text = "Отправить";
            buttonSend.UseVisualStyleBackColor = true;
            buttonSend.Click += ButtonSend_Click;
            // 
            // FormMessage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSend);
            Controls.Add(labelReply);
            Controls.Add(textBoxReply);
            Controls.Add(textBoxBody);
            Controls.Add(labelBody);
            Controls.Add(textBoxSubject);
            Controls.Add(labelSubject);
            Controls.Add(textBoxSender);
            Controls.Add(labelSender);
            Name = "FormMessage";
            Text = "Ответ";
            Load += FormMessage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelSender;
        private TextBox textBoxSender;
        private Label labelSubject;
        private TextBox textBoxSubject;
        private Label labelBody;
        private TextBox textBoxBody;
        private TextBox textBoxReply;
        private Label labelReply;
        private Button buttonSend;
    }
}