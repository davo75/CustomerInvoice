/// <summary>
/// The InvoiceItem class holds information about which items belong to an
/// invoice and the quantity of each item on the invocie. 
/// <sumary>
/// <remarks>
/// author: David Pyle 041110777
/// version: 1.0
/// date: 25/4/2016
/// </remarks>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAssignment2
{
    class InvoiceItem
    {
        /// <summary>
        /// The item on the invoice
        /// </summary>
        private Item item;

        /// <summary>
        /// The item
        /// </summary>
        public Item Item
        {
            get { return item; }
            set { item = value; }
        }
        
        /// <summary>
        /// The item quantity
        /// </summary>
        private int qty;

        /// <summary>
        /// Constructor sets the item and item quantity
        /// </summary>
        /// <param name="item"></param>
        /// <param name="qty"></param>
        public InvoiceItem(Item item, int qty)
        {
            this.item = item;
            this.qty = qty;
        }

        /// <summary>
        /// Item quantity
        /// </summary>
        public int ItemQty
        {
            get { return qty; }
            set { qty = value; }
        }

        /// <summary>
        /// The cost of the item * quantity
        /// </summary>
        public decimal TotalCost
        {
            get { return qty * ItemCost; }
        }
       
        /// <summary>
        /// The item number
        /// </summary>
        public int ItemNum
        {
            get { return item.ItemNum; }
           
        }

        /// <summary>
        /// The item name
        /// </summary>
        public string ItemName
        {
            get { return item.ItemName; }
            
        }

        /// <summary>
        /// The item description
        /// </summary>
        public string ItemDesc
        {
            get { return item.ItemDesc; }
          
        }

        /// <summary>
        /// The item cost
        /// </summary>
        public decimal ItemCost
        {
            get { return item.ItemCost; }
         
        }
       
    }
}
