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
            try
            {
                string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "EXEC GetBillsByDay @Date";

                cmd.Parameters.Add("@Date", SqlDbType.SmallDateTime);
                cmd.Parameters["@Date"].Value = dtpDateTime.Value.ToShortDateString();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlConnection.Open();
                adapter.Fill(dt);
                cmd.CommandText = "SELECT SUM(Amount) FROM Bills WHERE CheckoutDate = @Date";
                setNameColumns(dt);
                var doanhThu = cmd.ExecuteScalar();
                lblDoanhThu.Text = doanhThu.ToString() + " VND";

                dgvBill.DataSource = dt;
                sqlConnection.Close();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message, "SQL Error");
            }
        }

        private void dgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void setNameColumns(DataTable table)
        {
            dgvBill.DataSource = table;
            dgvBill.Columns[0].ReadOnly = true;

            dgvBill.Columns[0].HeaderCell.Value = "Mã hóa đơn";
            dgvBill.Columns[1].HeaderCell.Value = "Tên hóa đơn";
            dgvBill.Columns[2].HeaderCell.Value = "Mã bàn";
            dgvBill.Columns[3].HeaderCell.Value = "Tổng cộng";
            dgvBill.Columns[4].HeaderCell.Value = "Giảm giá";
            dgvBill.Columns[5].HeaderCell.Value = "Tax";
            dgvBill.Columns[6].HeaderCell.Value = "Trạng thái";
            dgvBill.Columns[7].HeaderCell.Value = "Ngày bán";
            dgvBill.Columns[8].HeaderCell.Value = "Tài khoản";
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
