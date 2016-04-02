namespace UIAssignment2
{
    partial class CustomerForm
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
            this.txtBoxPhone = new System.Windows.Forms.TextBox();
            this.txtBoxPostCode = new System.Windows.Forms.TextBox();
            this.txtBoxSuburb = new System.Windows.Forms.TextBox();
            this.txtBoxStreet = new System.Windows.Forms.TextBox();
            this.txtBoxLastName = new System.Windows.Forms.TextBox();
            this.txtBoxFirstName = new System.Windows.Forms.TextBox();
            this.txtBoxCustNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBoxCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtBoxState = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbInvoiceNum = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lbCustomers = new System.Windows.Forms.ListBox();
            this.gbInvoiceDetails = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.tbTotalInvoiceCost = new System.Windows.Forms.TextBox();
            this.lblTotalInvoiceCost = new System.Windows.Forms.Label();
            this.dgInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.btnEditInvoice = new System.Windows.Forms.Button();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbInvoiceDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoxPhone
            // 
            this.txtBoxPhone.Location = new System.Drawing.Point(153, 283);
            this.txtBoxPhone.Name = "txtBoxPhone";
            this.txtBoxPhone.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPhone.TabIndex = 31;
            // 
            // txtBoxPostCode
            // 
            this.txtBoxPostCode.Location = new System.Drawing.Point(153, 251);
            this.txtBoxPostCode.Name = "txtBoxPostCode";
            this.txtBoxPostCode.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPostCode.TabIndex = 30;
            // 
            // txtBoxSuburb
            // 
            this.txtBoxSuburb.Location = new System.Drawing.Point(153, 187);
            this.txtBoxSuburb.Name = "txtBoxSuburb";
            this.txtBoxSuburb.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSuburb.TabIndex = 29;
            // 
            // txtBoxStreet
            // 
            this.txtBoxStreet.Location = new System.Drawing.Point(153, 155);
            this.txtBoxStreet.Name = "txtBoxStreet";
            this.txtBoxStreet.Size = new System.Drawing.Size(100, 20);
            this.txtBoxStreet.TabIndex = 28;
            // 
            // txtBoxLastName
            // 
            this.txtBoxLastName.Location = new System.Drawing.Point(153, 123);
            this.txtBoxLastName.Name = "txtBoxLastName";
            this.txtBoxLastName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxLastName.TabIndex = 27;
            // 
            // txtBoxFirstName
            // 
            this.txtBoxFirstName.Location = new System.Drawing.Point(153, 91);
            this.txtBoxFirstName.Name = "txtBoxFirstName";
            this.txtBoxFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFirstName.TabIndex = 26;
            // 
            // txtBoxCustNum
            // 
            this.txtBoxCustNum.Location = new System.Drawing.Point(153, 29);
            this.txtBoxCustNum.Name = "txtBoxCustNum";
            this.txtBoxCustNum.ReadOnly = true;
            this.txtBoxCustNum.Size = new System.Drawing.Size(100, 20);
            this.txtBoxCustNum.TabIndex = 25;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Post Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "State";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Suburb";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Contact Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Street Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Last Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "First Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Customer Number";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBoxCompany);
            this.groupBox1.Controls.Add(this.lblCompany);
            this.groupBox1.Controls.Add(this.txtBoxState);
            this.groupBox1.Controls.Add(this.txtBoxPhone);
            this.groupBox1.Controls.Add(this.txtBoxPostCode);
            this.groupBox1.Controls.Add(this.txtBoxSuburb);
            this.groupBox1.Controls.Add(this.txtBoxStreet);
            this.groupBox1.Controls.Add(this.txtBoxLastName);
            this.groupBox1.Controls.Add(this.txtBoxFirstName);
            this.groupBox1.Controls.Add(this.txtBoxCustNum);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(198, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 321);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // txtBoxCompany
            // 
            this.txtBoxCompany.Location = new System.Drawing.Point(153, 60);
            this.txtBoxCompany.Name = "txtBoxCompany";
            this.txtBoxCompany.Size = new System.Drawing.Size(100, 20);
            this.txtBoxCompany.TabIndex = 34;
            this.txtBoxCompany.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Location = new System.Drawing.Point(22, 64);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(51, 13);
            this.lblCompany.TabIndex = 33;
            this.lblCompany.Text = "Company";
            // 
            // txtBoxState
            // 
            this.txtBoxState.Location = new System.Drawing.Point(153, 220);
            this.txtBoxState.Name = "txtBoxState";
            this.txtBoxState.Size = new System.Drawing.Size(100, 20);
            this.txtBoxState.TabIndex = 32;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbInvoiceNum);
            this.groupBox2.Location = new System.Drawing.Point(568, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 321);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Invoices";
            // 
            // lbInvoiceNum
            // 
            this.lbInvoiceNum.FormattingEnabled = true;
            this.lbInvoiceNum.Location = new System.Drawing.Point(20, 26);
            this.lbInvoiceNum.Name = "lbInvoiceNum";
            this.lbInvoiceNum.Size = new System.Drawing.Size(95, 277);
            this.lbInvoiceNum.TabIndex = 1;
            this.lbInvoiceNum.SelectedIndexChanged += new System.EventHandler(this.lbInvoiceNum_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tbSearch);
            this.groupBox3.Controls.Add(this.lbCustomers);
            this.groupBox3.Location = new System.Drawing.Point(17, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(156, 321);
            this.groupBox3.TabIndex = 37;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Customers";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Filter";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(21, 52);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(115, 20);
            this.tbSearch.TabIndex = 1;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lbCustomers
            // 
            this.lbCustomers.FormattingEnabled = true;
            this.lbCustomers.Location = new System.Drawing.Point(21, 78);
            this.lbCustomers.Name = "lbCustomers";
            this.lbCustomers.Size = new System.Drawing.Size(115, 225);
            this.lbCustomers.TabIndex = 0;
            this.lbCustomers.SelectedIndexChanged += new System.EventHandler(this.lbCustomers_SelectedIndexChanged);
            // 
            // gbInvoiceDetails
            // 
            this.gbInvoiceDetails.Controls.Add(this.lblStatus);
            this.gbInvoiceDetails.Controls.Add(this.lblPaymentStatus);
            this.gbInvoiceDetails.Controls.Add(this.tbTotalInvoiceCost);
            this.gbInvoiceDetails.Controls.Add(this.lblTotalInvoiceCost);
            this.gbInvoiceDetails.Controls.Add(this.dgInvoiceDetails);
            this.gbInvoiceDetails.Location = new System.Drawing.Point(17, 405);
            this.gbInvoiceDetails.Name = "gbInvoiceDetails";
            this.gbInvoiceDetails.Size = new System.Drawing.Size(684, 207);
            this.gbInvoiceDetails.TabIndex = 38;
            this.gbInvoiceDetails.TabStop = false;
            this.gbInvoiceDetails.Text = "Invoice Details";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(117, 177);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 45;
            this.lblStatus.Text = "lblStatus";
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentStatus.Location = new System.Drawing.Point(21, 177);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(99, 13);
            this.lblPaymentStatus.TabIndex = 44;
            this.lblPaymentStatus.Text = "Payment Status:";
            // 
            // tbTotalInvoiceCost
            // 
            this.tbTotalInvoiceCost.Location = new System.Drawing.Point(590, 173);
            this.tbTotalInvoiceCost.Name = "tbTotalInvoiceCost";
            this.tbTotalInvoiceCost.ReadOnly = true;
            this.tbTotalInvoiceCost.Size = new System.Drawing.Size(70, 20);
            this.tbTotalInvoiceCost.TabIndex = 43;
            this.tbTotalInvoiceCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTotalInvoiceCost
            // 
            this.lblTotalInvoiceCost.AutoSize = true;
            this.lblTotalInvoiceCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInvoiceCost.Location = new System.Drawing.Point(471, 177);
            this.lblTotalInvoiceCost.Name = "lblTotalInvoiceCost";
            this.lblTotalInvoiceCost.Size = new System.Drawing.Size(115, 13);
            this.lblTotalInvoiceCost.TabIndex = 42;
            this.lblTotalInvoiceCost.Text = "Total Invoice Cost:";
            // 
            // dgInvoiceDetails
            // 
            this.dgInvoiceDetails.AllowUserToAddRows = false;
            this.dgInvoiceDetails.AllowUserToDeleteRows = false;
            this.dgInvoiceDetails.AllowUserToResizeColumns = false;
            this.dgInvoiceDetails.AllowUserToResizeRows = false;
            this.dgInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInvoiceDetails.Location = new System.Drawing.Point(21, 27);
            this.dgInvoiceDetails.Name = "dgInvoiceDetails";
            this.dgInvoiceDetails.ReadOnly = true;
            this.dgInvoiceDetails.Size = new System.Drawing.Size(640, 130);
            this.dgInvoiceDetails.TabIndex = 42;
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Location = new System.Drawing.Point(455, 373);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnAddInvoice.TabIndex = 39;
            this.btnAddInvoice.Text = "Add Invoice";
            this.btnAddInvoice.UseVisualStyleBackColor = true;
            this.btnAddInvoice.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnEditInvoice
            // 
            this.btnEditInvoice.Location = new System.Drawing.Point(536, 373);
            this.btnEditInvoice.Name = "btnEditInvoice";
            this.btnEditInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnEditInvoice.TabIndex = 40;
            this.btnEditInvoice.Text = "Edit Invoice";
            this.btnEditInvoice.UseVisualStyleBackColor = true;
            this.btnEditInvoice.Click += new System.EventHandler(this.btnEditInvoice_Click);
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.Location = new System.Drawing.Point(617, 373);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(84, 23);
            this.btnDeleteInvoice.TabIndex = 41;
            this.btnDeleteInvoice.Text = "Delete Invoice";
            this.btnDeleteInvoice.UseVisualStyleBackColor = true;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 632);
            this.Controls.Add(this.btnDeleteInvoice);
            this.Controls.Add(this.btnEditInvoice);
            this.Controls.Add(this.btnAddInvoice);
            this.Controls.Add(this.gbInvoiceDetails);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ABC Invoice Application";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbInvoiceDetails.ResumeLayout(false);
            this.gbInvoiceDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInvoiceDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxPhone;
        private System.Windows.Forms.TextBox txtBoxPostCode;
        private System.Windows.Forms.TextBox txtBoxSuburb;
        private System.Windows.Forms.TextBox txtBoxStreet;
        private System.Windows.Forms.TextBox txtBoxLastName;
        private System.Windows.Forms.TextBox txtBoxFirstName;
        private System.Windows.Forms.TextBox txtBoxCustNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbInvoiceDetails;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.Button btnEditInvoice;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.ListBox lbInvoiceNum;
        private System.Windows.Forms.ListBox lbCustomers;
        private System.Windows.Forms.DataGridView dgInvoiceDetails;
        private System.Windows.Forms.TextBox tbTotalInvoiceCost;
        private System.Windows.Forms.Label lblTotalInvoiceCost;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.TextBox txtBoxState;
        private System.Windows.Forms.TextBox txtBoxCompany;
        private System.Windows.Forms.Label lblCompany;
    }
}

