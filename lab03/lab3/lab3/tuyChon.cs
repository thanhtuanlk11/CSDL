using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab3
{
    public partial class tuyChon : Form
    {
        public List<SinhVien> listSV;
      
        QuanLySinhVien qlsv;
        ListView listView;

        public tuyChon(QuanLySinhVien qlsv,ListView listView)
        {
            InitializeComponent();
            this.qlsv = qlsv;
            this.listView = listView;
        }
        
        private void tuyChon_Load(object sender, EventArgs e)
        {
            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (rdID.Checked == true)
            {
                qlsv.DanhSach.Sort((x, y) => x.MaSo.CompareTo(y.MaSo));
                Close();
            }
            if (rdName.Checked == true)
            {
                qlsv.DanhSach.Sort((x, y) => x.HoTen.CompareTo(y.HoTen));
                Close();
            }
            if (rdLop.Checked == true)
            {
                qlsv.DanhSach.Sort((x, y) => x.NgaySinh.CompareTo(y.NgaySinh));
                Close();
            }
        }

        private void btnSreach_Click(object sender, EventArgs e)
        {
            SinhVien sv = null;

            if (rdID.Checked)
                sv = qlsv.DanhSach.Find(s => s.MaSo == txtInput.Text);
            else if (rdName.Checked)
                sv = qlsv.DanhSach.Find(s => s.HoTen == txtInput.Text);
            else if (rdLop.Checked)
            {
                try
                {
                    sv = qlsv.DanhSach.Find(s => s.NgaySinh.Day == int.Parse(txtInput.Text));
                }
                catch
                {
                    if (txtInput is null)
                    {
                        MessageBox.Show("Kiểm tra lại thông tin nhập" + listView.Items.Count, "Lỗi nhập thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            


            if (sv is null)
            {
                MessageBox.Show("Kiểm tra lại thông tin nhập", "Lỗi nhập thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            ListViewItem item = new ListViewItem(sv.MaSo);
            item.SubItems.Add(sv.HoTen);
            item.SubItems.Add(sv.NgaySinh.ToString("dd/MM/yyyy"));
            item.SubItems.Add(sv.DiaChi);
            item.SubItems.Add(sv.Lop);
            item.SubItems.Add(sv.GioiTinh ? "Nam" : "Nữ");
            item.SubItems.Add(String.Join(", ", sv.ChuyenNganh));
            item.SubItems.Add(sv.Hinh);
            listView.Items.Clear();
            listView.Items.Add(item);
        }

        private void rdLop_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
