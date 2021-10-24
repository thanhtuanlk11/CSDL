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
    public partial class frmFood : Form
    {
        public frmFood()
        {
            InitializeComponent();
        }

        private void dgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadFood(int categoryID)
        {
            // tạo chuỗi  kết nối tới cơ sở dữ liệu RestaurantManagerment
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tương command
            sqlCommand.CommandText = "select TenLoaiMonAn from ThongTinMonAn where MaLoai = " + categoryID;

            // mở kết nối đến csdl
            sqlConnection.Open();

            // Gán tên nhóm sản phẩm cho tiêu đề
            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text = " Danh sách các món ăn thuộc nhóm :" + catName;

            sqlCommand.CommandText = " select * from DanhSachMonAn where FoodCateloryID = " + categoryID;

            // tạo đối tượng Dataadapter

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);

            // tạo database chứa dữ liệu 
            DataTable dt = new DataTable("Food");
            da.Fill(dt);

            // Hiển thị danh sách món ăn lên Form
            dgvFood.DataSource = dt;

            // Đóng kết nối và giải phóng bộ nhớ 
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();     
        }

        private void frmFood_Load(object sender, EventArgs e)
        {

        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // thiết lập lệnh truy vấn cho đối tương Command
            sqlCommand.CommandText = "select * from DanhSachMonA";

            //Mở kết nối tới csdl
            sqlConnection.Open();

            if (this.dgvFood.SelectedRows.Count > 0)
            {
                dgvFood.Rows.RemoveAt(this.dgvFood.SelectedRows[0].Index);
                MessageBox.Show("Xóa nhóm món ăn thành công ");
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra, vui lòng thử lại");
            }
            // Đống kết nối 
            sqlConnection.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // tạo chuỗi  kết nối tới cơ sở dữ liệu RestaurantManagerment
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=QLMonAn;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // mở kết nối đến csdl
            sqlConnection.Open();

            sqlCommand.CommandText = " select * from DanhSachMonAn where FoodCateloryID = ";

            // tạo đối tượng Dataadapter
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(ds);

            // Hiển thị danh sách món ăn lên Form
            dgvFood.DataSource = ds.Tables[0];
            dgvFood.Refresh();
            // Đóng kết nối và giải phóng bộ nhớ 
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }

       
    }
}
