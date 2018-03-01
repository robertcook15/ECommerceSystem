using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FindCustomer
{
    public partial class SearchCustomer : Form
    {
        public SearchCustomer()
        {
            InitializeComponent();
        }

        private SmallDatabase.SmallDatabaseEntities dbcontext =
            new SmallDatabase.SmallDatabaseEntities();
        private void SearchCustomer_Load(object sender, EventArgs e)
        {
            dbcontext.Customers
                .OrderBy(customer => customer.LastName)
                .ThenBy(customer => customer.FirstName)
                .Load();

            customerBindingSource.DataSource = dbcontext.Customers.Local;
        }

        private void lastNameButton_Click(object sender, EventArgs e)
        {
            var lastNameQuery =
                dbcontext.Customers
                .Where(customer => customer.LastName.StartsWith(lastNameTextBox.Text))
                .OrderBy(customer => customer.LastName)
                .ThenBy(customer => customer.FirstName)
                .Select(customer => customer);

            customerBindingSource.DataSource = lastNameQuery.ToList();
            customerBindingSource.MoveFirst();

            //bindingNavigatorAddNewItem.Enabled = false;
            //bindingNavigatorDeleteItem.Enabled = false;
        }

        private void countryButton_Click(object sender, EventArgs e)
        {
            var countryQuery =
                dbcontext.Customers
                .Where(place => place.Country.StartsWith(countryTextBox.Text))
                .Select(country => country);

            customerBindingSource.DataSource = countryQuery.ToList();
            customerBindingSource.MoveFirst();

            //bindingNavigatorAddNewItem.Enabled = false;
            //bindingNavigatorDeleteItem.Enabled = false;
        }

        private void refillButton_Click(object sender, EventArgs e)
        {
            dbcontext.Customers
                .OrderBy(customer => customer.LastName)
                .ThenBy(customer => customer.FirstName)
                .Load();

            customerBindingSource.DataSource = dbcontext.Customers.Local;
        }
    }
}
