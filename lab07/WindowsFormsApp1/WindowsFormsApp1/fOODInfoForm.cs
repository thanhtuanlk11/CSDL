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
    public partial class fOODInfoForm : Form
    {
        public fOODInfoForm()
        {
            InitializeComponent();
        }

        private void fOODInfoForm_Load(object sender, EventArgs e)
        {
            this.InitValues();
        }
        private void InitValues()
        {
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "select ID,Name from Category";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            conn.Open();
            // Lấy dữ liệu từ csdl đưa vào datatable 
            adapter.Fill(ds, "Category");

            // Hiển thị nhóm món ăn 
            cbbCatName.DataSource = ds.Tables["Category"];
            cbbCatName.DisplayMember = "Name";
            cbbCatName.ValueMember = "ID";
            // đóng kết nôi và giải phóng bộ nhwos 

            conn.Dispose();
            conn.Close();
        }
        private void ResetText()
        {
            txtFoodID.ResetText();
            txtName.ResetText();
            txtNotes.ResetText();
            txtUnit.ResetText();
            cbbCatName.ResetText();
            nudPrice.ResetText();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "execute InsertFood @id OUTPUT, @name,@unit,@foodCategoryID,@price,@notes";

                // Thêm tham số vào đối tượng command
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@foodCategoryId", SqlDbType.Int);
                cmd.Parameters.Add("@price", SqlDbType.Int);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);
                cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                //Truyền giá trị vào thủ tục qua tham số
                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@unit"].Value = txtUnit.Text;
                cmd.Parameters["@foodCategoryId"].Value = cbbCatName.SelectedValue;
                cmd.Parameters["@price"].Value = nudPrice.Text;
                cmd.Parameters["@notes"].Value = txtNotes.Text;

                conn.Open();
                int numRowAffected = cmd.ExecuteNonQuery();
                // thông báo kêt quả
                if (numRowAffected > 0)
                {
                    string foodID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show("Successfully adding new food. Food ID = " + foodID, "Message");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Adding food failed");
                }
                conn.Close();
                conn.Dispose();
            }
            // Bắt lỗi sql và các lỗi khác
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }
        public void DisplayFoodInfo(DataRowView rowView)
        {
            try
            {
                txtFoodID.Text = rowView["ID"].ToString();
                txtName.Text = rowView["Name"].ToString();
                txtUnit.Text = rowView["Unit"].ToString();
                txtNotes.Text = rowView["Notes"].ToString();
                nudPrice.Text = rowView["Price"].ToString();

                cbbCatName.SelectedIndex = -1;

                //Chọn món ăn tương ứng 
                for(int index =0; index < cbbCatName.Items.Count; index++)
                {
                    DataRowView cat = cbbCatName.Items[index] as DataRowView;
                    if (cat["ID"].ToString() == rowView["FoodCategoryID"].ToString())
                    {
                        cbbCatName.SelectedIndex = index;
                        break;
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
                this.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "excute UpdateFood @id, @name, @unit, @foodCategoryID, @price,@notes";

                // Thêm tham số vào đối tượng command
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@unit", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@foodCategoryId", SqlDbType.Int);
                cmd.Parameters.Add("@price", SqlDbType.Int);
                cmd.Parameters.Add("@notes", SqlDbType.NVarChar, 3000);

                //Tuyền giá trị vào thủ tục qua tham số 
                cmd.Parameters["@id"].Value = int.Parse(txtFoodID.Text);
                cmd.Parameters["@name"].Value = txtName.Text;
                cmd.Parameters["@unit"].Value = txtUnit.Text;
                cmd.Parameters["@foodCategoryId"].Value = cbbCatName.SelectedValue;
                cmd.Parameters["@price"].Value = nudPrice.Text;
                cmd.Parameters["notes"].Value = txtNotes.Text;

                conn.Open();
                int numRowAffected = cmd.ExecuteNonQuery();
                // thông báo kết quả 
                if (numRowAffected > 0)
                {
                    MessageBox.Show("Successfully adating food", "Message");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("Updating food failed");
                }
                conn.Close();
                conn.Dispose();
            }
            catch(SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL error");
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message, "error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //// tạo chuỗi  kết nối tới cơ sở dữ liệu RestaurantManagerment
            //string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            //SqlConnection sqlConnection = new SqlConnection(connectionString);

            //// Tạo đối tượng thực thi lệnh 
            //SqlCommand cmd = sqlConnection.CreateCommand();

            //// mở kết nối đến csdl
            //sqlConnection.Open();

            //for (int i = 0; i < dgvFood.Rows.Count - 1; i++)
            //{
            //    int id = (int)dgvFood.Rows[i].Cells["ID"].Value;
            //    cmd.CommandText = "select * from Food WHERE ID = " + id;
            //    var checkID = cmd.ExecuteScalar();

            //    if (checkID == null)
            //    {
            //        string query = string.Format(" insert into Food(Name, Unit, FoodCategoryID, Price, Notes) " +
            //        "values (N'{0}', N'{1}', {2}, {3}, N'{4}')",
            //        dgvFood.Rows[i].Cells["Name"].Value,
            //        dgvFood.Rows[i].Cells["Unit"].Value,
            //        categoryID,
            //        dgvFood.Rows[i].Cells["Price"].Value,
            //        dgvFood.Rows[i].Cells["Notes"].Value.ToString());
            //        cmd.CommandText = query;
            //        MessageBox.Show("Thêm mới thành công");
            //    }
            //    else
            //    {
            //        string query = string.Format(" update Food set Name = N'{0}', Unit = N'{1}', FoodCategoryID = {2}, Price = {3}, Notes = N'{4}' WHERE ID = {5}",
            //        dgvFood.Rows[i].Cells["Name"].Value,
            //        dgvFood.Rows[i].Cells["Unit"].Value,
            //        categoryID,
            //        dgvFood.Rows[i].Cells["Price"].Value,
            //        dgvFood.Rows[i].Cells["Notes"].Value.ToString(),
            //        id.ToString());
            //        cmd.CommandText = query;
            //        MessageBox.Show("Cập nhật thành công");
            //    }
            //}

            //sqlConnection.Close();
        }
    }
}
