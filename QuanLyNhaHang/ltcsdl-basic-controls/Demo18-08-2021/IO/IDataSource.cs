using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo18_08_2021.DTO;

namespace Demo18_08_2021
{
	public interface IDataSource
	{
		List<Food> GetFoods();

		void Save(List<Food> foods);
	}
}
