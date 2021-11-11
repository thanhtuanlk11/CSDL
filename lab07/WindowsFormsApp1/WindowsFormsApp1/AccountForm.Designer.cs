
namespace WindowsFormsApp1
{
    partial class AccountForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCall = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpNgay = new System.Windows.Forms.DateTimePicker();
            this.btnLoadAccount = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemDanhSáchVaiTròToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemNhậtKíHoạtĐộngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lvAccount = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tên tài khoản";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(113, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(213, 22);
            this.txtName.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Mật khẩu :";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(113, 50);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(213, 22);
            this.txtPassword.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tên đầy đủ:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(113, 87);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(213, 22);
            this.txtFullName.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(113, 128);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(213, 22);
            this.txtEmail.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(360, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Liên hệ:";
            // 
            // txtCall
            // 
            this.txtCall.Location = new System.Drawing.Point(437, 4);
            this.txtCall.Name = "txtCall";
            this.txtCall.Size = new System.Drawing.Size(213, 22);
            this.txtCall.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(360, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 21;
            this.label6.Text = "Ngày tạo:";
            // 
            // dtpNgay
            // 
            this.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgay.Location = new System.Drawing.Point(437, 45);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(213, 22);
            this.dtpNgay.TabIndex = 22;
            // 
            // btnLoadAccount
            // 
            this.btnLoadAccount.Location = new System.Drawing.Point(363, 90);
            this.btnLoadAccount.Name = "btnLoadAccount";
            this.btnLoadAccount.Size = new System.Drawing.Size(133, 33);
            this.btnLoadAccount.TabIndex = 23;
            this.btnLoadAccount.Text = "Tải danh sách";
            this.btnLoadAccount.UseVisualStyleBackColor = true;
            this.btnLoadAccount.Click += new System.EventHandler(this.btnLoadAccount_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(537, 90);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 32);
            this.btnAdd.TabIndex = 24;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(651, 90);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 33);
            this.btnUpdate.TabIndex = 25;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemDanhSáchVaiTròToolStripMenuItem,
            this.xemNhậtKíHoạtĐộngToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(230, 52);
            // 
            // xemDanhSáchVaiTròToolStripMenuItem
            // 
            this.xemDanhSáchVaiTròToolStripMenuItem.Name = "xemDanhSáchVaiTròToolStripMenuItem";
            this.xemDanhSáchVaiTròToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.xemDanhSáchVaiTròToolStripMenuItem.Text = "Xem danh sách vai trò ";
            // 
            // xemNhậtKíHoạtĐộngToolStripMenuItem
            // 
            this.xemNhậtKíHoạtĐộngToolStripMenuItem.Name = "xemNhậtKíHoạtĐộngToolStripMenuItem";
            this.xemNhậtKíHoạtĐộngToolStripMenuItem.Size = new System.Drawing.Size(229, 24);
            this.xemNhậtKíHoạtĐộngToolStripMenuItem.Text = "Xem nhật kí hoạt động";
            // 
            // lvAccount
            // 
            this.lvAccount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvAccount.ContextMenuStrip = this.contextMenuStrip1;
            this.lvAccount.FullRowSelect = true;
            this.lvAccount.HideSelection = false;
            this.lvAccount.Location = new System.Drawing.Point(-1, 209);
            this.lvAccount.MultiSelect = false;
            this.lvAccount.Name = "lvAccount";
            this.lvAccount.Size = new System.Drawing.Size(804, 323);
            this.lvAccount.TabIndex = 26;
            this.lvAccount.UseCompatibleStateImageBehavior = false;
            this.lvAccount.View = System.Windows.Forms.View.Details;
            this.lvAccount.Click += new System.EventHandler(this.lvAccount_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên tài khoản";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mật khẩu";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên đầy đủ ";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Email";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Liên hệ";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Ngày tạo";
            this.columnHeader6.Width = 120;
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 535);
            this.Controls.Add(this.lvAccount);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLoadAccount);
            this.Controls.Add(this.dtpNgay);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCall);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Name = "AccountForm";
            this.Text = "AccountForm";
            this.Load += new System.EventHandler(this.AccountForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCall;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNgay;
        private System.Windows.Forms.Button btnLoadAccount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xemDanhSáchVaiTròToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemNhậtKíHoạtĐộngToolStripMenuItem;
        private System.Windows.Forms.ListView lvAccount;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}