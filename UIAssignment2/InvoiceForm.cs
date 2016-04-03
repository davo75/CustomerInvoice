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
    public partial class InvoiceForm : Form
    {

        public MainForm parent;
        public string purpose; //add or edit

        private DataGridViewTextBoxColumn itemDescCol;
        private DataGridViewComboBoxColumn itemNumCbox;
        private DataGridViewTextBoxColumn itemCostCol;
        private DataGridViewTextBoxColumn itemQtyCol;
        private DataGridViewTextBoxColumn itemTotalCostCol;
        private decimal invoiceTotal; //total of invoice when adding a new invoice
        private Invoice invoiceToEdit; //used when an existing invoice is edited

        public InvoiceForm()
        {
            InitializeComponent();
            paymentDatePicker.CustomFormat = "dd/MM/yyyy";
            paymentDatePicker.Format = DateTimePickerFormat.Custom;
        }


        //cancel button handler
        private void button2_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("Add Invoice Form closed using (Text)" + ((Button)sender).Text); //displays 'Cancel'
            this.Dispose();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            //tbInvoiceNum.Text = ((CustomerForm)this.Owner).InvoiceToSearch;
           
            if (purpose.Equals("Edit Invoice"))
            {
                tbInvoiceNum.Text = parent.InvoiceToSearch;
                
                this.Text = "Edit Invoice";

                //get the invoice
                invoiceToEdit = parent.currentSelectedCustomer.invoices.Find(x => x.InvoiceNum == parent.InvoiceToSearch);

                paymentDatePicker.Value = invoiceToEdit.PaymentDate;
                cboxPaidStatus.Checked = invoiceToEdit.PaidStatus;
                
                List<Item> products = parent.products;
                addColumnstoTable();

                foreach (InvoiceItem item in invoiceToEdit.InvoiceItems)
                {
                    addItemToTable(item);
                }

                updateInvoiceTotal();

                //add the datagridview listeners
                dgAddInvoiceItems.CellValueChanged += new DataGridViewCellEventHandler(dgAddInvoiceItems_CellValueChanged);
                dgAddInvoiceItems.CurrentCellDirtyStateChanged += new EventHandler(dgAddInvoiceItems_CurrentCellDirtyStateChanged);
                dgAddInvoiceItems.UserDeletedRow += new DataGridViewRowEventHandler(dgAddInvoiceItems_UserDeletedRow);

            }
            else if (purpose.Equals("Add Invoice"))
            {
                this.Text = "Add Invoice";
                invoiceTotal = 0;
                //get a new invoice number
                tbInvoiceNum.Text = parent.getNewInvoiceNum();
                //populate the item combobox
                List<Item> products = parent.products;
                addColumnstoTable();

                //disbable the save button until items have been added
                btnSave.Enabled = false;

                //add the datagridview listeners
                dgAddInvoiceItems.CellValueChanged += new DataGridViewCellEventHandler(dgAddInvoiceItems_CellValueChanged);
                dgAddInvoiceItems.CurrentCellDirtyStateChanged += new EventHandler(dgAddInvoiceItems_CurrentCellDirtyStateChanged);
                dgAddInvoiceItems.UserDeletedRow += new DataGridViewRowEventHandler(dgAddInvoiceItems_UserDeletedRow);
            }

        }

        private void addItemToTable(InvoiceItem item) {

            int rowIndex = dgAddInvoiceItems.Rows.Add();
            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgAddInvoiceItems.Rows[rowIndex].Cells[0];
            cb.Value = item.ItemNum;
            dgAddInvoiceItems.Rows[rowIndex].Cells[1].Value = item.ItemDesc;
            dgAddInvoiceItems.Rows[rowIndex].Cells[2].Value = item.ItemCost;
            dgAddInvoiceItems.Rows[rowIndex].Cells[3].Value = item.ItemQty;
            dgAddInvoiceItems.Rows[rowIndex].Cells[4].Value = item.TotalCost;

        }

        //handle user row deletions by updating the invoice total
        void dgAddInvoiceItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //if all items deleted from the table then disable the save button
            if (dgAddInvoiceItems.Rows.Count == 1)
            {
                btnSave.Enabled = false;
            }
            updateInvoiceTotal();
        }

        // This event handler manually raises the CellValueChanged event 
        // by calling the CommitEdit method. 
        void dgAddInvoiceItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgAddInvoiceItems.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dgAddInvoiceItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgAddInvoiceItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            

            if (e.ColumnIndex == 0)
            {
                //Console.Write("Combobox detected " + e.ColumnIndex);
                
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgAddInvoiceItems.Rows[e.RowIndex].Cells[0];
                if (cb.Value != null)
                {

                    btnSave.Enabled = true;
                    addItemRow((int)cb.Value, e);
                    

                   

                }
            }

            if (e.ColumnIndex == 3)
            {
                //Console.Write("Qty change detected " + e.ColumnIndex);
                object qty = dgAddInvoiceItems.Rows[e.RowIndex].Cells[3].Value;
                object itemCost = dgAddInvoiceItems.Rows[e.RowIndex].Cells[2].Value;

                double total = Convert.ToDouble(itemCost) * Convert.ToInt16(qty);
                dgAddInvoiceItems.Rows[e.RowIndex].Cells[4].Value = total;

               

              
            }
            updateInvoiceTotal();

        }


        private void updateInvoiceTotal()
        {
            invoiceTotal = 0;

            for (int i = 0; i < dgAddInvoiceItems.Rows.Count; i++)
            {
                invoiceTotal += Convert.ToDecimal(dgAddInvoiceItems.Rows[i].Cells[4].Value);
            }
            
            txtBoxInvoiceTotal.Text = "$" + invoiceTotal.ToString("#.00");
        }
        private void addItemRow(int itemNum, DataGridViewCellEventArgs e)
        {
            

            foreach (var item in parent.products)
            {
                
                    if (item.ItemNum == itemNum)
                    {
                        dgAddInvoiceItems.Rows[e.RowIndex].Cells[1].Value = item.ItemDesc;
                        dgAddInvoiceItems.Rows[e.RowIndex].Cells[2].Value = item.ItemCost;
                        dgAddInvoiceItems.Rows[e.RowIndex].Cells[3].Value = 1;
                        dgAddInvoiceItems.Rows[e.RowIndex].Cells[4].Value = item.ItemCost;
                        
                    }
                
            }

        }

        private void addColumnstoTable()
        {
            
            itemNumCbox = new DataGridViewComboBoxColumn();
            itemNumCbox.DataSource = parent.products;
            itemNumCbox.HeaderText = "Item";
            itemNumCbox.ValueMember = "ItemNum";
            itemNumCbox.DisplayMember = "ItemName";
            itemNumCbox.Width = 117;
            dgAddInvoiceItems.Columns.Add(itemNumCbox);

            itemDescCol = new DataGridViewTextBoxColumn();
            itemDescCol.ReadOnly = true;
            itemDescCol.HeaderText = "Description";
            itemDescCol.DataPropertyName = "ItemDesc";
            itemDescCol.Width = 130;
            itemDescCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            itemDescCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAddInvoiceItems.Columns.Add(itemDescCol);

            itemCostCol = new DataGridViewTextBoxColumn();
            itemCostCol.ReadOnly = true;
            itemCostCol.HeaderText = "Cost";
            itemCostCol.DataPropertyName = "ItemCost";
            itemCostCol.Width = 80;
            itemCostCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            itemCostCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAddInvoiceItems.Columns.Add(itemCostCol);

            itemQtyCol = new DataGridViewTextBoxColumn();
            itemQtyCol.HeaderText = "Qty";
            itemQtyCol.DataPropertyName = "ItemQty";
            itemQtyCol.Width = 60;
            itemQtyCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            itemQtyCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAddInvoiceItems.Columns.Add(itemQtyCol);

            itemTotalCostCol = new DataGridViewTextBoxColumn();
            itemTotalCostCol.ReadOnly = true;
            itemTotalCostCol.HeaderText = "Total Cost";
            itemTotalCostCol.DataPropertyName = "TotalCost";
            itemTotalCostCol.Width = 80;
            itemTotalCostCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            itemTotalCostCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAddInvoiceItems.Columns.Add(itemTotalCostCol);

            dgAddInvoiceItems.ClearSelection();
        }

        private void dgInvoiceDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //save button - create a new invoice for the customer
        private void button1_Click(object sender, EventArgs e)
        {
            if (purpose.Equals("Add Invoice"))
            {
                createInvoice();

            }
            else if (purpose.Equals("Edit Invoice"))
            {
                updateInvoice();
            }


            this.Dispose();
        }

        private void updateInvoice()
        {
            string invoiceNum = tbInvoiceNum.Text;
            DateTime paymentDate = paymentDatePicker.Value;
            bool payStatus = cboxPaidStatus.Checked;
            decimal invCost = invoiceTotal;
            List<InvoiceItem> invItems = new List<InvoiceItem>();

            //if some rows have been added
            if (dgAddInvoiceItems.Rows.Count - 1 > 0)
            {

                //go through the row of items and create a new InvoiceItem object
                for (int i = 0; i < dgAddInvoiceItems.Rows.Count - 1; i++)
                {
                    int itemNum = Convert.ToInt16(dgAddInvoiceItems.Rows[i].Cells[0].Value);
                    Item theItem = getItem(itemNum);
                    int qty = Convert.ToInt16(dgAddInvoiceItems.Rows[i].Cells[3].Value);
                    if (theItem != null)
                    {
                        invItems.Add(new InvoiceItem(theItem, qty));
                    }
                    else
                    {
                        Console.WriteLine("Item not found");
                    }

                }
            }
            invoiceToEdit.PaymentDate = paymentDate;
            invoiceToEdit.PaidStatus = payStatus;
            invoiceToEdit.InvoiceItems = invItems;
            invoiceToEdit.TotalCost = invCost;

        }

        private void createInvoice()
        {
            string invoiceNum = tbInvoiceNum.Text;
            DateTime paymentDate = paymentDatePicker.Value;
            bool payStatus = cboxPaidStatus.Checked;
            decimal invCost = invoiceTotal;
            List<InvoiceItem> invItems = new List<InvoiceItem>();

            //if some rows have been added
            if (dgAddInvoiceItems.Rows.Count - 1 > 0)
            {
                
                //go through the row of items and create a new InvoiceItem object
                for (int i = 0; i < dgAddInvoiceItems.Rows.Count - 1; i++)
                {
                    int itemNum = Convert.ToInt16(dgAddInvoiceItems.Rows[i].Cells[0].Value);
                    Item theItem = getItem(itemNum);
                    int qty = Convert.ToInt16(dgAddInvoiceItems.Rows[i].Cells[3].Value);
                    if (theItem != null)
                    {
                        invItems.Add(new InvoiceItem(theItem, qty));
                    }
                    else
                    {
                        Console.WriteLine("Item not found");
                    }

                }

                //create the new invoice form user input
                Invoice invToAdd = new Invoice(invoiceNum, paymentDate, payStatus, invCost, invItems);
                //add the invoice for the customer
                parent.currentSelectedCustomer.addInvoice(invToAdd);
                //increment invoice counter. This is used when generating a new invoice number.
                parent.InvoiceCount++;
            }
            
        }

        private Item getItem(int itemNum)
        {
            Item itemToFind = null;
            Console.WriteLine("Looking for item: " + itemNum);

            foreach (var item in parent.products)
            {
                if (item.ItemNum == itemNum)
                {
                    itemToFind = item;

                }
            }

            return itemToFind;

        }

    }
}
