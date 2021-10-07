using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<SinhVien> sinhVienList;
        public readonly QuanLySinhVien qlsv;

        public Form1(QuanLySinhVien quanLySinhVien)
        {
             qlsv = quanLySinhVien;
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            ShowTreeOnTreeView(qlsv.GetNew());
            sinhVienList = new List<SinhVien>();
            qlsv.DocTuFile();
            LoadListView();
        }
        //Thêm sv vào ListView
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MSSV);
            lvitem.SubItems.Add(sv.HoVaTenLot);
            lvitem.SubItems.Add(sv.Ten);
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.SoDienThoai);
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.Khoa);
            this.LVSinhVien.Items.Add(lvitem);
        }
        //Hiển thị thông tin SV vào listView
        public void LoadListView()
        {         
            this.LVSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.danhSach)
            {
                ThemSV(sv);
            }
            
        }
        private void ShowTreeOnTreeView(List<Khoa> khoas)
        {
            tvwKhoa.Nodes.Clear();
            LVSinhVien.Controls.Clear();
            foreach (var khoa in khoas)
            {
                var khoaNode = tvwKhoa.Nodes.Add(khoa.Name);
                foreach (var lop in khoa.Lops)
                {
                    khoaNode.Nodes.Add(lop.Name);
                }

            }
            tvwKhoa.ExpandAll();
        }
        private int SoSanhTheoMa(object obj1, object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MSSV.CompareTo(obj1);
        }

        private void xóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.LVSinhVien.Items.Count - 1;
            for (i = count; i >= 0; i--)
            {
                lvitem = this.LVSinhVien.Items[i];
                if (lvitem.Checked)
                    qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
            }
            this.LoadListView();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemSV frmThem = new frmThemSV();
            frmThem.ShowDialog();
        }
    }
}
