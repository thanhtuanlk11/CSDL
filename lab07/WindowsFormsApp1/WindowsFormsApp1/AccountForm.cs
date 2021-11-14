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
                cmd.Parameters.Add("@accountname", SqlDbType.NVarChar , 100);
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 200);
                cmd.Parameters.Add("@fullname", SqlDbType.NVarChar, 1000);
                cmd.Parameters.Add("@email", SqlDbType.NVarChar,1000);
                cmd.Parameters.Add("@tell", SqlDbType.NVarChar,200);
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
              
                    MessageBox.Show("Thêm tài khoản thành công");
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
                cmd.Parameters["@fullname"].Value = txtFullName.Text;
                cmd.Parameters["@email"].Value = txtEmail.Text;
                cmd.Parameters["@tell"].Value = txtCall.Text;
                cmd.Parameters["@datecreated"].Value = DateTime.Now.ToString();

                conn.Open();
                int numRowAffected = cmd.ExecuteNonQuery();
                // thông báo kết quả 
                if (numRowAffected == 1)
                {
                    
                    MessageBox.Show("cập nhập tài khoản thành công", "Message");
                    btnLoadAccount.PerformClick();
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

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAccount.SelectedRows.Count == 0) return;
            var selected = dgvAccount.SelectedRows[0];
            
            //Tạo đối tượng kết nối 
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=RestaurantManagement;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Tạo đối tượng thực thi lệnh 
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandText = "delete from Account where AccountName = '" + txtName.Text + "'";

            sqlConnection.Open();
            
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
            int numOfRowsEffected = cmd.ExecuteNonQuery();
            if (numOfRowsEffected == 1)
            {
                dgvAccount.Rows.Remove(selected);
                MessageBox.Show("Xóa món ăn thành công");
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi");
                return;
            }
        }

        private void xemDanhSáchVaiTròToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VaiTro frm = new VaiTro();
            frm.ShowDialog();
        }
    }
}
