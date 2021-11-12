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
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable accountable = new DataTable();
            connection.Open();
            adapter.Fill(accountable);
            connection.Close();
            connection.Dispose();

            dgvAccount.DataSource = accountable;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "execute InsertAccount @accountName OUTPUT,@password,@fullname,@email,@tell,@datecreated";

            // thêm tham số vào đối tượng command
            cmd.Parameters.Add("@accountname", SqlDbType.NVarChar, 300);
            cmd.Parameters.Add("@password", SqlDbType.NVarChar, 300);
            cmd.Parameters.Add("@fullname", SqlDbType.NVarChar, 300);
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 300);
            cmd.Parameters.Add("@tell", SqlDbType.NVarChar, 300);
            cmd.Parameters.Add("@datecreated", SqlDbType.NVarChar, 300);

            cmd.Parameters["@accountname"].Direction = ParameterDirection.Output;
            // Truyền giá trị vào thủ tục qua tham số
            cmd.Parameters["@accountname"].Value = txtName.Text;
            cmd.Parameters["@password"].Value = txtPassword.Text;
            cmd.Parameters["@email"].Value = txtEmail.Text;
            cmd.Parameters["@tell"].Value = txtCall.Text;
            cmd.Parameters["@datecreated"].Value = dtpNgay.Value;

            sqlConnection.Open();
            int numOfAffected = cmd.ExecuteNonQuery();
            // thông báo kết quả 
            if (numOfAffected > 0)
            {
                string AccountName = cmd.Parameters["@accountname"].Value.ToString();
                MessageBox.Show("Thêm tài khoản thành công với tên là = " + AccountName,"Message");
                this.ResetText();

            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            sqlConnection.Close();
            sqlConnection.Dispose();
        }
    }
}
