
namespace WindowsFormsApp1
{
    partial class BuilDetailFrom
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
            this.dgvBuilDetail = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuilDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBuilDetail
            // 
            this.dgvBuilDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuilDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBuilDetail.Location = new System.Drawing.Point(0, 0);
            this.dgvBuilDetail.Name = "dgvBuilDetail";
            this.dgvBuilDetail.RowHeadersWidth = 51;
            this.dgvBuilDetail.RowTemplate.Height = 24;
            this.dgvBuilDetail.Size = new System.Drawing.Size(800, 450);
            this.dgvBuilDetail.TabIndex = 0;
            // 
            // BuilDetailFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvBuilDetail);
            this.Name = "BuilDetailFrom";
            this.Text = "BuilDetailFrom";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuilDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBuilDetail;
    }
}