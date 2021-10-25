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
    public partial class frmTable : Form
    {
        public frmTable()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // tạo chuỗi  kết nối tới cơ sở dữ liệu RestaurantManagerment
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";

            // Tạo đối tượng kết nối 
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = "select * from DanhSachBanAn ";

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
            lvTable.Items.Clear();

            // Đọc 1 dòng dữ liệu 
            while (reader.Read())
            {
                //Tạo một dòng mới trong ListView
                ListViewItem item = new ListViewItem(reader["ID"].ToString());

                //Them một dòng mới vào ListVew
                lvTable.Items.Add(item);


                // Bổ sung thông tin khác cho ListViewItem 
                item.SubItems.Add(reader["SoBan"].ToString());
                item.SubItems.Add(reader["SoTang"].ToString());

            }

        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            //Thiết lập lệnh truy vấn cho đối tượng Command 

            sqlCommand.CommandText = "insert into DanhSachBanAn values('" + txtStt.Text + "','" + txtTableMunber.Text + "','" + txtFloat.Text + "')";

            // mở kết nối đến cơ sở dữ liệu 
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExcuteReader
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            //Đóng kết nối 
            sqlConnection.Close();

            if (numOfRowsEffected == 1)
            {
                MessageBox.Show("Thêm bàn ăn thành công ");

                // Tải lại dữ liệu 
                btnLoad.PerformClick();

                //Xóa các ô nhập 
                txtStt.Text = "";
                txtTableMunber.Text = "";
                txtFloat.Text = "";


            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại ");
            }
        }


    }
}
