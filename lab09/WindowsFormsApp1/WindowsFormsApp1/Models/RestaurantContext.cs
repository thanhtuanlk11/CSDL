using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class RestaurantContext : DbContext
    {
        // tham chiếu tới nhóm món ăn trong bảng Ctegory
        public DbSet<Category> Categories { get; set; }
        //Tham số tới các món ăn , đồ uống trong bảng Food
        public DbSet<Food> Foods { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Xóa br quy tắc sử dụng danh từ số nhiều ch tên bảng 
            // lúc này, thuộc tính categoríes ánh xạ tới bảng category trong db
            // và thuộc tính Foods tương ứng với bảng food trong CSDL
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // định nghĩa mối quan hệ một nhiều giữa 2 bảng category và food
            modelBuilder.Entity<Food>()
                .HasRequired(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.FoodCategoryId)
                .WillCascadeOnDelete(true);
        }
    }
}
