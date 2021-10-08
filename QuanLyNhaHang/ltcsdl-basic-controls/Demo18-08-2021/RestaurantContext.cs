using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo18_08_2021.DTO;

namespace Demo18_08_2021
{
	public class RestaurantContext
	{
		private List<Food> _foods;
		//private Category<Category> categories;

		private IDataSource _dataSource;

		public RestaurantContext(IDataSource dataSource)
		{
			_dataSource = dataSource;
		}

		public List<Food> GetFoods()
		{
			if (_foods == null)
				_foods = _dataSource.GetFoods();
			return _foods;
		}

		public void SaveFood()
		{
			_dataSource.Save(_foods);
		}
	}
}
