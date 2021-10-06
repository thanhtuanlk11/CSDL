using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using _1911170_NguyenHuuThanhNam_tuan3.Models;
using _1911170_NguyenHuuThanhNam_tuan3.RssFeed;

namespace _1911170_NguyenHuuThanhNam_tuan3.RssFeed
{
    public class RssReader
    {
        private readonly NewsParser _parser;
        public RssReader(NewsParser parser)
        {
            _parser = parser;
        }
        public List<Article> GetNews(string rssLink)
        {
            var feedData = DownloadFeed(rssLink);
            return _parser.ParseXml(feedData);
        }
        private string DownloadFeed(string rssLink)
        {
            var client = new WebClient()
            {
                Encoding = Encoding.UTF8
            };
            return client.DownloadString(rssLink);
        }
    }
}
