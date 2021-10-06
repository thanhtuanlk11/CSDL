using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1911170_NguyenHuuThanhNam_tuan3.Models;
using _1911170_NguyenHuuThanhNam_tuan3.IO;
using _1911170_NguyenHuuThanhNam_tuan3.RssFeed;


namespace _1911170_NguyenHuuThanhNam_tuan3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            INewsRepository repository = new NewsRepository();
            NewsParser parser = new NewsParser();
            RssReader reader = new RssReader(parser);
            NewsFeedManager manager = new NewsFeedManager(repository,reader);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(manager));
        }
    }
} 
 