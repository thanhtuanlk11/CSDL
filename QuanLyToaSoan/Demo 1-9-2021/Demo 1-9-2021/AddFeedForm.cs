using Demo_1_9_2021.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Demo_1_9_2021
{
    public partial class AddFeedForm : Form
    {
        private readonly NewsFeedManager _newsManager;
        public bool HasChanges { get; set; }
        public AddFeedForm(NewsFeedManager newsManager)
        {
            _newsManager = newsManager;
            InitializeComponent();
        }

        private void AddFeedForm_Load(object sender, EventArgs e)
        {
            var publishers = _newsManager.GetNewsFeed();
            foreach(var publisher in publishers)
            {
                cbbToaSoan.Items.Add(publisher.Name);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var publisherName = cbbToaSoan.Text;
            var categoryName = txtChuyenMuc.Text;
            var rssLink = txtRssLink.Text;

            if(string.IsNullOrWhiteSpace(publisherName)||
                string.IsNullOrWhiteSpace(categoryName)||
                string.IsNullOrWhiteSpace(rssLink))
            {
                MessageBox.Show("Bạn phải nhập đầy đủ dữ liệu", "Lỗi");
                return;
            }
            HasChanges = true;
            var success = _newsManager.AddCategory(publisherName, categoryName, rssLink, false);
            if (success)
            {
                ClearForm();
                return;
            }
            if(MessageBox.Show("Chuyên mục này đã tồn tại, bạn có muốn cập nhập RSS link không?","Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _newsManager.AddCategory(publisherName, categoryName, rssLink, true);
            }
            ClearForm();
        }

        private void ClearForm()
        {
            cbbToaSoan.Text = "";
            txtChuyenMuc.Text = "";
            txtRssLink.Text = "";
        }
    }
}
