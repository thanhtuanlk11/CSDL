using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Food
    {
        //ID của bảng Food
        public int ID { get; set; }
        //Tên loại đồ uống thức ăn 
        public string Name { get; set; } 
        // Dơn vị tính 
        public string Unit { get; set; }
        // Loại thức ăn , ứng với bảng ở trên 
        public int FoodCategoryID { get; set; }
        //Giá
        public int Price { get; set; }
        //Ghi chú 
        public string Notes { get; set; }
    }
}
