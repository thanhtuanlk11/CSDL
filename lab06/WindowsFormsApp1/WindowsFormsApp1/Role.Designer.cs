
namespace WindowsFormsApp1
{
    partial class Role
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
            this.dgvRole = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRole)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRole
            // 
            this.dgvRole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRole.Location = new System.Drawing.Point(-131, -48);
            this.dgvRole.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRole.Name = "dgvRole";
            this.dgvRole.RowHeadersWidth = 51;
            this.dgvRole.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRole.Size = new System.Drawing.Size(928, 495);
            this.dgvRole.TabIndex = 1;
            this.dgvRole.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRole_CellContentClick);
            // 
            // Role
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvRole);
            this.Name = "Role";
            this.Text = "Role";
            this.Load += new System.EventHandler(this.Role_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRole)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRole;
    }
}