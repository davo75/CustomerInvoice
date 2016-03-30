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
        private int qty;

        public Item(int itemNum, string itemName, string itemDesc, decimal itemCost, int qty)
        {
            this.ItemNum = itemNum;
            this.ItemName = itemName;
            this.ItemDesc = itemDesc;
            this.ItemCost = itemCost;
            this.Qty = qty;
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

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        
    }
}
