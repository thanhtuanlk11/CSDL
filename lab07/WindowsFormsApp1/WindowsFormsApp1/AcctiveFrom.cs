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
    public partial class AcctiveFrom : Form
    {
        public AcctiveFrom()
        {
            InitializeComponent();
        }

        private void AcctiveFrom_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from RoleAccount";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable accountable = new DataTable();
            connection.Open();
            adapter.Fill(accountable);
            connection.Close();
            connection.Dispose();

            dgvAcctive.DataSource = accountable;

        }
    }
}
