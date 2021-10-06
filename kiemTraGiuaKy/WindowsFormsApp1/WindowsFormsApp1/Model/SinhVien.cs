using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class SinhVien
    {
        public string MSSV { get; set; }
        public string HoVaTenLot { get; set; }
        public string Ten { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }

        public string SoDienThoai { get; set; }
        public string Lop { get; set; }
        public List<SinhVien> dssv { get; set; }
        public SinhVien()
        {
            dssv = new List<SinhVien>();
        }
        public SinhVien(string mssv, string hoVaTenLot,string ten,bool gt,DateTime ngaySinh,string soDienThoai,string lop)
        {
            this.MSSV = mssv;
            this.HoVaTenLot = hoVaTenLot;
            this.Ten = ten;
            this.GioiTinh = gt;
            this.NgaySinh = ngaySinh;
            this.SoDienThoai = soDienThoai;
            this.Lop = lop;
        }
    }
}
