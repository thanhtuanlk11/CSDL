using Demo_1_9_2021.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Xml;

namespace Demo_1_9_2021.RSSFeed
{
    public class RssReader
    {
        private readonly NewParser _parser;

        public RssReader(NewParser parser)
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
