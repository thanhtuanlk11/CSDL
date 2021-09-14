using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _1911170_ThongTinGiaoVien
{
    public partial class frmSearch : Form
    {
        public List<GiaoVien> dsGiaoVien;
        public GiaoVien gv;
    
        public frmSearch(QuanlyGiaoVien qlgv)
        {
            dsGiaoVien = qlgv.dsGV;
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {

        }

        private void rdIDGV_CheckedChanged(object sender, EventArgs e)
        {

            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                if (rdIDGV.Checked)
                {
                    label1.Text = rdIDGV.Text;
                }
            }
        }

        private void rdName_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                if (rdName.Checked)
                {
                    label1.Text = rdName.Text;
                }
            }
        }

        private void rdPhone_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioButton = (RadioButton)sender;
                if (rdPhone.Checked)
                {
                    label1.Text = rdPhone.Text;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var timkiem = txtSearch.Text;
            if (rdIDGV.Checked == true)
            {
                GiaoVien kq = dsGiaoVien.Find(x => x.MaSo.Trim() == timkiem.Trim());
                if (kq == null)
                {
                    MessageBox.Show("Không tìm thấy giáo viên có mã số " + timkiem, "Lỗi");
                }
                else
                {
                    frmTBGiaoVien frm = new frmTBGiaoVien();
                    frm.SetText(kq.ToString());
                    frm.ShowDialog();
                }
            }
            if (rdName.Checked == true)
            {
                GiaoVien kq = dsGiaoVien.Find(x => x.HoTen.ToLower().Trim() == timkiem.ToLower().Trim());
                if (kq == null)
                {
                    MessageBox.Show("Không tìm thấy giáo viên có họ tên " + timkiem, "Lỗi");
                }
                else
                {
                    frmTBGiaoVien frm = new frmTBGiaoVien();
                    frm.SetText(kq.ToString());
                    frm.ShowDialog();
                }
            }
            if (rdPhone.Checked == true)
            {
                GiaoVien kq = dsGiaoVien.Find(x => x.SoDT.Trim() == timkiem.Trim());
                if (kq == null)
                {
                    MessageBox.Show("Không tìm thấy giáo viên có số điện thoại " + timkiem, "Lỗi");
                }
                else
                {
                    frmTBGiaoVien frm = new frmTBGiaoVien();
                    frm.SetText(kq.ToString());
                    frm.ShowDialog();
                }
            }
        }
    }
}
