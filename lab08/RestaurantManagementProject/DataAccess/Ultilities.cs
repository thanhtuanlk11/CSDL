using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess
{
    public class Ultilities
    {
        // lấy chuỗi từ tập tin App.config
        private static string StrName = "ConnectionStringName";
        public static string ConnectionString = ConfigurationManager
                                                    .ConnectionStrings[StrName]
                                                    .ConnectionString;
        // Các biến của bảng Food
        public static string Food_GetAll = "Food_GetAll";
        public static string Food_InsertUpdateDelete = "Food_InsertUpdateDelete";
        //Các biến của bảng Food
        public static string Category_GetAll = "Category_GetAll";
        public static string Category_InsertUpdateDelete = "Category_InsertUpdateDelete";

    }
}
