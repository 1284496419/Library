namespace 图书管理系统
{
    partial class Frm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm2));
            this.x = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(38, 12);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(125, 32);
            this.x.TabIndex = 0;
            this.x.Text = " ";
            this.x.UseVisualStyleBackColor = true;
            this.x.Click += new System.EventHandler(this.x_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "图书管理系统";
            this.notifyIcon1.Visible = true;
            // 
            // Frm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 442);
            this.Controls.Add(this.x);
            this.Name = "Frm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图书列表";
            this.Load += new System.EventHandler(this.Frm2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button x;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}