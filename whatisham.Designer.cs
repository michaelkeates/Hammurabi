
namespace Hammurabi
{
    partial class whatisham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(whatisham));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btngoback1 = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.lblwhatishamm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Hammurabi.Properties.Resources.whatisham1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btngoback1
            // 
            this.btngoback1.BackColor = System.Drawing.Color.Transparent;
            this.btngoback1.BackgroundImage = global::Hammurabi.Properties.Resources.goback;
            this.btngoback1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btngoback1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngoback1.Location = new System.Drawing.Point(576, 359);
            this.btngoback1.Name = "btngoback1";
            this.btngoback1.Size = new System.Drawing.Size(158, 44);
            this.btngoback1.TabIndex = 2;
            this.btngoback1.UseVisualStyleBackColor = false;
            this.btngoback1.Click += new System.EventHandler(this.btngoback1_Click);
            this.btngoback1.MouseLeave += new System.EventHandler(this.btngoback1_MouseLeave);
            this.btngoback1.MouseHover += new System.EventHandler(this.btngoback1_MouseHover);
            // 
            // btnexit
            // 
            this.btnexit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnexit.BackgroundImage")));
            this.btnexit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Location = new System.Drawing.Point(742, 36);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(34, 34);
            this.btnexit.TabIndex = 3;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            this.btnexit.MouseLeave += new System.EventHandler(this.btnexit_MouseLeave);
            this.btnexit.MouseHover += new System.EventHandler(this.btnexit_MouseHover);
            // 
            // lblwhatishamm
            // 
            this.lblwhatishamm.BackColor = System.Drawing.Color.Transparent;
            this.lblwhatishamm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblwhatishamm.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblwhatishamm.Location = new System.Drawing.Point(96, 90);
            this.lblwhatishamm.Name = "lblwhatishamm";
            this.lblwhatishamm.Size = new System.Drawing.Size(616, 220);
            this.lblwhatishamm.TabIndex = 4;
            this.lblwhatishamm.Text = "label1";
            this.lblwhatishamm.Click += new System.EventHandler(this.lblwhatishamm_Click);
            // 
            // whatisham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblwhatishamm);
            this.Controls.Add(this.btnexit);
            this.Controls.Add(this.btngoback1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "whatisham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btngoback1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Label lblwhatishamm;
    }
}