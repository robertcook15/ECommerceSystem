using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newCustomerForm = new NewCustomer.ManageCustomers();
            newCustomerForm.MdiParent = this;
            newCustomerForm.Show();
        }

        private void findCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form findCustomerForm = new FindCustomer.SearchCustomer();
            findCustomerForm.MdiParent = this;
            findCustomerForm.Show();
        }

        private void addNewSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newSupplierForm = new NewSupplier.ManageSuppliers();
            newSupplierForm.MdiParent = this;
            newSupplierForm.Show();
        }

        private void findSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form findSupplierForm = new FindSupplier.SearchSupplier();
            findSupplierForm.MdiParent = this;
            findSupplierForm.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
