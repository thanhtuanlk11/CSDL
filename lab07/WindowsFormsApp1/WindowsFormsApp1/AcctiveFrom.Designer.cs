
namespace WindowsFormsApp1
{
    partial class AcctiveFrom
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
            this.dgvAcctive = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcctive)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAcctive
            // 
            this.dgvAcctive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcctive.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvAcctive.Location = new System.Drawing.Point(0, 54);
            this.dgvAcctive.Name = "dgvAcctive";
            this.dgvAcctive.RowHeadersWidth = 51;
            this.dgvAcctive.RowTemplate.Height = 24;
            this.dgvAcctive.Size = new System.Drawing.Size(800, 396);
            this.dgvAcctive.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách hoạt động ";
            // 
            // AcctiveFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAcctive);
            this.Name = "AcctiveFrom";
            this.Text = "AcctiveFrom";
            this.Load += new System.EventHandler(this.AcctiveFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcctive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAcctive;
        private System.Windows.Forms.Label label1;
    }
}