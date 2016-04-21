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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboxState = new System.Windows.Forms.ComboBox();
            this.txtBoxCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
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
            this.btnCustSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblAllReqd = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboxState);
            this.groupBox1.Controls.Add(this.txtBoxCompany);
            this.groupBox1.Controls.Add(this.lblCompany);
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
            this.groupBox1.Location = new System.Drawing.Point(23, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 321);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Details";
            // 
            // cboxState
            // 
            this.cboxState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxState.FormattingEnabled = true;
            this.errorProvider1.SetIconPadding(this.cboxState, 38);
            this.cboxState.Items.AddRange(new object[] {
            "ACT",
            "NSW",
            "NT",
            "QLD",
            "SA",
            "TAS",
            "VIC",
            "WA"});
            this.cboxState.Location = new System.Drawing.Point(153, 218);
            this.cboxState.Name = "cboxState";
            this.cboxState.Size = new System.Drawing.Size(67, 21);
            this.cboxState.TabIndex = 6;
            this.cboxState.Validating += new System.ComponentModel.CancelEventHandler(this.cboxState_Validating);
            this.cboxState.Validated += new System.EventHandler(this.cboxState_Validated);
            // 
            // txtBoxCompany
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxCompany, 5);
            this.txtBoxCompany.Location = new System.Drawing.Point(153, 60);
            this.txtBoxCompany.Name = "txtBoxCompany";
            this.txtBoxCompany.Size = new System.Drawing.Size(100, 20);
            this.txtBoxCompany.TabIndex = 1;
            this.txtBoxCompany.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxCompany_Validating);
            this.txtBoxCompany.Validated += new System.EventHandler(this.txtBoxCompany_Validated);
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
            // txtBoxPhone
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxPhone, 5);
            this.txtBoxPhone.Location = new System.Drawing.Point(153, 283);
            this.txtBoxPhone.Name = "txtBoxPhone";
            this.txtBoxPhone.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPhone.TabIndex = 8;
            this.txtBoxPhone.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxPhone_Validating);
            this.txtBoxPhone.Validated += new System.EventHandler(this.txtBoxPhone_Validated);
            // 
            // txtBoxPostCode
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxPostCode, 5);
            this.txtBoxPostCode.Location = new System.Drawing.Point(153, 251);
            this.txtBoxPostCode.Name = "txtBoxPostCode";
            this.txtBoxPostCode.Size = new System.Drawing.Size(100, 20);
            this.txtBoxPostCode.TabIndex = 7;
            this.txtBoxPostCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxPostCode_Validating);
            this.txtBoxPostCode.Validated += new System.EventHandler(this.txtBoxPostCode_Validated);
            // 
            // txtBoxSuburb
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxSuburb, 5);
            this.txtBoxSuburb.Location = new System.Drawing.Point(153, 187);
            this.txtBoxSuburb.Name = "txtBoxSuburb";
            this.txtBoxSuburb.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSuburb.TabIndex = 5;
            this.txtBoxSuburb.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxSuburb_Validating);
            this.txtBoxSuburb.Validated += new System.EventHandler(this.txtBoxSuburb_Validated);
            // 
            // txtBoxStreet
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxStreet, 5);
            this.txtBoxStreet.Location = new System.Drawing.Point(153, 155);
            this.txtBoxStreet.Name = "txtBoxStreet";
            this.txtBoxStreet.Size = new System.Drawing.Size(100, 20);
            this.txtBoxStreet.TabIndex = 4;
            this.txtBoxStreet.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxStreet_Validating);
            this.txtBoxStreet.Validated += new System.EventHandler(this.txtBoxStreet_Validated);
            // 
            // txtBoxLastName
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxLastName, 5);
            this.txtBoxLastName.Location = new System.Drawing.Point(153, 123);
            this.txtBoxLastName.Name = "txtBoxLastName";
            this.txtBoxLastName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxLastName.TabIndex = 3;
            this.txtBoxLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxLastName_Validating);
            this.txtBoxLastName.Validated += new System.EventHandler(this.txtBoxLastName_Validated);
            // 
            // txtBoxFirstName
            // 
            this.errorProvider1.SetIconPadding(this.txtBoxFirstName, 5);
            this.txtBoxFirstName.Location = new System.Drawing.Point(153, 91);
            this.txtBoxFirstName.Name = "txtBoxFirstName";
            this.txtBoxFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtBoxFirstName.TabIndex = 2;
            this.txtBoxFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtBoxFirstName_Validating);
            this.txtBoxFirstName.Validated += new System.EventHandler(this.txtBoxFirstName_Validated);
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
            // btnCustSave
            // 
            this.btnCustSave.Location = new System.Drawing.Point(212, 363);
            this.btnCustSave.Name = "btnCustSave";
            this.btnCustSave.Size = new System.Drawing.Size(75, 23);
            this.btnCustSave.TabIndex = 9;
            this.btnCustSave.Text = "Save";
            this.btnCustSave.UseVisualStyleBackColor = true;
            this.btnCustSave.Click += new System.EventHandler(this.btnCustSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(293, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // lblAllReqd
            // 
            this.lblAllReqd.AutoSize = true;
            this.lblAllReqd.ForeColor = System.Drawing.Color.Red;
            this.lblAllReqd.Location = new System.Drawing.Point(20, 368);
            this.lblAllReqd.Name = "lblAllReqd";
            this.lblAllReqd.Size = new System.Drawing.Size(92, 13);
            this.lblAllReqd.TabIndex = 37;
            this.lblAllReqd.Text = "* all fields required";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 402);
            this.Controls.Add(this.lblAllReqd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCustSave);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboxState;
        private System.Windows.Forms.TextBox txtBoxCompany;
        private System.Windows.Forms.Label lblCompany;
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
        private System.Windows.Forms.Button btnCustSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblAllReqd;
    }
}