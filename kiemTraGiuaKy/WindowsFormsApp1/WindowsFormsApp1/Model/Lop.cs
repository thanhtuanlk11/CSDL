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
        public string SinhVienss { get; set; }
        public List<SinhVien> sinhViens { get; set; }
        public Lop()
        {
            sinhViens = new List<SinhVien>();
        }
    }
}
