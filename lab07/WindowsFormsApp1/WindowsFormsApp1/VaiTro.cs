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
    public partial class VaiTro : Form
    {
        public VaiTro()
        {
            InitializeComponent();
        }

       
        private void VaiTro_Load(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "select * from RoleAccount ";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlConnection.Open();
            adapter.Fill(dt);

            sqlConnection.Close();
            sqlConnection.Dispose();

            dgvVaiTro.DataSource = dt;

        }

        private void dgvVaiTro_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
