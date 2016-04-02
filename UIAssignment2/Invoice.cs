using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAssignment2
{
    class Invoice
    {
        private string invoiceNum;
        private bool paidStatus;
        private List<InvoiceItem> invoiceItems;

       
        private DateTime paymentDate;
        private decimal totalCost;

        public Invoice(string invoiceNum, DateTime paymentDate)
        {
            this.InvoiceNum = invoiceNum;
            this.PaymentDate = paymentDate;
            this.PaidStatus = false;
            this.TotalCost = 0.00m;
            invoiceItems = new List<InvoiceItem>();

        }

        public Invoice(string invoiceNum, DateTime paymentDate, bool paymentStatus, decimal totalCost, List<InvoiceItem> items)
        {
            this.InvoiceNum = invoiceNum;
            this.PaymentDate = paymentDate;
            this.PaidStatus = paymentStatus;
            this.TotalCost = totalCost;
            invoiceItems = items;
        }

        internal List<InvoiceItem> InvoiceItems
        {
            get { return invoiceItems; }
            set { invoiceItems = value; }
        }

        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        public void addItem(Item item, int qty)
        {
            this.invoiceItems.Add(new InvoiceItem(item, qty));
            TotalCost += item.ItemCost * qty;

        }

        public List<InvoiceItem> getItems()
        {
            return invoiceItems;
        }

        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }

        public bool PaidStatus
        {
            get { return paidStatus; }
            set { paidStatus = value; }
        }

        public string InvoiceNum
        {
            get { return invoiceNum; }
            set { invoiceNum = value; }
        }
    }
}
