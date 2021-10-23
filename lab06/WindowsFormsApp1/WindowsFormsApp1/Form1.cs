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
    public partial class Form1 : Form
    {
        public Form1()
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
            sqlCommand.CommandText = "select * from ThongTinMonAn ";

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
        // hàm displayCatelory 
        private void DisplayCatelory(SqlDataReader reader)
        {
            // Xóa tất cả các dòng hiện tại 
            lvCatelory.Items.Clear();

            // Đọc 1 dòng dữ liệu 
            while (reader.Read())
            {
                //Tạo một dòng mới trong ListView
                ListViewItem item = new ListViewItem(reader["MaLoai"].ToString());

                //Them một dòng mới vào ListVew
                lvCatelory.Items.Add(item);


                // Bổ sung thông tin khác cho ListViewItem 
                item.SubItems.Add(reader["TenLoaiMonAn"].ToString());
                item.SubItems.Add(reader["Loai"].ToString());

            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            //Thiết lập lệnh truy vấn cho đối tượng Command 

            sqlCommand.CommandText = "insert into ThongTinMonAn values('" + txtID.Text + "','" + txtName.Text + "','" + txtType.Text + "')";

            // mở kết nối đến cơ sở dữ liệu 
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExcuteReader
            int numOfRowsEffected = sqlCommand.ExecuteNonQuery();

            //Đóng kết nối 
            sqlConnection.Close();

            if(numOfRowsEffected == 1)
            {
                MessageBox.Show("Thêm món ăn thành công ");

                // Tải lại dữ liệu 
                btnLoad.PerformClick();

                //Xóa các ô nhập 
                txtName.Text = "";
                txtType.Text = "";
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại ");
            }
        }

        private void lvCatelory_Click(object sender, EventArgs e)
        {
            // lấy dòng được chọn trong ListView
            ListViewItem item = lvCatelory.SelectedItems[0];

            // Hiển thị dữ liệu lên TextBox
            txtID.Text = item.Text;
            txtName.Text = item.SubItems[1].Text;
            txtType.Text = item.SubItems[2].Text == "0" ? "thức uống " : "Đồ ăn";

            //Hiển thị nút cập nhật và xóa 
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // THiết lập lệnh truy vấn cho đối tượng Conmmad
            sqlCommand.CommandText = "update ThongTinMonAn set TenLoaiMonAn ='"+txtName.Text+"', Loai='"+txtType.Text +"'where MaLoai ='"+txtID.Text+"'";

            //Mở kết nối CSDL
            sqlConnection.Open();

            // Thực thi lệnh bằng phương thức ExcuteReader
            int munOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đống kết nối
            sqlConnection.Close();

            if(munOfRowsEffected == 1)
            {
                //Cập nhật dữ liệu trên listview
                ListViewItem item = lvCatelory.SelectedItems[0];

                item.SubItems[1].Text = txtName.Text;
                item.SubItems[2].Text = txtType.Text;

                // Xóa các ô nhập 
                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";
                //disable các nút xóa và cập nhật 
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MessageBox.Show("Cập nhật nhóm món ăn thành công");

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // thiết lập lệnh truy vấn cho đối tương Command
            sqlCommand.CommandText = "delete from ThongTinMonAn where MaLoai = '"+txtID.Text+"'";

            //Mở kết nối tới csdl
            sqlConnection.Open();

            // thực thi lệnh bằng phương thức ExcuteReader
            int munOfRowsEffected = sqlCommand.ExecuteNonQuery();

            // Đống kết nối 
            sqlConnection.Close();

            if(munOfRowsEffected == 1)
            {
                ListViewItem item = lvCatelory.SelectedItems[0];
                lvCatelory.Items.Remove(item);

                // xóa ô nhập 
                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";

                // Disable nút xóa và cập nhật 
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MessageBox.Show("Xóa nhóm món ăn thành công ");

            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại");
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if (lvCatelory.SelectedItems.Count > 0)
                btnDelete.PerformClick();
        }

        private void tsmViewFood_Click(object sender, EventArgs e)
        {
            if (txtID.Text !="")
            {
                frmFood frm = new frmFood();
                frm.Show(this);
                frm.LoadFood(Convert.ToInt32(txtID.Text));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
