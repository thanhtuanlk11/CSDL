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
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }

        public string SoDienThoai { get; set; }
        public string Lop { get; set; }
        public string Khoa { get; set; }
        public string DiaChi { get; set; }
        public List<string> DSSinhVien;

        public SinhVien()
        {
            
        }
        public SinhVien(string mssv, string hoVaTenLot,string ten,string gt,DateTime ngaySinh,string soDienThoai,string dc,string lop,string khoa)
        {
            this.MSSV = mssv;
            this.HoVaTenLot = hoVaTenLot;
            this.Ten = ten;
            this.GioiTinh = gt;
            this.NgaySinh = ngaySinh;
            this.SoDienThoai = soDienThoai;
            this.DiaChi = dc;
            this.Lop = lop;
            this.Khoa = khoa;
        }
        public void CapNhatSV(string mssv, string hoVaTenLot, string ten, string gt, DateTime ngaySinh, string soDienThoai, string dc, string lop, string khoa)
        {
            this.MSSV = mssv;
            this.HoVaTenLot = hoVaTenLot;
            this.Ten = ten;
            this.GioiTinh = gt;
            this.NgaySinh = ngaySinh;
            this.SoDienThoai = soDienThoai;
            this.DiaChi = dc;
            this.Lop = lop;
            this.Khoa = khoa;
        }
    }
}
