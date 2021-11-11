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

        private void lvAccount_Click(object sender, EventArgs e)
        {
            // lấy dòng được chọn trong ListView
            ListViewItem item = lvAccount.SelectedItems[0];

            // Hiển thị dữ liệu lên TextBox
            txtName.Text = item.Text;
            txtPassword.Text = item.SubItems[1].Text;
            txtFullName.Text = item.SubItems[2].Text;
            txtEmail.Text = item.SubItems[3].Text;
            txtCall.Text = item.SubItems[4].Text;
            dtpNgay.Text = item.SubItems[5].Text;

        }
    }
}
