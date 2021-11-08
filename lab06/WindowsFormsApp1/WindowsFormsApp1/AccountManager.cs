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
 

        private void xóaTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // thiết lập lệnh truy vấn cho đối tương Command
            sqlCommand.CommandText = "delete from Account where AccountName = '" + txtName.Text + "'";

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

                // xóa ô nhập 
                txtName.Text = "";
                txtPassword.Text = "";
                txtFullName.Text = "";
                txtEmail.Text = "";
                txtCall.Text = "";
                dtpNgay.Value = DateTime.Now;
                MessageBox.Show("Xóa tài khoản thành công");

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại");
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            //Thiết lập lệnh truy vấn cho đối tượng Command 

            sqlCommand.CommandText = "insert into Account values('" + txtName.Text + "','" 
                                                            + txtPassword.Text + "','" 
                                                            + txtFullName.Text +"','"
                                                            +txtEmail.Text+"','"
                                                            +txtCall.Text+"','"
                                                            +dtpNgay.Value + "')";

            // mở kết nối đến cơ sở dữ liệu 
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExcuteReader
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            //Đóng kết nối 
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                MessageBox.Show("Thêm tài khoản mới thành công ");

                // Tải lại dữ liệu 
                btnLoadData.PerformClick();

                //Xóa các ô nhập 
                txtName.Text = "";
                txtPassword.Text = "";
                txtFullName.Text = "";
                txtEmail.Text = "";
                txtCall.Text = "";
                dtpNgay.Value = DateTime.Now;
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
        private void DisplayCatelory(SqlDataReader reader)
        {
            // Xóa tất cả các dòng hiện tại 
            lvAccount.Items.Clear();
            // Đọc 1 dòng dữ liệu 
            while (reader.Read())
            {
                //Tạo một dòng mới trong ListView
                ListViewItem item = new ListViewItem(reader["AccountName"].ToString());
                //Them một dòng mới vào ListVew
                lvAccount.Items.Add(item);
                // Bổ sung thông tin khác cho ListViewItem 
                item.SubItems.Add(reader["Password"].ToString());
                item.SubItems.Add(reader["FullName"].ToString());
                item.SubItems.Add(reader["Email"].ToString());
                item.SubItems.Add(reader["Tell"].ToString());
                item.SubItems.Add(reader["DateCreated"].ToString());
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // THiết lập lệnh truy vấn cho đối tượng Conmmad
            sqlCommand.CommandText = "update Account set Password='"+txtPassword.Text
                                        +"',FullName='"+txtFullName.Text
                                        +"',Email='"+txtEmail.Text
                                        +"',Tell='"+txtCall.Text
                                        +"',DateCreted='"+dtpNgay.Value
                                        +"'where AccountName='"+txtName.Text+"'";


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

                item.SubItems[1].Text = txtPassword.Text;
                item.SubItems[2].Text = txtFullName.Text;
                item.SubItems[3].Text = txtEmail.Text;
                item.SubItems[4].Text = txtCall.Text;
                item.SubItems[5].Text = dtpNgay.Text;


                // Xóa các ô nhập 
                txtName.Text = "";
                txtPassword.Text = "";
                txtFullName.Text = "";
                txtEmail.Text = "";
                txtCall.Text = "";
                dtpNgay.Value = DateTime.Now;
                

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
            
        }

        private void lvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lvAccount_Click_1(object sender, EventArgs e)
        {
            // lấy dòng được chọn trong ListView
            ListViewItem item = lvAccount.SelectedItems[0];

            // Hiển thị dữ liệu lên TextBox
            txtName.Text = item.Text;
            txtPassword.Text = item.SubItems[1].Text;
            txtFullName.Text = item.SubItems[2].Text;
            txtEmail.Text = item.SubItems[3].Text;
            txtCall.Text = item.SubItems[4].Text;
            dtpNgay.Text = item.SubItems[5].Text;
           
        }

        private void xóaTàiKhoảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // thiết lập lệnh truy vấn cho đối tương Command
            sqlCommand.CommandText = "delete from Account where AccountName = '" + txtName.Text + "'";

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

                // xóa ô nhập 
                txtName.Text = "";
                txtPassword.Text = "";
                txtFullName.Text = "";
                txtEmail.Text = "";
                txtCall.Text = "";
                dtpNgay.Value = DateTime.Now;
                MessageBox.Show("Xóa tài khoản thành công");

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại");
            }
        }

        private void xemDanhSáchVaiTròToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListViewItem item = lvAccount.SelectedItems[0];
            if (lvAccount.SelectedItems.Count > 0)
            {
                Role frm = new Role();
                frm.Show(this);
                frm.LoadRole();
            }
        }

        private void resetPassword_Click(object sender, EventArgs e)
        {
            string defaultPass = "123456";
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlCommand sqlComd = sqlConn.CreateCommand();

            sqlComd.CommandText = string.Format("UPDATE Account SET Password = '{1}' WHERE AccountName = '{0}' ",
                txtName.Text, defaultPass);

            sqlConn.Open();

            sqlComd.ExecuteNonQuery();
            MessageBox.Show("Reset mật khẩu thành công");
            btnLoadData.PerformClick();
            sqlConn.Close();
        }
    }
}
