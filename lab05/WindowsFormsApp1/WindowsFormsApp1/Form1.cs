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
    public partial class Form1 : Form
    {
        private QuanlySinhVien qlsv;
        public Form1()
        {
            InitializeComponent();
        }

        //lây thoogn tin 
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> cn = new List<string>();
            sv.MSSV = this.mtxtMaSo.Text;
            sv.HoVaTenLot = this.txtHoTen.Text;
            sv.Ten = this.txtTen.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.Lop = cboLop.Text;
            sv.SoCMND = this.mtxtSoCMND.Text;
            sv.SDT = this.mkbSDT.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            return sv;
        }
        //Láy thông tin từ listView lên để hiển thị khi click 
        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = lvitem.SubItems[0].Text;
            sv.HoVaTenLot = lvitem.SubItems[1].Text;
            sv.Ten = lvitem.SubItems[2].Text;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;
            sv.SoCMND = lvitem.SubItems[5].Text;
            sv.SDT = lvitem.SubItems[6].Text;
            sv.DiaChi = lvitem.SubItems[7].Text;
         
            return sv;
        }
        private void ThietLapThongtin(SinhVien sv)
        {
            this.mtxtMaSo.Text = sv.MSSV;
            this.txtHoTen.Text = sv.HoVaTenLot;
            this.txtTen.Text = sv.Ten;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.cboLop.Text = sv.Lop;
            this.mtxtSoCMND.Text = sv.SoCMND;
            this.mkbSDT.Text = sv.SDT;
            this.txtDiaChi.Text = sv.DiaChi;
 
        }
        //Thêm sv vào ListView
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MSSV);
            lvitem.SubItems.Add(sv.HoVaTenLot);
            lvitem.SubItems.Add(sv.Ten);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());         
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.SoCMND);
            lvitem.SubItems.Add(sv.SDT);
            lvitem.SubItems.Add(sv.DiaChi);
            this.lvSinhVien.Items.Add(lvitem);
        }
        private void LoadListView()
        {
            this.lvSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.DanhSach)
            {
                ThemSV(sv);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            qlsv = new QuanlySinhVien();
            qlsv.DocTuFile();
            LoadListView();
        }

        //private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int count = this.lvSinhVien.SelectedItems.Count;
        //    if (count > 0)
        //    {
        //        ListViewItem lvitem = this.lvSinhVien.SelectedItems[0];
        //        SinhVien sv = GetSinhVienLV(lvitem);
        //        ThietLapThongtin(sv);
        //    }
        //}

        private void lvSinhVien_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int count = this.lvSinhVien.CheckedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.lvSinhVien.CheckedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongtin(sv);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
                DialogResult dlr = MessageBox.Show("Lưu thay đổi", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dlr == DialogResult.OK)
                {
                   
                    Application.Exit();
                }
                else if (dlr == DialogResult.Cancel)
                {
                    Application.Exit();
                }
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }
    }
}
