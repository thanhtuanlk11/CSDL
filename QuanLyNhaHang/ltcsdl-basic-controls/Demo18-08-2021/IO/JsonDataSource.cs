using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Demo18_08_2021.DTO;

namespace Demo18_08_2021.IO
{
	public class JsonDataSource:IDataSource
	{
		private string _filePath;

		public JsonDataSource(string filePath)
		{
			_filePath = filePath;
		}

		public List<Food> GetFoods()
		{
			List<Food> foods = new List<Food>();
			if (File.Exists(_filePath))
			{
				using (var reader = new StreamReader(_filePath))
				{
					var json = reader.ReadToEnd();
					foods = JsonConvert.DeserializeObject<List<Food>>(json);
				}
			}
			return foods;
		}

		public void Save(List<Food> foods)
		{
			var foodData = JsonConvert.SerializeObject(foods);
			File.WriteAllText(_filePath, foodData);
		}
	}
}
