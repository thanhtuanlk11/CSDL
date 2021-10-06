using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly QuanLySinhVien _quanLySinhVien;

        public Form1(QuanLySinhVien quanLySinhVien)
        {
            _quanLySinhVien = quanLySinhVien;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowTreeOnTreeView(_quanLySinhVien.GetNew());
        }
        private void ShowTreeOnTreeView(List<Khoa> khoas)
        {
            tvwKhoa.Nodes.Clear();
            lvItem.Controls.Clear();
            foreach (var khoa in khoas)
            {
                var khoaNode = tvwKhoa.Nodes.Add(khoa.Name);
                foreach (var lop in khoa.Lops)
                {
                    khoaNode.Nodes.Add(lop.Name);
                }

            }
            tvwKhoa.ExpandAll();
        }

       
    }
}
