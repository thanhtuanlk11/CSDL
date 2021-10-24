
namespace WindowsFormsApp1
{
    partial class AccountManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lvAccount = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip100 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhSáchVaiTròToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.resetPassword = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtStt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAcctive = new System.Windows.Forms.TextBox();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.contextMenuStrip100.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvAccount
            // 
            this.lvAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvAccount.ContextMenuStrip = this.contextMenuStrip100;
            this.lvAccount.FullRowSelect = true;
            this.lvAccount.GridLines = true;
            this.lvAccount.HideSelection = false;
            this.lvAccount.Location = new System.Drawing.Point(4, 195);
            this.lvAccount.MultiSelect = false;
            this.lvAccount.Name = "lvAccount";
            this.lvAccount.Size = new System.Drawing.Size(794, 248);
            this.lvAccount.TabIndex = 0;
            this.lvAccount.UseCompatibleStateImageBehavior = false;
            this.lvAccount.View = System.Windows.Forms.View.Details;
            this.lvAccount.ContextMenuStripChanged += new System.EventHandler(this.AccountManager_Load);
            this.lvAccount.Click += new System.EventHandler(this.lvAccount_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "số thứ tự";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tài khoản";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Mật khẩu";
            this.columnHeader6.Width = 200;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Trạng thái";
            this.columnHeader7.Width = 200;
            // 
            // contextMenuStrip100
            // 
            this.contextMenuStrip100.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip100.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaTàiKhoảnToolStripMenuItem,
            this.xemDanhSáchVaiTròToolStripMenuItem});
            this.contextMenuStrip100.Name = "contextMenuStrip100";
            this.contextMenuStrip100.Size = new System.Drawing.Size(225, 52);
            // 
            // xóaTàiKhoảnToolStripMenuItem
            // 
            this.xóaTàiKhoảnToolStripMenuItem.Name = "xóaTàiKhoảnToolStripMenuItem";
            this.xóaTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(224, 24);
            this.xóaTàiKhoảnToolStripMenuItem.Text = "Xóa tài khoản";
            this.xóaTàiKhoảnToolStripMenuItem.Click += new System.EventHandler(this.xóaTàiKhoảnToolStripMenuItem_Click);
            // 
            // xemDanhSáchVaiTròToolStripMenuItem
            // 
            this.xemDanhSáchVaiTròToolStripMenuItem.Name = "xemDanhSáchVaiTròToolStripMenuItem";
            this.xemDanhSáchVaiTròToolStripMenuItem.Size = new System.Drawing.Size(224, 24);
            this.xemDanhSáchVaiTròToolStripMenuItem.Text = "Xem danh sách vai trò";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(504, 9);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(77, 37);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(504, 52);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(91, 37);
            this.btnCapNhat.TabIndex = 3;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // resetPassword
            // 
            this.resetPassword.Location = new System.Drawing.Point(504, 95);
            this.resetPassword.Name = "resetPassword";
            this.resetPassword.Size = new System.Drawing.Size(128, 38);
            this.resetPassword.TabIndex = 4;
            this.resetPassword.Text = "Reset mật khẩu";
            this.resetPassword.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tài khoản :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu : ";
            // 
            // txtAccount
            // 
            this.txtAccount.Location = new System.Drawing.Point(141, 49);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(332, 22);
            this.txtAccount.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(141, 91);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(332, 22);
            this.txtPassword.TabIndex = 8;
            // 
            // txtStt
            // 
            this.txtStt.Location = new System.Drawing.Point(141, 9);
            this.txtStt.Name = "txtStt";
            this.txtStt.Size = new System.Drawing.Size(332, 22);
            this.txtStt.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Số thứ tự :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Trạng thái :";
            // 
            // txtAcctive
            // 
            this.txtAcctive.Location = new System.Drawing.Point(141, 130);
            this.txtAcctive.Name = "txtAcctive";
            this.txtAcctive.Size = new System.Drawing.Size(332, 22);
            this.txtAcctive.TabIndex = 12;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(504, 139);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(128, 38);
            this.btnLoadData.TabIndex = 13;
            this.btnLoadData.Text = "Lấy danh sách account";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // AccountManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.txtAcctive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStt);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtAccount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resetPassword);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lvAccount);
            this.Name = "AccountManager";
            this.Text = "AccountManager";
            this.Load += new System.EventHandler(this.AccountManager_Load);
            this.contextMenuStrip100.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvAccount;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip100;
        private System.Windows.Forms.ToolStripMenuItem xóaTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDanhSáchVaiTròToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button resetPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccount;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtStt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAcctive;
        private System.Windows.Forms.Button btnLoadData;
    }
}