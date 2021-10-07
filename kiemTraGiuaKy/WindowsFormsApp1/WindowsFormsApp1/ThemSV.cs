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
    public partial class frmThemSV:Form
    {
        public List<SinhVien> ListSV;
        QuanLySinhVien qlsv;
        ListView listView;

        public frmThemSV(QuanLySinhVien qlsv, ListView listView)
        {
            InitializeComponent();
            this.qlsv = qlsv;
            this.listView = listView;
        }
      
        private void frmThemSV_Load(object sender, EventArgs e)
        {

        }

        private void btnLưu_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
