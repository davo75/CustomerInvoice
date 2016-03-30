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
        private List<Customer> customers;
        public CustomerForm()
        {
            InitializeComponent();
            customers = new List<Customer>();
            addTestData();
        }


        public void addTestData()
        {

            Customer c1 = new Customer("001",
                                        "Dave", "Pyle",
                                        "349 Grand Prom", "Dianella", "WA", "6059",
                                        "0478220117",
                                        "Intekka");
            c1.invoices.Add(new Invoice("INV001", DateTime.Today));
            c1.invoices[0].addItem(new Item(1, "Mouse", "Wireless Mouse", 14.99m, 2));
            c1.invoices[0].addItem(new Item(2, "Macbook Pro", "i7 8Gb RAM 15-inch", 1450.00m, 1));

            c1.invoices.Add(new Invoice("INV002", DateTime.Today));
            c1.invoices[1].addItem(new Item(1, "Monitor", "DELL 16:9 24inch", 350.00m, 2));
            c1.invoices[1].addItem(new Item(2, "Dock", "3xUSB HDMI", 200.00m, 2));
            c1.invoices[1].PaidStatus = true;

            Customer c2 = new Customer("002",
                                       "Lena", "Funtseva",
                                       "123 Flinders Ave", "Mirrabooka", "WA", "6061",
                                       "0478221847",
                                       "Russki");

            c2.invoices.Add(new Invoice("INV003", DateTime.Today));
            c2.invoices[0].addItem(new Item(1, "Keyboard", "Wireless Keyboard", 34.99m, 1));
            c2.invoices[0].addItem(new Item(2, "USB Drive", "SanDisk 16GB", 59.00m, 2));

            Customer c3 = new Customer("003",
                                      "Tom", "Butler",
                                      "4 Mill Lane", "East Perth", "WA", "6061",
                                      "1512281438",
                                      "Red Cross");


            customers.Add(c1);
            customers.Add(c2);
            customers.Add(c3);

            //set the datasource of the listbox to the arraylist of customers
            lbCustomers.DataSource = getCustData();// customers;
            lbCustomers.DisplayMember = "CustFirstName"; 
            lbCustomers.ValueMember = "CustNum";



            dgInvoiceDetails.AutoGenerateColumns = false;

            addColumnstoTable();
            
            fillCustomerDetails();

            
            
        }

        private DataTable dtCustomers;
        private DataTable getCustData()
        {
            dtCustomers = new DataTable();
            
            dtCustomers.Columns.Add("CustFirstName");
            dtCustomers.Columns.Add("CustNum");

            foreach (Customer cust in customers)
            {
                var row = dtCustomers.NewRow();
                row["CustFirstName"] = cust.CustFirstName;
                row["CustNum"] = cust.CustNum;
                dtCustomers.Rows.Add(row);
            }

           

            return dtCustomers;

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
            col2.HeaderText = "Name";
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


        Customer currentSelectedCustomer;

        private void fillCustomerDetails()
        {
            string custToSearch = lbCustomers.SelectedValue.ToString();
            currentSelectedCustomer = customers.Find(x => x.CustNum == custToSearch);

            if (currentSelectedCustomer != null)
            {
                txtBoxCustNum.Text = currentSelectedCustomer.CustNum;
                txtBoxFirstName.Text = currentSelectedCustomer.CustFirstName;
                txtBoxLastName.Text = currentSelectedCustomer.CustLastName;
                txtBoxStreet.Text = currentSelectedCustomer.CustStreet;
                txtBoxSuburb.Text = currentSelectedCustomer.CustSuburb;
                comBoxState.Text = currentSelectedCustomer.CustState;
                txtBoxPostCode.Text = currentSelectedCustomer.CustPostCode;
                txtBoxPhone.Text = currentSelectedCustomer.CustContactNum;

                fillInvoiceList(currentSelectedCustomer);
            }

        }

        private void fillInvoiceList(Customer cust)
        {
            lbInvoiceNum.Items.Clear();

            if (cust.invoices.Count > 0)
            {
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
                tbTotalInvoiceCost.Text = "";
                
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
                string invoiceToSearch = lbInvoiceNum.SelectedItem.ToString();
                Invoice theInvoice = cust.invoices.Find(x => x.InvoiceNum == invoiceToSearch);               
                List<Item> invItems = theInvoice.getItems();

                if (invItems.Count > 0)
                {
                    var source = new BindingSource();
                    source.DataSource = invItems;                    
                    dgInvoiceDetails.DataSource = source;
                    dgInvoiceDetails.ClearSelection();

                    gbInvoiceDetails.Text = "Invoice Details for " + invoiceToSearch;

                    lblStatus.Text = getPaymentStatus(theInvoice);
                    tbTotalInvoiceCost.Text = theInvoice.TotalCost.ToString();
                }
                dgInvoiceDetails.Rows[0].Selected = false;
                dgInvoiceDetails.ClearSelection();                            

            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            InvoiceForm addInvoice = new InvoiceForm();
            addInvoice.parent = this;
            addInvoice.ShowDialog();
        }

        private void lbCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillCustomerDetails();
        }

        private void lbInvoiceNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillInvoiceDetails(currentSelectedCustomer);

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dvCustomers = dtCustomers.DefaultView;
            dvCustomers.RowFilter = "CustFirstName LIKE '%" + tbSearch.Text + "%'";
            fillCustomerDetails();
        }

       
    }
}
