using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1911170_NguyenHuuThanhNam_tuan3.Models;

namespace _1911170_NguyenHuuThanhNam_tuan3.IO
{
    public interface INewsRepository
    {
        List<Publisher> GetNew();
        void Save(List<Publisher> publishers);
    }   
}
