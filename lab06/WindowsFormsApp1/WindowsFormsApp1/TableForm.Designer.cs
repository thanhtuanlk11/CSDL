
namespace WindowsFormsApp1
{
    partial class frmTable
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
            this.btnCheckBills = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStt = new System.Windows.Forms.TextBox();
            this.txtTableMunber = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvTable = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaBànToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhMụcHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemNhậtKýHóaĐơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_load = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheckBills
            // 
            this.btnCheckBills.Location = new System.Drawing.Point(416, 13);
            this.btnCheckBills.Name = "btnCheckBills";
            this.btnCheckBills.Size = new System.Drawing.Size(125, 28);
            this.btnCheckBills.TabIndex = 0;
            this.btnCheckBills.Text = "Xem hóa đơn";
            this.btnCheckBills.UseVisualStyleBackColor = true;
            this.btnCheckBills.Click += new System.EventHandler(this.btnCheckBills_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(416, 61);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(125, 28);
            this.btnAddTable.TabIndex = 1;
            this.btnAddTable.Text = "Thêm bàn mới";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(416, 106);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(125, 28);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(416, 155);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa bàn";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Số thứ tự ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Số bàn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Trạng thái";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtStt
            // 
            this.txtStt.Location = new System.Drawing.Point(126, 17);
            this.txtStt.Name = "txtStt";
            this.txtStt.Size = new System.Drawing.Size(192, 22);
            this.txtStt.TabIndex = 8;
            // 
            // txtTableMunber
            // 
            this.txtTableMunber.Location = new System.Drawing.Point(126, 67);
            this.txtTableMunber.Name = "txtTableMunber";
            this.txtTableMunber.Size = new System.Drawing.Size(192, 22);
            this.txtTableMunber.TabIndex = 9;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(126, 107);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(192, 22);
            this.txtStatus.TabIndex = 10;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Số thứ tự";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số bàn";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Trạng thái";
            this.columnHeader3.Width = 150;
            // 
            // lvTable
            // 
            this.lvTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvTable.ContextMenuStrip = this.contextMenuStrip1;
            this.lvTable.FullRowSelect = true;
            this.lvTable.HideSelection = false;
            this.lvTable.Location = new System.Drawing.Point(3, 213);
            this.lvTable.MultiSelect = false;
            this.lvTable.Name = "lvTable";
            this.lvTable.Size = new System.Drawing.Size(613, 239);
            this.lvTable.TabIndex = 11;
            this.lvTable.UseCompatibleStateImageBehavior = false;
            this.lvTable.View = System.Windows.Forms.View.Details;
            this.lvTable.Click += new System.EventHandler(this.lvTable_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Sức chứa";
            this.columnHeader4.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaBànToolStripMenuItem,
            this.xemDanhMụcHóaĐơnToolStripMenuItem,
            this.xemNhậtKýHóaĐơnToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(237, 76);
            // 
            // xóaBànToolStripMenuItem
            // 
            this.xóaBànToolStripMenuItem.Name = "xóaBànToolStripMenuItem";
            this.xóaBànToolStripMenuItem.Size = new System.Drawing.Size(236, 24);
            this.xóaBànToolStripMenuItem.Text = "Xóa bàn ";
            this.xóaBànToolStripMenuItem.Click += new System.EventHandler(this.xóaBànToolStripMenuItem_Click);
            // 
            // xemDanhMụcHóaĐơnToolStripMenuItem
            // 
            this.xemDanhMụcHóaĐơnToolStripMenuItem.Name = "xemDanhMụcHóaĐơnToolStripMenuItem";
            this.xemDanhMụcHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(236, 24);
            this.xemDanhMụcHóaĐơnToolStripMenuItem.Text = "Xem danh mục hóa đơn";
            this.xemDanhMụcHóaĐơnToolStripMenuItem.Click += new System.EventHandler(this.xemDanhMụcHóaĐơnToolStripMenuItem_Click);
            // 
            // xemNhậtKýHóaĐơnToolStripMenuItem
            // 
            this.xemNhậtKýHóaĐơnToolStripMenuItem.Name = "xemNhậtKýHóaĐơnToolStripMenuItem";
            this.xemNhậtKýHóaĐơnToolStripMenuItem.Size = new System.Drawing.Size(236, 24);
            this.xemNhậtKýHóaĐơnToolStripMenuItem.Text = "Xem nhật ký hóa đơn";
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(28, 171);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(138, 36);
            this.btn_load.TabIndex = 12;
            this.btn_load.Text = "Tải danh sách bàn";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Sức chứa";
            // 
            // txtCapacity
            // 
            this.txtCapacity.Location = new System.Drawing.Point(126, 148);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(192, 22);
            this.txtCapacity.TabIndex = 14;
            // 
            // frmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 450);
            this.Controls.Add(this.txtCapacity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.lvTable);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.txtTableMunber);
            this.Controls.Add(this.txtStt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddTable);
            this.Controls.Add(this.btnCheckBills);
            this.Name = "frmTable";
            this.Text = "TableForm";
            this.Load += new System.EventHandler(this.frmTable_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheckBills;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStt;
        private System.Windows.Forms.TextBox txtTableMunber;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView lvTable;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaBànToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDanhMụcHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemNhậtKýHóaĐơnToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCapacity;
    }
}