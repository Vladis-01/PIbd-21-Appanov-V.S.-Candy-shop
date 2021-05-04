namespace CandyShopView
{
    partial class FormReportOrders
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
            this.panelDate = new System.Windows.Forms.Panel();
            this.ButtonToPdf = new System.Windows.Forms.Button();
            this.ButtonMake = new System.Windows.Forms.Button();
            this.labelBy = new System.Windows.Forms.Label();
            this.labelWith = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.reportViewerOrders = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.ButtonToPdf);
            this.panelDate.Controls.Add(this.ButtonMake);
            this.panelDate.Controls.Add(this.labelBy);
            this.panelDate.Controls.Add(this.labelWith);
            this.panelDate.Controls.Add(this.dateTimePickerTo);
            this.panelDate.Controls.Add(this.dateTimePickerFrom);
            this.panelDate.Location = new System.Drawing.Point(-2, 2);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(807, 40);
            this.panelDate.TabIndex = 0;
            // 
            // ButtonToPdf
            // 
            this.ButtonToPdf.Location = new System.Drawing.Point(644, 5);
            this.ButtonToPdf.Name = "ButtonToPdf";
            this.ButtonToPdf.Size = new System.Drawing.Size(100, 20);
            this.ButtonToPdf.TabIndex = 5;
            this.ButtonToPdf.Text = "В PDF";
            this.ButtonToPdf.UseVisualStyleBackColor = true;
            this.ButtonToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // ButtonMake
            // 
            this.ButtonMake.Location = new System.Drawing.Point(439, 5);
            this.ButtonMake.Name = "ButtonMake";
            this.ButtonMake.Size = new System.Drawing.Size(109, 20);
            this.ButtonMake.TabIndex = 4;
            this.ButtonMake.Text = "Сформировать";
            this.ButtonMake.UseVisualStyleBackColor = true;
            this.ButtonMake.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // labelBy
            // 
            this.labelBy.AutoSize = true;
            this.labelBy.Location = new System.Drawing.Point(209, 12);
            this.labelBy.Name = "labelBy";
            this.labelBy.Size = new System.Drawing.Size(21, 13);
            this.labelBy.TabIndex = 3;
            this.labelBy.Text = "По";
            // 
            // labelWith
            // 
            this.labelWith.AutoSize = true;
            this.labelWith.Location = new System.Drawing.Point(52, 12);
            this.labelWith.Name = "labelWith";
            this.labelWith.Size = new System.Drawing.Size(14, 13);
            this.labelWith.TabIndex = 2;
            this.labelWith.Text = "С";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(236, 6);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(123, 20);
            this.dateTimePickerTo.TabIndex = 1;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(72, 6);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(122, 20);
            this.dateTimePickerFrom.TabIndex = 0;
            // 
            // reportViewerOrders
            // 
            this.reportViewerOrders.LocalReport.ReportEmbeddedResource = "CandyShopView.ReportPastrySweets.rdlc";
            this.reportViewerOrders.Location = new System.Drawing.Point(-2, 34);
            this.reportViewerOrders.Name = "reportViewerOrders";
            this.reportViewerOrders.ServerReport.BearerToken = null;
            this.reportViewerOrders.Size = new System.Drawing.Size(807, 416);
            this.reportViewerOrders.TabIndex = 1;
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewerOrders);
            this.Controls.Add(this.panelDate);
            this.Name = "FormReportOrders";
            this.Text = "Список заказов";
            this.Load += new System.EventHandler(this.FormClientOrders_Load);
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDate;
        private System.Windows.Forms.Label labelBy;
        private System.Windows.Forms.Label labelWith;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerOrders;
        private System.Windows.Forms.Button ButtonToPdf;
        private System.Windows.Forms.Button ButtonMake;
    }
}