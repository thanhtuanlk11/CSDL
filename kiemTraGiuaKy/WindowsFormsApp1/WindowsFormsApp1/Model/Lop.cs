using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
    public class Lop
    {
        public string Name { get; set; }
     
        public List<SinhVien> sinhViens { get; set; }
        public Lop()
        {
            sinhViens = new List<SinhVien>();
        }
        public void ThemSinhVien(SinhVien nSinhvien)
        {
            sinhViens.Add(nSinhvien);
        }

        public void XoaSinhVien(string SinhViens)
        {
            sinhViens.RemoveAll(p => p.MSSV == SinhViens);
        }
    }
}
