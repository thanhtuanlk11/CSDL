using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SinhVien
    {
        public string MSSV { get; set; }
        public string HoVaTenLot { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoCMND { get; set; }
        public bool GioiTinh { get; set; }
        public string Ten { get; set; }
        public string Lop { get; set; }

        public  string SDT { get; set; }
        public string DiaChi { get; set; }
        public List<string> MonHoc { get; set; }
        public SinhVien()
        {
            MonHoc = new List<string>();
        }
        public SinhVien(string mssv,string hoVaTenLot,DateTime ngaySinh,string soCMND,bool gioiTinh,string ten,string lop,string sdt,string diaChi,List<string> mh)
        {
            this.MSSV = mssv;
            this.HoVaTenLot = hoVaTenLot;
            this.NgaySinh = ngaySinh;
            this.SoCMND = soCMND;
            this.GioiTinh = gioiTinh;
            this.Ten = ten;
            this.Lop = lop;
            this.SDT = sdt;
            this.DiaChi = diaChi;
            this.MonHoc = mh;

        }

    }
}
