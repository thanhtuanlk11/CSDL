using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1911170_NguyenHuuThanhNam_tuan3
{
    public partial class AddFeedForm : Form
    {
        private readonly NewsFeedManager _newManager;
        public bool HasChanges { get; set; }
        public AddFeedForm(NewsFeedManager newManager)
        {
            _newManager = newManager;
            InitializeComponent();
        }
        public AddFeedForm()
        {
            InitializeComponent();
        }

    

        private void AddFeedForm_Load(object sender, EventArgs e)
        {
            var publishers = _newManager.GetNewFeed();
            foreach (var publisher in publishers)
            {
                cbbPublishers.Items.Add(publisher.Name);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var publisherName = cbbPublishers.Text;
            var categoryName = txtCatelogyName.Text;
            var rssLink = txtRssLink.Text;
            if(string.IsNullOrWhiteSpace(publisherName) | string.IsNullOrWhiteSpace(categoryName) || string.IsNullOrWhiteSpace(rssLink))
            {
                MessageBox.Show("Bạn phải nhập dầy đủ dữ liệu", "Lỗi");
                return;
            }
            HasChanges = true;
            var success = _newManager.AddCategory(publisherName, categoryName, rssLink, false);
            if (success)
            {
                ClearForm();
                return;
            }
            if(MessageBox.Show("Chuyên mục này đã tồn tại, bạn có muốn cập nhật Rss link không ","Thông báo",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                _newManager.AddCategory(publisherName, categoryName, rssLink, true);
            }
            ClearForm();
        }
       private void ClearForm()
        {
            cbbPublishers.Text = "";
            txtCatelogyName.Text = "";
            txtRssLink.Text = "";
        }
    }
}
