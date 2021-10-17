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
using WindowsFormsApp1.IO;
using WindowsFormsApp1.Model;
using Application = System.Windows.Forms.Application;
using app = Microsoft.Office.Interop.Excel.Application;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        static string filePath = "E:\\sinhVien.json";
        List<SinhVien> sinhVienList;
        private ListView listView;
        private NewSinhVienDataSourch _NewSinhVienDataSourch;
        private const string PlaceHolderText = "Nhập thông tin sinh viên cần tìm !!!!!";
        public Form1()
        {
            _NewSinhVienDataSourch = new NewSinhVienDataSourch();
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowTreeOnTreeView(_NewSinhVienDataSourch.GetKhoa());
            SetUpSearchInputText();
         
        }
        //Thêm sv vào ListView
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MSSV);
            lvitem.SubItems.Add(sv.HoVaTenLot);
            lvitem.SubItems.Add(sv.Ten);
            string gt = "Nữ";
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.SoDienThoai);
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.Khoa);
            this.LVSinhVien.Items.Add(lvitem);
        }
        private void tvwKhoa_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                var sinhViens = _NewSinhVienDataSourch.GetSinhVien(e.Node.Parent.Text, e.Node.Text);
                LoadListView(sinhViens);
            }
        }
        //Hiển thị thông tin SV vào listView
        public void LoadListView(List<SinhVien> sinhViens)
        {         
            LVSinhVien.Items.Clear();
            foreach (SinhVien sv in sinhViens)
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
            if(lvitem.SubItems[3].Text =="Nam")
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[4].Text);
            sv.SoDienThoai = lvitem.SubItems[5].Text;
            sv.Lop = lvitem.SubItems[6].Text;
            sv.Khoa = lvitem.SubItems[7].Text;
            return sv;
        }
        private void ShowTreeOnTreeView(List<Khoa> khoas)
        {
            tvwKhoa.Nodes.Clear();
            foreach (var khoa in khoas)
            {
                var khoanode = tvwKhoa.Nodes.Add(khoa.Ten);
                foreach (var cls in khoa.Lops)
                {
                    khoanode.Nodes.Add(cls.Ten);
                }

            }
            tvwKhoa.ExpandAll();
        }

       

        private void xóaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            DialogResult dlg= MessageBox.Show("Bạn có chắc xóa sinh viên được chọn?", "Xóa sinh viên", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dlg == DialogResult.OK)
            {
                string k = tvwKhoa.SelectedNode.Parent.Text;
                string l = tvwKhoa.SelectedNode.Text;



                var listDe = _NewSinhVienDataSourch.GetKhoa();
                Khoa khoa = listDe.Find(p => p.Ten == k);
                var lop = khoa.Lops.Find(p => p.Ten == l);


                var listItemsCheck = LVSinhVien.CheckedItems;

                foreach (ListViewItem item in listItemsCheck)
                {
                    var maSo = item.SubItems[0].Text;
                    lop.XoaSinhVien(maSo);

                }

                List<SinhVien> sinhViens = _NewSinhVienDataSourch.GetSinhVien(k, l);
                LoadListView(sinhViens);

            }
            else
            {
                return;
            }
        }
       
        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LuuFile();
           
        }
        private async void LuuFile()
        {
            app obj = new app();
            var wb = obj.Workbooks.Add(XlSheetType.xlWorksheet);
            var ws = (Worksheet)obj.ActiveSheet;
            obj.Columns.ColumnWidth = 20;

            var khoa = tvwKhoa.SelectedNode.Parent.Text;
            var lop = tvwKhoa.SelectedNode.Text;
            List<SinhVien> ds = _NewSinhVienDataSourch.GetSinhVien(khoa, lop);
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "Excel |*.xlsx";
                saveFile.InitialDirectory = @"D:\";
                saveFile.Title = "Chọn mục cần lưu";
                saveFile.FileName = lop + ".xlsx";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    ws.Name = lop;
                    ws.Cells[1, 1] = "MSSV";
                    ws.Cells[1, 2] = "Họ và tên lót";
                    ws.Cells[1, 3] = "Tên";
                    ws.Cells[1, 4] = "Giới tính";
                    ws.Cells[1, 5] = "Ngày sinh";
                    ws.Cells[1, 6] = "Số điện thoại";
                    ws.Cells[1, 7] = "Địa chỉ";
                    ws.Cells[1, 8] = "Lớp";
                    ws.Cells[1, 9] = "Khoa";


                    ws.Cells.Style.Font.Size = 13;

                    for (int i = 0; i < ds.Count; i++)
                    {

                        ws.Cells[i + 2, 1] = ds[i].MSSV;
                        ws.Cells[i + 2, 2] = ds[i].HoVaTenLot;
                        ws.Cells[i + 2, 3] = ds[i].Ten;
                        ws.Cells[i + 2, 4] = ds[i].GioiTinh;
                        ws.Cells[i + 2, 5] = ds[i].NgaySinh.ToString("dd/MM/yyyy");
                        ws.Cells[i + 2, 6] = ds[i].SoDienThoai;
                        ws.Cells[i + 2, 7] = ds[i].DiaChi;
                        ws.Cells[i + 2, 8] = ds[i].Lop;
                        ws.Cells[i + 2, 9] = ds[i].Khoa;
                    }

                    wb.SaveAs(saveFile.FileName, XlFileFormat.xlWorkbookDefault,
                        Type.Missing, Type.Missing, false, false, XlSaveAsAccessMode.xlShared);
                    MessageBox.Show("Lưu thành công", "Thông báo");
                }
            }
        }
        private void SetUpSearchInputText()
        {
            txtTim.Text = PlaceHolderText;
            txtTim.GotFocus += RemovePlaceHolderText;
            txtTim.LostFocus += ShowPlaceHolderText;
        }
        private void ShowPlaceHolderText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTim.Text))
                txtTim.Text = PlaceHolderText;
        }
        private void RemovePlaceHolderText(object sender,EventArgs e)
        {
            if (txtTim.Text == PlaceHolderText)
                txtTim.Text = "";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Lưu thay đổi nhé", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlr == DialogResult.OK)
            {
                LuuFile();
                Application.Exit();
            }
            else if (dlr == DialogResult.Cancel)
            {
                Application.Exit();
            }

        }

     
        private List<SinhVien> returnSinhVien()
        {

            var lay = _NewSinhVienDataSourch.GetKhoa();
            List<SinhVien> sinhViens = new List<SinhVien>();

            foreach (var k in lay)
            {
                foreach (var n in k.Lops)
                {
                    foreach (var sv in n.sinhViens)
                    {
                        sinhViens.Add(sv);
                    }
                }
            }
            return sinhViens;
        }

        private void txtTim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                List<SinhVien> sinhViens = returnSinhVien();

                List<SinhVien> dssv = new List<SinhVien>();

                if (rdHoTen.Checked)
                {
                    var hoTen = txtTim.Text.Trim().ToLower();

                    List<SinhVien> kq = new List<SinhVien>();
                    foreach (var sv in sinhViens)
                    {
                        if (sv.HoVaTenLot.ToLower() + " " + sv.Ten.ToLower() == hoTen)
                        {
                            kq.Add(sv);
                            continue;
                        }

                        if (sv.Ten.ToLower() == hoTen)
                        {
                            kq.Add(sv);
                            continue;
                        }

                        if (sv.HoVaTenLot.ToLower().StartsWith(hoTen))
                        {
                            kq.Add(sv);
                            continue;
                        }

                        int vt = sv.HoVaTenLot.LastIndexOf(' ') + 1;
                        string tenDem = sv.HoVaTenLot.Substring(vt).ToLower();
                        if (tenDem + " " + sv.Ten.ToLower() == hoTen)
                        {
                            kq.Add(sv);
                        }
                    }
                    dssv = kq;

                }
                if (rdMaSo.Checked)
                {
                    var maSo = txtTim.Text;
                    var list1 = sinhViens.FindAll(p => p.MSSV == maSo);
                    dssv = list1;
                }
                if (rdSDT.Checked)
                {
                    var sdt = txtTim.Text;
                    var list2 = sinhViens.FindAll(p => p.SoDienThoai == sdt);
                    dssv = list2;
                }

                if (dssv.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                LoadListView(dssv);
            }
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string khoa = tvwKhoa.SelectedNode.Parent.Text;
            string lop = tvwKhoa.SelectedNode.Text;
            List<SinhVien> ds;
            var dialog = new frmThemSV(_NewSinhVienDataSourch);

            dialog.comboboxKhoa(khoa);
            dialog.comboboxLop(lop);
            dialog.ShowDialog(this);

            if (dialog.HasChildren)
            {
                ds = _NewSinhVienDataSourch.GetSinhVien(khoa, lop);
                LoadListView(ds);

            }
        }
        private void SaveJson(List<SinhVien> ds, string fileName)
        {
            using (StreamWriter file = File.CreateText(fileName))
            {
                JsonSerializer js = new JsonSerializer();
                js.Serialize(file, ds);

            }
        }

        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var khoa = tvwKhoa.SelectedNode.Parent.Text;
            var lop = tvwKhoa.SelectedNode.Text;
            List<SinhVien> ds = _NewSinhVienDataSourch.GetSinhVien(khoa, lop);
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "Json File(json) |*.json";
                saveFile.InitialDirectory = @"D:\";
                saveFile.Title = "Chọn mục lưu";
                saveFile.FileName = lop + ".json";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    SaveJson(ds, saveFile.FileName);
                    MessageBox.Show("Lưu thành công", "Thông báo");
                }


            }
        }

        private void LVSinhVien_DoubleClick(object sender, EventArgs e)
        {
            var dialog = new frmThemSV(_NewSinhVienDataSourch, true);
            List<SinhVien> danhSachSV = returnSinhVien();
            int count = LVSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                string ma = LVSinhVien.SelectedItems[0].SubItems[0].Text;
                var kq = danhSachSV.FirstOrDefault(x => x.MSSV == ma);
                if (kq != null)
                {
                    ma = kq.MSSV;
                    string hovaten = kq.HoVaTenLot;
                    string ten = kq.Ten;
                    string gt = kq.GioiTinh;
                    DateTime ns = kq.NgaySinh;
                    string lop = kq.Lop;
                    string sdt = kq.SoDienThoai;
                    string kh = kq.Khoa;
                    string diaChi = kq.DiaChi;
                    dialog.sv = new SinhVien(ma,hovaten,ten,lop,ns,gt,kh,sdt,diaChi);
                }
            }
            dialog.ShowDialog();
            if (dialog.HasChildren)
            {
                string khoas = tvwKhoa.SelectedNode.Parent.Text;
                string lops = tvwKhoa.SelectedNode.Text;
                List<SinhVien> sv;
                sv = _NewSinhVienDataSourch.GetSinhVien(khoas, lops);
                LoadListView(sv);
            }
        }

        private void LVSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
