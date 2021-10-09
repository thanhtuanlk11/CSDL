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
    public partial class tuychon : Form
    {
        public List<SinhVien> listSV;
      
        QuanLySinhVien qlsv;
        ListView listView;
        public tuychon(QuanLySinhVien qlsv, ListView listView)
        {
            InitializeComponent();
            this.qlsv = qlsv;
            this.listView = listView;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSreach_Click(object sender, EventArgs e)
        {
            SinhVien sv = null;

            if (rdID.Checked)
                sv = qlsv.danhSach.Find(s => s.MSSV == txtInput.Text);
            else if (rdName.Checked)
                sv = qlsv.danhSach.Find(s => s.Ten == txtInput.Text);
            else if (rdLop.Checked)
            {
                try
                {
                    sv = qlsv.danhSach.Find(s => s.Lop == txtInput.Text);
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


            
            ListViewItem lvitem = new ListViewItem(sv.MSSV);
            lvitem.SubItems.Add(sv.HoVaTenLot);
            lvitem.SubItems.Add(sv.Ten);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.SoCMND);
            lvitem.SubItems.Add(sv.SDT);
            lvitem.SubItems.Add(sv.DiaChi);
            this.listView.Items.Add(lvitem); listView.Items.Clear();
            listView.Items.Add(lvitem);
        }

        private void tuychon_Load(object sender, EventArgs e)
        {

        }
    }
    
}
