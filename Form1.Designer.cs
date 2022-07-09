
namespace Hammurabi
{
    partial class nameinput
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
            this.inputtextbox = new System.Windows.Forms.TextBox();
            this.btnconfirm = new System.Windows.Forms.Button();
            this.lblmessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputtextbox
            // 
            this.inputtextbox.Location = new System.Drawing.Point(120, 46);
            this.inputtextbox.Name = "inputtextbox";
            this.inputtextbox.Size = new System.Drawing.Size(146, 20);
            this.inputtextbox.TabIndex = 0;
            this.inputtextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnconfirm
            // 
            this.btnconfirm.Location = new System.Drawing.Point(120, 72);
            this.btnconfirm.Name = "btnconfirm";
            this.btnconfirm.Size = new System.Drawing.Size(146, 22);
            this.btnconfirm.TabIndex = 1;
            this.btnconfirm.Text = "Confirm";
            this.btnconfirm.UseVisualStyleBackColor = true;
            this.btnconfirm.Click += new System.EventHandler(this.btnconfirm_Click);
            // 
            // lblmessage
            // 
            this.lblmessage.Location = new System.Drawing.Point(12, 12);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(361, 31);
            this.lblmessage.TabIndex = 2;
            this.lblmessage.Text = "message";
            this.lblmessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nameinput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(385, 100);
            this.Controls.Add(this.lblmessage);
            this.Controls.Add(this.btnconfirm);
            this.Controls.Add(this.inputtextbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "nameinput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hammurabi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputtextbox;
        private System.Windows.Forms.Button btnconfirm;
        private System.Windows.Forms.Label lblmessage;
    }
}