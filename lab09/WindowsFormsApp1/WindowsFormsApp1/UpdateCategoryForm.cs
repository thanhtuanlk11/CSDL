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
        private bool ValidateUserInput()
        {
            // Kiểm tra nhóm món ăn đã được nhập hay chưa 
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên thức ăn không được để trống", "thông báo");
                return false;
            }
            //Kiểm tra loại thức ăn đã được chọn hay chưa
            if (cbbCategoryType.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn chưa chọn loại thức ăn", "thông báo");
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu dữ liệu nhập vào là hợp lệ 
            if (ValidateUserInput())
            {
                // thì lấy thông tin ng dùng nhập 
                var newCategory = GetUpdatedCategory();
                // tìm xem thử có nhóm ón ăn trong CSDL chưa
                var oldCategory = GetCategoryById(_categoryId);
                // Nếu chưa có 
                if(oldCategory == null)
                {
                    // Thì thêm nhóm thức ăn mới 
                    _dbContext.Categories.Add(newCategory);
                }
                else
                {
                    //Ngược lại ta chỉ cần cập nhật thông tinn cần thiết 
                    oldCategory.Name = newCategory.Name;
                    oldCategory.Type = newCategory.Type;
                }
                // Lưu các thay đổi xuống csdl
                _dbContext.SaveChanges();
                // Đống hội thaoij 
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
