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
    public partial class frmVaiTro : Form
    {
        public frmVaiTro()
        {
            InitializeComponent();
        }

        private void dgvVaiTro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vaiTro_Load(object sender, EventArgs e)
        {
           
        }
        public void LoadAccount(string accountName)
        {
            // tạo chuỗi  kết nối tới cơ sở dữ liệu RestaurantManagerment
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tương command
            sqlCommand.CommandText = "select * from Account where AccountName = " + accountName;

            // mở kết nối đến csdl
            sqlConnection.Open();

            //// Gán tên nhóm sản phẩm cho tiêu đề
            //string catName = sqlCommand.ExecuteScalar().ToString();
            //this.Text = " Danh sách tài khoản :" + catName;

            sqlCommand.CommandText = " select * from RoleAccount where AccountName = " + accountName;

            // tạo đối tượng Dataadapter

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            // tạo database chứa dữ liệu 
            DataTable dt = new DataTable("RoleAccount");
            da.Fill(dt);

            // Hiển thị danh sách món ăn lên Form
            dgvVaiTro.DataSource = dt;

            // Đóng kết nối và giải phóng bộ nhớ 
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }
    }
}
