using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo18_08_2021.DTO;

namespace Demo18_08_2021
{
	public partial class FoodForm : Form
	{
		private int _foodId;

		private List<Food> _foods;

		private RestaurantContext _context;


		public Food ReturnedFood { get; private set; }

		public FoodForm(RestaurantContext context, int foodId = 0)
		{
			InitializeComponent();
			_context = context;
			_foodId = foodId;
			_foods = _context.GetFoods();
			if (_foodId > 0)
			{
				ReturnedFood = _foods.FirstOrDefault(f => f.Id == _foodId);
				ShowFoodInfo(ReturnedFood);
			}
		}

		private void FoodForm_Load(object sender, EventArgs e)
		{
			cbbCategory.DataSource = WorkingContext.CategoryList;
			cbbCategory.DisplayMember = "Name";
			cbbCategory.ValueMember = "Id";
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Title = "Select Picture";// "Add Photos";
			dlg.Filter = "Image Files (JPEG, GIF, BMP, etc.)|"
						  + "*.jpg;*.jpeg;*.gif;*.bmp;"
						  + "*.tif;*.tiff;*.png|"
						+ "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|"
						+ "GIF files (*.gif)|*.gif|"
						+ "BMP files (*.bmp)|*.bmp|"
						+ "TIFF files (*.tif;*.tiff)|*.tif;*.tiff|"
						+ "PNG files (*.png)|*.png|"
						+ "All files (*.*)|*.*";

			dlg.InitialDirectory = Environment.CurrentDirectory;

			if (dlg.ShowDialog() == DialogResult.OK)
			{
				var fileName = dlg.FileName;
				txtImageLink.Text = fileName;
				ptbFoodImage.Load(fileName);
			}
		}

		private void btnSaveFood_Click(object sender, EventArgs e)
		{
			var name = txtFoodName.Text;
			var unit = txtUnit.Text;
			var description = txtDescription.Text;
			var link = txtImageLink.Text;
			var price = Convert.ToInt32(nudUnitPrice.Value);
			var categoryId = Convert.ToInt32(cbbCategory.SelectedValue);

			if (_foodId == 0)
			{
				int id = _foods.Any() ? _foods.Max(f => f.Id) + 1 : 1;
				ReturnedFood = new Food(id, name, unit, price, description, link, categoryId);
				_foods.Add(ReturnedFood);
			}
			else
			{
				if (ReturnedFood != null)
				{
					ReturnedFood.Name = name;
					ReturnedFood.Unit = unit;
					ReturnedFood.UnitPrice = price;
					ReturnedFood.Description = description;
					ReturnedFood.ImageLink = link;
					ReturnedFood.CategoryId = categoryId;
				} 
			}

			DialogResult = DialogResult.OK;
		}

		private void ShowFoodInfo(Food food)
		{
			if (food == null) return;

			txtFoodId.Text = food.Id.ToString();
			txtFoodName.Text = food.Name;
			txtUnit.Text = food.Unit;
			nudUnitPrice.Value = food.UnitPrice;
			txtImageLink.Text = food.ImageLink;
			cbbCategory.SelectedValue = food.CategoryId;
			txtDescription.Text = food.Description;

			if (!string.IsNullOrWhiteSpace(food.ImageLink) && File.Exists(food.ImageLink))
			{
				ptbFoodImage.Load(food.ImageLink);
			}
		}

		
	}
}
