using Demo_1_9_2021.IO;
using Demo_1_9_2021.Models;
using Demo_1_9_2021.RSSFeed;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_1_9_2021
{
    public class NewsFeedManager
    {
        private readonly INewRepository _newRepository;

        private List<Publisher> _publishers;
        private readonly RssReader _rssReader;
        public NewsFeedManager(INewRepository newRepository)
        {
            _newRepository = newRepository;
        }

        public List<Publisher> GetNewsFeed()
        {
            if(_publishers == null)
            {
                _publishers = _newRepository.GetNews();
            }
            return _publishers;
        }

        public void SaveChanges()
        {
            _newRepository.Save(_publishers);
        }

        public void RemovePublisher(string publisherName)
        {
            _publishers.RemoveAll(x => x.Name == publisherName);
            SaveChanges();
        }

        public void RemoveCategory(string _publisherName, string categoryName)
        {
            var publisher = _publishers.Find(x => x.Name == _publisherName);
            if (publisher == null)
                return;
            publisher.RemoveCategory(categoryName);
            SaveChanges(); 
        }

        public bool AddCategory(string publisherName, string categoryName, string rssLink, bool updateIfExisted)
        {
            var publisher = _publishers.Find(x => x.Name == publisherName);
            if (publisher == null)
            {
                publisher = new Publisher()
                {
                    Name = publisherName
                };
                _publishers.Add(publisher);
            }
            return publisher.AddCategory(categoryName, rssLink, updateIfExisted);
        }

        public List<Article> GetNews(string publisherName, string categoryName)
        {
            var publisher = _publishers.Find(x => x.Name == publisherName);
            if (publisher == null) return new List<Article>();

            var category = publisher.Categories.Find(x => x.Name == categoryName);
            if (category == null) return new List<Article>();

            if(category.Articles.Count == 0)
            {
                category.Articles = _rssReader.GetNews(category.RssLink);
            }
            return category.Articles;
        }
    }
}
