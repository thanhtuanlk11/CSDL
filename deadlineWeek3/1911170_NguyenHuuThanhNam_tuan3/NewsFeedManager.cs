using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1911170_NguyenHuuThanhNam_tuan3.IO;
using _1911170_NguyenHuuThanhNam_tuan3.Models;
using _1911170_NguyenHuuThanhNam_tuan3.RssFeed;

namespace _1911170_NguyenHuuThanhNam_tuan3
{
    public class NewsFeedManager
    {
        private readonly INewsRepository _newsRepository;
        private List<Publisher> _publishers;
        private readonly RssReader _rssReader;

        public NewsFeedManager(INewsRepository newsRepository, RssReader rssReader)
        {
            _newsRepository = newsRepository;
            _rssReader = rssReader;
        }

        public NewsFeedManager()
        {
        }

        public List<Publisher> GetNewFeed()
        {
            if(_publishers == null)
            {
                _publishers = _newsRepository.GetNew();
            }
            return _publishers;
        }
        public void SaveChanges()
        {
            _newsRepository.Save(_publishers);
        }
        public void RemovePublisher(string publisherName)
        {
            _publishers.RemoveAll(x => x.Name == publisherName);
            SaveChanges();
        }
        public void RemoveCategory(string publisherName,string categoryName)
        {
            var publisher = _publishers.Find(x => x.Name == publisherName);
            if (publisher == null) return;
            publisher.RemoveCatelogy(categoryName);
            SaveChanges();
        }
        public bool AddCategory(string publisherName,string catelogyName,string rssLink,bool updateIfExisted)
        {
            var publisher = _publishers.Find(x => x.Name == publisherName);
            if (publisher==null)
            {
                publisher = new Publisher()
                {
                    Name = publisherName

                };
                _publishers.Add(publisher);
            }
            return publisher.AddCategory(catelogyName, rssLink, updateIfExisted);
        }
        public List<Article> GetNews(string publisherName, string categoryName)
        {
            var publisher = _publishers.Find(x => x.Name == publisherName);
            if (publisher == null) return new List<Article>();

            var category = publisher.Catelogies.Find(x => x.Name == categoryName);
            if (category == null) return new List<Article>();
            if (category.Articles.Count == 0)
            {
                category.Articles = _rssReader.GetNews(category.RssLink);
            }
            return category.Articles;
        }
    }
}
