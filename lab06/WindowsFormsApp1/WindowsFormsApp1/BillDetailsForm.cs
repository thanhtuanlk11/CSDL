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
    public partial class BillDetailsForm : Form
    {
        int ID;
        public BillDetailsForm()
        {
            InitializeComponent();
        }
        public void LoadBillDetail(int id)
        {
            this.ID = id;

            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();

            command.CommandText = "SELECT Name FROM Bills WHERE ID = " + id;
            connection.Open();
            string billName = command.ExecuteScalar().ToString();
            this.Text = billName + " " + id;

            string query = string.Format(
                " SELECT Name, Unit, Price, Quantity, Price * Quantity as Total FROM BillDetails" +
                " JOIN Food ON BillDetails.FoodID = Food.ID" +
                " WHERE BillDetails.InvoiceID = {0}", id);
            command.CommandText = query;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Food");
            adapter.Fill(dt);

            dgvBillDetail.DataSource = dt;
            dgvBillDetail.Columns[0].ReadOnly = true;

            connection.Dispose();
            adapter.Dispose();
        }
        private void BillDetailsForm_Load(object sender, EventArgs e)
        {

        }

        private void dgvBillDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
