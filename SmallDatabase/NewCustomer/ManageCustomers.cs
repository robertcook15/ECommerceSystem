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

namespace NewCustomer
{
    public partial class ManageCustomers : Form
    {
        public ManageCustomers()
        {
            InitializeComponent();
        }

        private SmallDatabase.SmallDatabaseEntities dbcontext = 
            new SmallDatabase.SmallDatabaseEntities();
        private void ManageCustomers_Load(object sender, EventArgs e)
        {
            dbcontext.Customers
                .OrderBy(customer => customer.LastName)
                .ThenBy(customer => customer.FirstName)
                .Load();

            customerBindingSource.DataSource = dbcontext.Customers.Local;
        }

        private void customerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            Validate();
            customerBindingSource.EndEdit();
            try
            {
                dbcontext.SaveChanges();
            }
            catch(DbEntityValidationException)
            {
                MessageBox.Show("FirstName and LastName must contain values", "Entity Validation Exception");
            }
        }
    }
}
