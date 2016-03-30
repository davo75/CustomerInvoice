using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIAssignment2
{
    public partial class InvoiceForm : Form
    {

        public CustomerForm parent;
        public string purpose; //add or edit

        public InvoiceForm()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            //tbInvoiceNum.Text = ((CustomerForm)this.Owner).InvoiceToSearch;
           
            if (purpose.Equals("Edit Invoice"))
            {
                tbInvoiceNum.Text = parent.InvoiceToSearch;
            }

        }
    }
}
