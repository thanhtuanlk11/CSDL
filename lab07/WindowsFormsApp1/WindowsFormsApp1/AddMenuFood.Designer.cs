
namespace WindowsFormsApp1
{
    partial class AddMenuFood
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
            this.txtAddMenuFood = new System.Windows.Forms.TextBox();
            this.btnAddMenuFood = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập nhóm món ăn mới :";
            // 
            // txtAddMenuFood
            // 
            this.txtAddMenuFood.Location = new System.Drawing.Point(186, 7);
            this.txtAddMenuFood.Name = "txtAddMenuFood";
            this.txtAddMenuFood.Size = new System.Drawing.Size(392, 22);
            this.txtAddMenuFood.TabIndex = 1;
            // 
            // btnAddMenuFood
            // 
            this.btnAddMenuFood.Location = new System.Drawing.Point(585, 7);
            this.btnAddMenuFood.Name = "btnAddMenuFood";
            this.btnAddMenuFood.Size = new System.Drawing.Size(75, 28);
            this.btnAddMenuFood.TabIndex = 2;
            this.btnAddMenuFood.Text = "Thêm";
            this.btnAddMenuFood.UseVisualStyleBackColor = true;
            this.btnAddMenuFood.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AddMenuFood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 162);
            this.Controls.Add(this.btnAddMenuFood);
            this.Controls.Add(this.txtAddMenuFood);
            this.Controls.Add(this.label1);
            this.Name = "AddMenuFood";
            this.Text = "AddMenuFood";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddMenuFood;
        private System.Windows.Forms.Button btnAddMenuFood;
    }
}