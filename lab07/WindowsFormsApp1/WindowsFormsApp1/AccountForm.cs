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
            try
            {
                string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "execute InsertAccount @accountname ,@password,@fullname,@email,@tell,@datecreated";

                // Thêm tham số vào đối tượng command
                cmd.Parameters.Add("@accountname", SqlDbType.NVarChar , 3000);
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 300);
                cmd.Parameters.Add("@fullname", SqlDbType.NVarChar, 300);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar,300);
                cmd.Parameters.Add("@tell", SqlDbType.NVarChar,300);
                cmd.Parameters.Add("@datecreated", SqlDbType.SmallDateTime);

                //Truyền giá trị vào thủ tục qua tham số
                cmd.Parameters["@accountname"].Value = txtName.Text;
                cmd.Parameters["@password"].Value = txtPassword.Text;
                cmd.Parameters["@fullname"].Value = txtFullName.Text;
                cmd.Parameters["@email"].Value = txtEmail.Text;
                cmd.Parameters["@tell"].Value = txtCall.Text;
                cmd.Parameters["@datecreated"].Value = DateTime.Now.ToString();
                
                conn.Open();
                int numRowAffected = cmd.ExecuteNonQuery();
                // thông báo kêt quả
                if (numRowAffected == 1)
                {
                    string accountname = cmd.Parameters["@accountname"].Value.ToString();
                    MessageBox.Show("Thêm tài khoản thành công. Tên tài khoản có tên = " + accountname, "Message");
                    btnLoadAccount.PerformClick();
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thất bại");
                }
                conn.Close();
                conn.Dispose();
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

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvAccount.Rows[e.RowIndex];

                txtName.Text = row.Cells[0].Value.ToString();
                txtPassword.Text = row.Cells[1].Value.ToString();
                txtFullName.Text = row.Cells[2].Value.ToString();
                txtEmail.Text = row.Cells[3].Value.ToString();
                txtCall.Text = row.Cells[4].Value.ToString();
                dtpNgay.Text = row.Cells[5].Value.ToString();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "execute UpdateAccount @accountname, @password, @fullname, @email, @tell,@datecreated";

                // Thêm tham số vào đối tượng command
                cmd.Parameters.Add("@accountname", SqlDbType.NVarChar,1000);
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@fullname", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@tell", SqlDbType.NVarChar, 100);
                cmd.Parameters.Add("@datecreated", SqlDbType.SmallDateTime);

                //Tuyền giá trị vào thủ tục qua tham số 
                cmd.Parameters["@accountname"].Value = txtName.Text;
                cmd.Parameters["@password"].Value = txtPassword.Text;
                cmd.Parameters["@fullname"].Value = txtName.Text;
                cmd.Parameters["@email"].Value = txtEmail.Text;
                cmd.Parameters["@tell"].Value = txtCall.Text;
                cmd.Parameters["@datecreated"].Value = DateTime.Now.ToString();

                conn.Open();
                int numRowAffected = cmd.ExecuteNonQuery();
                // thông báo kết quả 
                if (numRowAffected == 1)
                {
                    MessageBox.Show("cập nhập tài khoản thành công", "Message");
                    this.ResetText();
                }
                else
                {
                    MessageBox.Show("cập nhật account lỗi");
                }
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException exception)
            {
                MessageBox.Show(exception.Message, "SQL error");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "error");
            }
        }
    }
}
