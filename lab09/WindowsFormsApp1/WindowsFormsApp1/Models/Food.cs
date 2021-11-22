﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Food
    {
        public int  Id { get; set; }
        public string  Name { get; set; }
        public string Unit { get; set; }
        public int FoodCategoryId { get; set; }
        public int Price { get; set; }
        public string Notes { get; set; }

        public Category Category { get; set; }
    }
}
