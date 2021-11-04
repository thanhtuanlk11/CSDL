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
    public partial class AccountManager : Form
    {
        public AccountManager()
        {
            InitializeComponent();
        }

        private void AccountManager_Load(object sender, EventArgs e)
        {
            
        }
        private void DisplayCatelory(SqlDataReader reader)
        {
            

        }

        private void xóaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng kết nối 
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            //Thiết lập lệnh truy vấn cho đối tượng Command 

            sqlCommand.CommandText = "insert into DanhSachTaiKhoan2 values('"+txtStt.Text+"','"+txtAccount.Text+"','"+txtPassword.Text+"','"+txtAcctive.Text+"')";

            // mở kết nối đến cơ sở dữ liệu 
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExcuteReader
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            //Đóng kết nối 
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                MessageBox.Show("Thêm tài khoản thành công ");

                // Tải lại dữ liệu 
                btnLoadData.PerformClick();

                //Xóa các ô nhập 
                txtStt.Text = "";
                txtAccount.Text = "";
                txtPassword.Text = "";
                txtAcctive.Text = "";

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại ");
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            // tạo chuỗi  kết nối tới cơ sở dữ liệu RestaurantManagerment
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";

            // Tạo đối tượng kết nối 
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select * from Account ";

            // TThiết lập lệnh truy vấn cho đối tượng Command
            //string query = "SELECT ID, Name, Type FROM Category";

            // Mở kết nối đến cơ sở dữ liệu 
            sqlConnection.Open();
            //thực thi lệnh bằng phương thức ExcuteReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            // GỌi hàm hiển thị dữ liệu lên màn hình 
            this.DisplayCatelory(sqlDataReader);

            //Đóng kết nối
            sqlConnection.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            
               
        }

        private void lvAccount_Click(object sender, EventArgs e)
        {
            
        }

        private void lvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
