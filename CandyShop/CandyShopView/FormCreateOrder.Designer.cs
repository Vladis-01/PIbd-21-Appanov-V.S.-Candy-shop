﻿namespace CandyShopView
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
            this.labelPastry = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.comboBoxPastry = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPastry
            // 
            this.labelPastry.AutoSize = true;
            this.labelPastry.Location = new System.Drawing.Point(12, 9);
            this.labelPastry.Name = "labelPastry";
            this.labelPastry.Size = new System.Drawing.Size(79, 13);
            this.labelPastry.TabIndex = 0;
            this.labelPastry.Text = "Кондитерское изделие ";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 34);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(66, 13);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(12, 59);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(41, 13);
            this.labelSum.TabIndex = 2;
            this.labelSum.Text = "Сумма";
            // 
            // comboBoxPastry
            // 
            this.comboBoxPastry.FormattingEnabled = true;
            this.comboBoxPastry.Location = new System.Drawing.Point(103, 4);
            this.comboBoxPastry.Name = "comboBoxPastry";
            this.comboBoxPastry.Size = new System.Drawing.Size(178, 21);
            this.comboBoxPastry.TabIndex = 3;
            this.comboBoxPastry.SelectedIndexChanged += new System.EventHandler(this.ComboBoxPastry_SelectedIndexChanged);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(103, 31);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(178, 20);
            this.textBoxCount.TabIndex = 4;
            this.textBoxCount.TextChanged += new System.EventHandler(this.TextBoxCount_TextChanged);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(103, 56);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(178, 20);
            this.textBoxSum.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(129, 82);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(73, 22);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(208, 82);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(73, 22);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 113);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxPastry);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelPastry);
            this.Name = "FormCreateOrder";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPastry;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.ComboBox comboBoxPastry;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}