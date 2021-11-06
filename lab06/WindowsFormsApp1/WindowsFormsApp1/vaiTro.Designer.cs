
namespace WindowsFormsApp1
{
    partial class frmVaiTro
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
            this.dgvVaiTro = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaiTro)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVaiTro
            // 
            this.dgvVaiTro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVaiTro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVaiTro.Location = new System.Drawing.Point(0, 0);
            this.dgvVaiTro.Name = "dgvVaiTro";
            this.dgvVaiTro.RowHeadersWidth = 51;
            this.dgvVaiTro.RowTemplate.Height = 24;
            this.dgvVaiTro.Size = new System.Drawing.Size(839, 450);
            this.dgvVaiTro.TabIndex = 0;
            this.dgvVaiTro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVaiTro_CellContentClick);
            // 
            // frmVaiTro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 450);
            this.Controls.Add(this.dgvVaiTro);
            this.Name = "frmVaiTro";
            this.Text = "vaiTro";
            this.Load += new System.EventHandler(this.vaiTro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVaiTro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVaiTro;
    }
}