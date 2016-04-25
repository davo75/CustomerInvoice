/// <summary>
/// Displays the invoice form for editing an existing invoice details or
/// for adding a new invoice
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

namespace UIAssignment2
{
    public partial class InvoiceForm : Form
    {
        /// <summary>
        /// Reference to parent form
        /// </summary>
        public MainForm parent;
        /// <summary>
        /// The purpose of invoice form; either edit or add
        /// </summary>
        public string purpose;

        /// <summary>
        /// Item description column for item table
        /// </summary>
        private DataGridViewTextBoxColumn itemDescCol;
        /// <summary>
        /// Item number column for item table
        /// </summary>
        private DataGridViewComboBoxColumn itemNumCbox;
        /// <summary>
        /// Item cost column for item table
        /// </summary>
        private DataGridViewTextBoxColumn itemCostCol;
        /// <summary>
        /// Item quantity column for item table
        /// </summary>
        private DataGridViewTextBoxColumn itemQtyCol;
        /// <summary>
        /// Item total cost column for item table
        /// </summary>
        private DataGridViewTextBoxColumn itemTotalCostCol;
        /// <summary>
        /// Total of all invoice items
        /// </summary>
        private decimal invoiceTotal;
        /// <summary>
        /// The invoice when editing an existing invoice
        /// </summary>
        private Invoice invoiceToEdit;

        /// <summary>
        /// Constructor initialises the UI components for the invoice form
        /// </summary>
        public InvoiceForm()
        {
            InitializeComponent();
            //set the format for the data picker
            paymentDatePicker.CustomFormat = "dd/MM/yyyy";
            paymentDatePicker.Format = DateTimePickerFormat.Custom;
        }


        /// <summary>
        /// Closes the invoice form
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// Called when invoice form first loads.
        /// </summary>
        /// <remarks>
        /// If adding a new invoice all fields except invoice number are empty ready for input. 
        /// If editing an existing invoice all fields are populated ready for modification except invoice number.</remarks>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            //set the theme
            showTheme(parent.theme);

            //if editing an invoice
            if (purpose.Equals("Edit Invoice"))
            {
                //set the invoice number - read only
                tbInvoiceNum.Text = parent.InvoiceToSearch;

                //set form title
                this.Text = "Edit Invoice";

                //get the invoice
                invoiceToEdit = parent.currentSelectedCustomer.findInvoice(parent.InvoiceToSearch);

                //set the payment due date
                paymentDatePicker.Value = invoiceToEdit.PaymentDate;
                //set the payment status
                cboxPaidStatus.Checked = invoiceToEdit.PaidStatus;

                //get the list of items for the invoice
                List<Item> products = parent.products;
                //add the column headers to the item table
                addColumnstoTable();
                //populate the items table
                foreach (InvoiceItem item in invoiceToEdit.InvoiceItems)
                {
                    addItemToTable(item);
                }
                //calcualte the invoice total cost
                updateInvoiceTotal();

                //add the datagridview listeners - triggered when a row is edited or when a row is deleted
                dgAddInvoiceItems.CellValueChanged += new DataGridViewCellEventHandler(dgAddInvoiceItems_CellValueChanged);
                dgAddInvoiceItems.CurrentCellDirtyStateChanged += new EventHandler(dgAddInvoiceItems_CurrentCellDirtyStateChanged);
                dgAddInvoiceItems.UserDeletedRow += new DataGridViewRowEventHandler(dgAddInvoiceItems_UserDeletedRow);

            }
            //if adding a new invoice
            else if (purpose.Equals("Add Invoice"))
            {
                //set form title
                this.Text = "Add Invoice";
                //initialise invoice total cost to 0
                invoiceTotal = 0;
                //get a new invoice number
                tbInvoiceNum.Text = parent.getNewInvoiceNum();
                //populate the item combobox
                List<Item> products = parent.products;
                //add column headers to item table
                addColumnstoTable();
                //disbable the save button until items have been added
                btnSave.Enabled = false;

                //add the datagridview listeners - triggered when a row is edited or when a row is deleted
                dgAddInvoiceItems.CellValueChanged += new DataGridViewCellEventHandler(dgAddInvoiceItems_CellValueChanged);
                dgAddInvoiceItems.CurrentCellDirtyStateChanged += new EventHandler(dgAddInvoiceItems_CurrentCellDirtyStateChanged);
                dgAddInvoiceItems.UserDeletedRow += new DataGridViewRowEventHandler(dgAddInvoiceItems_UserDeletedRow);
            }

        }

