/// <summary>
/// Displays the main form used for viewing customers and invoices.
/// <sumary>
/// <remarks>
/// author: David Pyle 041110777
/// version: 1.0
/// date: 25/4/2016
/// </remarks>

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
        /// <summary>
        /// List of customers
        /// </summary>
        internal Customer[] customers;
        /// <summary>
        /// Maximum number of customers
        /// </summary>
        private const int NUM_CUSTOMERS = 20;
        /// <summary>
        /// List of products
        /// </summary>
        internal List<Item> products;
        /// <summary>
        /// Current selected customer from customer list
        /// </summary>
        internal Customer currentSelectedCustomer;
        /// <summary>
        /// List of customers sorted by first name
        /// </summary>
        private DataTable sortedCustomers;
        /// <summary>
        /// Invoice to search
        /// </summary>
        private string invoiceToSearch;
        /// <summary>
        /// Invoice number that was edited
        /// </summary>
        private int invoiceNumThatWasEdited;
        /// <summary>
        /// A count of the current number of invoices
        /// </summary>
        private int invoiceCount;
        /// <summary>
        /// A count of the current number of customers
        /// </summary>
        private int customerCount;

        /// <summary>
        /// Current name of selected theme
        /// </summary>
        internal string theme;

        /// <summary>
        /// Constructor initialises the UI components of the main form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            //create customer list
            customers = new Customer[NUM_CUSTOMERS];
            //add test date for application to use
            addTestData();
            //set up initial state of form
            setupInitialState();
        }

        /// <summary>
        /// Current count of invoices
        /// </summary>
        public int InvoiceCount
        {
            get { return invoiceCount; }
            set { invoiceCount = value; }
        }

        /// <summary>
        /// Invoice number to search for
        /// </summary>
        public string InvoiceToSearch
        {
            get { return invoiceToSearch; }
            set { invoiceToSearch = value; }
        }

        /// <summary>
        /// Adds test data for the application to load when starting
        /// </summary>
        public void addTestData()
        {           
            //initilaise invoice and customer count
            invoiceCount = 0;
            customerCount = 0;

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
            addNewInvoice(customers[3]);
            addNewInvoice(customers[4]);            
            addNewInvoice(customers[5]);
            addNewInvoice(customers[6]);
            
            //add some items to the invoices
            addNewInvoiceItem(customers[0].invoices[0], products[0], 2);
            addNewInvoiceItem(customers[0].invoices[0], products[1], 2);
            addNewInvoiceItem(customers[0].invoices[1], products[2], 1);
            addNewInvoiceItem(customers[0].invoices[1], products[3], 2);
            addNewInvoiceItem(customers[1].invoices[0], products[4], 3);
            addNewInvoiceItem(customers[1].invoices[0], products[5], 4);
            addNewInvoiceItem(customers[3].invoices[0], products[1], 1);
            addNewInvoiceItem(customers[3].invoices[0], products[5], 1);
            addNewInvoiceItem(customers[4].invoices[0], products[0], 2);
            addNewInvoiceItem(customers[4].invoices[0], products[1], 2);
            addNewInvoiceItem(customers[4].invoices[0], products[2], 1);
            addNewInvoiceItem(customers[5].invoices[0], products[3], 2);
            addNewInvoiceItem(customers[5].invoices[0], products[5], 1);
            addNewInvoiceItem(customers[6].invoices[0], products[2], 1);            
        }

        /// <summary>
        /// Sets the inital state of the main form once loaded
        /// </summary>
        /// <remarks>
        /// Sets up the customer and invoice list boxes with the first item selected in each list.
        /// Fills in the customer and invoice details and initialises the theme to default.</remarks>
        /// 
        private void setupInitialState()
        {
            //set the datasource of the listbox to the arraylist of customers
            lbCustomers.DataSource = getCustData();// customers;
            lbCustomers.DisplayMember = "CustFirstName";
            lbCustomers.ValueMember = "CustNum";

            //stop table columns from generating automatically
            dgInvoiceDetails.AutoGenerateColumns = false;
            dgInvoiceDetails.RowHeadersVisible = false;
            //add the columsn to the table
            addColumnstoTable();
            //fill the table with customer details
            fillCustomerDetails();
            //initialise search for auto complete on customer filter
            fillSearchAutoComplete();

            //set the theme for the form to default
            cboxTheme.ComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Adds a new customer
        /// </summary>
        /// <param name="custNum">Customer numnber</param>
        /// <param name="custFirstName">Customer first name</param>
        /// <param name="custLastName">Customer last name</param>
        /// <param name="custStreet">Customer street address</param>
        /// <param name="custSuburb">Customer suburb</param>
        /// <param name="custState">Customer state</param>
        /// <param name="custPostCode">Customer post code</param>
        /// <param name="custContactNum">Customer contact number</param>
        /// <param name="custCompany">Customer company</param>
        public void addNewCustomer(string custNum, string custFirstName, string custLastName, string custStreet, string custSuburb, string custState, string custPostCode, string custContactNum, string custCompany)
        {
            //add customer
            customers[customerCount] = new Customer(custNum, custFirstName, custLastName, custStreet, custSuburb, custState, custPostCode, custContactNum, custCompany);
            //increment customer count
            customerCount++;
        }

        /// <summary>
        /// Adds a new invoice for a customer
        /// </summary>
        /// <param name="cust">Customer to add invoice for</param>
        internal void addNewInvoice(Customer cust)
        {
            //add the invoice for the customer
            cust.addInvoice(new Invoice(getNewInvoiceNum(), DateTime.Today));
            //increment the invoice count
            invoiceCount++;
            
        }

        /// <summary>
        /// Find a customer by customer number
        /// </summary>
        /// <param name="custNum">Customer number to search for</param>
        /// <returns>If found returns the Customer else returns null</returns>
        internal Customer findCustomer(string custNum)
        {
            bool found = false;
            int index = -1;
            //search customers
            for (int i = 0; i < customerCount; i++)
            {
                //if customer number match
                if (customers[i].CustNum.Equals(custNum))
                {
                    //set found flag to true
                    found = true;
                    //set index position
                    index = i;
                    break;
                }
            }
            //return customer if found else return null
            if (found)
            {
                return customers[index];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Remove customer from customer lists
        /// </summary>
        /// <param name="custToDelete">Customer to remove</param>
        internal void removeCustomer(Customer custToDelete)
        {
            //convert array to list
            List<Customer> list = customers.ToList<Customer>();
            //remove the customer
            list.Remove(custToDelete);
            //convert list back to array
            customers = list.ToArray();
            //decrement customer count
            customerCount--;
        }

        /// <summary>
        /// Get a new customer number
        /// </summary>
        /// <returns>New customer number</returns>
        public string getNewCustNum()
        {
            return (customerCount + 1).ToString();
        }

        /// <summary>
        /// Get a new invoice number
        /// </summary>
        /// <returns>New invoice number</returns>
        public string getNewInvoiceNum()
        {
            return "INV00" + (invoiceCount + 1);
        }

        /// <summary>
        /// Adds a new invoice item and quantity
        /// </summary>
        /// <param name="inv">Invoice to add item to</param>
        /// <param name="product">Item to add</param>
        /// <param name="qty">Item quantity</param>
        internal void addNewInvoiceItem(Invoice inv, Item product, int qty)
        {
            inv.addItem(product, qty);
        }

        /// <summary>
        /// Generates a table of customer first names
        /// </summary>
        /// <returns>Table of customer first names</returns>
        private DataTable getCustData()
        {
            //create new data table to store customer first names
            DataTable dtCustomers = new DataTable();

            //add the columns
            dtCustomers.Columns.Add("CustFirstName");
            dtCustomers.Columns.Add("CustNum");

            //go through all customers
            foreach (Customer cust in customers)
            {
                //if a customer exists
                if (cust != null)
                {
                    //add a new row to the table (first name and customer number)
                    var row = dtCustomers.NewRow();
                    row["CustFirstName"] = cust.CustFirstName;
                    row["CustNum"] = cust.CustNum;
                    dtCustomers.Rows.Add(row);
                }
            }
            //sort the table by first name
            DataView dv = dtCustomers.DefaultView;
            dv.Sort = "CustFirstName";
            sortedCustomers = dv.ToTable();

            //reurn the sorted table
            return sortedCustomers;
        }

        /// <summary>
        /// Add column headers to Invoice details table
        /// </summary>
        private void addColumnstoTable()
        {
            //add Item number column
            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Item Num";
            col1.DataPropertyName = "ItemNum";
            col1.Width = 80;
            col1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns.Add(col1);

            //add item name column
            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Item";
            col2.DataPropertyName = "ItemName";
            col2.Width = 117;
            dgInvoiceDetails.Columns.Add(col2);

            //add item description column
            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Description";
            col3.DataPropertyName = "ItemDesc";
            col3.Width = 200;
            dgInvoiceDetails.Columns.Add(col3);

            //add item cost column
            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "Cost";
            col4.DataPropertyName = "ItemCost";
            col4.Width = 90;
            col4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns.Add(col4);

            //add item quantity column
            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Qty";
            col5.DataPropertyName = "ItemQty";
            col5.Width = 60;
            col5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns.Add(col5);

            //add item total cost colum
            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "Total Cost";
            col6.DataPropertyName = "TotalCost";
            col6.Width = 90;
            col6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceDetails.Columns.Add(col6);

            //clear any default table selections
            dgInvoiceDetails.ClearSelection();
        }


        /// <summary>
        /// Populates the customer details on the main form
        /// </summary>
        private void fillCustomerDetails()
        {
            try
            {
                //search for the customer name form the customer list
                string custToSearch = lbCustomers.SelectedValue.ToString();
                //set the current selected customer 
                currentSelectedCustomer = findCustomer(custToSearch);

                //if customer exits populate the customer detail fields
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
                    //add any associated invoice numbers to the invoice list
                    fillInvoiceList(currentSelectedCustomer);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Populates the invoice list with invoice numbers associated with the customer 
        /// </summary>
        /// <param name="cust">The customer that the invoices belong to</param>
        private void fillInvoiceList(Customer cust)
        {
            //clear the list from any leftover items
            lbInvoiceNum.Items.Clear();

            //if the customer has invocies
            if (cust.InvoiceCounter > 0)
            {
                //invoice items so enable edit invoice and delete invoice buttons
                btnEditInvoice.Enabled = true;
                btnDeleteInvoice.Enabled = true;

                //add the invoice numbers to the list for the customer
                for (int i = 0; i < cust.InvoiceCounter; i++)
                {
                    lbInvoiceNum.Items.Add(cust.invoices[i].InvoiceNum);
                }
                //select the first item in the list
                lbInvoiceNum.SelectedIndex = 0;
                //populate the invoice details table with details for the selected invoice number in the list
                fillInvoiceDetails(cust);
            }
            //if customer has no invoices
            else
            {
                //reset data source for invoice details table
                dgInvoiceDetails.DataSource = null;
                //reset invoice cost field
                tbTotalInvoiceCost.Text = string.Empty;
                //reset payment status field
                lblStatus.Text = string.Empty;
                //no invoice items so disable edit invoice and delete invoice buttons
                btnEditInvoice.Enabled = false;
                btnDeleteInvoice.Enabled = false;
            }
        }

        /// <summary>
        /// Get the payment status of an invoice
        /// </summary>
        /// <param name="inv">The invoice to get the payment status for</param>
        /// <returns>Payment status message</returns>
        private string getPaymentStatus(Invoice inv)
        {
            //status message
            string status;

            //if invoice paid
            if (inv.PaidStatus)
            {
                //construct paid message
                status = "Paid on " + inv.PaymentDate.ToString("dd/MM/yyyy");
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                //construct unpaid message
                status = "Unpaid. Payment due on " + inv.PaymentDate.ToString("dd/MM/yyyy");
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            //return the payment status message
            return status;
        }
        
        /// <summary>
        /// Populate the invoice details table
        /// </summary>
        /// <param name="cust">The customer who the invocie is associated with</param>
        private void fillInvoiceDetails(Customer cust)
        {
            try
            {
                //get the current selected invoice number
                invoiceToSearch = lbInvoiceNum.SelectedItem.ToString();
                //find the invoice
                Invoice theInvoice = cust.findInvoice(invoiceToSearch);
                //get the items on the invoice
                List<InvoiceItem> invItems = theInvoice.getItems();
                
                //if there are items on the invoice
                if (invItems.Count > 0)
                {
                    //set the data source for the invoice details table
                    var source = new BindingSource();
                    source.DataSource = invItems;
                    dgInvoiceDetails.DataSource = source;
                    dgInvoiceDetails.ClearSelection();

                    //set the title of the invoice details group box
                    gbInvoiceDetails.Text = "Invoice Details for " + invoiceToSearch;
                    //set the payment status
                    lblStatus.Text = getPaymentStatus(theInvoice);
                    //set the invoice total 
                    tbTotalInvoiceCost.Text = "$" + (theInvoice.TotalCost).ToString("#.00");
                }
                //deselect any default selections on table
                dgInvoiceDetails.Rows[0].Selected = false;
                dgInvoiceDetails.ClearSelection();

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Gets the current selected invoice number in the invoices list
        /// </summary>
        /// <returns>The invoice number currently selected</returns>
        public string getSelectedInvoiceNum()
        {
            try
            {
                Console.WriteLine("Invoice Num is " + invoiceToSearch);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return invoiceToSearch;
        }

        /// <summary>
        /// Displays the Add Invoice form.
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void button1_Click(object sender, EventArgs e)
        {
            //create an instance of the invoice form
            InvoiceForm addInvoiceForm = new InvoiceForm();
            //add a form closed handler
            addInvoiceForm.FormClosed += new FormClosedEventHandler(addInvoiceForm_FormClosed);
            //set reference to the parent form
            addInvoiceForm.parent = this;
            //set the purpose of the form - either add or edit
            addInvoiceForm.purpose = (sender as Button).Text;
            //show the invoice form
            addInvoiceForm.ShowDialog();            
        }

        /// <summary>
        /// Refreshes main form display once the invoice form has closed after adding a new invoice.
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        void addInvoiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //refresh the customer details data
            fillCustomerDetails();
            //add invoice to the list for autocomplete search
            fillSearchAutoComplete();
            //set the selection to the newly created invoice number so its details are displayed
            if (lbInvoiceNum.Items.Count > 0)
            {
                lbInvoiceNum.SetSelected(lbInvoiceNum.Items.Count - 1, true);
            }
        }

        /// <summary>
        /// Refreshes main form display once the invoice form has closed after editing an invoice.
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        void editInvoiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //refresh the customer details data
            fillCustomerDetails();
            //select the invoice number that was just edited
            lbInvoiceNum.SetSelected(invoiceNumThatWasEdited, true);
        }

        /// <summary>
        /// Clears any text in the customer filter search input
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void lbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear any searches in the invoice search text box
            txtBoxInvSearch.Text = string.Empty;
            //refesh the customer detials
            fillCustomerDetails();           
        }

        /// <summary>
        /// Clears any text in the invoices search field
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void lbInvoiceNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear any searches in the invoice search text box
            txtBoxInvSearch.Text = string.Empty;
            //refesh the invoice detials
            fillInvoiceDetails(currentSelectedCustomer);
        }

        /// <summary>
        /// Filters the customer list based on the text enterted into the filter search field
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            //set the view
            DataView dvCustomers = sortedCustomers.DefaultView;
            //filter teh customer list
            dvCustomers.RowFilter = "CustFirstName LIKE '" + tbSearchCust.Text + "%'";
            //refresh customer details
            fillCustomerDetails();
        }

        /// <summary>
        /// Displays the Edit Invoice form
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            //create new instance of invoice form
            InvoiceForm editInvoiceForm = new InvoiceForm();
            //add form closed handler
            editInvoiceForm.FormClosed += new FormClosedEventHandler(editInvoiceForm_FormClosed);
            //set reference to parent form
            editInvoiceForm.parent = this;
            //set the purpose of the form - either add or edit
            editInvoiceForm.purpose = (sender as Button).Text;
            //set the invoice number that will be edited
            invoiceNumThatWasEdited = lbInvoiceNum.SelectedIndex;
            //show the invoice form for editing
            editInvoiceForm.ShowDialog();
        }
       
        /// <summary>
        /// Deletes an invoice
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            //confirmation delete message dialog
            DialogResult deleteConfirm = MessageBox.Show("Are you sure you want to delete invoice " + lbInvoiceNum.SelectedItem + "?",
                                                    "Delete Confirmation",
                                                    MessageBoxButtons.YesNo);
            //if deletion confirmed
            if (deleteConfirm == DialogResult.Yes)
            {
                //do the delete
                //first find the invoice object for the currently selected customer
                invoiceToSearch = lbInvoiceNum.SelectedItem.ToString();
                Invoice theInvoice = currentSelectedCustomer.findInvoice(invoiceToSearch);
                currentSelectedCustomer.removeInvoice(theInvoice);
                //update the search autocomplete
                fillSearchAutoComplete();
                //refesh the customer details after deletion
                fillCustomerDetails();
                if (lbInvoiceNum.Items.Count != 0)
                {
                    lbInvoiceNum.SetSelected(0, true);
                }
            }
        }

        /// <summary>
        /// Handles the add customer menu item click
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           showNewCustomerForm();
        }

        private void showNewCustomerForm() {
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
            //select the newly created customer in the customer list box
            lbCustomers.SelectedValue = customers[customerCount-1].CustNum;
        }

        /// <summary>
        /// Handles delete customer menu item click
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void deleteCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteCustomer();            
        }

        /// <summary>
        /// Deletes a customer
        /// </summary>
        private void deleteCustomer()
        {
            //show confirmation delete message dialog
            DialogResult deleteConfirm = MessageBox.Show("Are you sure you want to delete customer " + currentSelectedCustomer.CustFirstName + "?",
                                                   "Delete Confirmation",
                                                   MessageBoxButtons.YesNo);
           //if deletion confirmed
            if (deleteConfirm == DialogResult.Yes)
            {
                //remove customer
                removeCustomer(currentSelectedCustomer);
                //update the search autocomplete
                fillSearchAutoComplete();
                //refresh customer data source
                lbCustomers.DataSource = getCustData();
                //refresh the customer details
                fillCustomerDetails();
            }
        }


        /// <summary>
        /// Exits the application
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles edit customer menu item  click
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void editCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showEditCustomerForm();        
        }

        /// <summary>
        /// Displays edit customer form
        /// </summary>
        private void showEditCustomerForm()
        {
            //create a new instance of the customer form
            CustomerForm editCustForm = new CustomerForm();
            //add a form closed handler
            editCustForm.FormClosed += new FormClosedEventHandler(addCustForm_FormClosed);
            //set reference to parent form
            editCustForm.parent = this;
            //set purpose of form to edit
            editCustForm.purpose = "Edit";
            //show the form
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
        
        /// <summary>
        /// Handles invoice search button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            findInvoice(txtBoxInvSearch.Text);
        }

        /// <summary>
        /// Finds an invoice by invoice number and sets selection on customer and invoice lists.
        /// If not found a message box is displayed informain user of no search results.
        /// </summary>
        /// <param name="invoiceNum">The invoice number ot search for</param>
        private void findInvoice(string invoiceNum)
        {
            //flag if invoice found or not
            bool found = false;

            try
            {
                //find the customer the invoice belongs to
                for (int i = 0; i < customerCount; i++)
                {
                    //go through the customer's invoices
                    for (int j = 0; j < customers[i].InvoiceCounter; j++)
                    {
                        //if invoice number matches
                        if (customers[i].invoices[j].InvoiceNum.Equals(invoiceNum))
                        {
                            //set found flag
                            found = true;
                            //select customer in customer list
                            lbCustomers.SelectedValue = customers[i].CustNum;
                            //select invoice number in list
                            lbInvoiceNum.SelectedItem = invoiceNum.ToString();
                            break;
                        }
                    }
                    //stop searchng if invoice found
                    if (found)
                    {
                        break;
                    }
                }
                //show message dialog if invoice not found
                if (!found)
                {
                    MessageBox.Show("No results for invoice number: " + invoiceNum, "Search Results");
                    //clear any searches in the invoice search text box
                    txtBoxInvSearch.Text = string.Empty;
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Can't find it! " + ex.Message);
            }
        }

        /// <summary>
        /// Displays pop-up list of invoice numbers when searching for invoices
        /// </summary>
        private void fillSearchAutoComplete()
        {
            //create new collection for invoice numbers
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            //for each customer
            foreach (var cust in customers)
            {
                //if the customer exists
                if (cust != null)
                {
                    //go through the customer's invoices
                    foreach (var inv in cust.invoices)
                    {
                        if (inv != null)
                        {
                            //add the invoice number to the pop-up list
                            collection.Add(inv.InvoiceNum);
                        }

                    }
                }

            }
            //add the pop-up list to the search field so it is displayed when a search is performed
            txtBoxInvSearch.AutoCompleteCustomSource = collection;
        }
        
        /// <summary>
        /// Changes the interface theme
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void cboxTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            //name of theme currently selected
            theme = cboxTheme.ComboBox.GetItemText(cboxTheme.ComboBox.SelectedItem);

            switch (theme)
            {
                case "Light":
                    //settings for light theme
                    Image lightImage = new Bitmap(UIAssignment2.Properties.Resources.light);
                    this.BackgroundImage = lightImage;
                    //Customer List Box
                    gBoxCustomers.ForeColor = Color.White;
                    gBoxCustomers.BackColor = Color.Transparent;
                    //Customer Details Box
                    gBoxCustomerDetails.ForeColor = Color.White;
                    gBoxCustomerDetails.BackColor = Color.Transparent;
                    //Invoice List Box
                    gBoxInvoices.ForeColor = Color.White;
                    gBoxInvoices.BackColor = Color.Transparent;
                    //Invoice Details Box
                    gbInvoiceDetails.ForeColor = Color.White;
                    gbInvoiceDetails.BackColor = Color.Transparent;

                    dgInvoiceDetails.ForeColor = Color.Black;
                    //Menu Strip
                    msFile.ForeColor = Color.White;
                    msFile.BackColor = Color.Transparent;                  
                    break;
                case "Dark":
                    //settings for dark theme
                    Image darkImage = new Bitmap(UIAssignment2.Properties.Resources.dark);
                    this.BackgroundImage = darkImage;
                    //Customer List Box
                    gBoxCustomers.ForeColor = Color.White;
                    gBoxCustomers.BackColor = Color.Transparent;
                    //Customer Details Box
                    gBoxCustomerDetails.ForeColor = Color.White;
                    gBoxCustomerDetails.BackColor = Color.Transparent;
                    //Invoice List Box
                    gBoxInvoices.ForeColor = Color.White;
                    gBoxInvoices.BackColor = Color.Transparent;
                    //Invoice Details Box
                    gbInvoiceDetails.ForeColor = Color.White;
                    gbInvoiceDetails.BackColor = Color.Transparent;

                    dgInvoiceDetails.ForeColor = Color.Black;
                    //Menu Strip
                    msFile.ForeColor = Color.White;
                    msFile.BackColor = Color.Transparent;
                    break;

                default:   
                    //settings for default theme
                    this.BackgroundImage = null;
                    //Customer List Box
                    gBoxCustomers.ForeColor = SystemColors.ControlText;
                    gBoxCustomers.BackColor = SystemColors.Control;
                    //Customer Details Box
                    gBoxCustomerDetails.ForeColor = SystemColors.ControlText;
                    gBoxCustomerDetails.BackColor = SystemColors.Control;
                    //Invoice List Box
                    gBoxInvoices.ForeColor = SystemColors.ControlText;
                    gBoxInvoices.BackColor = SystemColors.Control;
                    //Invoice Details Box
                    gbInvoiceDetails.ForeColor = SystemColors.ControlText;
                    gbInvoiceDetails.BackColor = SystemColors.Control;
                    //Menu Strip
                    msFile.ForeColor = SystemColors.ControlText;        
                    msFile.BackColor = SystemColors.Control;
                    //Tool Strip
                    tsMain.ForeColor = SystemColors.ControlText;
                    tsMain.BackColor = Color.Gainsboro;
                    //search button on tool strip
                    btnSearch.ForeColor = SystemColors.ControlText;
                    btnSearch.BackColor = SystemColors.Control;
                    break;
            }           
        }

        /// <summary>
        /// Handles add new customer button click by opening blank customer form
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btnAddCust_Click(object sender, EventArgs e)
        {
            showNewCustomerForm();
        }

        /// <summary>
        /// Handles edit customer button click by opening customer form
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btnEditCust_Click(object sender, EventArgs e)
        {
            showEditCustomerForm();
        }

        /// <summary>
        /// Handles delete customer button click
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void btnDeleteCust_Click(object sender, EventArgs e)
        {
            deleteCustomer();
        }
    }
}
