
namespace Hammurabi
{
    partial class mainmenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainmenu));
            this.exitbtn = new System.Windows.Forms.Button();
            this.rulesbtn = new System.Windows.Forms.Button();
            this.howtoplaybtn = new System.Windows.Forms.Button();
            this.playgamebtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // exitbtn
            // 
            this.exitbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitbtn.BackgroundImage")));
            this.exitbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitbtn.Location = new System.Drawing.Point(310, 326);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(178, 49);
            this.exitbtn.TabIndex = 5;
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            this.exitbtn.MouseLeave += new System.EventHandler(this.exitbtn_MouseLeave);
            this.exitbtn.MouseHover += new System.EventHandler(this.exitbtn_MouseHover);
            // 
            // rulesbtn
            // 
            this.rulesbtn.BackgroundImage = global::Hammurabi.Properties.Resources.scoreboard;
            this.rulesbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.rulesbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rulesbtn.Location = new System.Drawing.Point(310, 271);
            this.rulesbtn.Name = "rulesbtn";
            this.rulesbtn.Size = new System.Drawing.Size(178, 49);
            this.rulesbtn.TabIndex = 3;
            this.rulesbtn.UseVisualStyleBackColor = true;
            this.rulesbtn.Click += new System.EventHandler(this.rulesbtn_Click);
            this.rulesbtn.MouseLeave += new System.EventHandler(this.rulesbtn_MouseLeave);
            this.rulesbtn.MouseHover += new System.EventHandler(this.rulesbtn_MouseHover);
            // 
            // howtoplaybtn
            // 
            this.howtoplaybtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("howtoplaybtn.BackgroundImage")));
            this.howtoplaybtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.howtoplaybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.howtoplaybtn.Location = new System.Drawing.Point(310, 216);
            this.howtoplaybtn.Name = "howtoplaybtn";
            this.howtoplaybtn.Size = new System.Drawing.Size(178, 49);
            this.howtoplaybtn.TabIndex = 2;
            this.howtoplaybtn.UseVisualStyleBackColor = true;
            this.howtoplaybtn.Click += new System.EventHandler(this.howtoplaybtn_Click);
            this.howtoplaybtn.MouseLeave += new System.EventHandler(this.howtoplaybtn_MouseLeave);
            this.howtoplaybtn.MouseHover += new System.EventHandler(this.howtoplaybtn_MouseHover);
            // 
            // playgamebtn
            // 
            this.playgamebtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playgamebtn.BackgroundImage")));
            this.playgamebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playgamebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playgamebtn.Location = new System.Drawing.Point(310, 161);
            this.playgamebtn.Name = "playgamebtn";
            this.playgamebtn.Size = new System.Drawing.Size(178, 49);
            this.playgamebtn.TabIndex = 1;
            this.playgamebtn.UseVisualStyleBackColor = true;
            this.playgamebtn.Click += new System.EventHandler(this.playgamebtn_Click);
            this.playgamebtn.MouseLeave += new System.EventHandler(this.playgamebtn_MouseLeave);
            this.playgamebtn.MouseHover += new System.EventHandler(this.playgamebtn_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Hammurabi.Properties.Resources.mainmenu_new;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 450);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // mainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitbtn);
            this.Controls.Add(this.rulesbtn);
            this.Controls.Add(this.howtoplaybtn);
            this.Controls.Add(this.playgamebtn);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainmenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hammurabi";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button playgamebtn;
        private System.Windows.Forms.Button howtoplaybtn;
        private System.Windows.Forms.Button rulesbtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}