using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1911170_NguyenHuuThanhNam_tuan3.Models;
using _1911170_NguyenHuuThanhNam_tuan3.RssFeed;


namespace _1911170_NguyenHuuThanhNam_tuan3.IO
{
    public class NewsRepository : INewsRepository
    {
        private const string FilePath="data\\data.txt";

        public List<Publisher> GetNew()
        {
            var publisher = new List<Publisher>();
            Publisher office = null;
            string line;
            try
            {
                using (var stream= new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    using(var reader =new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            if (line == null)
                            {
                                break;
                            }
                            if (line.StartsWith("@"))
                            {
                                office = ParsePublisher(line);
                                publisher.Add(office);
                            }
                            else if (line.StartsWith("#")&& office!=null)
                            {
                                var category = ParseCategory(line);
                                office.Catelogies.Add(category);

                            }
                        }
                    }    
                }
            }
            catch (Exception)
            {

                throw;
            }
            return publisher;
        }

        public void Save(List<Publisher> publishers)
        {
            using (var stream = new FileStream(FilePath, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new StreamWriter(stream))
                {
                    foreach(var publisher in publishers)
                    {
                        writer.WriteLine("@{0}", publisher.Name);
                        foreach (var category in publisher.Catelogies)
                        {
                            writer.WriteLine("#{0}^{1}", category.Name, category.RssLink); 
                        }
                    }   
                }
            }
        }
        private Publisher ParsePublisher(string info)
        {
            return new Publisher()
            {
                Name = info.Substring(1).Trim()
            };
        }
        private Catelogy ParseCategory(string info)
        {
            var parts = info.Substring(1).Split('^');
            return new Catelogy()
            {
                Name = parts[0].Trim(),
                RssLink = parts[1].Trim()
            };
        }
    }
}
