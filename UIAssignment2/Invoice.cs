/// <summary>
/// The Invoice class holds information about an invoice. An invoice can 
/// store many items.
/// <sumary>
/// <remarks>
/// author: David Pyle 041110777
/// version: 1.0
/// date: 25/4/2016
/// </remarks>
/// 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAssignment2
{
    class Invoice
    {
        /// <summary>
        /// The invoice number
        /// </summary>
        private string invoiceNum;
        /// <summary>
        /// The payment status of the invoice. True if paid, false if unpaid.
        /// </summary>
        private bool paidStatus;
        /// <summary>
        /// Associated invoice items for the invoices
        /// </summary>
        private List<InvoiceItem> invoiceItems;
        /// <summary>
        /// The date payment for the invoice is due
        /// </summary>
        private DateTime paymentDate;
        /// <summary>
        /// The total cost of the invoice
        /// </summary>
        private decimal totalCost;

        /// <summary>
        /// Constructor sets the invoice number, payment date and default values for payment date, payment status, total cost and initialises a list of items
        /// </summary>
        /// <param name="invoiceNum">The invoice number</param>
        /// <param name="paymentDate">The due date for invoice payment</param>
        public Invoice(string invoiceNum, DateTime paymentDate)
        {
            this.InvoiceNum = invoiceNum;
            this.PaymentDate = paymentDate;
            this.PaidStatus = false;
            this.TotalCost = 0.00m;
            invoiceItems = new List<InvoiceItem>();
        }

        /// <summary>
        /// Constructor sets the invoice number, payment date, payment date, payment status, total cost and list of items
        /// </summary>
        /// <param name="invoiceNum">Invoice number</param>
        /// <param name="paymentDate">Due date for invoice payment</param>
        /// <param name="paymentStatus">Payment status of the invoice</param>
        /// <param name="totalCost">Total cost of the invoice</param>
        /// <param name="items">The items on the invoice</param>
        public Invoice(string invoiceNum, DateTime paymentDate, bool paymentStatus, decimal totalCost, List<InvoiceItem> items)
        {
            this.InvoiceNum = invoiceNum;
            this.PaymentDate = paymentDate;
            this.PaidStatus = paymentStatus;
            this.TotalCost = totalCost;
            invoiceItems = items;
        }
        /// <summary>
        /// List of invoice items for an invoice
        /// </summary>
        internal List<InvoiceItem> InvoiceItems
        {
            get { return invoiceItems; }
            set { invoiceItems = value; }
        }


        /// <summary>
        /// The total cost of the invoice
        /// </summary>
        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }


        /// <summary>
        /// Adds an item to the invoice
        /// </summary>
        /// <param name="item">The item to add</param>
        /// <param name="qty">The quantity of the item</param>
        public void addItem(Item item, int qty)
        {
            //add the item and quantity
            this.invoiceItems.Add(new InvoiceItem(item, qty));
            //update the total cost of the invoice
            TotalCost += item.ItemCost * qty;
        }

        /// <summary>
        /// Gets the list of items on the invoice
        /// </summary>
        /// <returns>The list of invoce items</returns>
        public List<InvoiceItem> getItems()
        {
            return invoiceItems;
        }

        /// <summary>
        /// The payment due date for an invoice
        /// </summary>
        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        /// <summary>
        /// The payment status of an invoice. True if paid, false if unpaid.
        /// </summary>
        public bool PaidStatus
        {
            get { return paidStatus; }
            set { paidStatus = value; }
        }

        /// <summary>
        /// Th invoice number
        /// </summary>
        public string InvoiceNum
        {
            get { return invoiceNum; }
            set { invoiceNum = value; }
        }
    }
}
