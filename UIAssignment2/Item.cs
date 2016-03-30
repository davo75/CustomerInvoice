using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAssignment2
{
    class Item
    {

        private int itemNum;
        private string itemName;
        private string itemDesc;
        private decimal itemCost;
        private int itemQty;
        private decimal totalCost;

        public Item(int itemNum, string itemName, string itemDesc, decimal itemCost, int qty)
        {
            this.ItemNum = itemNum;
            this.ItemName = itemName;
            this.ItemDesc = itemDesc;
            this.ItemCost = itemCost;
            this.ItemQty = qty;
        }

        public decimal TotalCost
        {
            get { return itemCost * itemQty; }
        }

        public int ItemNum
        {
            get { return itemNum; }
            set { itemNum = value; }
        }
        

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
        

        public string ItemDesc
        {
            get { return itemDesc; }
            set { itemDesc = value; }
        }
        

        public decimal ItemCost
        {
            get { return itemCost; }
            set { itemCost = value; }
        }

        public int ItemQty
        {
            get { return itemQty; }
            set { itemQty = value; }
        }

        
    }
}
