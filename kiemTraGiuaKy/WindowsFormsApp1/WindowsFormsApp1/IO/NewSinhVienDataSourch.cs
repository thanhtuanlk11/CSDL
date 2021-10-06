using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.IO
{
    public class NewSinhVienDataSourch : INewSinhVien
    {
        private const string filePath="Data\\data.txt";
        public List<Khoa> GetNews()
        {
            var khoas = new List<Khoa>();
            Khoa office = null;
            string line;

            try
            {
                using( var stream= new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using( var reader = new StreamReader(stream))
                    {
                        while(!reader.EndOfStream)
                        {
                            line = reader.ReadLine();
                            if(line == null) 
                            {
                                break;
                            }
                            if (line.StartsWith("@"))
                            {
                                office = ParseKhoa(line);
                                khoas.Add(office);
                            }
                            else if(line.StartsWith("#") && office != null)
                            {
                                var lop = ParseLop(line);
                                office.Lops.Add(lop);
                            }

                        }    
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return khoas;
        }

        

        

        public void Save(List<Khoa> khoas)
        {
            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                using (var writer = new StreamWriter(stream))
                {
                    foreach (var khoa in khoas)
                    {
                        writer.WriteLine("@{0}", khoa.Name);
                        foreach (var lop in khoa.Lops)
                        {
                            writer.WriteLine("#{0}^{1}", lop.Name, lop.SinhVienss);
                        }
                    }
                }
            }
        }


        private Khoa ParseKhoa(string info)
        {
            return new Khoa()
            {
                Name = info.Substring(1).Trim()
            };
        }
        private Lop ParseLop(string info)
        {
            var parts = info.Substring(1).Split('^');
            return new Lop()
            {
                Name = parts[0].Trim(),
                SinhVienss = parts[1].Trim()
            };
        }
        
        
      
    }
}
