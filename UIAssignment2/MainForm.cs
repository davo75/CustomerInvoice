using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;

namespace UIAssignment2
{
    public partial class MainForm : Form
    {
        internal List<Customer> customers;
        internal List<Item> products;
        internal Customer currentSelectedCustomer;

        private DataTable sortedCustomers;
        private string invoiceToSearch;
        private int invoiceNumThatWasEdited;
        private int invoiceCount;
        
        public MainForm()
        {
            InitializeComponent();
            customers = new List<Customer>();
            
            addTestData();

        }

        public int InvoiceCount
        {
            get { return invoiceCount; }
            set { invoiceCount = value; }
        }

        public string InvoiceToSearch
        {
            get { return invoiceToSearch; }
            set { invoiceToSearch = value; }
        }



        public void addTestData()
        {
           

            invoiceCount = 0;

            //create some product items
            products = new List<Item>();
            products.Add(new Item(1, "Mouse", "Wireless Mouse", 14.99m));
            products.Add(new Item(2, "Macbook Pro", "i7 8Gb RAM 15-inch", 1450.00m));
            products.Add(new Item(3, "Monitor", "DELL 16:9 24inch", 350.00m));
            products.Add(new Item(4, "Dock", "USB HDMI DVI Dual Monitor", 200.00m));
            products.Add(new Item(5, "Keyboard", "Wireless Keyboard", 34.99m));
            products.Add(new Item(6, "USB Drive", "SanDisk 16GB", 59.00m));

            //add some customers
            addNewCustomer("1", "Dave", "Pyle", "349 Grand Prom", "Dianella", "WA", "6059", "0478220117", "Intekka");
            addNewCustomer("2", "Lena", "Funtseva", "123 Flinders Ave", "Mirrabooka", "WA", "6061", "0478221847", "Russki");
            addNewCustomer("3", "Tom", "Butler", "4 Mill Lane", "East Perth", "WA", "6061", "1512281438", "Red Cross");
            addNewCustomer("4", "Andy", "Smith", "123 Main", "Dianella", "WA", "6000", "123444", "Microsoft");
            addNewCustomer("5", "Albert", "Smith", "123 Main", "Dianella", "WA", "6000", "123444", "Microsoft");
            addNewCustomer("6", "Andrew", "Smith", "123 Main", "Dianella", "WA", "6000", "123444", "Microsoft");
            addNewCustomer("7", "Alex", "Smith", "123 Main", "Dianella", "WA", "6000", "123444", "Microsoft");
           
            //add some invoices
            addNewInvoice(customers[0]);
            addNewInvoice(customers[0]);
            addNewInvoice(customers[1]);

            //add some items to the invoices
            addNewInvoiceItem(customers[0].invoices[0], products[0], 2);
            addNewInvoiceItem(customers[0].invoices[0], products[1], 2);
            addNewInvoiceItem(customers[0].invoices[1], products[2], 1);
            addNewInvoiceItem(customers[0].invoices[1], products[3], 2);
            addNewInvoiceItem(customers[1].invoices[0], products[4], 3);
            addNewInvoiceItem(customers[1].invoices[0], products[5], 4);
           
            //set the datasource of the listbox to the arraylist of customers
            lbCustomers.DataSource = getCustData();// customers;
            lbCustomers.DisplayMember = "CustFirstName";
            lbCustomers.ValueMember = "CustNum";

            //stop table columns from generating automatically
            dgInvoiceDetails.AutoGenerateColumns = false;
            //add the columsn to the table
            addColumnstoTable();
            //fill the table with customer details
            fillCustomerDetails();

            fillSearchAutoComplete();

            //set the theme for the form to default
            cboxTheme.ComboBox.SelectedIndex = 0;
            
            
        }

        public void addNewCustomer(string custNum, string custFirstName, string custLastName, string custStreet, string custSuburb, string custState, string custPostCode, string custContactNum, string custCompany)
        {

            customers.Add(new Customer(custNum, custFirstName, custLastName, custStreet, custSuburb, custState, custPostCode, custContactNum, custCompany));
        }

