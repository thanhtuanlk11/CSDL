using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;
using DataAccess;
namespace RestaurantManagementProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Danh sách biến toàn cục bảng categorry
        List<Category> listCategory = new List<Category>();
        List<Food> listFood = new List<Food>();
        // đối tượng food đang chọn hiện hành 
        Food foodCurrent = new Food();


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtUnit.Text = "";
            txtUnit.Text = "";

            if (cbbCategory.Items.Count > 0)
            {
                cbbCategory.SelectedIndex = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // đổ dữ liệu vào cbb
            LoadCategory();
            LoadFoodDataToListView();
           
        }
        private void LoadCategory()
        {
            // gọi đối tượng CategoryBL từ tầng BisinessLogic
            CategoryBL categoryBL = new CategoryBL();
            // Lấy dữ liệu gán cho biến toàn cục listCategory
            listCategory = categoryBL.GetAll();
            // Chuyển vào Combobox với dữ liệu là ID, hiển thị là Name
            cbbCategory.DataSource = listCategory;
            cbbCategory.ValueMember = "ID";
            cbbCategory.DisplayMember = "Name";
        }
        public void LoadFoodDataToListView()
        {
            //Gọi đối tượng FoodBL từ tầng BusinessLogic
            FoodBL foodBL = new FoodBL();
            // Lấy dữ liệu
            listFood = foodBL.GetAll();
            int count = 1; // Biến số thứ tự
                           // Xoá dữ liệu trong ListView
            lvFood.Items.Clear();
            // Duyệt mảng dữ liệu để đưa vào ListView
            foreach (var food in listFood)
            {
                // Số thứ tự
                ListViewItem item = lvFood.Items.Add(count.ToString());
                // Đưa dữ liệu Name, Unit, price vào cột tiếp theo
                item.SubItems.Add(food.Name);
                item.SubItems.Add(food.Unit);
                item.SubItems.Add(food.Price.ToString());
                // Theo dữ liệu của bảng Category ID, lấy Name để hiển thị
                string foodName = listCategory
                .Find(x => x.ID == food.FoodCategoryID).Name;
                item.SubItems.Add(foodName);
                // Đưa dữ liệu Notes vào cột cuối
                item.SubItems.Add(food.Notes);
                count++;
            }
        }

        private void lvFood_Click(object sender, EventArgs e)
        {
            // Duyệt toàn bộ dữ liệu trong ListView
            for (int i = 0; i < lvFood.Items.Count; i++)
            {
                // Nếu có dòng được chọn thì lấy dòng đó
                if (lvFood.Items[i].Selected)
                {
                    // Lấy các tham số và gán dữ liệu vào các ô
                    foodCurrent = listFood[i];
                    txtName.Text = foodCurrent.Name;
                    txtUnit.Text = foodCurrent.Unit;
                    txtPrice.Text = foodCurrent.Price.ToString();
                    txtNotes.Text = foodCurrent.Notes;
                    // Lấy index của Combobox theo FoodCategoryID
                    cbbCategory.SelectedIndex = listCategory
                    .FindIndex(x => x.ID == foodCurrent.FoodCategoryID);
                }
            }
        }
    }
}
