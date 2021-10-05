using Demo_1_9_2021.Components;
using Demo_1_9_2021.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_1_9_2021
{
    public partial class MainForm : Form
    {
        private readonly NewsFeedManager _newsManager;
        public MainForm(NewsFeedManager newsManager)
        {
            _newsManager = newsManager;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new AddFeedForm(_newsManager);
            dialog.ShowDialog(this);
            if (dialog.HasChanges)
            {
                _newsManager.SaveChanges();
                ShowFeedOnTreeView(_newsManager.GetNewsFeed());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tvwPublisher.SelectedNode == null) return;
            if(tvwPublisher.SelectedNode.Level == 0)
            {
                _newsManager.RemovePublisher(tvwPublisher.SelectedNode.Text);
            }
            else
            {
                var publisherNode = tvwPublisher.SelectedNode.Parent;
                _newsManager.RemoveCategory(publisherNode.Text, tvwPublisher.SelectedNode.Text);
            }
            tvwPublisher.SelectedNode.Remove(); 
        }

        private void tvwPublisher_AfterSelect(object sender, TreeViewEventArgs e)
        {
            pnlNews.Controls.Clear();
            /*if(e.Node.Level == 1)
            {
                var articles = _newsManager.GetNews(e.Node.Parent.Text, e.Node.Text);
                foreach (var article in articles)
                {
                    var item = new NewsControl();
                    item.Size = new Size(500, 100);
                    item.Dock = DockStyle.Top;
                    item.SetArticle(article);
                    pnlNews.Controls.Add(item);
                }
            }*/

            if(e.Node.Level == 0)
            {
                MessageBox.Show($"Tòa soạn: {e.Node.Text}", "Bạn chọn");
            }
            else
            {
                MessageBox.Show($"Tòa soạ: {e.Node.Parent.Text}, Chuyên mục: {e.Node.Text}", "Bạn chọn");
            }    
        }

        public void ShowFeedOnTreeView(List<Publisher> publishers)
        {
            tvwPublisher.Nodes.Clear();
            pnlNews.Controls.Clear();

            foreach(var publisher in publishers)
            {
                var publisherNode = tvwPublisher.Nodes.Add(publisher.Name);
                foreach(var category in publisher.Categories)
                {
                    publisherNode.Nodes.Add(category.Name);
                }
            }
            tvwPublisher.ExpandAll();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowFeedOnTreeView(_newsManager.GetNewsFeed());
        }

        private void pnlNews_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
