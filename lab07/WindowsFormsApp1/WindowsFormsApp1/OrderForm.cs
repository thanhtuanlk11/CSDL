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
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void btn_LoadBill_Click(object sender, EventArgs e)
        {
            LoadBill();
        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadBill()
        {
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "select * from Bills where CheckoutDate = @date";
            cmd.Parameters.Add("@date", SqlDbType.DateTime);
            cmd.Parameters["@date"].Value = DateTime.Parse(dtpDateTime.Value.ToString("dd/MM/yyyy"));

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlConnection.Open();

            adapter.Fill(dt);
            sqlConnection.Close();
            sqlConnection.Dispose();

            dgvBill.DataSource = dt;


        }
        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BuilDetailFrom frm = new BuilDetailFrom();
            frm.Show();
         
        }
        
    }
}
