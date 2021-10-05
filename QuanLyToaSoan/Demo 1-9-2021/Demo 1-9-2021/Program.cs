using Demo_1_9_2021.IO;
using Demo_1_9_2021.RSSFeed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_1_9_2021
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        static void Main()
        {
            INewRepository repository = new NewsRepository();
            /*NewParser parser = new NewParser();
            RssReader reader = new RssReader(parser);*/
            var manager = new NewsFeedManager(repository/*, reader*/);

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(manager));
        }
    }
}
