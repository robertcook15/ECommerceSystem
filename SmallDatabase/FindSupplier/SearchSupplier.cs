using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindSupplier
{
    public partial class SearchSupplier : Form
    {
        public SearchSupplier()
        {
            InitializeComponent();
        }

        private SmallDatabase.SmallDatabaseEntities dbcontext =
            new SmallDatabase.SmallDatabaseEntities();

        private void companyButton_Click(object sender, EventArgs e)
        {
             var companyNameQuery =
                dbcontext.Suppliers
                .Where(supplier => supplier.CompanyName.StartsWith(supplierTextBox.Text))
                .Select(supplier => supplier);

            supplierBindingSource.DataSource = companyNameQuery.ToList();
        }

        private void supplierDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 9)
            {
                int i = e.RowIndex;
                DataGridViewRow row = supplierDataGridView.Rows[i];
                DataGridViewCell cell = row.Cells[0];
                int supplierID = (int)cell.Value;

                Form viewProductForm = new ProductInfo();
                viewProductForm.Tag = supplierID;
                viewProductForm.ShowDialog();
            }
        }
    }
}
