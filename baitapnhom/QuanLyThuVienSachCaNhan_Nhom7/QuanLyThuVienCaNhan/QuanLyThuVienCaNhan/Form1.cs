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

namespace QuanLyThuVienCaNhan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void LoadListView()
        {
            string connectionString = @"Data Source=DESKTOP-RDFL65K\SQLEXPRESS;Initial Catalog=ThuVienCaNhan;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from Sach";
            connection.Open();
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            this.DisplayCatelory(sqlDataReader);
            connection.Close();
        }
        private void DisplayCatelory(SqlDataReader reader)
        {      
            lsvDanhSach.Items.Clear();     
            while (reader.Read())
            {              
                ListViewItem item = new ListViewItem(reader["MaSach"].ToString());            
                lsvDanhSach.Items.Add(item);
                item.SubItems.Add(reader["TenSach"].ToString());
                item.SubItems.Add(reader["NamXB"].ToString());
                item.SubItems.Add(reader["TacGia"].ToString());
                item.SubItems.Add(reader["NXB"].ToString());
                item.SubItems.Add(reader["TrangThai"].ToString());
                item.SubItems.Add(reader["KeSach"].ToString());
                item.SubItems.Add(reader["VTNgan"].ToString());
                item.SubItems.Add(reader["MaTL"].ToString());

            }

        }

        private void tsmiMuonSach_Click(object sender, EventArgs e)
        {
            frmMuonTra frmMuon = new frmMuonTra();
            frmMuon.ShowDialog();
        }

        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void tsmThongKe_Click(object sender, EventArgs e)
        {
            frmThongKe frmThongKe = new frmThongKe();
            frmThongKe.ShowDialog();
        }

        private void tsmThem_Click(object sender, EventArgs e)
        {
            frmSach frmSach = new frmSach();
            frmSach.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void lsvDanhSach_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            
        }

        private void lsvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            frmSach frm = new frmSach();
            frm.ShowDialog();
        }
    }
}
