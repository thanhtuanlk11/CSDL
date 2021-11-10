using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddMenuFood : Form
    {
        public AddMenuFood()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // tạo chuỗi  kết nối tới cơ sở dữ liệu RestaurantManagerment
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh 
            SqlCommand cmd = sqlConnection.CreateCommand();
            //cmd.CommandText = "insert into Category(Name,[Type])" + "values(N'" + txtName.Text + "', " + txtType.Text + ")";

            // mở kết nối đến csdl
            sqlConnection.Open();



            sqlConnection.Close();
        }
    }
}
