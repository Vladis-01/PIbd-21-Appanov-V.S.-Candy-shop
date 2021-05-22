namespace CandyShopView
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сладостиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кондитерскиеИзделияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокСладостейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоКондитерскимИзделиямToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonPayOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.списокСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сладостиПоСкладамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.датыЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьСкладToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.запускРаботToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сладостиToolStripMenuItem,
            this.кондитерскиеИзделияToolStripMenuItem,
            this.складыToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.исполнителиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // сладостиToolStripMenuItem
            // 
            this.сладостиToolStripMenuItem.Name = "сладостиToolStripMenuItem";
            this.сладостиToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.сладостиToolStripMenuItem.Text = "Сладости";
            this.сладостиToolStripMenuItem.Click += new System.EventHandler(this.СладостиToolStripMenuItem_Click);
            // 
            // кондитерскиеИзделияToolStripMenuItem
            // 
            this.кондитерскиеИзделияToolStripMenuItem.Name = "кондитерскиеИзделияToolStripMenuItem";
            this.кондитерскиеИзделияToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.кондитерскиеИзделияToolStripMenuItem.Text = "Кондитерские Изделия";
            this.кондитерскиеИзделияToolStripMenuItem.Click += new System.EventHandler(this.КондитерскиеИзделияToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // пополнитьСкладToolStripMenuItem
            // 
            this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
            this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокСладостейToolStripMenuItem,
            this.компонентыПоКондитерскимИзделиямToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem,
            this.списокСкладовToolStripMenuItem,
            this.сладостиПоСкладамToolStripMenuItem,
            this.датыЗаказовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // списокСладостейToolStripMenuItem
            // 
            this.списокСладостейToolStripMenuItem.Name = "списокСладостейToolStripMenuItem";
            this.списокСладостейToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.списокСладостейToolStripMenuItem.Text = "Список сладостей";
            this.списокСладостейToolStripMenuItem.Click += new System.EventHandler(this.SweetsToolStripMenuItem_Click);
            // 
            // компонентыПоКондитерскимИзделиямToolStripMenuItem
            // 
            this.компонентыПоКондитерскимИзделиямToolStripMenuItem.Name = "компонентыПоКондитерскимИзделиямToolStripMenuItem";
            this.компонентыПоКондитерскимИзделиямToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.компонентыПоКондитерскимИзделиямToolStripMenuItem.Text = "Компоненты по кондитерским изделиям";
            this.компонентыПоКондитерскимИзделиямToolStripMenuItem.Click += new System.EventHandler(this.SweetPastrysToolStripMenuItem_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(0, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(624, 252);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(636, 38);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(154, 26);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // buttonTakeOrderInWork
            // 
            this.buttonTakeOrderInWork.Location = new System.Drawing.Point(636, 89);
            this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            this.buttonTakeOrderInWork.Size = new System.Drawing.Size(154, 26);
            this.buttonTakeOrderInWork.TabIndex = 3;
            this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
            this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.buttonTakeOrderInWork.Click += new System.EventHandler(this.ButtonTakeOrderInWork_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(636, 140);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(154, 26);
            this.buttonOrderReady.TabIndex = 4;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.ButtonOrderReady_Click);
            // 
            // buttonPayOrder
            // 
            this.buttonPayOrder.Location = new System.Drawing.Point(636, 189);
            this.buttonPayOrder.Name = "buttonPayOrder";
            this.buttonPayOrder.Size = new System.Drawing.Size(154, 26);
            this.buttonPayOrder.TabIndex = 5;
            this.buttonPayOrder.Text = "Заказ оплачен";
            this.buttonPayOrder.UseVisualStyleBackColor = true;
            this.buttonPayOrder.Click += new System.EventHandler(this.ButtonPayOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(636, 235);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(154, 26);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // списокСкладовToolStripMenuItem
            // 
            this.списокСкладовToolStripMenuItem.Name = "списокСкладовToolStripMenuItem";
            this.списокСкладовToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.списокСкладовToolStripMenuItem.Text = "Список складов";
            this.списокСкладовToolStripMenuItem.Click += new System.EventHandler(this.storagesListToolStripMenuItem_Click);
            // 
            // сладостиПоСкладамToolStripMenuItem
            // 
            this.сладостиПоСкладамToolStripMenuItem.Name = "сладостиПоСкладамToolStripMenuItem";
            this.сладостиПоСкладамToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.сладостиПоСкладамToolStripMenuItem.Text = "Сладости по складам";
            this.сладостиПоСкладамToolStripMenuItem.Click += new System.EventHandler(this.sweetsByStoragesToolStripMenuItem_Click);
            // 
            // датыЗаказовToolStripMenuItem
            // 
            this.датыЗаказовToolStripMenuItem.Name = "датыЗаказовToolStripMenuItem";
            this.датыЗаказовToolStripMenuItem.Size = new System.Drawing.Size(300, 22);
            this.датыЗаказовToolStripMenuItem.Text = "Даты заказов";
            this.датыЗаказовToolStripMenuItem.Click += new System.EventHandler(this.ordersByDatesToolStripMenuItem_Click);
            // клиентыToolStripMenuItem
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(800, 280);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayOrder);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonTakeOrderInWork);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Кондитерский магазин";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сладостиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кондитерскиеИзделияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem складыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button buttonTakeOrderInWork;
        private System.Windows.Forms.Button buttonOrderReady;
        private System.Windows.Forms.Button buttonPayOrder;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСладостейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem компонентыПоКондитерскимИзделиямToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сладостиПоСкладамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem датыЗаказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполнителиToolStripMenuItem;
    }
}
