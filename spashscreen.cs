using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Hammurabi
{
    public partial class spashscreen : Form
    {
        private const int CS_DROPSHADOW = 0x00020000;

        public spashscreen()
        {
            InitializeComponent();

            pictureBox1.Controls.Add(lblloadingstatus);
            lblloadingstatus.BackColor = Color.Transparent;

            lblloadingstatus.Text = ("IS1S455 Programming 1 Assignment 2 - Michael Keates (23009273)");
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

        private void timer1_Tick(object sender, EventArgs e) //loading bar which is a gimick but does check to see if .dat files exist, if not they are created :)
        {
            panel2.Width += 3;
            if(panel2.Width >= 700)
            {
                timer1.Stop();
                mainmenu f2 = new mainmenu();
                f2.Show();
                this.Hide();
            }
            if (panel2.Width >= 350)
            {
                if (File.Exists(@"Data/Hammurabi_ScoreBuildUp.dat"))
                {
                    lblloadingstatus.ForeColor = Color.White;
                    lblloadingstatus.Text = ("Hammurabi_ScoreBuildUp.dat exists");
                }
                else
                {
                    lblloadingstatus.ForeColor = Color.Red;                   
                    lblloadingstatus.Text = ("Hammurabi_ScoreBuildUp.dat does not exist! New file has been created!");
                    timer1.Stop();
                    FileStream fs = File.Create(@"Data/Hammurabi_ScoreBuildUp.dat");                
                    timer1.Start();
                }
            }
            if (panel2.Width >= 550)
            {
                if (File.Exists(@"Data/Hammurabi_ScoreBoard.dat"))
                {
                    lblloadingstatus.ForeColor = Color.White;
                    lblloadingstatus.Text = ("Hammurabi_ScoreBoard.dat exists");
                }
                else
                {
                    lblloadingstatus.ForeColor = Color.Red;
                    lblloadingstatus.Text = ("Hammurabi_ScoreBoard.dat does not exist! New file has been created!");
                    timer1.Stop();
                    using (StreamWriter stream = new StreamWriter("Data/Hammurabi_ScoreBoard.dat", true))
                        stream.WriteLine("51,Nahire" + "\n" + "50,Hammurabi" + "\n" + "45,Mike" + "\n" + "44,David" + "\n" + "40,Terry" + "\n" + "35,Joanna" + "\n" + "30,Arron" + "\n" + "28,Ash" + "\n" + "20,Nathan" + "\n" + "10,Jazz");
                    timer1.Start();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
