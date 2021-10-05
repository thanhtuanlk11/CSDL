
namespace WindowsFormsApp1
{
    partial class tuychon
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdLop = new System.Windows.Forms.RadioButton();
            this.rdName = new System.Windows.Forms.RadioButton();
            this.rdID = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnSearch = new System.Windows.Forms.Panel();
            this.btnSreach = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tìm Theo ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdLop);
            this.panel1.Controls.Add(this.rdName);
            this.panel1.Controls.Add(this.rdID);
            this.panel1.Location = new System.Drawing.Point(24, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 79);
            this.panel1.TabIndex = 1;
            // 
            // rdLop
            // 
            this.rdLop.AutoSize = true;
            this.rdLop.Location = new System.Drawing.Point(338, 26);
            this.rdLop.Name = "rdLop";
            this.rdLop.Size = new System.Drawing.Size(48, 21);
            this.rdLop.TabIndex = 2;
            this.rdLop.TabStop = true;
            this.rdLop.Text = "lớp";
            this.rdLop.UseVisualStyleBackColor = true;
            // 
            // rdName
            // 
            this.rdName.AutoSize = true;
            this.rdName.Location = new System.Drawing.Point(182, 26);
            this.rdName.Name = "rdName";
            this.rdName.Size = new System.Drawing.Size(71, 21);
            this.rdName.TabIndex = 1;
            this.rdName.TabStop = true;
            this.rdName.Text = "Họ tên";
            this.rdName.UseVisualStyleBackColor = true;
            // 
            // rdID
            // 
            this.rdID.AutoSize = true;
            this.rdID.Location = new System.Drawing.Point(29, 26);
            this.rdID.Name = "rdID";
            this.rdID.Size = new System.Drawing.Size(70, 21);
            this.rdID.TabIndex = 0;
            this.rdID.TabStop = true;
            this.rdID.Text = "Mã SV";
            this.rdID.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnSearch);
            this.groupBox2.Location = new System.Drawing.Point(24, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(503, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // pnSearch
            // 
            this.pnSearch.Controls.Add(this.btnSreach);
            this.pnSearch.Controls.Add(this.txtInput);
            this.pnSearch.Controls.Add(this.label2);
            this.pnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnSearch.Location = new System.Drawing.Point(3, 18);
            this.pnSearch.Name = "pnSearch";
            this.pnSearch.Size = new System.Drawing.Size(497, 79);
            this.pnSearch.TabIndex = 1;
            // 
            // btnSreach
            // 
            this.btnSreach.Location = new System.Drawing.Point(389, 24);
            this.btnSreach.Name = "btnSreach";
            this.btnSreach.Size = new System.Drawing.Size(75, 23);
            this.btnSreach.TabIndex = 2;
            this.btnSreach.Text = "Tìm";
            this.btnSreach.UseVisualStyleBackColor = true;
            this.btnSreach.Click += new System.EventHandler(this.btnSreach_Click);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(136, 25);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(247, 22);
            this.txtInput.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhập thông tin";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(177, 290);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 45);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tuychon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 347);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "tuychon";
            this.Text = "frmTim";
            this.Load += new System.EventHandler(this.tuychon_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.pnSearch.ResumeLayout(false);
            this.pnSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdLop;
        private System.Windows.Forms.RadioButton rdName;
        private System.Windows.Forms.RadioButton rdID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnSearch;
        private System.Windows.Forms.Button btnSreach;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExit;
    }
}