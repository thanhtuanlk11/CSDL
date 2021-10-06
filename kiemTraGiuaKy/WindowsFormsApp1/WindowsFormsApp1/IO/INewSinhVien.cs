using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;
namespace WindowsFormsApp1.IO
{
    public interface INewSinhVien
    {
        // hàm đọc 
        List<Khoa> GetNews();

        //Hàm lưu xuống 
        void Save(List<Khoa> sinhViens);


    }
}
