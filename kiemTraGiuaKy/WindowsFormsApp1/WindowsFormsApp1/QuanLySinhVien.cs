using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.IO;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public delegate int SoSanh(object sv1, object sv2);
    public class QuanLySinhVien
    {
        private readonly INewSinhVien _newsSinhVien;
        private List<Khoa> _khoas;
        public List<SinhVien> danhSach;

        public QuanLySinhVien(INewSinhVien newsSinhVien)
        {
            _newsSinhVien = newsSinhVien;
            danhSach = new List<SinhVien>();
        }
        public List<Khoa> GetNew()
        {
            if(_khoas == null)
            {
                _khoas = _newsSinhVien.GetNews();
            }
            return _khoas;
        }
        public void SaveChanges()
        {
            _newsSinhVien.Save(_khoas);
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
        public void Xoa(object obj, SoSanh ss)
        {
            int i = danhSach.Count - 1;
            for (; i >= 0; i--)
                if (ss(obj, this[i]) == 0)
                    this.danhSach.RemoveAt(i);
        }
        public bool Sua(SinhVien svsua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.danhSach.Count - 1;
            for (i = 0; i < count; i++)
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
                if (ss(obj, sv) == 0)
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
                s = t.Split('\t');
                sv = new SinhVien();
                sv.MSSV = s[0];
                sv.HoVaTenLot = s[1];
                sv.Ten = s[2];
                sv.GioiTinh = false;
                if (s[2] == "1")
                    sv.GioiTinh = true;
                sv.NgaySinh = new DateTime();
                sv.SoDienThoai = "";
                sv.Lop = s[3];
                sv.Khoa = s[4];
                this.Them(sv);
            }
        }
    }
}
