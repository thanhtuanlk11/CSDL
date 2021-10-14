using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.IO
{
    public class NewSinhVienDataSourch
    {
        private List<Khoa> _khoa;
        private const string filePath="Data\\data.txt";
        public List<SinhVien> GetNews()
        {
            List<SinhVien> ds = new List<SinhVien>();
            string line;
            string[] s;

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            s = line.Split('\t');
                            SinhVien a = new SinhVien();
                            a.MSSV = s[0];
                            a.HoVaTenLot = s[1];
                            a.Ten = s[2];
                            a.Lop = s[3];
                            a.Khoa = s[4];
                            a.GioiTinh = "Nam";
                            a.NgaySinh = new DateTime(0001, 1, 1);
                            a.SoDienThoai = "";
                            a.DiaChi = "";

                            var kt = ds.FindAll(p => p.MSSV == a.MSSV);
                            if (kt.Count == 0)
                            {
                                ds.Add(a);
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return ds;
        }


        private List<Khoa> ListKhoa(List<SinhVien> ds)
        {
            List<Khoa> dsDep = new List<Khoa>();

            foreach (var sv in ds)
            {
                Khoa k = new Khoa();
                k.Ten = sv.Khoa;

                var kq = dsDep.FindAll(p => p.Ten == k.Ten);
                if (kq.Count == 0)
                {
                    dsDep.Add(k);
                }

                foreach (var khoa in dsDep)
                {
                    if (khoa.Ten == sv.Khoa)
                    {
                        Lop a = new Lop();
                        a.Ten = sv.Lop;
                        var kt = khoa.Lops.FindAll(p => p.Ten == sv.Lop);
                        if (kt.Count == 0)
                        {
                            khoa.Lops.Add(a);
                        }
                    }


                    foreach (var lop in khoa.Lops)
                    {
                        if (lop.Ten == sv.Lop)
                        {
                            lop.sinhViens.Add(sv);
                            break;
                        }

                    }
                }
            }
            // sắp xếp danh sách
            foreach (var khoa in dsDep)
            {
                khoa.Lops.Sort((x1, x2) => x1.Ten.CompareTo(x2.Ten));
            }
            return dsDep;




        }
        public List<Khoa> GetKhoa()
        {
            if (_khoa == null)
            {
                _khoa = ListKhoa(GetNews());
            }
            return _khoa;
        }

        public List<SinhVien> GetSinhVien(string tenKhoa, string tenLop)
        {


            var department = _khoa.Find(x => x.Ten == tenKhoa);
            if (department == null) return new List<SinhVien>();

            var clss = department.Lops.Find(x => x.Ten == tenLop);
            if (clss == null) return new List<SinhVien>();
            else
            {
                return clss.sinhViens;
            }

        }


    }
}
