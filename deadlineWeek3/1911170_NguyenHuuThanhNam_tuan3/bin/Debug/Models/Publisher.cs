using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _1911170_NguyenHuuThanhNam_tuan3.RssFeed;
using System.Threading.Tasks;

namespace _1911170_NguyenHuuThanhNam_tuan3.Models
{
    public class Publisher
    {
        public string Name { get; set; }
        public List<Catelogy> Catelogies { get; set; }
        public Publisher()
        {
            Catelogies = new List<Catelogy>();
        }
        public bool AddCategory(string name,string link,bool updateIfExisted)
        {
            var category = Catelogies.Find(x => x.Name == name);
            if (category == null)
            {
                category = new Catelogy()
                {
                    Name = name,
                    RssLink = link

                };
                Catelogies.Add(category);
                return true;
            }
            if (updateIfExisted)
            {
                category.RssLink = link;
                return true;
            }
            return false;
       
        }
        public void RemoveCatelogy(string name)
        {
            Catelogies.RemoveAll(x => x.Name == name);
        }
    } 
}
