using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            DialogResult dlg= MessageBox.Show("Bạn có chắc xóa sinh viên được chọn?", "Xóa sinh viên", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dlg == DialogResult.OK)
            {
                for (i = count; i >= 0; i--)
                {
                    lvitem = this.LVSinhVien.Items[i];
                    if (lvitem.Checked)
                        qlsv.Xoa(lvitem.SubItems[0].Text, SoSanhTheoMa);
                }
                this.LoadListView();
            }
            else
            {
                return;
            }
        }
        private void LoadSV(List<SinhVien> dsSV)
        {
            this.LVSinhVien.Items.Clear();
            qlsv.danhSach.ForEach(sv => ThemSV(sv));
        }
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemSV frmThem = new frmThemSV(qlsv,LVSinhVien);
            frmThem.ShowDialog();
            LoadSV(frmThem.ListSV);
            
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LuuFile();
            Application.Exit();
        }
        private async void LuuFile()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "*|.xlsx", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (TextWriter tw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8))
                    {
                        foreach (ListViewItem item in LVSinhVien.Items)
                        {
                            await tw.WriteLineAsync(item.SubItems[0].Text + "\t"
                                + item.SubItems[1].Text + "\t"
                                + item.SubItems[2].Text + "\t"
                                + item.SubItems[3].Text + "\t"
                                + item.SubItems[4].Text + "\t"
                                + item.SubItems[5].Text + "\t"
                                + item.SubItems[6].Text + "\t");
                        }
                    }
                }
            }
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
