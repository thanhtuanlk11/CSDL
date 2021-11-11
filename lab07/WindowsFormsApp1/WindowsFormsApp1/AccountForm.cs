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
    public partial class AccountForm : Form
    {
        public AccountForm()
        {
            InitializeComponent();
        }

        private void AccountForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadAccount_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from Account";
            
            connection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            this.DisplayCatelory(sqlDataReader);
            connection.Close();
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
    }
}
