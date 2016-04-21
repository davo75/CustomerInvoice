using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIAssignment2
{
    public partial class CustomerForm : Form
    {

        public string purpose; //add or edit customer
        public MainForm parent;

        public CustomerForm()
        {
            InitializeComponent();
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            showTheme(parent.theme);

            if (purpose.Equals("Add"))
            {
                txtBoxCustNum.Text = parent.getNewCustNum();
            }
            else if (purpose.Equals("Edit"))
            {
                txtBoxCustNum.Text = parent.currentSelectedCustomer.CustNum;
                //hide the all field reqd label
                lblAllReqd.Visible = false;
                fillCustomerDetails();
            }
            //make the first editable text input active (company)
            this.ActiveControl = txtBoxCompany;
        }

        private void showTheme(string theTheme)
        {

            switch (theTheme)
            {
                case "Light":
                    Image lightImage = new Bitmap(UIAssignment2.Properties.Resources.light);
                    this.BackgroundImage = lightImage;
                    //Customer Details Box
                    groupBox1.ForeColor = Color.White;
                    groupBox1.BackColor = Color.Transparent;
                    break;
                case "Dark":
                    Image darkImage = new Bitmap(UIAssignment2.Properties.Resources.dark);
                    this.BackgroundImage = darkImage;
                    //Customer Details Box
                    groupBox1.ForeColor = Color.White;
                    groupBox1.BackColor = Color.Transparent;
                    break;

                default:
                    this.BackgroundImage = null;
                    //Customer Details Box
                    groupBox1.ForeColor = SystemColors.ControlText;
                    groupBox1.BackColor = SystemColors.Control;
                    break;
            }
        }

        private void btnCustSave_Click(object sender, EventArgs e)
        {
            if (purpose.Equals("Add"))
            {

                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    createNewCustomer();
                    this.Dispose();
                }
            }
            else if (purpose.Equals("Edit"))
            {
                if (this.ValidateChildren(ValidationConstraints.Enabled))
                {
                    updateCustomerDetails();
                    this.Dispose();
                }
            }

        }

        private void updateCustomerDetails()
        {
            parent.currentSelectedCustomer.CustFirstName = txtBoxFirstName.Text;
            parent.currentSelectedCustomer.CustLastName = txtBoxLastName.Text;
            parent.currentSelectedCustomer.CustStreet = txtBoxStreet.Text;
            parent.currentSelectedCustomer.CustSuburb = txtBoxSuburb.Text;
            parent.currentSelectedCustomer.CustState = cboxState.Text;
            parent.currentSelectedCustomer.CustPostCode = txtBoxPostCode.Text;
            parent.currentSelectedCustomer.CustContactNum = txtBoxPhone.Text;
            parent.currentSelectedCustomer.CustCompany = txtBoxCompany.Text;

        }

        private void fillCustomerDetails()
        {
            txtBoxFirstName.Text = parent.currentSelectedCustomer.CustFirstName;
            txtBoxLastName.Text = parent.currentSelectedCustomer.CustLastName;
            txtBoxStreet.Text = parent.currentSelectedCustomer.CustStreet;
            txtBoxSuburb.Text = parent.currentSelectedCustomer.CustSuburb;
            cboxState.Text = parent.currentSelectedCustomer.CustState.ToString();
            txtBoxPostCode.Text = parent.currentSelectedCustomer.CustPostCode;
            txtBoxPhone.Text = parent.currentSelectedCustomer.CustContactNum;
            txtBoxCompany.Text = parent.currentSelectedCustomer.CustCompany;

        }

        private void createNewCustomer()
        {

            parent.addNewCustomer(txtBoxCustNum.Text,
                txtBoxFirstName.Text,
                txtBoxLastName.Text,
                txtBoxStreet.Text,
                txtBoxSuburb.Text,
                cboxState.GetItemText(cboxState.SelectedItem),
                txtBoxPostCode.Text,
                txtBoxPhone.Text,
                txtBoxCompany.Text);
        }

        private void txtBoxCompany_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtBoxCompany.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxCompany, "Please enter a company name");
            }

            e.Cancel = cancel;
        }

        private void txtBoxFirstName_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;

            if (string.IsNullOrEmpty(this.txtBoxFirstName.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxFirstName, "Please enter a first name");
            }
            
            e.Cancel = cancel;
        }

        private void txtBoxLastName_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtBoxLastName.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxLastName, "Please enter a last name");
            }
           
            e.Cancel = cancel;
        }

        private void txtBoxStreet_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtBoxStreet.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxStreet, "Please enter a street name");
            }
           
            e.Cancel = cancel;
        }

        private void txtBoxSuburb_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtBoxSuburb.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxSuburb, "Please enter a suburb");
            }
           
            e.Cancel = cancel;
        }

        private void cboxState_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.cboxState.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(cboxState, "Please select a state");
            }
           
            e.Cancel = cancel;
        }

        private void txtBoxPostCode_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtBoxPostCode.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxPostCode, "Please enter a post code");
            }
            
            e.Cancel = cancel;
        }

        private void txtBoxPhone_Validating(object sender, CancelEventArgs e)
        {
            bool cancel = false;
            if (string.IsNullOrEmpty(this.txtBoxPhone.Text))
            {
                cancel = true;
                this.errorProvider1.SetError(txtBoxPhone, "Please enter a contact number");
            }
           
            e.Cancel = cancel;
        }


        private void txtBoxCompany_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxCompany, string.Empty);
        }

        private void txtBoxFirstName_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxFirstName, string.Empty);
        }

        private void txtBoxLastName_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxLastName, string.Empty);
        }

        private void txtBoxStreet_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxStreet, string.Empty);
        }

        private void txtBoxSuburb_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxSuburb, string.Empty);
        }

        private void cboxState_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.cboxState, string.Empty);
        }

        private void txtBoxPostCode_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxPostCode, string.Empty);
        }

        private void txtBoxPhone_Validated(object sender, EventArgs e)
        {
            this.errorProvider1.SetError(this.txtBoxPhone, string.Empty);
        }
    }
}
