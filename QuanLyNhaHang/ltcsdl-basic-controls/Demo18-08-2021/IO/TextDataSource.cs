using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo18_08_2021.DTO;

namespace Demo18_08_2021.IO
{
	public class TextDataSource: IDataSource
	{
		private string _filePath;

		public TextDataSource(string filePath)
		{
			_filePath = filePath;
		}

		public List<Food> GetFoods()
		{
			List<Food> foods = new List<Food>();
			if (File.Exists(_filePath))
			{
				using (var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
				{
					using (var reader = new StreamReader(stream))
					{
						string line;
						while ((line = reader.ReadLine()) != null)
						{
							var food = ParseFood(line);
							foods.Add(food);
						}
					}
				}
			}
			return foods;
		}

		public void Save(List<Food> foods)
		{
			using (var stream = new FileStream(_filePath, FileMode.Create, FileAccess.ReadWrite))
			{
				using (var writer = new StreamWriter(stream))
				{
					foreach (var food in foods)
					{
						var line = FoodFormat(food);
						writer.WriteLine(line);
					}
				}
			}
		}

		private Food ParseFood(string line)
		{
			var parts = line.Split('^');

			return new Food()
			{
				Id = Convert.ToInt32(parts[0]),
				Name = parts[1],
				Unit = parts[2],
				UnitPrice = Convert.ToInt32(parts[3]),
				Description = parts[4],
				ImageLink = parts[5],
				CategoryId = Convert.ToInt32(parts[6])
			};
		}

		private string FoodFormat(Food food)
		{
			return string.Format("{0}^{1}^{2}^{3}^{4}^{5}^{6}", 
				food.Id,
				food.Name,
				food.Unit,
				food.UnitPrice,
				food.Description,
				food.ImageLink,
				food.CategoryId
				);
		}
	}
}
