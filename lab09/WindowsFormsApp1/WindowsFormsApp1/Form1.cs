using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }
        private List<Category> GetCategories()
        {
            // khởi tạo đối tượng context
            var dbContext = new RestaurantContext();
            // Lấy ds tất cả các nhóm món ăn sắp xếp theo tên 
            return dbContext.Categories.OrderBy(x => x.Name).ToList();
        }

        private void ShowCategories()
        {
            // Xóa tát cả các nút hiện cs trên cây
            tvwCategory.Nodes.Clear();
            // Tạo danh mục nhóm món ăn , đò uống 
            //Tên các loại này được hiển thị trên các nút mức 2
            var cateMap = new Dictionary<CategoryType, string>()
            {
                [CategoryType.Food] = "Đồ ăn",
                [CategoryType.Drink] = "Đồng uống"
            };
            //Tạo nút gốc của cây
            var rootNode =tvwCategory.Nodes.Add("Tất cả");
            // Lấy ds nhóm đồ ăn, thức uống
            var categoies = GetCategories();
            // Duyệt qua các nhóm thức ăn 
            foreach(var cateType in cateMap)
            {
                //tạo các nút tương ứng với loại nhóm món ăn
                var childNode = rootNode.Nodes.Add(cateType.Key.ToString(), cateType.Value);
                childNode.Tag = cateType.Key;
                // duyệt qua các nhóm thức ăn 
                foreach(var category in categoies)
                {
                    // Nếu nhóm món ăn đang xét không cùng loại thì bỏ qua 
                    if (category.Type != cateType.Key) continue;
                    // Ngược lại tạo các nút tương ứng trên cây 
                    var grantChildNode = childNode.Nodes.Add(category.Id.ToString(), category.Name);
                    grantChildNode.Tag = category;
                }
            }
            // Mở rộng các nhánh của cây để thấy hết tát cả các nhóm thức ăn 
            tvwCategory.ExpandAll();
            // Đánh dấu nút gôc đang được chọn 
            tvwCategory.SelectedNode = rootNode;
        }
        private void MainFrom_Load(object sender, EventArgs e)
        {
            ShowCategories();
        }

        private void btnReloadCategory_Click(object sender, EventArgs e)
        {
            ShowCategories();
        }
        //lấy danh sách theo mã
        private List<FoodModel> GetFoodByCategory(int? categoryId)
        {
            // khởi tạo đối tương context
            var dbContext = new RestaurantContext();

            // Tạo truy vấn lấy dánh sách món ăn 
            var foods = dbContext.Foods.AsQueryable();
            //Nếu mã nhóm món ăn khác null và hợp lệ 
            if(categoryId!=null && categoryId > 0)
            {
                // thì tìm thoe mã nhóm món ăn 
                foods = foods.Where(x => x.FoodCategoryId == categoryId);
            }
            // Sắp xếp đồ ăn thức uống theoe tên và trả về
            // dánh sách chứa đầy đủ thông tin món ăn 
            return foods
                .OrderBy(x=>x.Name)
                .Select(x=>new FoodModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Unit = x.Unit,
                    Price = x.Price,
                    Notes =x.Notes,
                    CategoryName =x.Category.Name
                })
                .ToList();
        }
        // Lấy dánh sách theo thể loại 
        private List<FoodModel> GetFoodByCategoryType(CategoryType cateType)
        {
            var dbContext = new RestaurantContext();
            //Tìm các món ăn theo loại nhóm món ăn (CategoryType).
            //Sap xếp đồ ăn thức uống thoe tên và trả về .
            //danh sách chứa đầy đủ thông tin về món ăn 
            return dbContext.Foods
                .Where(x => x.Category.Type == cateType)
                .OrderBy(x => x.Name)
                .Select(x => new FoodModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Unit = x.Unit,
                    Price = x.Price,
                    Notes = x.Notes,
                    CategoryName = x.Category.Name
                })
                .ToList();
        }
        //Kiểm tra treeView và xuất 
        private void ShowFoodsForNode(TreeNode node)
        {
            // Xóa dánh sách thực đơn hiện tại trên listview
            lvFood.Items.Clear();
            // Nếu node = null , không cần xử lsy gì thêm 
            if (node == null) return;
            // Tao dánh sách chưa các món ăn vừa tìm được 
            List<FoodModel> foods = null;

            // nếu nút được chọn trên treeView tương ứng với loại thức ăn CategoryType (mức thức 2 trên cây)
            if (node.Level == 1)
            {
                // thì láy danh sách món ăn thoe thể loại nhóm 
                var categoryType = (CategoryType)node.Tag;
                foods = GetFoodByCategoryType(categoryType);
            }
            else
            {
                // Ngược lại lấy danh sách món ăn theo thể loại , nếu nút được chọn là tát cả thì hiển thị hết 
                var category = node.Tag as Category;
                foods = GetFoodByCategory(category?.Id);
            }
            // Gọi hàm để hiển thị món ăn trên litsView
            ShowFoodsOnListView(foods);
        }
        private void ShowFoodsOnListView(List<FoodModel> foods)
        {
            // duyệt qua các phần tử trong ds food
            foreach (var foodItem in foods)
            {
                // tạo item tương ứng trên LitsView
                var item = lvFood.Items.Add(foodItem.Id.ToString());
                // và hiển thị thông tin các món ăn 
                item.SubItems.Add(foodItem.Name);
                item.SubItems.Add(foodItem.Unit);
                item.SubItems.Add(foodItem.Price.ToString("##,###"));
                item.SubItems.Add(foodItem.CategoryName);
                item.SubItems.Add(foodItem.Notes);
            }
        }

        private void tvwCategory_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowFoodsForNode(e.Node);
        }
    }
}
