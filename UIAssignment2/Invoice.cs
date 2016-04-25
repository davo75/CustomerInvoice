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
        /// The payment status type - Paid, Unpaid or Overdue
        /// </summary>
        public enum PaidStatus { Paid, Unpaid, Overdue };
        /// <summary>
        /// The payment status of the invoice
        /// </summary>
        private PaidStatus paymentStatus;
        /// <summary>
        /// Associated invoice items for the invoices
        /// </summary>
        private List<InvoiceItem> invoiceItems;
        /// <summary>
        /// The date payment for the invoice is due
        /// </summary>
        private DateTime paymentDueDate;
        /// <summary>
        /// The date the payment was made
        /// </summary>
        private DateTime? paymentDate;
        /// <summary>
        /// The total cost of the invoice
        /// </summary>
        private decimal totalCost;

        /// <summary>
        /// Constructor sets the invoice number, payment date and default values for payment date, payment status, total cost and initialises a list of items
        /// </summary>
        /// <param name="invoiceNum">The invoice number</param>
        /// <param name="paymentDueDate">The due date for invoice payment</param>
        public Invoice(string invoiceNum, DateTime paymentDueDate)
        {
            this.InvoiceNum = invoiceNum;
            this.PaymentDueDate = paymentDueDate;
            this.PaymentDate = null;
            this.PaymentStatus = PaidStatus.Unpaid;
            this.TotalCost = 0.00m;
            invoiceItems = new List<InvoiceItem>();
        }

        /// <summary>
        /// Constructor sets the invoice number, payment date, payment date, payment status, total cost and list of items
        /// </summary>
        /// <param name="invoiceNum">Invoice number</param>
        /// <param name="paymentDueDate">Due date for invoice payment</param>
        /// <param name="paymentStatus">Payment status of the invoice</param>
        /// <param name="totalCost">Total cost of the invoice</param>
        /// <param name="items">The items on the invoice</param>
        public Invoice(string invoiceNum, DateTime paymentDueDate, DateTime? paymentDate, PaidStatus paymentStatus, decimal totalCost, List<InvoiceItem> items)
        {
            this.InvoiceNum = invoiceNum;
            this.PaymentDueDate = paymentDueDate;
            this.PaymentDate = paymentDate;
            this.PaymentStatus = paymentStatus;
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
        public DateTime PaymentDueDate
        {
            get { return paymentDueDate; }
            set { paymentDueDate = value; }
        }


        /// <summary>
        /// The date the invoice was paid
        /// </summary>
        public DateTime? PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        /// <summary>
        /// The payment status of an invoice. Paid, Unpaid or Overdue.
        /// </summary>
        public PaidStatus PaymentStatus
        {
            get { return paymentStatus; }
            set { paymentStatus = value; }
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
