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
    public partial class UpdateCategoryForm : Form
    {
        private RestaurantContext _dbContext;
        private int _categoryId;

        public UpdateCategoryForm(int? categoryId = null)
        {
            InitializeComponent();
            _dbContext = new RestaurantContext();
            _categoryId = categoryId ?? 0;
        }

        private Category GetCategoryById(int categoryId)
        {
            // Nếu ID được truyền vào là hợp lệ , ta tìm theo thông tin ID
            // Ngược lại, chỉ đơn giản là null , cho biết không thấy
            return categoryId > 0 ? _dbContext.Categories.Find(categoryId) : null;
        }

        private void ShowCategory()
        {
            // lấy thông tin các nhóm món ăn 
            var category = GetCategoryById(_categoryId);

            // Nếu không tìm thấy thông tin, khoogn cần làm gì cả 
            if (category == null) return;
            // Ngược lại nếu tìm thấy thì hiển thị lên form
            txtCategoryId.Text = category.Id.ToString();
            txtCategoryName.Text = category.Name;
            cbbCategoryType.SelectedIndex = (int)category.Type;
        }
        private void UpdateCategoryForm_Load(object sender, EventArgs e)
        {
            // Hiển thị thoogn tin nhóm thwucs ăn lên fỏm 
            ShowCategory();
        }
        private Category GetUpdatedCategory()
        {
            // Tạo đối tượng Catefory với thông tin nhập
            var category = new Category()
            {
                Name = txtCategoryName.Text.Trim(),
                Type = (CategoryType)cbbCategoryType.SelectedIndex
            };
            // Gán giá trị ID ban đầu nếu đang cập nhật 
            if (_categoryId > 0)
            {
                category.Id = _categoryId;
            }
            return category;
        }
    }
}