        internal void addNewInvoice(Customer cust)
        {
            
            cust.invoices.Add(new Invoice(getNewInvoiceNum(), DateTime.Today));
            invoiceCount++;
            
        }

        public string getNewInvoiceNum()
        {
            return "INV00" + (invoiceCount + 1);
        }

        internal void addNewInvoiceItem(Invoice inv, Item product, int qty)
        {
            inv.addItem(product, qty);
        }

        private DataTable getCustData()
        {
            DataTable dtCustomers = new DataTable();

            dtCustomers.Columns.Add("CustFirstName");
            dtCustomers.Columns.Add("CustNum");

            foreach (Customer cust in customers)
            {
                var row = dtCustomers.NewRow();
                row["CustFirstName"] = cust.CustFirstName;
                row["CustNum"] = cust.CustNum;
                dtCustomers.Rows.Add(row);
            }

            DataView dv = dtCustomers.DefaultView;
            dv.Sort = "CustFirstName";
            sortedCustomers = dv.ToTable();

            return sortedCustomers;

        }

        private void addColumnstoTable()
        {
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Item Num";
            col1.DataPropertyName = "ItemNum";
            col1.Width = 80;
            col1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns.Add(col1);

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Item";
            col2.DataPropertyName = "ItemName";
            col2.Width = 117;
            dgInvoiceDetails.Columns.Add(col2);

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Description";
            col3.DataPropertyName = "ItemDesc";
            col3.Width = 180;
            dgInvoiceDetails.Columns.Add(col3);

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "Cost";
            col4.DataPropertyName = "ItemCost";
            col4.Width = 80;
            col4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns.Add(col4);

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Qty";
            col5.DataPropertyName = "ItemQty";
            col5.Width = 60;
            col5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns.Add(col5);

            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "Total Cost";
            col6.DataPropertyName = "TotalCost";
            col6.Width = 80;
            col6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns.Add(col6);

            dgInvoiceDetails.ClearSelection();
        }

