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
    public partial class BuilDetails : Form
    {
        public BuilDetails()
        {
            InitializeComponent();
        }

        private void Columns(DataTable table)
        {
            dgvBillDetail.DataSource = table;
            dgvBillDetail.Columns[0].ReadOnly = true;
            dgvBillDetail.Columns[1].HeaderCell.Value = "Mã hóa đơn";
            dgvBillDetail.Columns[2].HeaderCell.Value = "Mã món ăn";
            dgvBillDetail.Columns[3].HeaderCell.Value = "Số lượng";
        }
        public void LoadBuilDetails(string builID)
        {
             try
            {
                string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                sqlCommand.CommandText = "EXEC GetBillDetailsByID @ID";

                sqlCommand.Parameters.Add("@ID", SqlDbType.Int);
                sqlCommand.Parameters["@ID"].Value = builID;

                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                sqlConnection.Open();
                adapter.Fill(dt);
                Columns(dt);
                dgvBillDetail.DataSource = dt;
                dgvBillDetail.Columns[0].ReadOnly = true;

                sqlConnection.Close();

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "SQL Error");
            }
}
        private void BuilDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
