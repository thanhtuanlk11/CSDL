using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo18_08_2021.DTO;

namespace Demo18_08_2021
{
	public partial class AdminForm : Form
	{
		private RestaurantContext _context;

		private int _currentCategoryId = 0;
		private const string PlaceHolderText = "Nhập tên món ăn";
		

		public AdminForm(RestaurantContext context)
		{
			_context = context;
			InitializeComponent();
		}

		private void AdminForm_Load(object sender, EventArgs e)
		{
			LoadTableToLvDetail();
			LoadCategoryToPanel();
			LoadFoodListToLV(_context.GetFoods());

			SetUpSearchInputText();
		}
		private void LoadTableToLvDetail()
		{
			lvTableList.Items.Clear();
			foreach (var table in WorkingContext.TableList)
			{
				ListViewItem item = new ListViewItem(table.TableId.ToString());
				item.SubItems.Add(table.TableName);
				item.SubItems.Add(table.Status == 1 ? "Có người" : "Trống");
				item.SubItems.Add(table.Floor.ToString());

				lvTableList.Items.Add(item);
			}
		}
		private void btnAdd_Click(object sender, EventArgs e)
		{
			var tableName = txtTableName.Text;
			var floor = int.Parse(cbbFloor.Text);
			var tableId = WorkingContext.TableList.Max(p => p.TableId) + 1;

			DiningTable table = new DiningTable(tableId, tableName, floor);
			WorkingContext.TableList.Add(table);

			LoadTableToLvDetail();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			var tableName = txtTableName.Text;
			var floor = int.Parse(cbbFloor.Text);
			var tableId = int.Parse(txtTableId.Text);

			var table = WorkingContext.TableList.FirstOrDefault(p => p.TableId == tableId);
			table.TableName = tableName;
			table.Floor = floor;

			LoadTableToLvDetail();
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			var tableId = int.Parse(txtTableId.Text);

			WorkingContext.TableList.RemoveAll(p => p.TableId == tableId);
			LoadTableToLvDetail();
		}

		private void tsmiDelete_Click(object sender, EventArgs e)
		{
			var listCheckedItem = lvTableList.CheckedItems;

			foreach (ListViewItem item in listCheckedItem)
			{
				var id = int.Parse(item.SubItems[0].Text);
				WorkingContext.TableList.RemoveAll(p => p.TableId == id);
			}

			LoadTableToLvDetail();
		}

		private void lvTableList_SelectedIndexChanged(object sender, EventArgs e)
		{
			var count = lvTableList.SelectedItems.Count;

			if (count > 0)
			{
				var item = lvTableList.SelectedItems[0];

				txtTableId.Text = item.SubItems[0].Text;
				txtTableName.Text = item.SubItems[1].Text;
				cbbFloor.SelectedIndex = int.Parse(item.SubItems[3].Text) - 1;

				btnDelete.Enabled = true;
				btnUpdate.Enabled = true;
			}
		}

		// Tab page 25/8

		private void CreateButton(int id, string name, int yPos)
		{
			var btn = new Button();
			btn.Text = name;
			btn.BackColor = Color.Aquamarine;
			btn.Height = 30;
			btn.Width = 250;
			btn.Location = new Point(0, yPos);
			btn.Tag = id;
			btn.Click += CategoryButton_Click;
			
			pnFoodCatList.Controls.Add(btn);
		}

		private void CategoryButton_Click(object sender, EventArgs e)
		{
			_currentCategoryId = Convert.ToInt32((sender as Button).Tag);
			var foods = WorkingContext.FoodList; 
			// lọc ra danh sách các món ăn thuộc nhóm có id = _currentCategoryId
			if (_currentCategoryId > 0)
			{
				foods = foods.Where(f => f.CategoryId == _currentCategoryId).ToList();
			}
			LoadFoodListToLV(foods);
		}

		private void LoadFoodListToLV(List<Food> list)
		{
			lvFoodList.Items.Clear();
			foreach (var food in list)
			{
				AddFoodToLV(food);
			}
		}

		private void AddFoodToLV(Food food)
		{
			ListViewItem item = new ListViewItem(food.Id.ToString());
			item.SubItems.Add(food.Name);
			item.SubItems.Add(food.Unit);
			item.SubItems.Add(food.UnitPrice.ToString());
			item.SubItems.Add(food.CategoryId.ToString());
			item.SubItems.Add(food.Description);
			item.SubItems.Add(food.ImageLink);

			lvFoodList.Items.Add(item);
		}
		private void LoadCategoryToPanel()
		{
			var yPos = 0;

			CreateButton(0,"Tất cả", yPos);

			foreach (var cat in WorkingContext.CategoryList)
			{
				yPos += 35;
				CreateButton(cat.Id, cat.Name, yPos);
			}
		}

		private void SetUpSearchInputText()
		{
			txtSearch.Text = PlaceHolderText;
			txtSearch.GotFocus += RemovePlaceHolderText;
			txtSearch.LostFocus += ShowPlaceHolderText;
		}

		private void ShowPlaceHolderText(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtSearch.Text))
				txtSearch.Text = PlaceHolderText;
		}

		private void RemovePlaceHolderText(object sender, EventArgs e)
		{
			if (txtSearch.Text == PlaceHolderText)
				txtSearch.Text = "";
		}

		private void btnAddFood_Click(object sender, EventArgs e)
		{
			var dialog = new FoodForm(_context);
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				var food = dialog.ReturnedFood;
				AddFoodToLV(food);
			}
		}

		private void lvFoodList_DoubleClick(object sender, EventArgs e)
		{
			if (lvFoodList.SelectedItems.Count == 0) return;

			var item = lvFoodList.SelectedItems[0];
			var foodId = Convert.ToInt32(item.Text);

			var dialog = new FoodForm(_context,foodId);
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				var food = dialog.ReturnedFood;
				item.SubItems[1].Text = food.Name;
				item.SubItems[2].Text = food.Unit;
				item.SubItems[3].Text = food.UnitPrice.ToString();
				item.SubItems[4].Text = food.CategoryId.ToString();
				item.SubItems[5].Text = food.Description;
				item.SubItems[6].Text = food.ImageLink;
			}
		}

		private List<Food> FindFoods(int categoryId, string keyword)
		{
			IEnumerable<Food> query = WorkingContext.FoodList;

			if (categoryId > 0)
			{
				query = query.Where(f => f.CategoryId == _currentCategoryId);
			}
			if (!string.IsNullOrWhiteSpace(keyword))
			{
				query = query.Where(f => f.Name.IndexOf(keyword, StringComparison.InvariantCultureIgnoreCase) >= 0);

			}
			return query.ToList();
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			var keyword = txtSearch.Text;
			if (keyword == PlaceHolderText) return;

			var foods = FindFoods(_currentCategoryId, keyword);

			LoadFoodListToLV(foods);
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			_context.SaveFood();
			MessageBox.Show("Đã lưu thành công.", "Thông báo");
		}
	}
}
