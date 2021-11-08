using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Role : Form
    {
        public Role()
        {
            InitializeComponent();
        }
        public void LoadRole()
        {
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT a.AccountName, r.RoleName " +
                " from Role r, RoleAccount ra, Account a" +
                " Where a.AccountName = ra.AccountName and r.ID = ra.RoleID and a.AccountName = '" + "'";

            connection.Open();

            this.Text = "Danh sách role cua tai khoan ";

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable table = new DataTable("Role");
            adapter.Fill(table);

            dgvRole.DataSource = table;

            // Prevent user to edit ID
            dgvRole.Columns[0].ReadOnly = true;

            connection.Close();
        }
        private void dgvRole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Role_Load(object sender, EventArgs e)
        {
            LoadRole();
        }
    }
}
