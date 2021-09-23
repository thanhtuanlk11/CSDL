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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private QuanLySinhVien qlsv;

        public Form1()
        {
            InitializeComponent();
        }
 
        //Lấy thong tin sinh viên
        private SinhVien GetSinhVien()
        {
            SinhVien sv = new SinhVien();
            bool gt = true;
            List<string> cn = new List<string>();
            sv.MaSo = this.mtxtMSSV.Text;
            sv.HoTen = this.txtHoVaten.Text;
            sv.Email = this.txtEmail.Text;
            sv.NgaySinh = this.dtpNgaySinh.Value;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.Lop = this.cbLop.Text;
            sv.Hinh = this.txtHinh.Text;
            sv.SoDT = this.mtxtSoDT.Text;
            if (rdNu.Checked)
            {
                gt = false;
               
            }
            sv.GioiTinh = gt;   
            return sv;

        }
        //Láy thông tin từ listView lên để hiển thị khi click 
        private SinhVien GetSinhVienLV(ListViewItem lvitem)
        {
            SinhVien sv = new SinhVien();
            sv.MaSo = lvitem.SubItems[0].Text;
            sv.HoTen = lvitem.SubItems[1].Text;
            sv.GioiTinh = false;
            if (lvitem.SubItems[5].Text == "Nam")
                sv.GioiTinh = true;
            sv.NgaySinh = DateTime.Parse(lvitem.SubItems[3].Text);
            sv.Lop = lvitem.SubItems[4].Text;
            sv.SoDT = lvitem.SubItems[5].Text;
            sv.Email = lvitem.SubItems[6].Text;
            sv.DiaChi = lvitem.SubItems[7].Text; 
            sv.Hinh = lvitem.SubItems[8].Text;
            return sv;
        }
        //Hiển thi tt sinh viên
        private void ThietLapThongTin(SinhVien sv)
        {
            this.mtxtMSSV.Text = sv.MaSo;
            this.txtHoVaten.Text = sv.HoTen;
            this.txtEmail.Text = sv.Email;
            this.dtpNgaySinh.Value = sv.NgaySinh;
            this.txtDiaChi.Text = sv.DiaChi;
            this.cbLop.Text = sv.Lop;
            this.mtxtSoDT.Text = sv.SoDT;
            this.txtHinh.Text = sv.Hinh;
            this.pbHinh.ImageLocation = sv.Hinh;
            if (sv.GioiTinh)
                this.rdNam.Checked = true;
            else
                this.rdNu.Checked = true;
  
        }
        
        //Thêm sv vào ListView
        private void ThemSV(SinhVien sv)
        {
            ListViewItem lvitem = new ListViewItem(sv.MaSo);
            lvitem.SubItems.Add(sv.HoTen);
            string gt = "Nữ";
            if (sv.GioiTinh)
                gt = "Nam";
            lvitem.SubItems.Add(gt);
            lvitem.SubItems.Add(sv.NgaySinh.ToShortDateString());
            lvitem.SubItems.Add(sv.Lop);
            lvitem.SubItems.Add(sv.SoDT);           
            lvitem.SubItems.Add(sv.Email);
            lvitem.SubItems.Add(sv.DiaChi);
            lvitem.SubItems.Add(sv.Hinh);
            this.LVSinhVien.Items.Add(lvitem);
        }
        //Hiển thị thông tin SV vào listView
        private void LoadListView()
        {
            this.LVSinhVien.Items.Clear();
            foreach (SinhVien sv in qlsv.danhSach)
            {
                ThemSV(sv);
            }
            txtTongSV.Text = "Tổng Sinh Viên:" + LVSinhVien.Items.Count;
        }
        //Load Form
        private void Form1_Load(object sender, EventArgs e)
        {
            qlsv = new QuanLySinhVien();
            qlsv.DocTuFile();
            LoadListView();
        }
        //Btn thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Lưu thay đổi", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
        //btn chọn hình
        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Select Picture";// "Add Photos";
            dlg.Filter = "Image Files (JPEG, GIF, BMP, etc.)|"
                          + "*.jpg;*.jpeg;*.gif;*.bmp;"
                          + "*.tif;*.tiff;*.png|"
                        + "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|"
                        + "GIF files (*.gif)|*.gif|"
                        + "BMP files (*.bmp)|*.bmp|"
                        + "TIFF files (*.tif;*.tiff)|*.tif;*.tiff|"
                        + "PNG files (*.png)|*.png|"
                        + "All files (*.*)|*.*";

            dlg.InitialDirectory = Environment.CurrentDirectory;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var fileName = dlg.FileName;
                pbHinh.Load(fileName);
            }
        }
        //button mặc định
        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            this.mtxtMSSV.Text = "";
            this.txtHoVaten.Text = "";
            this.txtEmail.Text = "";
            this.btnChonHinh = null;
            this.mtxtSoDT.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.txtDiaChi.Text = "";
            this.cbLop.Text = this.cbLop.Items[0].ToString();
            this.txtHinh.Text = "";
            this.pbHinh.ImageLocation = "";
            this.rdNam.Checked = true;
        }
        //Chọn Sinh Viên hiển thị bên các Control
        private void LVSinhVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = this.LVSinhVien.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.LVSinhVien.SelectedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }
        }

        private void LVSinhVien_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            int count = this.LVSinhVien.CheckedItems.Count;
            if (count > 0)
            {
                ListViewItem lvitem = this.LVSinhVien.CheckedItems[0];
                SinhVien sv = GetSinhVienLV(lvitem);
                ThietLapThongTin(sv);
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            SinhVien sv = GetSinhVien();  
            ListViewItem lvitem = new ListViewItem();
            SinhVien kq = qlsv.Tim(sv.MaSo, delegate (object obj1, object obj2)
            {
                return (obj2 as SinhVien).MaSo.CompareTo(obj1.ToString());
            });
            if (kq != null)
            {
                MessageBox.Show("Mã Sinh Viên đã tồn tại! Đã cập nhật thông tin sinh viên mã này!", "Cập nhật thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                bool kqsua;
                kqsua = qlsv.Sua(sv, sv.MaSo, SoSanhTheoMa);
                if (kqsua)
                {
                    this.LoadListView();
                }


            }
            else
            {
                qlsv.Them(sv);
                this.LoadListView();
            }
        }
        

        private async void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            DialogResult dlr = MessageBox.Show("Lưu thay đổi", "Thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
        private async void LuuFile()
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Document|*.txt", ValidateNames = true })
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
                                + item.SubItems[6].Text + "\t"
                                + item.SubItems[7].Text + "\t"
                                + item.SubItems[8].Text + "\t");
                        }
                    }
                }
            }
        }
        //Xóa SV
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count, i;
            ListViewItem lvitem;
            count = this.LVSinhVien.Items.Count - 1;
            for (i=count;i>0;i--)
            {
                lvitem = this.LVSinhVien.Items[i];
                if (lvitem.Checked)
                    qlsv.Xoa(lvitem.SubItems[0].Text,SoSanhTheoMa);
            }
            this.LoadListView();
        }
        private int SoSanhTheoMa(object obj1,object obj2)
        {
            SinhVien sv = obj2 as SinhVien;
            return sv.MaSo.CompareTo(obj1);
        }
        //Reload lại file
        private void tảiLạiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.mtxtMSSV.Text = "";
            this.txtHoVaten.Text = "";
            this.txtEmail.Text = "";
            this.btnChonHinh = null;
            this.mtxtSoDT.Text = "";
            this.dtpNgaySinh.Value = DateTime.Now;
            this.txtDiaChi.Text = "";
            this.cbLop.Text = this.cbLop.Items[0].ToString();
            this.txtHinh.Text = "";
            this.pbHinh.ImageLocation = "";
            this.rdNam.Checked = true;
            LoadListView();  
        }

     
    }
}
