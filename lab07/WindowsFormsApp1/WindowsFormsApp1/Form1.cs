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
        private DataTable foodTable;
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadCatelory()
        {
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select ID,Name from Category";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            conn.Open();

            adapter.Fill(dt);
            conn.Close();
            // giải phóng bộ nhớ
            conn.Dispose();

            cbbCatelory.DataSource = dt;
            //Hiển thị tên nhóm sản phẩm
            cbbCatelory.DisplayMember = "Name";
            // Nhưng khi lấy giá trị là lấy ID của nhóm 
            cbbCatelory.ValueMember = "ID";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.LoadCatelory();
        }

        private void cbbCatelory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCatelory.SelectedIndex == -1) return;

            string connecttionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connecttionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select * from food where FoodCategoryID = @categoryId";

            // Truyền tham số 
            cmd.Parameters.Add("@categoryId", SqlDbType.Int);

            if(cbbCatelory.SelectedValue is DataRowView)
            {
                DataRowView rowView = cbbCatelory.SelectedValue as DataRowView;
                cmd.Parameters["@categoryId"].Value = rowView["ID"];
            }
            else
            {
                cmd.Parameters["@categoryId"].Value = cbbCatelory.SelectedValue;
            }
            // Tạo bộ điều khiển dữ liệu
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            foodTable = new DataTable();

            // Mở kết nối 
            conn.Open();

            // Lấy dữ liệu 
            adapter.Fill(foodTable);

            conn.Close();
            conn.Dispose();

            // Đựa dữ liệu vào data girdView
            dgvFoodList.DataSource = foodTable;

            // Tính số lượng mẫu tin
            lblQuantity.Text = foodTable.Rows.Count.ToString();
            lblCatName.Text = cbbCatelory.Text;

        }

        private void smCalculateQuantity_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select @numSaleFood = sum(Quantity) form BillDetails where FoodID = @foodId";
            // Lấy thông tín ản phẩm được chọn 
            if(dgvFoodList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvFoodList.SelectedRows[0];
                DataRowView rowView = selectedRow.DataBoundItem as DataRowView;

                // Truyền tham số 
                cmd.Parameters.Add("@foodId", SqlDbType.Int);
                cmd.Parameters["@foodId"].Value = rowView["ID"];

                cmd.Parameters.Add("@numSaleFood", SqlDbType.Int);
                cmd.Parameters["@numSaleFood"].Direction = ParameterDirection.Output;

                // mở kết nối sql
                conn.Open();
                // thực thi truy vấn
                cmd.ExecuteNonQuery();

                string result = cmd.Parameters["@numSaleFood"].Value.ToString();
                MessageBox.Show("Tổng số lượng món" + rowView["Name"] + "đã bán là" + result + "" + rowView["Unit"]);

                conn.Close();

            }
            cmd.Dispose();
            conn.Dispose();

        }
    }
}
