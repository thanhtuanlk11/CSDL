using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo18_08_2021.IO;

namespace Demo18_08_2021
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//IDataSource dataSource = new TextDataSource("Data\\data.txt");
			IDataSource dataSource = new JsonDataSource("Data\\data.json");
			RestaurantContext context = new RestaurantContext(dataSource);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain(context));
		}
	}
}
