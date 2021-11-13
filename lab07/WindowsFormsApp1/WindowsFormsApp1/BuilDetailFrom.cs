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
    public partial class BuilDetailFrom : Form
    {
        public BuilDetailFrom()
        {
            InitializeComponent();

        }

        private void dgvBuilDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadBuid()
        {
            string connectionstring = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionstring);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "Select * from BillDetails";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            sqlConnection.Open();
            adapter.Fill(dataTable);
            sqlConnection.Close();
            sqlConnection.Dispose();

            dgvBuilDetail.DataSource = dataTable;


        }

        private void BuilDetailFrom_Load(object sender, EventArgs e)
        {
            LoadBuid();
        }
    }
}