        private void fillCustomerDetails()
        {
            try
            {

                string custToSearch = lbCustomers.SelectedValue.ToString();
                currentSelectedCustomer = customers.Find(x => x.CustNum == custToSearch);

                if (currentSelectedCustomer != null)
                {
                    txtBoxCustNum.Text = currentSelectedCustomer.CustNum;
                    txtBoxCompany.Text = currentSelectedCustomer.CustCompany;
                    txtBoxFirstName.Text = currentSelectedCustomer.CustFirstName;
                    txtBoxLastName.Text = currentSelectedCustomer.CustLastName;
                    txtBoxStreet.Text = currentSelectedCustomer.CustStreet;
                    txtBoxSuburb.Text = currentSelectedCustomer.CustSuburb;
                    txtBoxState.Text = currentSelectedCustomer.CustState;
                    txtBoxPostCode.Text = currentSelectedCustomer.CustPostCode;
                    txtBoxPhone.Text = currentSelectedCustomer.CustContactNum;

                    fillInvoiceList(currentSelectedCustomer);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void fillInvoiceList(Customer cust)
        {
            lbInvoiceNum.Items.Clear();

            if (cust.invoices.Count > 0)
            {
                //invoice items so enable edit invoice and delete invoice buttons
                btnEditInvoice.Enabled = true;
                btnDeleteInvoice.Enabled = true;

                for (int i = 0; i < cust.invoices.Count; i++)
                {
                    lbInvoiceNum.Items.Add(cust.invoices[i].InvoiceNum);
                }
                lbInvoiceNum.SelectedIndex = 0;
                fillInvoiceDetails(cust);

            }
            else
            {
                dgInvoiceDetails.DataSource = null;
                tbTotalInvoiceCost.Text = string.Empty;
                lblStatus.Text = string.Empty;
                //no invoice items so disable edit invoice and delete invoice buttons
                btnEditInvoice.Enabled = false;
                btnDeleteInvoice.Enabled = false;

            }
        }

        private string getPaymentStatus(Invoice inv)
        {
            string status;

            if (inv.PaidStatus)
            {
                status = "Paid on " + inv.PaymentDate.ToShortDateString();
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                status = "Unpaid. Payment due on " + inv.PaymentDate.ToShortDateString();
                lblStatus.ForeColor = System.Drawing.Color.Red;

            }

            return status;
        }

        private void fillInvoiceDetails(Customer cust)
        {
            try
            {
                invoiceToSearch = lbInvoiceNum.SelectedItem.ToString();
                Invoice theInvoice = cust.invoices.Find(x => x.InvoiceNum == invoiceToSearch);
                List<InvoiceItem> invItems = theInvoice.getItems();


                if (invItems.Count > 0)
                {

                    var source = new BindingSource();
                    source.DataSource = invItems;
                    dgInvoiceDetails.DataSource = source;
                    dgInvoiceDetails.ClearSelection();

                    gbInvoiceDetails.Text = "Invoice Details for " + invoiceToSearch;

                    lblStatus.Text = getPaymentStatus(theInvoice);
                    tbTotalInvoiceCost.Text = "$" + theInvoice.TotalCost.ToString();
                }

                dgInvoiceDetails.Rows[0].Selected = false;
                dgInvoiceDetails.ClearSelection();

            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public string getSelectedInvoiceNum()
        {
            try
            {
                Console.WriteLine("Invoice Num is " + invoiceToSearch);

                //return lbInvoiceNum.SelectedItem.ToString();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return invoiceToSearch;
        }

        //add invoice handler
        private void button1_Click(object sender, EventArgs e)
        {
            InvoiceForm addInvoiceForm = new InvoiceForm();
            addInvoiceForm.FormClosed += new FormClosedEventHandler(addInvoiceForm_FormClosed);
            addInvoiceForm.parent = this;
            addInvoiceForm.purpose = (sender as Button).Text;
            addInvoiceForm.ShowDialog();
            //addInvoice.ShowDialog(this);
        }

        //actions to do after Invoice dialog closes from adding new invoice
        void addInvoiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //refresh the data
            fillCustomerDetails();
            //add invoice to the list for autocomplete search
            fillSearchAutoComplete();
            //set the selection to the newly created invoice number so its details are displayed
            lbInvoiceNum.SetSelected(lbInvoiceNum.Items.Count - 1, true);

        }

        //actions to do after Invoice dialog closes from editing existing invoice
        void editInvoiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //refresh the data
            fillCustomerDetails();

            lbInvoiceNum.SetSelected(invoiceNumThatWasEdited, true);


        }

        private void lbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear any searches in the invoice search text box
            txtBoxInvSearch.Text = string.Empty;
            fillCustomerDetails();
           
        }

        private void lbInvoiceNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear any searches in the invoice search text box
            txtBoxInvSearch.Text = string.Empty;
            fillInvoiceDetails(currentSelectedCustomer);

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dvCustomers = sortedCustomers.DefaultView;
            dvCustomers.RowFilter = "CustFirstName LIKE '" + tbSearch.Text + "%'";
            fillCustomerDetails();
        }

        //edit invoice handler
        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            InvoiceForm editInvoiceForm = new InvoiceForm();
            editInvoiceForm.FormClosed += new FormClosedEventHandler(editInvoiceForm_FormClosed);
            //editInvoiceForm.ShowDialog(this);
            editInvoiceForm.parent = this;
            editInvoiceForm.purpose = (sender as Button).Text;

            invoiceNumThatWasEdited = lbInvoiceNum.SelectedIndex;
            // Console.WriteLine((sender as Button).Text);
            editInvoiceForm.ShowDialog();
        }
       

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            DialogResult deleteConfirm = MessageBox.Show("Are you sure you want to delete invoice " + lbInvoiceNum.SelectedItem + "?",
                                                    "Delete Confirmation",
                                                    MessageBoxButtons.YesNo);
            if (deleteConfirm == DialogResult.Yes)
            {
                //do the delete
                //first find the invoice object for the currently selected customer
                invoiceToSearch = lbInvoiceNum.SelectedItem.ToString();
                Invoice theInvoice = currentSelectedCustomer.invoices.Find(x => x.InvoiceNum == invoiceToSearch);

                currentSelectedCustomer.invoices.Remove(theInvoice);
                fillCustomerDetails();
                if (lbInvoiceNum.Items.Count != 0)
                {
                    lbInvoiceNum.SetSelected(0, true);
                }

            }
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm addCustForm = new CustomerForm();
            addCustForm.FormClosed += new FormClosedEventHandler(addCustForm_FormClosed);
            addCustForm.parent = this;
            addCustForm.purpose = "Add";
            addCustForm.ShowDialog();
        }

