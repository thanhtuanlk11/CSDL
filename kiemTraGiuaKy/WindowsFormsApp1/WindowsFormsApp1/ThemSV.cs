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
    public partial class frmThemSV:Form
    {
        public List<SinhVien> ListSV;
        QuanLySinhVien qlsv;
        ListView listView;

        public frmThemSV(QuanLySinhVien qlsv, ListView listView)
        {
            InitializeComponent();
            this.qlsv = qlsv;
            this.listView = listView;
        }
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
            sv.SoDienThoai = this.mkbSDT.Text;
            sv.DiaChi = this.txtDiaChi.Text;
            sv.Khoa = this.cboKhoa.Text;
            return sv;
        }

        private void btnLưu_Click(object sender, EventArgs e)
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
               
            }
        }

        private void frmThemSV_Load(object sender, EventArgs e)
        {

        }
    }
}
