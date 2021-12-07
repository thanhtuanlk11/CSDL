using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab3
{
    public delegate int SoSanh(object sv1, object sv2);
    public class QuanLySinhVien
    {
        public List<SinhVien> DanhSach;

        public List<SinhVien> List { get; internal set; }

        public QuanLySinhVien()
        {
            DanhSach = new List<SinhVien>();
        }
        public void Them(SinhVien sv)
        {
            this.DanhSach.Add(sv);
        }
        public SinhVien this[int index]
        {
            get { return DanhSach[index]; }
            set { DanhSach[index] = value; }
        }
        public void Xoa(object obj,SoSanh ss)
        {
            int i = DanhSach.Count - 1;
            for (; i >= 0; i--)
                if (ss(obj, this[i]) == 0)
                    this.DanhSach.RemoveAt(i);
        }
        public SinhVien Tim(object obj,SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in DanhSach)
                if(ss(obj,sv)==0)
                {
                    svresult = sv;
                    break;
                }
            return svresult;
        }
        public bool Sua(SinhVien svsua,object obj,SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.DanhSach.Count - 1;
            for(i=0;i<count;i++)
                if (ss(obj,this[i]) == 0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }
            return kq;
        }
        public void DocTuFile()
        {
            string filename = "DanhSachSV.txt", t;
            string[] s;
            SinhVien sv;
            using (var stream = new FileStream(filename, FileMode.Open))
            {
                using (var reader = new StreamReader(stream))
                {
                    while ((t = reader.ReadLine()) != null)
                    {
                        s = t.Split('\t');
                        sv = new SinhVien();
                        sv.MaSo = s[0];
                        sv.HoTen = s[1];
                        
                        sv.DiaChi = s[3];
                        sv.Lop = s[4];
                        sv.Hinh = s[5];

                        sv.GioiTinh = false;
                        if (s[6] == "1")
                            sv.GioiTinh = true;
                        string[] cn = s[7].Split(',');
                        foreach (string c in cn)
                        {
                            sv.ChuyenNganh.Add(c);
                        }
                        this.Them(sv);
                    }
                }
            }
        }
    }
}

