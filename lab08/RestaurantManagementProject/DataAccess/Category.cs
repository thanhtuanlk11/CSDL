using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    //Lớp ánh xạ bảng Category
    public class Category
    {
        //ID trong bảng , tự tăng trong CSDL
        public int ID { get; set; }
        //Tên của loại thwucs ăn 
        public string Name { get; set; }
        //Kiểu : 0 là đồ uống , 1 là thức ăn 
        public int Type { get; set; }
    }
    //Lớp ánh xạ bảng food
    
}
         