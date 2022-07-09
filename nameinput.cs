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
    public partial class nameinput : Form
    {
        string playername;

        public nameinput()
        {
            InitializeComponent();

            inputtextbox.Text = "Hammurabi";
            lblmessage.Text = ("Hammurabi, I am delighted to say your final score is " + highscores.finalScore + " and that your people would like to honor you. What would you like to be remembered as?");
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {
            playername = inputtextbox.Text;
            using (StreamWriter stream = new StreamWriter("Data/Hammurabi_ScoreBoard.dat", true))
            stream.WriteLine("" + highscores.finalScore + "," + playername + "");
            
            this.Hide();
            highscores highscoresform = new highscores();
            scoreboard scoreboard = new scoreboard();
            highscoresform.Close();
            scoreboard.ShowDialog();
        }
    }
}