        /// <summary>
        /// Changes the interface baground image to the selected theme
        /// </summary>
        /// <param name="theTheme">The name of the theme</param>
        private void showTheme(string theTheme)
        {
            switch (theTheme)
            {
                case "Light":
                    //set background image
                    Image lightImage = new Bitmap(UIAssignment2.Properties.Resources.light);
                    this.BackgroundImage = lightImage;
                    //Customer Details Box text colours
                    gbInvoice.ForeColor = Color.White;
                    gbInvoice.BackColor = Color.Transparent;
                    dgAddInvoiceItems.ForeColor = Color.Black;
                    break;
                case "Dark":
                    //set background image
                    Image darkImage = new Bitmap(UIAssignment2.Properties.Resources.dark);
                    this.BackgroundImage = darkImage;
                    //Customer Details Box text colours
                    gbInvoice.ForeColor = Color.White;
                    gbInvoice.BackColor = Color.Transparent;
                    dgAddInvoiceItems.ForeColor = Color.Black;
                    break;

                default:
                    //remove background image
                    this.BackgroundImage = null;
                    //Customer Details Box text colours
                    gbInvoice.ForeColor = SystemColors.ControlText;
                    gbInvoice.BackColor = SystemColors.Control;
                    dgAddInvoiceItems.ForeColor = Color.Black;
                    break;
            }
        }

        /// <summary>
        /// Adds a new item to the item table
        /// </summary>
        /// <param name="item">The item to add</param>
        private void addItemToTable(InvoiceItem item)
        {
            //get the row index
            int rowIndex = dgAddInvoiceItems.Rows.Add();
            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgAddInvoiceItems.Rows[rowIndex].Cells[0];
            //add the item details to the table
            cb.Value = item.ItemNum;
            dgAddInvoiceItems.Rows[rowIndex].Cells[1].Value = item.ItemDesc;
            dgAddInvoiceItems.Rows[rowIndex].Cells[2].Value = item.ItemCost;
            dgAddInvoiceItems.Rows[rowIndex].Cells[3].Value = item.ItemQty;
            dgAddInvoiceItems.Rows[rowIndex].Cells[4].Value = item.TotalCost.ToString("#.00");

        }

