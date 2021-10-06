using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1911170_NguyenHuuThanhNam_tuan3.RssFeed;

namespace _1911170_NguyenHuuThanhNam_tuan3.Models
{
    public class Catelogy
    {
        public string Name { get; set; }
        public string RssLink { get; set; }
        public List<Article> Articles{get;set;}

        public Catelogy()
        {
            Articles = new List<Article>();
        }
    }
}
