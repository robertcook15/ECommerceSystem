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
    public partial class ProductInfo : Form
    {
        public ProductInfo()
        {
            InitializeComponent();
        }

        private SmallDatabase.SmallDatabaseEntities dbcontext =
            new SmallDatabase.SmallDatabaseEntities();

        private void ProductInfo_Load(object sender, EventArgs e)
        {
            int supplierID = (int)this.Tag;

            var supplierIDQuery =
                dbcontext.Products
                .Where(id => id.SupplierId == supplierID);

            productBindingSource.DataSource = supplierIDQuery.ToList();



        }
    }
}