        /// <summary>
        /// Called when an row is deleted in the item's table
        /// </summary>
        /// <remarks>
        /// Update the invoice total after detletion. If all item table is empty after deletion then disable the save button. </remarks>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        void dgAddInvoiceItems_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            //if all items deleted from the table then disable the save button
            if (dgAddInvoiceItems.Rows.Count == 1)
            {
                btnSave.Enabled = false;
            }
            //update invoice total
            updateInvoiceTotal();
        }

        /// <summary>
        /// This event handler manually raises the CellValueChanged event by calling the CommitEdit method.
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>         
        void dgAddInvoiceItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dgAddInvoiceItems.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dgAddInvoiceItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        /// <summary>
        /// Handles when a user chooses a new item or changes the quantity for an item 
        /// </summary>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param> 
        private void dgAddInvoiceItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if an item from the drop-down list is selected
            if (e.ColumnIndex == 0)
            {
                //get the item selected
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgAddInvoiceItems.Rows[e.RowIndex].Cells[0];
                //check its not null
                if (cb.Value != null)
                {
                    //something has been added to the item table so enable the save button
                    btnSave.Enabled = true;
                    //add the item to the item table
                    addItemRow((int)cb.Value, e);
                }
            }

            //if an item's quantity is changed
            if (e.ColumnIndex == 3)
            {
                //get the quantity entered by the users
                object qty = dgAddInvoiceItems.Rows[e.RowIndex].Cells[3].Value;
                //get the item's cost
                object itemCost = dgAddInvoiceItems.Rows[e.RowIndex].Cells[2].Value;
                //calcualte the item's total cost (item cost * quantity)
                double total = Convert.ToDouble(itemCost) * Convert.ToInt16(qty);
                //set the item total in the item table
                dgAddInvoiceItems.Rows[e.RowIndex].Cells[4].Value = total;
            }
            //update the invoice total cost
            updateInvoiceTotal();
        }

        /// <summary>
        /// Updates the invoice total cost by adding up all the item costs on the invoice
        /// </summary>
        private void updateInvoiceTotal()
        {
            //start with the invoice total at 0
            invoiceTotal = 0;

            //go through each item in the item table and add its cost to the invoice total
            for (int i = 0; i < dgAddInvoiceItems.Rows.Count; i++)
            {
                invoiceTotal += Convert.ToDecimal(dgAddInvoiceItems.Rows[i].Cells[4].Value);
            }
            //set the invoice total cost on the form
            txtBoxInvoiceTotal.Text = "$" + invoiceTotal.ToString("#.00");
        }

        /// <summary>
        /// Adds a new item row to the item table.
        /// </summary>
        /// <remarks>When adding an item the quantity is set to 1 by default.</remarks>
        /// <param name="itemNum">The item number to search for</param>
        /// <param name="e">Event arguments</param>
        private void addItemRow(int itemNum, DataGridViewCellEventArgs e)
        {
            //search for the item numebr in the products table
            foreach (var item in parent.products)
            {
                //if a match is found get the item details and populate the item table
                if (item.ItemNum == itemNum)
                {
                    dgAddInvoiceItems.Rows[e.RowIndex].Cells[1].Value = item.ItemDesc;
                    dgAddInvoiceItems.Rows[e.RowIndex].Cells[2].Value = item.ItemCost;
                    dgAddInvoiceItems.Rows[e.RowIndex].Cells[3].Value = 1;
                    dgAddInvoiceItems.Rows[e.RowIndex].Cells[4].Value = item.ItemCost;
                }
            }
        }

        /// <summary>
        /// Adds columen headers to the item table
        /// </summary>
        private void addColumnstoTable()
        {
            //add item number column
            itemNumCbox = new DataGridViewComboBoxColumn();
            itemNumCbox.DataSource = parent.products;
            itemNumCbox.HeaderText = "Item";
            itemNumCbox.ValueMember = "ItemNum";
            itemNumCbox.DisplayMember = "ItemName";
            itemNumCbox.Width = 117;
            dgAddInvoiceItems.Columns.Add(itemNumCbox);

            //add item description column
            itemDescCol = new DataGridViewTextBoxColumn();
            itemDescCol.ReadOnly = true;
            itemDescCol.HeaderText = "Description";
            itemDescCol.DataPropertyName = "ItemDesc";
            itemDescCol.Width = 130;
            itemDescCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            itemDescCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAddInvoiceItems.Columns.Add(itemDescCol);

            //add item cost column
            itemCostCol = new DataGridViewTextBoxColumn();
            itemCostCol.ReadOnly = true;
            itemCostCol.HeaderText = "Cost";
            itemCostCol.DataPropertyName = "ItemCost";
            itemCostCol.Width = 80;
            itemCostCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            itemCostCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAddInvoiceItems.Columns.Add(itemCostCol);

            //add item quantity column
            itemQtyCol = new DataGridViewTextBoxColumn();
            itemQtyCol.HeaderText = "Qty";
            itemQtyCol.DataPropertyName = "ItemQty";
            itemQtyCol.Width = 60;
            itemQtyCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            itemQtyCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAddInvoiceItems.Columns.Add(itemQtyCol);

            //add total cost column
            itemTotalCostCol = new DataGridViewTextBoxColumn();
            itemTotalCostCol.ReadOnly = true;
            itemTotalCostCol.HeaderText = "Total Cost";
            itemTotalCostCol.DataPropertyName = "TotalCost";
            itemTotalCostCol.Width = 80;
            itemTotalCostCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            itemTotalCostCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgAddInvoiceItems.Columns.Add(itemTotalCostCol);

            //clear any default selection
            dgAddInvoiceItems.ClearSelection();
        }

        /// <summary>
        /// Saves the invoice details
        /// </summary>
        /// <remarks>If adding an invoice a new invoice is created. If editing an invoice the details are updated.</remarks>
        /// <param name="sender">Object source</param>
        /// <param name="e">Event arguments</param>
        private void button1_Click(object sender, EventArgs e)
        {
            //if adding a new invoice
            if (purpose.Equals("Add Invoice"))
            {
                //add the invoice
                createInvoice();
            }
            //if editing an invoice
            else if (purpose.Equals("Edit Invoice"))
            {
                //update the existing invoice
                updateInvoice();
            }
            //close the form
            this.Dispose();
        }

        /// <summary>
        /// Update an existing invoice with details entered into the invoice form
        /// </summary>
        private void updateInvoice()
        {
            //set invoice number
            string invoiceNum = tbInvoiceNum.Text;
            //set the payment date
            DateTime paymentDate = paymentDatePicker.Value;
            //set payment status
            bool payStatus = cboxPaidStatus.Checked;
            //set invoice total
            decimal invCost = invoiceTotal;
            //create new list of invoice items
            List<InvoiceItem> invItems = new List<InvoiceItem>();

            //if some rows have been added
            if (dgAddInvoiceItems.Rows.Count - 1 > 0)
            {
                //go through the row of items and create a new InvoiceItem object
                for (int i = 0; i < dgAddInvoiceItems.Rows.Count - 1; i++)
                {
                    //get item number
                    int itemNum = Convert.ToInt16(dgAddInvoiceItems.Rows[i].Cells[0].Value);
                    //get the item
                    Item theItem = getItem(itemNum);
                    //get the item quantity
                    int qty = Convert.ToInt16(dgAddInvoiceItems.Rows[i].Cells[3].Value);
                    //if the item exists
                    if (theItem != null)
                    {
                        //add the item and quantity to the invoice
                        invItems.Add(new InvoiceItem(theItem, qty));
                    }
                    else
                    {
                        Console.WriteLine("Item not found");
                    }
                }
            }
            //set the payment date
            invoiceToEdit.PaymentDate = paymentDate;
            //set the payment status
            invoiceToEdit.PaidStatus = payStatus;
            //set the invoice items
            invoiceToEdit.InvoiceItems = invItems;
            //set the invoice total cost
            invoiceToEdit.TotalCost = invCost;
        }

        /// <summary>
        /// Create a new invoice from the details entered into the invoice form
        /// </summary>
        private void createInvoice()
        {
            //get invoice number
            string invoiceNum = tbInvoiceNum.Text;
            //get payment due date
            DateTime paymentDate = paymentDatePicker.Value;
            //get the payment status
            bool payStatus = cboxPaidStatus.Checked;
            //get the invoice total
            decimal invCost = invoiceTotal;
            //create new list of invoice items
            List<InvoiceItem> invItems = new List<InvoiceItem>();

            //if some rows have been added
            if (dgAddInvoiceItems.Rows.Count - 1 > 0)
            {
                //go through the row of items and create a new InvoiceItem object
                for (int i = 0; i < dgAddInvoiceItems.Rows.Count - 1; i++)
                {
                    //get item number
                    int itemNum = Convert.ToInt16(dgAddInvoiceItems.Rows[i].Cells[0].Value);
                    //get the item
                    Item theItem = getItem(itemNum);
                    //get the item quantity
                    int qty = Convert.ToInt16(dgAddInvoiceItems.Rows[i].Cells[3].Value);
                    //if the item exists
                    if (theItem != null)
                    {
                        //add the item to the invoice
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

        /// <summary>
        /// Finds an item from the products list
        /// </summary>
        /// <param name="itemNum">The item number to search for</param>
        /// <returns>Item if found or null if not found</returns>
        private Item getItem(int itemNum)
        {
            Item itemToFind = null;
            //search for item number in products
            foreach (var item in parent.products)
            {
                //if match found
                if (item.ItemNum == itemNum)
                {
                    //get item
                    itemToFind = item;
                }
            }
            //return item 
            return itemToFind;
        }
    }
}
