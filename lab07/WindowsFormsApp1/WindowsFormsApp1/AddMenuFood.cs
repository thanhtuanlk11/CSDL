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
    public partial class AddMenuFood : Form
    {
        public Form1 frm; 
        public AddMenuFood()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // tạo chuỗi  kết nối tới cơ sở dữ liệu RestaurantManagerment
                string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                //// Tạo đối tượng thực thi lệnh 
                SqlCommand cmd = sqlConnection.CreateCommand();
                


                cmd.CommandText = "execute InsertCategory @id OUTPUT,@name,@type";
                // Thêm tham số vào đối tượng commadn
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 300);
                cmd.Parameters.Add("@type", SqlDbType.Int);

                cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                // Truyền giá trị thủ tục qua tham số 
                cmd.Parameters["@name"].Value = txtAddMenuFood.Text;
                cmd.Parameters["@type"].Value = txtType.Text;

                // mở kết nối đến csdl
                sqlConnection.Open(); 
                int numRowAffected = cmd.ExecuteNonQuery();
                // Thông báo kết quả 
                if (numRowAffected > 0)
                {
                    string foodID = cmd.Parameters["@id"].Value.ToString();
                    MessageBox.Show("thêm nhóm món ăn thành công. Mã nhóm = " +foodID,"Message");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("thêm thất bại");
                }
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            // Bắt lỗi sql và các lỗi khác
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL Error");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error");
            }
        }

        private void AddMenuFood_Load(object sender, EventArgs e)
        {
           
        }
        
    }
}
