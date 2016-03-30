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
        private List<Item> items;
        private DateTime paymentDate;
        private decimal totalCost;

        public Invoice(string invoiceNum, DateTime paymentDate)
        {
            this.InvoiceNum = invoiceNum;
            this.PaymentDate = paymentDate;
            this.PaidStatus = false;
            this.TotalCost = 0.00m;
            items = new List<Item>();

        }

        public decimal TotalCost
        {
            get { return totalCost; }
            set { totalCost = value; }
        }

        public void addItem(Item item)
        {
            this.items.Add(item);
            TotalCost += item.ItemCost * item.ItemQty;

        }

        public List<Item> getItems()
        {
            return this.items;
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
