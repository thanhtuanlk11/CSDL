
namespace QuanLyThuVienCaNhan
{
    partial class frmThongKe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongKe));
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.btnTacGia = new System.Windows.Forms.Button();
            this.btnTheLoai = new System.Windows.Forms.Button();
            this.btnSachMuon = new System.Windows.Forms.Button();
            this.btnThoiGian = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Location = new System.Drawing.Point(40, 189);
            this.dgvDanhSach.Name = "dgvDanhSach";
            this.dgvDanhSach.RowHeadersWidth = 51;
            this.dgvDanhSach.RowTemplate.Height = 24;
            this.dgvDanhSach.Size = new System.Drawing.Size(878, 320);
            this.dgvDanhSach.TabIndex = 0;
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label19.Location = new System.Drawing.Point(391, 24);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(178, 35);
            this.label19.TabIndex = 56;
            this.label19.Text = "THỐNG KÊ";
            // 
            // btnTacGia
            // 
            this.btnTacGia.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTacGia.AutoSize = true;
            this.btnTacGia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTacGia.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTacGia.ForeColor = System.Drawing.Color.Red;
            this.btnTacGia.Location = new System.Drawing.Point(40, 115);
            this.btnTacGia.Margin = new System.Windows.Forms.Padding(4);
            this.btnTacGia.Name = "btnTacGia";
            this.btnTacGia.Size = new System.Drawing.Size(146, 42);
            this.btnTacGia.TabIndex = 68;
            this.btnTacGia.Text = "Theo tác giả";
            this.btnTacGia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTacGia.UseVisualStyleBackColor = false;
            // 
            // btnTheLoai
            // 
            this.btnTheLoai.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTheLoai.AutoSize = true;
            this.btnTheLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTheLoai.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheLoai.ForeColor = System.Drawing.Color.Red;
            this.btnTheLoai.Location = new System.Drawing.Point(259, 115);
            this.btnTheLoai.Margin = new System.Windows.Forms.Padding(4);
            this.btnTheLoai.Name = "btnTheLoai";
            this.btnTheLoai.Size = new System.Drawing.Size(154, 42);
            this.btnTheLoai.TabIndex = 68;
            this.btnTheLoai.Text = "Theo thể loại";
            this.btnTheLoai.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTheLoai.UseVisualStyleBackColor = false;
            // 
            // btnSachMuon
            // 
            this.btnSachMuon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSachMuon.AutoSize = true;
            this.btnSachMuon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSachMuon.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSachMuon.ForeColor = System.Drawing.Color.Red;
            this.btnSachMuon.Location = new System.Drawing.Point(499, 115);
            this.btnSachMuon.Margin = new System.Windows.Forms.Padding(4);
            this.btnSachMuon.Name = "btnSachMuon";
            this.btnSachMuon.Size = new System.Drawing.Size(188, 42);
            this.btnSachMuon.TabIndex = 68;
            this.btnSachMuon.Text = "Theo sách mượn";
            this.btnSachMuon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSachMuon.UseVisualStyleBackColor = false;
            // 
            // btnThoiGian
            // 
            this.btnThoiGian.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThoiGian.AutoSize = true;
            this.btnThoiGian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnThoiGian.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoiGian.ForeColor = System.Drawing.Color.Red;
            this.btnThoiGian.Location = new System.Drawing.Point(749, 115);
            this.btnThoiGian.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoiGian.Name = "btnThoiGian";
            this.btnThoiGian.Size = new System.Drawing.Size(169, 42);
            this.btnThoiGian.TabIndex = 68;
            this.btnThoiGian.Text = "Theo thời gian";
            this.btnThoiGian.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnThoiGian.UseVisualStyleBackColor = false;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(977, 561);
            this.Controls.Add(this.btnSachMuon);
            this.Controls.Add(this.btnTheLoai);
            this.Controls.Add(this.btnThoiGian);
            this.Controls.Add(this.btnTacGia);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dgvDanhSach);
            this.Name = "frmThongKe";
            this.Text = "frmThongKe";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnTacGia;
        private System.Windows.Forms.Button btnTheLoai;
        private System.Windows.Forms.Button btnSachMuon;
        private System.Windows.Forms.Button btnThoiGian;
    }
}