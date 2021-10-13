using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.MobileControls;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        QuanLySinhVien qlsv;
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
            for (int i = 0; i < this.clbMonHoc.Items.Count; i++)
                if (clbMonHoc.GetItemChecked(i))
                    cn.Add(clbMonHoc.Items[i].ToString());
            sv.MonHoc = cn;
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
            foreach (SinhVien sv in qlsv.danhSach)
            {
                ThemSV(sv);
            }
        }
        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MSSV.CompareTo(obj1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
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
        private void XoaForm()
        {
            mtxtMaSo.Text = "";
            txtHoTen.Text = "";
            txtTen.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            cboLop.Text = "";
            mtxtSoCMND.Text = "";
            mkbSDT.Text = "";
            txtDiaChi.Text = "";
            rdNam.Checked = false;
            rdNu.Checked = false;
            for (int i = 0; i < clbMonHoc.Items.Count; i++)
                clbMonHoc.SetItemChecked(i, false);
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            SinhVien kq = qlsv.Tim(sv.MSSV, delegate (object obj1, object obj2)
            {
                return (obj2 as SinhVien).MSSV.CompareTo(obj1.ToString());
            });
            if (kq != null)
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi thêm dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                qlsv.Them(sv);
                this.LoadListView();
            }
        }
        

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            bool kqsua;
            kqsua = qlsv.Sua(sv, sv.MSSV, SoSanhTheoMa);
            if (kqsua)
            {
                this.LoadListView();
            }
        }
        private void LoadSV(List<SinhVien> dsSV)
        {
            this.lvSinhVien.Items.Clear();
            qlsv.danhSach.ForEach(sv => ThemSV(sv));
        }

        private void btnTmKiem_Click(object sender, EventArgs e)
        {
            tuychon frm = new tuychon(qlsv,lvSinhVien);
            frm.ShowDialog();
            LoadSV(frm.listSV);

        }

        private void lvSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.lvSinhVien.Items.Count - 1;
            for (i = count; i >= 0; i--)
            {
                lvitem = this.lvSinhVien.Items[i];
                if (lvitem.Checked)
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }
            this.LoadListView();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();
            bool kqsua;
            kqsua = qlsv.Sua(sv, sv.MSSV, SoSanhTheoMa);
            if (kqsua)
            {
                this.LoadListView();
            }
        }
    }
}
