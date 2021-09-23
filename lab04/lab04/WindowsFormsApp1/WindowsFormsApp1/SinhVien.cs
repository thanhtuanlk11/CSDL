using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SinhVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SoDT { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Lop { get; set; }
        public bool GioiTinh { get; set; }
        public string Hinh { get; set; }
        public List<string> DSSinhVien;
        public SinhVien()
        {
            DSSinhVien = new List<string>();
        }
        public SinhVien(string ms,string ht,string em,DateTime ngay,string dc,string l,bool gt,string hinh)
        {
            this.MaSo = ms;
            this.HoTen = ht;
            this.Email = em;
            this.NgaySinh = ngay;
            this.DiaChi = dc;
            this.Lop = l;
            this.GioiTinh = gt;
            this.Hinh = hinh;
        }      
    }
}
