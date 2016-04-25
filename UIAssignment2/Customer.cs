/// <summary>
/// The Customer class holds information about a customer. A customer can have up
/// 10 invoices.
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
    class Customer
    {
        /// <summary>
        /// customer number
        /// </summary>
        private string custNum;
        /// <summary>
        /// customer first name
        /// </summary>
        private string custFirstName;
        /// <summary>
        /// customer last name
        /// </summary>
        private string custLastName;
        /// <summary>
        /// customer street address
        /// </summary>
        private string custStreet;
        /// <summary>
        /// customer suburb
        /// </summary>
        private string custSuburb;
        /// <summary>
        /// customer state
        /// </summary>
        private string custState;
        /// <summary>
        /// customer post code
        /// </summary>
        private string custPostCode;
        /// <summary>
        /// customer contact number
        /// </summary>
        private string custContactNum;
        /// <summary>
        /// customer company
        /// </summary>
        private string custCompany;
        /// <summary>
        /// customer invoices
        /// </summary>
        public Invoice[] invoices;
        /// <summary>
        /// number of invoices allowed per customer
        /// </summary>
        private const int NUM_INVOICES = 10;
        /// <summary>
        /// number of invoices allowed per customer
        /// </summary>
        private int invoiceCounter = 0;

        
        /// <summary>
        /// Constructor sets the customer number, name, address, contact number and initialises array of invoices
        /// </summary>
        /// <param name="custNum">Customer number</param>
        /// <param name="custFirstName">Customer first name</param>
        /// <param name="custLastName">Customer last name</param>
        /// <param name="custStreet">Customer steet address</param>
        /// <param name="custSuburb">Customer street address</param>
        /// <param name="custState">Customer state</param>
        /// <param name="custPostCode">Customer post code</param>
        /// <param name="custContactNum">Customer contact number</param>
        /// <param name="custCompany">Customer company</param>
        
        public Customer(string custNum, string custFirstName, string custLastName, string custStreet, string custSuburb, string custState, string custPostCode, string custContactNum, string custCompany)
        {
            this.CustNum = custNum;
            this.CustFirstName = custFirstName;
            this.CustLastName = custLastName;
            this.CustStreet = custStreet;
            this.CustSuburb = custSuburb;
            this.CustState = custState;
            this.CustPostCode = custPostCode;
            this.CustContactNum = custContactNum;
            this.CustCompany = custCompany;
            
            //initialise invoice array
            invoices = new Invoice[NUM_INVOICES];
        }

        /// <summary>
        /// Removes an invoice from the customer's list of invoices
        /// </summary>
        /// <param name="invoiceToDelete">The invoice to remove</param>
        public void removeInvoice(Invoice invoiceToDelete)
        {
            //convert array to list
            List<Invoice> list = invoices.ToList<Invoice>();
            //remove the invoice
            list.Remove(invoiceToDelete);
            //convert list back to array
            invoices = list.ToArray();
            //decrement invoice counter
            invoiceCounter--;
        }

        /// <summary>
        /// Adds an invoice to the customer's list of invoices
        /// </summary>
        /// <param name="invoice">The invoice to add</param>
        public void addInvoice(Invoice invoice)
        {
            //add the invoice to list
            invoices[invoiceCounter] = invoice;
            //incremenet the invoice counter
            invoiceCounter++;
            
        }

        /// <summary>
        /// Searches for an invoice
        /// </summary>
        /// <param name="invoiceNum">The invoice number to seach for</param>
        /// <returns>The invoice or null if no invoice is found</returns>
        public Invoice findInvoice(string invoiceNum)
        {
            //flag set to true if invoice found
            bool found = false;
            //initialise index position, set to position of invoice in list if found
            int index = -1;

            //search through the invoices
            for (int i = 0; i < invoices.Length; i++)
            {
                //if invoice number matched
                if (invoices[i].InvoiceNum.Equals(invoiceNum))
                {
                    //set flag and set position of invoice
                    found = true;
                    index = i;
                    break;
                }
            }
            //return the invoice if found else return null
            if (found)
            {
                return invoices[index];
            }            
            else
            {
                return null;
            }

        }

        /// <summary>
        /// The invoice count
        /// </summary>
        public int InvoiceCounter
        {
            get { return invoiceCounter; }
            set { invoiceCounter = value; }
        }
        /// <summary>
        /// The cutomer number
        /// </summary>
        public string CustNum
        {
            get { return custNum; }
            set { custNum = value; }
        }

        /// <summary>
        /// The customer first name
        /// </summary>
        public string CustFirstName
        {
            get { return custFirstName; }
            set { custFirstName = value; }
        }

        /// <summary>
        /// The cutomer last name
        /// </summary>
        public string CustLastName
        {
            get { return custLastName; }
            set { custLastName = value; }
        }

        /// <summary>
        /// The customer street address
        /// </summary>
        public string CustStreet
        {
            get { return custStreet; }
            set { custStreet = value; }
        }

        /// <summary>
        /// Customer suburb
        /// </summary>
        public string CustSuburb
        {
            get { return custSuburb; }
            set { custSuburb = value; }
        }

        /// <summary>
        /// Customer state
        /// </summary>
        public string CustState
        {
            get { return custState; }
            set { custState = value; }
        }

        /// <summary>
        /// Customer post code
        /// </summary>
        public string CustPostCode
        {
            get { return custPostCode; }
            set { custPostCode = value; }
        }

        /// <summary>
        /// Customer contact number
        /// </summary>
        public string CustContactNum
        {
            get { return custContactNum; }
            set { custContactNum = value; }
        }

        /// <summary>
        /// Customer company
        /// </summary>
        public string CustCompany
        {
            get { return custCompany; }
            set { custCompany = value; }
        }     

    }
}
