using Demo_1_9_2021.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo_1_9_2021.IO
{
    public interface INewRepository
    {
        List<Publisher> GetNews();
        void Save(List<Publisher> publishers);
    }
}
