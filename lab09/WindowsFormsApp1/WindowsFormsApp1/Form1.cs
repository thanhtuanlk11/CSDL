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
    }
}
