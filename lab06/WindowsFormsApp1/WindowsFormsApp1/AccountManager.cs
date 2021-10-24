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
            // Xóa tất cả các dòng hiện tại 
            lvAccount.Items.Clear();

            // Đọc 1 dòng dữ liệu 
            while (reader.Read())
            {
                //Tạo một dòng mới trong ListView
                ListViewItem item = new ListViewItem(reader["id"].ToString());

                //Them một dòng mới vào ListVew
                lvAccount.Items.Add(item);


                // Bổ sung thông tin khác cho ListViewItem 
                item.SubItems.Add(reader["account"].ToString());
                item.SubItems.Add(reader["password"].ToString());
                item.SubItems.Add(reader["active"].ToString());

            }

        }

        private void xóaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // thiết lập lệnh truy vấn cho đối tương Command
            sqlCommand.CommandText = "delete from DanhSachTaiKhoan";

            //Mở kết nối tới csdl
            sqlConnection.Open();

            // thực thi lệnh bằng phương thức ExcuteReader
            int munOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đống kết nối 
            sqlConnection.Close();

            if (munOfRowsEffected == 1)
            {
                ListViewItem item = lvAccount.SelectedItems[0];
                lvAccount.Items.Remove(item);
                MessageBox.Show("Xóa nhóm món ăn thành công ");

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại");
            }
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
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";

            // Tạo đối tượng kết nối 
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select * from DanhSachTaiKhoan2 ";

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
            // Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // THiết lập lệnh truy vấn cho đối tượng Conmmad
            sqlCommand.CommandText = "update DanhSachTaiKhoan2 set account ='" + txtAccount.Text + "', password='" + txtPassword.Text + "', active ='" + txtAcctive.Text + "'where id ='" + txtStt.Text + "'";

            //Mở kết nối CSDL
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExcuteReader
            int munOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đống kết nối
            sqlConnection.Close();

            if (munOfRowsEffected == 1)
            {
                //Cập nhật dữ liệu trên listview
                ListViewItem item = lvAccount.SelectedItems[0];

                item.SubItems[1].Text = txtAccount.Text;
                item.SubItems[2].Text = txtPassword.Text;
                item.SubItems[3].Text = txtAcctive.Text;

                // Xóa các ô nhập 
                txtStt.Text = "";
                txtAccount.Text = "";
                txtPassword.Text = "";
                txtAcctive.Text = "";
                //disable các nút xóa và cập nhật 
                btnCapNhat.Enabled = false;
                MessageBox.Show("Cập nhật tài khoản thành công");

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
            }
        }

        private void lvAccount_Click(object sender, EventArgs e)
        {
            // lấy dòng được chọn trong ListView
            ListViewItem item = lvAccount.SelectedItems[0];

            // Hiển thị dữ liệu lên TextBox
            txtStt.Text = item.Text;
            txtAccount.Text = item.SubItems[1].Text;
            txtPassword.Text = item.SubItems[2].Text;
            txtAcctive.Text = item.SubItems[3].Text;

            //Hiển thị nút cập nhật và xóa 
            btnCapNhat.Enabled = true;
        }
    }
}
