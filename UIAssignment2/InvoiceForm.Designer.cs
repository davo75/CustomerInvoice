namespace UIAssignment2
{
    partial class InvoiceForm
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
            this.gbInvoice = new System.Windows.Forms.GroupBox();
            this.txtBoxInvoiceTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgAddInvoiceItems = new System.Windows.Forms.DataGridView();
            this.cboxPaidStatus = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.paymentDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.tbInvoiceNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.gbInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAddInvoiceItems)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInvoice
            // 
            this.gbInvoice.Controls.Add(this.txtBoxInvoiceTotal);
            this.gbInvoice.Controls.Add(this.label4);
            this.gbInvoice.Controls.Add(this.dgAddInvoiceItems);
            this.gbInvoice.Controls.Add(this.cboxPaidStatus);
            this.gbInvoice.Controls.Add(this.label3);
            this.gbInvoice.Controls.Add(this.paymentDatePicker);
            this.gbInvoice.Controls.Add(this.label2);
            this.gbInvoice.Controls.Add(this.tbInvoiceNum);
            this.gbInvoice.Controls.Add(this.label1);
            this.gbInvoice.Location = new System.Drawing.Point(12, 12);
            this.gbInvoice.Name = "gbInvoice";
            this.gbInvoice.Size = new System.Drawing.Size(556, 418);
            this.gbInvoice.TabIndex = 0;
            this.gbInvoice.TabStop = false;
            this.gbInvoice.Text = "Invoice";
            // 
            // txtBoxInvoiceTotal
            // 
            this.txtBoxInvoiceTotal.Location = new System.Drawing.Point(462, 380);
            this.txtBoxInvoiceTotal.Name = "txtBoxInvoiceTotal";
            this.txtBoxInvoiceTotal.ReadOnly = true;
            this.txtBoxInvoiceTotal.Size = new System.Drawing.Size(70, 20);
            this.txtBoxInvoiceTotal.TabIndex = 8;
            this.txtBoxInvoiceTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(370, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Invoice Total:";
            // 
            // dgAddInvoiceItems
            // 
            this.dgAddInvoiceItems.AllowUserToResizeColumns = false;
            this.dgAddInvoiceItems.AllowUserToResizeRows = false;
            this.dgAddInvoiceItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAddInvoiceItems.Location = new System.Drawing.Point(22, 167);
            this.dgAddInvoiceItems.Name = "dgAddInvoiceItems";
            this.dgAddInvoiceItems.Size = new System.Drawing.Size(510, 197);
            this.dgAddInvoiceItems.TabIndex = 6;
            // 
            // cboxPaidStatus
            // 
            this.cboxPaidStatus.AutoSize = true;
            this.cboxPaidStatus.Location = new System.Drawing.Point(128, 114);
            this.cboxPaidStatus.Name = "cboxPaidStatus";
            this.cboxPaidStatus.Size = new System.Drawing.Size(47, 17);
            this.cboxPaidStatus.TabIndex = 5;
            this.cboxPaidStatus.Text = "Paid";
            this.cboxPaidStatus.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Payment Status";
            // 
            // paymentDatePicker
            // 
            this.paymentDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.paymentDatePicker.Location = new System.Drawing.Point(128, 71);
            this.paymentDatePicker.Name = "paymentDatePicker";
            this.paymentDatePicker.Size = new System.Drawing.Size(100, 20);
            this.paymentDatePicker.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Payment Due Date";
            // 
            // tbInvoiceNum
            // 
            this.tbInvoiceNum.Location = new System.Drawing.Point(128, 28);
            this.tbInvoiceNum.Name = "tbInvoiceNum";
            this.tbInvoiceNum.ReadOnly = true;
            this.tbInvoiceNum.Size = new System.Drawing.Size(100, 20);
            this.tbInvoiceNum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Invoice Number";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(412, 442);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(493, 442);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 481);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbInvoice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            this.gbInvoice.ResumeLayout(false);
            this.gbInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAddInvoiceItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInvoice;
        private System.Windows.Forms.DataGridView dgAddInvoiceItems;
        private System.Windows.Forms.CheckBox cboxPaidStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker paymentDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbInvoiceNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtBoxInvoiceTotal;
        private System.Windows.Forms.Label label4;
    }
}