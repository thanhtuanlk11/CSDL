using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1911170_NguyenHuuThanhNam_tuan3.Compoments;
using _1911170_NguyenHuuThanhNam_tuan3.Models;

namespace _1911170_NguyenHuuThanhNam_tuan3
{

    public partial class Form1 : Form
    {
        private readonly NewsFeedManager _newsManager;
        public Form1(NewsFeedManager newsManager)
        {
            _newsManager = newsManager;
            InitializeComponent(); 
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dialog = new AddFeedForm(_newsManager);
            dialog.ShowDialog(this);
            if (dialog.HasChanges)
            {
               _newsManager.SaveChanges();
               ShowFeedOnTreeView(_newsManager.GetNewFeed()); 
            }
        }

        private void tvwPublisher_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pnlNews.Controls.Clear();
            if (e.Node.Level == 1)
            {
                var articles = _newsManager.GetNews(e.Node.Parent.Text, e.Node.Text);
                foreach (var acticle in articles)
                {
                    var item = new NewsControl();
                    item.Size = new Size(500, 100);
                    item.Dock = DockStyle.Top;
                    item.SetArticle(acticle);
                    pnlNews.Controls.Add(item);
                }
            }

        }

        private void btnRemoved_Click(object sender, EventArgs e)
        {
            if (tvwPublisher.SelectedNode==null)
            {
                return;
            }
            if (tvwPublisher.SelectedNode.Level == 0)
            {
                _newsManager.RemovePublisher(tvwPublisher.SelectedNode.Text);
            }
            else
            {
                var publisherNode = tvwPublisher.SelectedNode.Parent;
                _newsManager.RemoveCategory(publisherNode.Text,tvwPublisher.SelectedNode.Text);
            }
            tvwPublisher.SelectedNode.Remove();
        }
        private void ShowFeedOnTreeView(List<Publisher> publishers)
        {
            tvwPublisher.Nodes.Clear();
            pnlNews.Controls.Clear();
            foreach (var publisher in publishers)
            {
                var publisherNode = tvwPublisher.Nodes.Add(publisher.Name);
                foreach (var catelogy in publisher.Catelogies)
                {
                    publisherNode.Nodes.Add(catelogy.Name);
                }
            }
            tvwPublisher.ExpandAll();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowFeedOnTreeView(_newsManager.GetNewFeed());
        }
    }
}
