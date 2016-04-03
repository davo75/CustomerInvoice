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
           //this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            if (purpose.Equals("Add"))
            {
                txtBoxCustNum.Text = (parent.customers.Count + 1).ToString();
            }
            else if (purpose.Equals("Edit"))
            {
                txtBoxCustNum.Text = parent.currentSelectedCustomer.CustNum;
                fillCustomerDetails();
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
                updateCustomerDetails();
                this.Dispose();
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
                cboxState.SelectedText = parent.currentSelectedCustomer.CustState;
                txtBoxPostCode.Text = parent.currentSelectedCustomer.CustPostCode;
                txtBoxPhone.Text = parent.currentSelectedCustomer.CustContactNum;
                txtBoxCompany.Text = parent.currentSelectedCustomer.CustCompany;

        }

        private void createNewCustomer() {
            
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
            if (txtBoxCompany.Text == "")
            {
                cancel = true;
                errorProvider1.SetError(txtBoxCompany, "Please enter a company name");
            }
            
            e.Cancel = cancel;
            
        }

       

        private void txtBoxCompany_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtBoxCompany, string.Empty);
        }
     }
}
