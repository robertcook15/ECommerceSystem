using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewSupplier
{
    public partial class ManageSuppliers : Form
    {
        public ManageSuppliers()
        {
            InitializeComponent();
        }

        private SmallDatabase.SmallDatabaseEntities dbcontext =
            new SmallDatabase.SmallDatabaseEntities();
        private void supplierBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            supplierBindingSource.EndEdit();
            try
            {
                dbcontext.SaveChanges();
            }
            catch (DbEntityValidationException)
            {
                MessageBox.Show("CompanyName must contain values", "Entity Validation Exception");
            }
        }

        private void ManageSuppliers_Load(object sender, EventArgs e)
        {
            dbcontext.Suppliers
                .OrderBy(location => location.City)
                .ThenBy(company => company.CompanyName)
                .Load();

            supplierBindingSource.DataSource = dbcontext.Suppliers.Local;
        }
    }
}
