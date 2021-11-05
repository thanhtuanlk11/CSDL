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
        int categoryID;
        public frmFood()
        {
            InitializeComponent();
        }

        public void LoadFood(int categoryID)
        {
            // tạo chuỗi  kết nối tới cơ sở dữ liệu RestaurantManagerment
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn cho đối tương command
            sqlCommand.CommandText = "select Name from Category where ID = " + categoryID;

            // mở kết nối đến csdl
            sqlConnection.Open();

            // Gán tên nhóm sản phẩm cho tiêu đề
            string catName = sqlCommand.ExecuteScalar().ToString();
            this.Text = " Danh sách các món ăn thuộc nhóm :" + catName;

            sqlCommand.CommandText = " select * from Food where FoodCategoryID = " + categoryID;

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
            if (dgvFood.SelectedRows.Count == 0) return;
            var selected = dgvFood.SelectedRows[0];
            string foodID = selected.Cells[0].Value.ToString();
            //Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh 
            SqlCommand cmd = sqlConnection.CreateCommand();
            string query = "delete from Food where ID =" + foodID;
            sqlConnection.Open();
            cmd.CommandText = "delete from BillDetails where FoodID = " + foodID;
            cmd.ExecuteNonQuery();

            cmd.CommandText = query;
            int numOfRowsEffected = cmd.ExecuteNonQuery();
            if (numOfRowsEffected == 1)
            {
                dgvFood.Rows.Remove(selected);
                MessageBox.Show("Xóa món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi");
                return;
            }



        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // tạo chuỗi  kết nối tới cơ sở dữ liệu RestaurantManagerment
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand cmd = sqlConnection.CreateCommand();

            // mở kết nối đến csdl
            sqlConnection.Open();

            for (int i = 0; i < dgvFood.Rows.Count - 1; i++)
            {
                int id = (int)dgvFood.Rows[i].Cells["ID"].Value;
                cmd.CommandText = "SELECT * FROM Food WHERE ID = " + id;
                var checkID = cmd.ExecuteScalar();

                if (checkID == null)
                {
                    string query = string.Format(" insert into Food(Name, Unit, FoodCategoryID, Price, Notes) " +
                    "values (N'{0}', N'{1}', {2}, {3}, N'{4}')",
                    dgvFood.Rows[i].Cells["Name"].Value,
                    dgvFood.Rows[i].Cells["Unit"].Value,
                    categoryID,
                    dgvFood.Rows[i].Cells["Price"].Value,s
                    dgvFood.Rows[i].Cells["Notes"].Value.ToString());
                    cmd.CommandText = query;
                    MessageBox.Show("Thêm mới thành công");
                }
                else
                {
                    string query = string.Format(" update Food set Name = N'{0}', Unit = N'{1}', FoodCategoryID = {2}, Price = {3}, Notes = N'{4}' WHERE ID = {5}",
                    dgvFood.Rows[i].Cells["Name"].Value,
                    dgvFood.Rows[i].Cells["Unit"].Value,
                    categoryID,
                    dgvFood.Rows[i].Cells["Price"].Value,
                    dgvFood.Rows[i].Cells["Notes"].Value.ToString(),
                    id.ToString());
                    cmd.CommandText = query;
                    MessageBox.Show("Cập nhật thành công");
                }
            }

            sqlConnection.Close();
        }

        private void dgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
