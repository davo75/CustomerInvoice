/// <summary>
/// The Item class holds information about an invoice item. 
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
    class Item
    {
        /// <summary>
        /// The number of the item
        /// </summary>
        private int itemNum;
        /// <summary>
        /// The name of the item
        /// </summary>
        private string itemName;
        /// <summary>
        /// The description of an item
        /// </summary>
        private string itemDesc;
        /// <summary>
        /// Cst of the item
        /// </summary>
        private decimal itemCost;


        /// <summary>
        /// Constructor sets the item number, name, descriotion and cost
        /// </summary>
        /// <param name="itemNum">Item number</param>
        /// <param name="itemName">Item name</param>
        /// <param name="itemDesc">Item description</param>
        /// <param name="itemCost">Item cost</param>
        public Item(int itemNum, string itemName, string itemDesc, decimal itemCost)
        {
            this.ItemNum = itemNum;
            this.ItemName = itemName;
            this.ItemDesc = itemDesc;
            this.ItemCost = itemCost;
        }

        /// <summary>
        /// Item number
        /// </summary>
        public int ItemNum
        {
            get { return itemNum; }
            set { itemNum = value; }
        }

        /// <summary>
        /// Item name
        /// </summary>
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        /// <summary>
        /// Item description
        /// </summary>
        public string ItemDesc
        {
            get { return itemDesc; }
            set { itemDesc = value; }
        }

        /// <summary>
        /// Item cost
        /// </summary>
        public decimal ItemCost
        {
            get { return itemCost; }
            set { itemCost = value; }
        }
    }
}
