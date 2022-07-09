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
using System.Drawing.Drawing2D;

namespace Hammurabi
{
    public partial class scoreboard : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        private const int CS_DROPSHADOW = 0x00020000;

        string lastposition;
        string lastbutoneposition;
        string lastbutsecondposition;

        string secondalmostworstleaderever;
        string almostworstleaderever;
        string worstleaderever;

        public scoreboard()
        {
            InitializeComponent();


            //fetch data from text file, organise and save back to file in order of score
            string inFile = @"Data/Hammurabi_ScoreBoard.dat";
            var contents = File.ReadAllLines(inFile).OrderBy(line => Int32.Parse(line.Split(',')[0])).ToList();

            //Array.Sort(contents);

            //line.Sort();
            contents.Reverse();

            File.WriteAllLines(inFile, contents);

            string str1;
            string str2;
            string str3;
            string str4;
            string str5;
            string str6;
            string str7;
            string str8;
            string str9;
            string str10;

            StreamReader sr = new StreamReader(@"Data/Hammurabi_ScoreBoard.dat");
            str1 = sr.ReadLine();
            str2 = sr.ReadLine();
            str3 = sr.ReadLine();
            str4 = sr.ReadLine();
            str5 = sr.ReadLine();
            str6 = sr.ReadLine();
            str7 = sr.ReadLine();
            str8 = sr.ReadLine();
            str9 = sr.ReadLine();
            str10 = sr.ReadLine();

            //strlast = sr.ReadLine().Last();

            //strlast = File.ReadLines(@"Hammurabi_ScoreBoard.dat").Last();

            var data = File.ReadAllLines(@"Data/Hammurabi_ScoreBoard.dat");

            string last = data[data.Length - 1];
            string lastButOne = data[data.Length - 2];
            string lastButSecond = data[data.Length - 3];

            var lineCount = 0;
            using (var reader = File.OpenText(@"Data/Hammurabi_ScoreBoard.dat"))
            {
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                    lastposition = lineCount.ToString();
                    lastbutoneposition = (lineCount - 1).ToString();
                    lastbutsecondposition = (lineCount - 2).ToString();
                }
            }

            //First place
            lblplayername1.Text = str1.Split(',')[1];
            lblfinalscore1.Text = str1.Split(',')[0];

            //Second Place
            lblplayername2.Text = str2.Split(',')[1];
            lblfinalscore2.Text = str2.Split(',')[0];

            //Third Place
            lblplayername3.Text = str3.Split(',')[1];
            lblfinalscore3.Text = str3.Split(',')[0];

            //Fourth Place
            lblplayername4.Text = str4.Split(',')[1];
            lblfinalscore4.Text = str4.Split(',')[0];

            //Fifth Place
            lblplayername5.Text = str5.Split(',')[1];
            lblfinalscore5.Text = str5.Split(',')[0];

            //Sixth Place
            lblplayername6.Text = str6.Split(',')[1];
            lblfinalscore6.Text = str6.Split(',')[0];

            //Seventh Place
            lblplayername7.Text = str7.Split(',')[1];
            lblfinalscore7.Text = str7.Split(',')[0];

            //Eighth Place
            lblplayername8.Text = str8.Split(',')[1];
            lblfinalscore8.Text = str8.Split(',')[0];

            //Ninth Place
            lblplayername9.Text = str9.Split(',')[1];
            lblfinalscore9.Text = str9.Split(',')[0];

            //Tenth Place
            lblplayername10.Text = str10.Split(',')[1];
            lblfinalscore10.Text = str10.Split(',')[0];

            //Third Last Place
            lblpositionlastbutone.Text = lastbutoneposition;
            lblplayernamelastbutone.Text = lastButOne.Split(',')[1];
            lblfinalscorelastbutone.Text = lastButOne.Split(',')[0];

            secondalmostworstleaderever = lastButSecond.Split(',')[1].ToString();

            //Second Last Place
            lblpositionlastbutsecond.Text = lastbutsecondposition;
            lblplayernamelastbutsecond.Text = lastButSecond.Split(',')[1];
            lblfinalscorelastbutsecond.Text = lastButSecond.Split(',')[0];

            almostworstleaderever = lastButOne.Split(',')[1].ToString();

            //Last Place
            lblpositionlast.Text = lastposition;
            lblplayernamelast.Text = last.Split(',')[1];
            lblfinalscorelast.Text = last.Split(',')[0];

            worstleaderever = last.Split(',')[1].ToString();

            lblworstleaders.Text = "" + secondalmostworstleaderever + ", " + almostworstleaderever +  " and "  + worstleaderever +  " are the three worst leaders we ever had!!";

            sr.Close();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }


        private void scoreboard_Load(object sender, EventArgs e)
        {

        }

        private void nextbtn3_Click(object sender, EventArgs e)
        {
            maingame maingame = new maingame();
            maingame.axHamMusic.Ctlcontrols.stop();
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            this.Hide();
            mainmenu mainmenu = new mainmenu();
            mainmenu.ShowDialog();
        }

        private void nextbtn3_MouseHover(object sender, EventArgs e)
        {
            this.nextbtn3.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.goback_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void nextbtn3_MouseLeave(object sender, EventArgs e)
        {
            this.nextbtn3.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.goback));
        }

        private void btnexit4_Click(object sender, EventArgs e)
        {
            Application.Exit();
            foreach (var process in Process.GetProcessesByName("Hammurabi"))
            {
                process.Kill();
            }
        }

        private void btnexit4_MouseHover(object sender, EventArgs e)
        {
            this.btnexit4.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.close_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btnexit4_MouseLeave(object sender, EventArgs e)
        {
            this.btnexit4.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.close));
        }

        private void btnminimize3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnminimize3_MouseHover(object sender, EventArgs e)
        {
            this.btnminimize3.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.minimize_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btnminimize3_MouseLeave(object sender, EventArgs e)
        {
            this.btnminimize3.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.minimize));
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            {
                mouseDown = true;
                lastLocation = e.Location;
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var panel = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var rectangle = e.CellBounds;
            using (var pen = new Pen(Color.FromArgb(70, 70, 70), 1))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                if (e.Row == (panel.RowCount - 1))
                {
                    rectangle.Height -= 2;
                }

                if (e.Column == (panel.ColumnCount - 1))
                {
                    rectangle.Width -= 2;
                }

                e.Graphics.DrawRectangle(pen, rectangle);
            }
        }

        private void tableLayoutPanel2_CellPaint_1(object sender, TableLayoutCellPaintEventArgs e)
        {
            var pane2 = sender as TableLayoutPanel;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var rectangle = e.CellBounds;
            using (var pen = new Pen(Color.FromArgb(70, 70, 70), 1))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

                if (e.Row == (pane2.RowCount - 1))
                {
                    rectangle.Height -= 2;
                }

                if (e.Column == (pane2.ColumnCount - 1))
                {
                    rectangle.Width -= 2;
                }

                e.Graphics.DrawRectangle(pen, rectangle);
            }
        }
    }
}
