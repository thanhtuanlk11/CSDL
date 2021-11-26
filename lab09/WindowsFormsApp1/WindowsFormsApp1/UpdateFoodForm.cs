using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class UpdateFoodForm : Form
    {
        private RestaurantContext _dbContext;
        private int _foodID;
        public UpdateFoodForm(int ? foodId = null)
        {
            InitializeComponent();
            _dbContext = new RestaurantContext();
            _foodID = foodId ?? 0;
        }

        private void UpdateFoodForm_Load(object sender, EventArgs e)
        {

        }
    }
}
