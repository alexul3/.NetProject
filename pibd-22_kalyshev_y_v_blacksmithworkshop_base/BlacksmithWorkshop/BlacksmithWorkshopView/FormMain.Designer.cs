namespace BlacksmithWorkshopView
{
    partial class FormMain
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
            menuStrip1 = new MenuStrip();
            guideToolStripMenuItem = new ToolStripMenuItem();
            componentsToolStripMenuItem = new ToolStripMenuItem();
            goodsToolStripMenuItem = new ToolStripMenuItem();
            ShopsToolStripMenuItem = new ToolStripMenuItem();
            clientsToolStripMenuItem = new ToolStripMenuItem();
            implemntersToolStripMenuItem = new ToolStripMenuItem();
            отчетыToolStripMenuItem = new ToolStripMenuItem();
            componentListToolStripMenuItem = new ToolStripMenuItem();
            componentsManufactureToolStripMenuItem = new ToolStripMenuItem();
            orderListToolStripMenuItem = new ToolStripMenuItem();
            shopListToolStripMenuItem = new ToolStripMenuItem();
            shopsCapacityToolStripMenuItem = new ToolStripMenuItem();
            ordersByDateToolStripMenuItem = new ToolStripMenuItem();
            workToolStripMenuItem = new ToolStripMenuItem();
            messagesToolStripMenuItem = new ToolStripMenuItem();
            backupToolStripMenuItem = new ToolStripMenuItem();
            dataGridView = new DataGridView();
            buttonCreateOrder = new Button();
            buttonIssuedOrder = new Button();
            buttonRef = new Button();
            buttonAddManufactureInShop = new Button();
            buttonSellManufacture = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { guideToolStripMenuItem, отчетыToolStripMenuItem, workToolStripMenuItem, messagesToolStripMenuItem, backupToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1286, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // guideToolStripMenuItem
            // 
            guideToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { componentsToolStripMenuItem, goodsToolStripMenuItem, ShopsToolStripMenuItem, clientsToolStripMenuItem, implemntersToolStripMenuItem });
            guideToolStripMenuItem.Name = "guideToolStripMenuItem";
            guideToolStripMenuItem.Size = new Size(87, 20);
            guideToolStripMenuItem.Text = "Справочник";
            // 
            // componentsToolStripMenuItem
            // 
            componentsToolStripMenuItem.Name = "componentsToolStripMenuItem";
            componentsToolStripMenuItem.Size = new Size(149, 22);
            componentsToolStripMenuItem.Text = "Компоненты";
            componentsToolStripMenuItem.Click += ComponentsToolStripMenuItem_Click;
            // 
            // goodsToolStripMenuItem
            // 
            goodsToolStripMenuItem.Name = "goodsToolStripMenuItem";
            goodsToolStripMenuItem.Size = new Size(149, 22);
            goodsToolStripMenuItem.Text = "Изделия";
            goodsToolStripMenuItem.Click += GoodsToolStripMenuItem_Click;
            // 
            // ShopsToolStripMenuItem
            // 
            ShopsToolStripMenuItem.Name = "ShopsToolStripMenuItem";
            ShopsToolStripMenuItem.Size = new Size(149, 22);
            ShopsToolStripMenuItem.Text = "Магазины";
            ShopsToolStripMenuItem.Click += ShopsToolStripMenuItem_Click;
            // 
            // clientsToolStripMenuItem
            // 
            clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            clientsToolStripMenuItem.Size = new Size(149, 22);
            clientsToolStripMenuItem.Text = "Клиенты";
            clientsToolStripMenuItem.Click += ClientsToolStripMenuItem_Click;
            // 
            // implemntersToolStripMenuItem
            // 
            implemntersToolStripMenuItem.Name = "implemntersToolStripMenuItem";
            implemntersToolStripMenuItem.Size = new Size(149, 22);
            implemntersToolStripMenuItem.Text = "Исполнители";
            implemntersToolStripMenuItem.Click += ImplemntersToolStripMenuItem_Click;
            // 
            // отчетыToolStripMenuItem
            // 
            отчетыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { componentListToolStripMenuItem, componentsManufactureToolStripMenuItem, orderListToolStripMenuItem, shopListToolStripMenuItem, shopsCapacityToolStripMenuItem, ordersByDateToolStripMenuItem });
            отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            отчетыToolStripMenuItem.Size = new Size(60, 20);
            отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // componentListToolStripMenuItem
            // 
            componentListToolStripMenuItem.Name = "componentListToolStripMenuItem";
            componentListToolStripMenuItem.Size = new Size(219, 22);
            componentListToolStripMenuItem.Text = "Список коспонентов";
            componentListToolStripMenuItem.Click += ComponentListToolStripMenuItem_Click;
            // 
            // componentsManufactureToolStripMenuItem
            // 
            componentsManufactureToolStripMenuItem.Name = "componentsManufactureToolStripMenuItem";
            componentsManufactureToolStripMenuItem.Size = new Size(219, 22);
            componentsManufactureToolStripMenuItem.Text = "Компоненты по изделиям";
            componentsManufactureToolStripMenuItem.Click += ComponentManufacturesToolStripMenuItem_Click;
            // 
            // orderListToolStripMenuItem
            // 
            orderListToolStripMenuItem.Name = "orderListToolStripMenuItem";
            orderListToolStripMenuItem.Size = new Size(219, 22);
            orderListToolStripMenuItem.Text = "Список заказов";
            orderListToolStripMenuItem.Click += OrderListToolStripMenuItem_Click;
            // 
            // shopListToolStripMenuItem
            // 
            shopListToolStripMenuItem.Name = "shopListToolStripMenuItem";
            shopListToolStripMenuItem.Size = new Size(219, 22);
            shopListToolStripMenuItem.Text = "Список магазинов";
            shopListToolStripMenuItem.Click += ShopsListToolStripMenuItem_Click;
            // 
            // shopsCapacityToolStripMenuItem
            // 
            shopsCapacityToolStripMenuItem.Name = "shopsCapacityToolStripMenuItem";
            shopsCapacityToolStripMenuItem.Size = new Size(219, 22);
            shopsCapacityToolStripMenuItem.Text = "Загруженность магазинов";
            shopsCapacityToolStripMenuItem.Click += ShopsCapacityStripMenuItem_Click;
            // 
            // ordersByDateToolStripMenuItem
            // 
            ordersByDateToolStripMenuItem.Name = "ordersByDateToolStripMenuItem";
            ordersByDateToolStripMenuItem.Size = new Size(219, 22);
            ordersByDateToolStripMenuItem.Text = "Заказы по датам";
            ordersByDateToolStripMenuItem.Click += OrdersByDateToolStripMenuItem_Click;
            // 
            // workToolStripMenuItem
            // 
            workToolStripMenuItem.Name = "workToolStripMenuItem";
            workToolStripMenuItem.Size = new Size(92, 20);
            workToolStripMenuItem.Text = "Запуск работ";
            workToolStripMenuItem.Click += WorkStartToolStripMenuItem_Click;
            // 
            // messagesToolStripMenuItem
            // 
            messagesToolStripMenuItem.Name = "messagesToolStripMenuItem";
            messagesToolStripMenuItem.Size = new Size(62, 20);
            messagesToolStripMenuItem.Text = "Письма";
            messagesToolStripMenuItem.Click += messagesToolStripMenuItem_Click;
            // 
            // backupToolStripMenuItem
            // 
            backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            backupToolStripMenuItem.Size = new Size(97, 20);
            backupToolStripMenuItem.Text = "Создать бэкап";
            backupToolStripMenuItem.Click += backupToolStripMenuItem_Click;
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(10, 23);
            dataGridView.Margin = new Padding(3, 2, 3, 2);
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersWidth = 51;
            dataGridView.RowTemplate.Height = 29;
            dataGridView.Size = new Size(1005, 286);
            dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            buttonCreateOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCreateOrder.Location = new Point(1035, 53);
            buttonCreateOrder.Margin = new Padding(3, 2, 3, 2);
            buttonCreateOrder.Name = "buttonCreateOrder";
            buttonCreateOrder.Size = new Size(216, 22);
            buttonCreateOrder.TabIndex = 2;
            buttonCreateOrder.Text = "Создать заказ";
            buttonCreateOrder.UseVisualStyleBackColor = true;
            buttonCreateOrder.Click += ButtonCreateOrder_Click;
            // 
            // buttonIssuedOrder
            // 
            buttonIssuedOrder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonIssuedOrder.Location = new Point(1035, 95);
            buttonIssuedOrder.Margin = new Padding(3, 2, 3, 2);
            buttonIssuedOrder.Name = "buttonIssuedOrder";
            buttonIssuedOrder.Size = new Size(216, 22);
            buttonIssuedOrder.TabIndex = 5;
            buttonIssuedOrder.Text = "Заказ выдан";
            buttonIssuedOrder.UseVisualStyleBackColor = true;
            buttonIssuedOrder.Click += ButtonIssuedOrder_Click;
            // 
            // buttonRef
            // 
            buttonRef.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonRef.Location = new Point(1035, 136);
            buttonRef.Margin = new Padding(3, 2, 3, 2);
            buttonRef.Name = "buttonRef";
            buttonRef.Size = new Size(216, 22);
            buttonRef.TabIndex = 6;
            buttonRef.Text = "Обновить список";
            buttonRef.UseVisualStyleBackColor = true;
            buttonRef.Click += ButtonRef_Click;
            // 
            // buttonAddManufactureInShop
            // 
            buttonAddManufactureInShop.Location = new Point(1035, 186);
            buttonAddManufactureInShop.Name = "buttonAddManufactureInShop";
            buttonAddManufactureInShop.Size = new Size(216, 22);
            buttonAddManufactureInShop.TabIndex = 7;
            buttonAddManufactureInShop.Text = "Пополнение магазина";
            buttonAddManufactureInShop.UseVisualStyleBackColor = true;
            buttonAddManufactureInShop.Click += buttonAddManufactureInShop_Click;
            // 
            // buttonSellManufacture
            // 
            buttonSellManufacture.Location = new Point(1035, 214);
            buttonSellManufacture.Name = "buttonSellManufacture";
            buttonSellManufacture.Size = new Size(216, 23);
            buttonSellManufacture.TabIndex = 8;
            buttonSellManufacture.Text = "Продать изделие";
            buttonSellManufacture.UseVisualStyleBackColor = true;
            buttonSellManufacture.Click += ButtonSellManufacture_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1286, 319);
            Controls.Add(buttonRef);
            Controls.Add(buttonIssuedOrder);
            Controls.Add(buttonCreateOrder);
            Controls.Add(buttonAddManufactureInShop);
            Controls.Add(buttonSellManufacture);
            Controls.Add(dataGridView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormMain";
            Text = "Кузнечная мастерская";
            Load += FormMain_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem guideToolStripMenuItem;
        private ToolStripMenuItem componentsToolStripMenuItem;
        private ToolStripMenuItem goodsToolStripMenuItem;
        private DataGridView dataGridView;
        private Button buttonCreateOrder;
        private Button buttonIssuedOrder;
        private Button buttonRef;
        private ToolStripMenuItem отчетыToolStripMenuItem;
        private ToolStripMenuItem componentListToolStripMenuItem;
        private ToolStripMenuItem componentsManufactureToolStripMenuItem;
        private ToolStripMenuItem orderListToolStripMenuItem;
        private ToolStripMenuItem clientsToolStripMenuItem;
        private ToolStripMenuItem implemntersToolStripMenuItem;
        private ToolStripMenuItem workToolStripMenuItem;
        private Button buttonAddManufactureInShop;
        private Button buttonSellManufacture;
        private ToolStripMenuItem shopListToolStripMenuItem;
        private ToolStripMenuItem shopsCapacityToolStripMenuItem;
        private ToolStripMenuItem ordersByDateToolStripMenuItem;
        private ToolStripMenuItem ShopsToolStripMenuItem;
        private ToolStripMenuItem messagesToolStripMenuItem;
        private ToolStripMenuItem backupToolStripMenuItem;
    }
}
