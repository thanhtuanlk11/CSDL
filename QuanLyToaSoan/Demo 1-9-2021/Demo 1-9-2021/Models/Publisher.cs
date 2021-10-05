using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_1_9_2021.Models
{
    public class Publisher
    {
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
        public Publisher()
        {
            Categories = new List<Category>();
        }

        public bool AddCategory(string name, string link, bool updateIfExisted)
        {
            var category = Categories.Find(x => x.Name == name);
            if(category == null)
            {
                category = new Category()
                {
                    Name = name,
                    RssLink = link
                };
                Categories.Add(category);
                return true;
            }
            if (updateIfExisted)
            {
                category.RssLink = link;
                return true;
            }
            return false;
        }
        
        public void RemoveCategory(string name)
        {
            Categories.RemoveAll(x => x.Name == name);
        }
    }
}
