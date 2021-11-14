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
        private void setNameColumns(DataTable table)
        {
            dgvVaiTro.DataSource = table;

            dgvVaiTro.Columns[1].HeaderCell.Value = "Mã vai trò";
            dgvVaiTro.Columns[2].HeaderCell.Value = "Tên vai trò";
            dgvVaiTro.Columns[3].HeaderCell.Value = "Đường dẫn";
           
        }
        public void LoadRole()
        {
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            sqlCommand.CommandText = $"Select * From Role";

            sqlConnection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                foreach (DataGridViewRow item in dgvVaiTro.Rows)
                {
                    if (reader["RoleID"].ToString() == item.ToString())
                    {

                    }
                }
            }
            sqlConnection.Close();

            sqlConnection.Open();
            adapter.Fill(dt);
            setNameColumns(dt);
            dgvVaiTro.DataSource = dt;
            sqlConnection.Close();
        }

        private void VaiTro_Load(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = $"select * from Role";
            
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