        //actions to do after Customers dialog closes from adding a new customer
        void addCustForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            lbCustomers.DataSource = getCustData();
            //refresh the data
            fillCustomerDetails();

        }

        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult deleteConfirm = MessageBox.Show("Are you sure you want to delete customer " + currentSelectedCustomer.CustFirstName + "?",
                                                   "Delete Confirmation",
                                                   MessageBoxButtons.YesNo);
            if (deleteConfirm == DialogResult.Yes)
            {
                customers.Remove(currentSelectedCustomer);
                lbCustomers.DataSource = getCustData();
                fillCustomerDetails();
            }
            
            
        }


        //handes File-Exit action
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void editCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm editCustForm = new CustomerForm();
            editCustForm.FormClosed += new FormClosedEventHandler(addCustForm_FormClosed);
            editCustForm.parent = this;
            editCustForm.purpose = "Edit";
            editCustForm.ShowDialog();
        
        }

        private void txtBoxInvSearch_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Search clicked");
        }

        private void txtBoxInvSearch_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Search box changed");
        }
        //search for invoice handler
        private void btnSearch_Click(object sender, EventArgs e)
        {
            findInvoice(txtBoxInvSearch.Text);
        }

        private void findInvoice(string invoiceNum)
        {
            bool found = false;
            //find the customer the invoice belongs to
            foreach (var cust in customers)
            {
                foreach (var inv in cust.invoices)
                {
                    if (inv.InvoiceNum.Equals(invoiceNum))
                    {
                        //Console.WriteLine("Invoice found for customer " + cust.CustFirstName);
                        found = true;
                        lbCustomers.SelectedValue = cust.CustNum;
                        lbInvoiceNum.SelectedItem = invoiceNum.ToString();
                        break;
                    }                    
                }
            }

            if (!found)            
            {
                MessageBox.Show("No results for invoice number: " + invoiceNum);
                //clear any searches in the invoice search text box
                txtBoxInvSearch.Text = string.Empty;
            }

        }

        private void fillSearchAutoComplete()
        {
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            foreach (var cust in customers)
            {
                foreach (var inv in cust.invoices)
                {
                    collection.Add(inv.InvoiceNum);
                }

            }
            txtBoxInvSearch.AutoCompleteCustomSource = collection;
        }

      

        private void cboxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            //string theme = cboxTheme.ComboBox.SelectedValue.ToString();

            string theme = cboxTheme.ComboBox.GetItemText(cboxTheme.ComboBox.SelectedItem);

            switch (theme)
            {
                case "Light":
                    Image lightImage = new Bitmap(UIAssignment2.Properties.Resources.light);
                    this.BackgroundImage = lightImage;
                    break;
                case "Dark":
                    //Image darkImage = new Bitmap(@"E:\TAFE\UI\Assignments\Assignment 2\Assignment 2 Git\dark.jpg");
                    Image darkImage = new Bitmap(UIAssignment2.Properties.Resources.dark);
                    this.BackgroundImage = darkImage;
                    //gBoxCustomerDetails.BackgroundImage = darkImage;
                    //gBoxCustomerDetails.ForeColor = Color.Salmon;
                    break;
                default:                    
                    this.BackgroundImage = null;
                    break;
            }
           
        }
    }
}
