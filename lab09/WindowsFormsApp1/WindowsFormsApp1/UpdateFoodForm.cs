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
    public partial class UpdateFoodForm : Form
    {
        private RestaurantContext _dbContext;
        private int _foodID;
        public UpdateFoodForm(int ? foodId = null)
        {
            InitializeComponent();
            _dbContext = new RestaurantContext();
            _foodID = foodId ?? 0;
        }
        private void LoadCategoriesToCombobox()
        {
            // Lấy tất cả danh mục thức ăn , săp tăng theo tên 
            var categories = _dbContext.Categories.OrderBy(x => x.Name).ToList();
            //Nạp danh mục vào cbb hiển thị cho tên người dùng xem nhưng khi được chọn thì lấy giá trị ID
            cbbFoodCategory.DisplayMember = "Name";
            cbbFoodCategory.ValueMember = "Id";
            cbbFoodCategory.DataSource = categories;
        }

        private void UpdateFoodForm_Load(object sender, EventArgs e)
        {
            LoadCategoriesToCombobox();
            ShowFoodInfomation();
        }
        private Food GetFoodById(int foodId)
        {
            // tìm món ăn theo mã số
            return foodId > 0 ? _dbContext.Foods.Find(foodId) : null;
        }
        private void ShowFoodInfomation()
        {
            // tìm món ăn theo mã số đã truyền vào from
            var food = GetFoodById(_foodID);
            // Nếu không tìm thấy không cần làm gì cả
            if (food == null) return;
            // Ngược lại hiển thị thông tin món ăn lên from
            txtFoodId.Text = food.Id.ToString();
            txtFoodName.Text = food.Name;
            cbbFoodCategory.SelectedValue = food.FoodCategoryId;
            txtFoodUnit.Text = food.Unit;
            nudFoodPrice.Value = food.Price;
            txtFoodNotes.Text = food.Notes;

        }
        private bool ValidateUserInput()
        {
            // Kiểm tra món ăn đã được nhập hay chưa 
            if (string.IsNullOrWhiteSpace(txtFoodName.Text))
            {
                MessageBox.Show("Tên món ăn, đồ uống khoogn được để trống", "thông báo");
            }
            //Kiểm tra đơn vị tính đã đc nhập hay chưa
            else
            {
                MessageBox.Show("đơn vị tính không được để trống", "thông báo");
                return false;
            }
            return true;
        }
        private Food GetUpdateFood()
        {
            // Tạo đối tượng food với thông tin láy từ các điều khiển trên from
            var food = new Food()
            {
                Name = txtFoodName.Text.Trim(),
                FoodCategoryId = (int)cbbFoodCategory.SelectedValue,
                Unit = txtFoodUnit.Text,
                Price = (int)nudFoodPrice.Value,
                Notes = txtFoodNotes.Text
            };
            //gán giá trị Id ban đầu (nếu đang cập nhật )
            if (_foodID > 0)
            {
                food.Id = _foodID;
            }
            return food;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu dữ liệu nhập vào là hợp lệ 
            if (ValidateUserInput())
            {
                //Thì lấy thông tin người dùng nhập vào '
                var newFood = GetUpdateFood();
                // tìm thử xem trong csdl có món ăn đó chauw 
                var oldFood = GetFoodById(_foodID);
                //Nếu chưa có
                if(oldFood == null)
                {
                    // thì thêm món ăn mới 
                    _dbContext.Foods.Add(newFood);
                }
                else
                {
                    // Ngược lại cập nhật thông tin món ăn 
                    oldFood.Name = newFood.Name;
                    oldFood.FoodCategoryId = newFood.FoodCategoryId;
                    oldFood.Unit = newFood.Unit;
                    oldFood.Price = newFood.Price;
                    oldFood.Notes = newFood.Notes;
                }
                // lưu các thay đổi xuống CSDL
                _dbContext.SaveChanges();
                // Đống hội thoại
                DialogResult = DialogResult.OK;
            }
        }
    }
}
