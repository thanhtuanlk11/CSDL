using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1911170_ThongTinGiaoVien
{

    public delegate int SoSanh(object gv1, object gv2);
    public class QuanlyGiaoVien
    {
        public List<GiaoVien> dsGV;
        public QuanlyGiaoVien()
        {
            dsGV = new List<GiaoVien>();
        }
        public void Them(GiaoVien gv)
        {
            this.dsGV.Add(gv);
        }
        public GiaoVien this[int index]
        {
            get { return dsGV[index]; }
            set { dsGV[index] = value; }
        }
        public void Xoa(object obj, SoSanh ss)
        {
            for (int i = dsGV.Count - 1; i >= 0; i--)
            {
                if (ss(obj, this[i]) == 0)
                    this.dsGV.RemoveAt(i);
            }
        }
        public GiaoVien Tim(object obj, SoSanh ss)
        {
            GiaoVien gvResult = null;
            foreach (GiaoVien giaoVien in dsGV)
            {
                if (ss(obj, giaoVien) == 0)
                {
                    gvResult = giaoVien;
                    break;
                }
            }
            return gvResult;
        }
    }
}
