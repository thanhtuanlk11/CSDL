
namespace WindowsFormsApp1
{
    partial class TableForm
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
            this.btnCheckBills = new System.Windows.Forms.Button();
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
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCheckBills);
            this.Name = "TableForm";
            this.Text = "TableForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCheckBills;
    }
}