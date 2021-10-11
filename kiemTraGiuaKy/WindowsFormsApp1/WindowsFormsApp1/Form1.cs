using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
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
        static string filePath = "E:\\sinhVien.json";

        List<SinhVien> sinhVienList;
        private ListView listView;
        public readonly QuanLySinhVien qlsv;
        private const string PlaceHolderText = "Nhập thông tin sinh viên cần tìm !!!!!";
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
        public SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MSSV = lvitem.SubItems[0].Text;
            sv.HoVaTenLot = lvitem.SubItems[1].Text;
            sv.Ten = lvitem.SubItems[2].Text;
            
            sv.SoDienThoai = lvitem.SubItems[3].Text;
            sv.Lop = lvitem.SubItems[4].Text;
            sv.Khoa = lvitem.SubItems[5].Text;
            return sv;
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
        public int SoSanhTheoMa(object obj1, object obj2)
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
        public void LoadSV(List<SinhVien> dsSV)
        {
            this.LVSinhVien.Items.Clear();
      
            qlsv.danhSach.ForEach(sv => ThemSV(sv));
            
        }
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemSV frmThem = new frmThemSV(qlsv,LVSinhVien);
            frmThem.Show();
            LoadSV(frmThem.ListSV);  
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LuuFile();
           
        }
        private async void LuuFile()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "SinhVien (.xlsx)|*.xlsx",InitialDirectory="D:\\", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                    Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet ws = (Worksheet)app.ActiveSheet;
                    app.Visible = false;
                    int i = 1, j = 1;

                    foreach ( ListViewItem item in LVSinhVien.Items)
                    {
                        ws.Cells[1, 1] = "Mã số Sinh Viên";
                        ws.Cells[1, 2] = " Họ và tên lót";
                        ws.Cells[1, 3] = "Tên";
                        ws.Cells[1, 4] = " Giới tính";
                        ws.Cells[1, 5] = " Ngày sinh";
                        ws.Cells[1, 6] = " Số điện thoại";
                        ws.Cells[1, 7] = " Lớp";
                        ws.Cells[1, 8] = " Khoa";
                        ws.Cells[i, j] = item.Text.ToString();
                        foreach (ListViewItem.ListViewSubItem item1 in item.SubItems)
                        {
                            ws.Cells[i, j] = item1.Text.ToString();
                            j++;
                        }
                        j = 1;
                        i++;
                    }
                    wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing);
                    MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);
                }
            }
        }
        
        public static void luuDanhSach(List<SinhVien> ds)
        {
            StreamWriter writer = new StreamWriter(filePath);
            string json = JsonConvert.SerializeObject(ds);
            writer.WriteLine(json);
            writer.Close();

        }
        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            luuDanhSach(sinhVienList);
        }

        private void realodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadListView();
        }
        

        private void LVSinhVien_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            frmThemSV frm = new frmThemSV(qlsv, listView);
            int count = this.LVSinhVien.CheckedItems.Count;
            if (count > 0)
            {                 
                ListViewItem lvitem = this.LVSinhVien.CheckedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                frm.mtxtMaSo.Text = sv.MSSV;
                frm.txtHoTen.Text = sv.HoVaTenLot;
                frm.txtTen.Text = sv.Ten;
                frm.cboKhoa.Text = sv.Khoa;
                frm.cboLop.Text = sv.Lop;
                frm.txtDiaChi.Text = sv.DiaChi;
                frm.Show();
            }
        }

        private void tvwKhoa_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SinhVien sv = null;

                if (rdMaSo.Checked)
                    sv = qlsv.danhSach.Find(s => s.MSSV == txtTim.Text);
                else if (rdHoTen.Checked)
                    sv = qlsv.danhSach.Find(s => (s.HoVaTenLot + " " + s.Ten) == txtTim.Text);
                else if (rdSDT.Checked)
                    sv = qlsv.danhSach.Find(s => s.SoDienThoai == txtTim.Text);

                if (sv is null)
                {
                    MessageBox.Show("Không tìm thấy, vui lòng kiểm tra lại!", "Lỗi nhập thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ListViewItem lvitem = new ListViewItem(sv.MSSV);
                lvitem.SubItems.Add(sv.HoVaTenLot);
                lvitem.SubItems.Add(sv.Ten);
                lvitem.SubItems.Add("nam");
                lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
                lvitem.SubItems.Add(sv.SoDienThoai);
                lvitem.SubItems.Add(sv.Lop);
                lvitem.SubItems.Add(sv.Khoa);
                this.LVSinhVien.Items.Add(lvitem);
                LVSinhVien.Items.Clear();
                LVSinhVien.Items.Add(lvitem);
            }
        }

        private void LVSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
