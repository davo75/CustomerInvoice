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
            c1.invoices[0] = new Invoice("INV001", DateTime.Today);
            c1.invoices[0].addItem(new Item(1, "Mouse", "Wireless Mouse", 14.99m, 2));
            c1.invoices[0].addItem(new Item(2, "Macbook Pro", "i7 8Gb RAM 15-inch", 1450.00m, 1));

            Customer c2 = new Customer("002",
                                       "Lena", "Funtseva",
                                       "123 Flinders Ave", "Mirrabooka", "WA", "6061",
                                       "0478221847",
                                       "Russki");

            c2.invoices[0] = new Invoice("INV002", DateTime.Today);
            c2.invoices[0].addItem(new Item(1, "Keyboard", "Wireless Keyboard", 34.99m, 1));
            c2.invoices[0].addItem(new Item(2, "USB Drive", "SanDisk 16GB", 59.00m, 2));


            customers.Add(c1);
            customers.Add(c2);

            //set the datasource of the listbox to the arraylist of customers
            lbCustomers.DataSource = customers;
            lbCustomers.DisplayMember = "CustFirstName"; 
            lbCustomers.ValueMember = "CustNum";

            fillCustomerDetails();
            
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

            if (cust.InvoiceCount > 0)
            {
                for (int i = 0; i < cust.InvoiceCount; i++)
                {
                    lbInvoiceNum.Items.Add(cust.invoices[i].InvoiceNum);
                }

                fillInvoiceDetails(cust);
            }


            
        }

        private void fillInvoiceDetails(Customer cust)
        {
            try
            {
                string invoiceToSearch = lbInvoiceNum.SelectedItem.ToString();
                string text = "";

                for (int i = 0; i < cust.InvoiceCount; i++)
                {
                    if (cust.invoices[i].InvoiceNum.Equals(invoiceToSearch))
                    {
                        List<Item> invItems = cust.invoices[i].getItems();

                        foreach (Item item in invItems)
                        {
                            text += item.ItemNum + "\t" + item.ItemName + "\t" + item.ItemDesc + "\t" + item.Qty + "\t" + item.ItemCost + "\n";
                        }

                        richInvoiceDetails.Text = text;
                    }
                }
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
    }
}
