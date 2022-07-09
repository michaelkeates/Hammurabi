using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Diagnostics;

namespace Hammurabi
{
    public partial class whatisham : Form
    {
        private const int CS_DROPSHADOW = 0x00020000;

        public whatisham()
        {
            InitializeComponent();
            lblwhatishamm.FlatStyle = FlatStyle.Standard;
            lblwhatishamm.Parent = pictureBox1;
            lblwhatishamm.BackColor = Color.Transparent;

            lblwhatishamm.Text = ("Hammurabi was originally called The Sumer Game it was developed by Doug Dyment at Digital Equipment Corporation and released 1968, this was done using the computer language FOCAL(Formulating On-Line Calculations in Algebraic Language). In 1973 David H. Ahl released “BASIC Computer Games” this was a library of games written using the computer language BASIC (Beginner's All-purpose Symbolic Instruction Code). Hammurabi was one of those games, David H. Ahl had expanded from The Sumer Game and added a 10-year assessment.");
        }

        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void lblwhatisham_TextChanged(object sender, EventArgs e)
        {
        }

        private void btngoback1_MouseHover(object sender, EventArgs e)
        {
            this.btngoback1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.goback_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btngoback1_MouseLeave(object sender, EventArgs e)
        {
            this.btngoback1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.goback));
        }

        private void btngoback1_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            this.Hide();
            mainmenu mainmenu = new mainmenu();
            mainmenu.ShowDialog();
        }

        private void btnexit_MouseHover(object sender, EventArgs e)
        {
            this.btnexit.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.close_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btnexit_MouseLeave(object sender, EventArgs e)
        {
            this.btnexit.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.close));
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            foreach (var process in Process.GetProcessesByName("Hammurabi"))
            {
                process.Kill();
            }
        }

        private void lblwhatishamm_Click(object sender, EventArgs e)
        {

        }
    }
}
