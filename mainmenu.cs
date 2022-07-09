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
using System.IO;
using System.Diagnostics;

namespace Hammurabi
{

    public partial class mainmenu : Form
    {
        private bool mouseDown;
        private Point lastLocation;
        private const int CS_DROPSHADOW = 0x00020000;

        public mainmenu()
        {
            InitializeComponent();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void playgamebtn_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            this.Hide();
            maingame maingame = new maingame();
            maingame.ShowDialog();
        }

        private void howtoplaybtn_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            this.Hide();
            whatisham whatisham = new whatisham();
            whatisham.ShowDialog();
        }

        private void rulesbtn_Click(object sender, EventArgs e)
        {
            //changed rules button to scoreboard
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            this.Hide();

            if (File.Exists(@"Data/Hammurabi_ScoreBoard.dat"))
            {
                scoreboard scoreboard = new scoreboard();
                scoreboard.ShowDialog();
            }
            else
            {
                using (StreamWriter stream = new StreamWriter("Data/Hammurabi_ScoreBoard.dat", true))
                    stream.WriteLine("51,Nahire" + "\n" + "50,Hammurabi" + "\n" + "45,Mike" + "\n" + "44,David" + "\n" + "40,Terry" + "\n" + "35,Joanna" + "\n" + "30,Arron" + "\n" + "28,Ash" + "\n" + "20,Nathan" + "\n" + "10,Jazz");
                scoreboard scoreboard = new scoreboard();
                scoreboard.ShowDialog();
            }
        }

        private void creditsbtn_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            this.Hide();
            highscores highscores = new highscores();
            highscores.ShowDialog();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            Application.Exit();
            foreach (var process in Process.GetProcessesByName("Hammurabi"))
            {
                process.Kill();
            }
        }

        private void playgamebtn_MouseHover(object sender, EventArgs e)
        {
            this.playgamebtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.playgame_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void playgamebtn_MouseLeave(object sender, EventArgs e)
        {
            this.playgamebtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.playgame2));
        }

        private void exitbtn_MouseHover(object sender, EventArgs e)
        {
            this.exitbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.exit_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void exitbtn_MouseLeave(object sender, EventArgs e)
        {
            this.exitbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.exit));
        }

        private void howtoplaybtn_MouseHover(object sender, EventArgs e)
        {
            this.howtoplaybtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.whatisham_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void howtoplaybtn_MouseLeave(object sender, EventArgs e)
        {
            this.howtoplaybtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.whatisham));
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void rulesbtn_MouseHover(object sender, EventArgs e)
        {
            //changed rules button to scoreboard
            this.rulesbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.scoreboard_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void rulesbtn_MouseLeave(object sender, EventArgs e)
        {
            //changed rules button to scoreboard
            this.rulesbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.scoreboard));
        }
    }
}
