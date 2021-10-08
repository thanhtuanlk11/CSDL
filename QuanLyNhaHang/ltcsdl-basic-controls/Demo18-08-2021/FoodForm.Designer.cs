namespace Demo18_08_2021
{
	partial class FoodForm
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
			this.cbbCategory = new System.Windows.Forms.ComboBox();
			this.btnSaveFood = new System.Windows.Forms.Button();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.nudUnitPrice = new System.Windows.Forms.NumericUpDown();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.ptbFoodImage = new System.Windows.Forms.PictureBox();
			this.txtFoodId = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtImageLink = new System.Windows.Forms.TextBox();
			this.txtUnit = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtFoodName = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.nudUnitPrice)).BeginInit();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ptbFoodImage)).BeginInit();
			this.SuspendLayout();
			// 
			// cbbCategory
			// 
			this.cbbCategory.FormattingEnabled = true;
			this.cbbCategory.Location = new System.Drawing.Point(309, 159);
			this.cbbCategory.Name = "cbbCategory";
			this.cbbCategory.Size = new System.Drawing.Size(255, 21);
			this.cbbCategory.TabIndex = 24;
			// 
			// btnSaveFood
			// 
			this.btnSaveFood.Location = new System.Drawing.Point(382, 276);
			this.btnSaveFood.Name = "btnSaveFood";
			this.btnSaveFood.Size = new System.Drawing.Size(75, 27);
			this.btnSaveFood.TabIndex = 26;
			this.btnSaveFood.Text = "Lưu";
			this.btnSaveFood.UseVisualStyleBackColor = true;
			this.btnSaveFood.Click += new System.EventHandler(this.btnSaveFood_Click);
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(308, 188);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(257, 81);
			this.txtDescription.TabIndex = 25;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(571, 130);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 22);
			this.btnBrowse.TabIndex = 23;
			this.btnBrowse.Text = "Chọn hình";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// nudUnitPrice
			// 
			this.nudUnitPrice.Location = new System.Drawing.Point(310, 106);
			this.nudUnitPrice.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.nudUnitPrice.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.nudUnitPrice.Name = "nudUnitPrice";
			this.nudUnitPrice.Size = new System.Drawing.Size(254, 20);
			this.nudUnitPrice.TabIndex = 22;
			this.nudUnitPrice.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.ptbFoodImage);
			this.groupBox4.Location = new System.Drawing.Point(19, 24);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(175, 180);
			this.groupBox4.TabIndex = 34;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Hình món ăn";
			// 
			// ptbFoodImage
			// 
			this.ptbFoodImage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ptbFoodImage.Location = new System.Drawing.Point(3, 16);
			this.ptbFoodImage.Name = "ptbFoodImage";
			this.ptbFoodImage.Size = new System.Drawing.Size(169, 161);
			this.ptbFoodImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.ptbFoodImage.TabIndex = 0;
			this.ptbFoodImage.TabStop = false;
			// 
			// txtFoodId
			// 
			this.txtFoodId.Location = new System.Drawing.Point(308, 28);
			this.txtFoodId.Name = "txtFoodId";
			this.txtFoodId.ReadOnly = true;
			this.txtFoodId.Size = new System.Drawing.Size(257, 20);
			this.txtFoodId.TabIndex = 35;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(204, 35);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(89, 13);
			this.label8.TabIndex = 27;
			this.label8.Text = "Mã món ăn/uống";
			// 
			// txtImageLink
			// 
			this.txtImageLink.Location = new System.Drawing.Point(308, 132);
			this.txtImageLink.Name = "txtImageLink";
			this.txtImageLink.ReadOnly = true;
			this.txtImageLink.Size = new System.Drawing.Size(257, 20);
			this.txtImageLink.TabIndex = 36;
			// 
			// txtUnit
			// 
			this.txtUnit.Location = new System.Drawing.Point(308, 80);
			this.txtUnit.Name = "txtUnit";
			this.txtUnit.Size = new System.Drawing.Size(257, 20);
			this.txtUnit.TabIndex = 21;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(204, 191);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(34, 13);
			this.label13.TabIndex = 32;
			this.label13.Text = "Mô tả";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(204, 167);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(73, 13);
			this.label14.TabIndex = 31;
			this.label14.Text = "Nhóm món ăn";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(204, 143);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(50, 13);
			this.label12.TabIndex = 30;
			this.label12.Text = "Hình ảnh";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(204, 113);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(44, 13);
			this.label11.TabIndex = 29;
			this.label11.Text = "Đơn giá";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(204, 85);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(60, 13);
			this.label10.TabIndex = 28;
			this.label10.Text = "Đơn vị tính";
			// 
			// txtFoodName
			// 
			this.txtFoodName.Location = new System.Drawing.Point(308, 54);
			this.txtFoodName.Name = "txtFoodName";
			this.txtFoodName.Size = new System.Drawing.Size(257, 20);
			this.txtFoodName.TabIndex = 20;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(204, 59);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(93, 13);
			this.label9.TabIndex = 33;
			this.label9.Text = "Tên món ăn/uống";
			// 
			// FoodForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(664, 327);
			this.Controls.Add(this.cbbCategory);
			this.Controls.Add(this.btnSaveFood);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.nudUnitPrice);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.txtFoodId);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtImageLink);
			this.Controls.Add(this.txtUnit);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.txtFoodName);
			this.Controls.Add(this.label9);
			this.Name = "FoodForm";
			this.Text = "FoodForm";
			this.Load += new System.EventHandler(this.FoodForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudUnitPrice)).EndInit();
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ptbFoodImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbbCategory;
		private System.Windows.Forms.Button btnSaveFood;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.NumericUpDown nudUnitPrice;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.PictureBox ptbFoodImage;
		private System.Windows.Forms.TextBox txtFoodId;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtImageLink;
		private System.Windows.Forms.TextBox txtUnit;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtFoodName;
		private System.Windows.Forms.Label label9;
	}
}