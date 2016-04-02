using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAssignment2
{
    class InvoiceItem
    {

        private Item item;

        public Item Item
        {
            get { return item; }
            set { item = value; }
        }
        
        private int qty;

       
        public InvoiceItem(Item item, int qty)
        {
            this.item = item;
            this.qty = qty;
        }

        public int ItemQty
        {
            get { return qty; }
            set { qty = value; }
        }

        public decimal TotalCost
        {
            get { return qty * ItemCost; }
        }
       

        public int ItemNum
        {
            get { return item.ItemNum; }
           
        }


        public string ItemName
        {
            get { return item.ItemName; }
            
        }


        public string ItemDesc
        {
            get { return item.ItemDesc; }
          
        }


        public decimal ItemCost
        {
            get { return item.ItemCost; }
         
        }
       
    }
}
