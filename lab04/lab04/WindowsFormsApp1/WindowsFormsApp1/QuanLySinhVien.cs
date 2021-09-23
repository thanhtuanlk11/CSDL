using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public delegate int SoSanh(object sv1, object sv2);
    public class QuanLySinhVien
    {
        public List<SinhVien> danhSach;
        public QuanLySinhVien()
        {
            danhSach = new List<SinhVien>();
        }
        public void Them(SinhVien sv)
        {
            this.danhSach.Add(sv);
        }
        public SinhVien this[int index]
        {
            get { return danhSach[index]; }
            set { danhSach[index] = value; }
        }
        public void Xoa(object obj,SoSanh ss)
        {
            int i = danhSach.Count - 1;
            for (; i >= 0; i--)
                if(ss(obj,this[i])==0)
                    this.danhSach.RemoveAt(i);          
        }
        public bool Sua(SinhVien svsua,object obj,SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.danhSach.Count - 1;
            for ( i = 0; i <count; i++)
                if (ss(obj, this[i]) == 0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }
            return kq;
        }
        public SinhVien Tim(object obj, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in danhSach)
                if(ss(obj,sv)==0)
                {
                    svresult = sv;
                    break;
                }
            return svresult; 
        }
        public void DocTuFile()
        {
            string filename = "SinhVien.txt", t;
            string[] s;
          
            SinhVien sv;
            StreamReader sr = new StreamReader(
                new FileStream(filename, FileMode.Open));
            while ((t = sr.ReadLine()) != null)
            {
                s = t.Split('*');
                sv = new SinhVien();
                sv.MaSo = s[0];
                sv.HoTen = s[1];
                sv.GioiTinh = false;
                if (s[2] =="1")
                    sv.GioiTinh = true;
                sv.NgaySinh = DateTime.Parse(s[3]);
                sv.Lop = s[4];
                sv.SoDT = s[5];
                sv.Email = s[6];
                sv.DiaChi = s[7];
                sv.Hinh = s[8];

                this.Them(sv);
            }
        }
    }
}
