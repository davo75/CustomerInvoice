﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIAssignment2
{
    class Customer
    {

        private string custNum;
        private string custFirstName;
        private string custLastName;
        private string custStreet;
        private string custSuburb;
        private string custState;
        private string custPostCode;
        private string custContactNum;
        private string custCompany;
        public Invoice[] invoices;
        private int invoiceCount;

        
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
            this.invoiceCount = 1;
            invoices = new Invoice[5];
        }

        public int InvoiceCount
        {
            get { return invoiceCount; }
            set { invoiceCount = value; }
        }
        

        public void addInvoice(Invoice invoice)
        {
            
        }

        //just getters and setter below here

        public string CustNum
        {
            get { return custNum; }
            set { custNum = value; }
        }

        public string CustFirstName
        {
            get { return custFirstName; }
            set { custFirstName = value; }
        }

        public string CustLastName
        {
            get { return custLastName; }
            set { custLastName = value; }
        }

        public string CustStreet
        {
            get { return custStreet; }
            set { custStreet = value; }
        }

        public string CustSuburb
        {
            get { return custSuburb; }
            set { custSuburb = value; }
        }

        public string CustState
        {
            get { return custState; }
            set { custState = value; }
        }


        public string CustPostCode
        {
            get { return custPostCode; }
            set { custPostCode = value; }
        }


        public string CustContactNum
        {
            get { return custContactNum; }
            set { custContactNum = value; }
        }

        public string CustCompany
        {
            get { return custCompany; }
            set { custCompany = value; }
        }     

    }
}