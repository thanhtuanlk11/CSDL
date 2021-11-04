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
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "select * from Table123 ";
            sqlConnection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            this.DisplayCatelory(sqlDataReader);

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
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Status"].ToString());
                item.SubItems.Add(reader["Capacity"].ToString());

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // THiết lập lệnh truy vấn cho đối tượng Conmmad
            sqlCommand.CommandText = "update DanhSachBanAn set SoBan ='" + txtTableMunber.Text + "', SoTang='" + txtFloat.Text +"'where ID ='" + txtStt.Text + "'";

            //Mở kết nối CSDL
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExcuteReader
            int munOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đống kết nối
            sqlConnection.Close();

            if (munOfRowsEffected == 1)
            {
                //Cập nhật dữ liệu trên listview
                ListViewItem item = lvTable.SelectedItems[0];

                item.SubItems[1].Text = txtTableMunber.Text;
                item.SubItems[2].Text = txtFloat.Text;
               

                // Xóa các ô nhập 
                txtStt.Text = "";
                txtTableMunber.Text = "";
                txtFloat.Text = "";
              
                //disable các nút xóa và cập nhật 
                btnUpdate.Enabled = false;
                MessageBox.Show("Cập nhật bàn ăn thành công");

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
            }
        }

        private void lvTable_Click(object sender, EventArgs e)
        {
            // lấy dòng được chọn trong ListView
            ListViewItem item = lvTable.SelectedItems[0];

            // Hiển thị dữ liệu lên TextBox
            txtStt.Text = item.Text;
            txtTableMunber.Text = item.SubItems[1].Text;
            txtFloat.Text = item.SubItems[2].Text;
         

            //Hiển thị nút cập nhật và xóa 
            btnUpdate.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // thiết lập lệnh truy vấn cho đối tương Command
            sqlCommand.CommandText = "delete from DanhSachBanAn where ID = '" + txtStt.Text + "'";

            //Mở kết nối tới csdl
            sqlConnection.Open();

            // thực thi lệnh bằng phương thức ExcuteReader
            int munOfRowsEffected = sqlCommand.ExecuteNonQuery();
            
            // Đống kết nối 
            sqlConnection.Close();

            if (munOfRowsEffected == 1)
            {
                ListViewItem item = lvTable.SelectedItems[0];
                lvTable.Items.Remove(item);

                // xóa ô nhập 
                txtStt.Text = "";
                txtTableMunber.Text = "";
                txtFloat.Text = "";

                //MessageBox.Show("Xóa bàn ăn thành công ");

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại");
            }
        }

        private void lvTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
