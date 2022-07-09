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
using System.Windows.Forms.DataVisualization.Charting; //Get data from text file
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace Hammurabi
{
    public partial class highscores : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        private const int CS_DROPSHADOW = 0x00020000;

        int tenyearsCheck;
        int scoreValueBushels;
        int scoreValuePopulation;
        int scoreValueAcres;
        int acresPerCitizen = 0;

        double maxYbushels;
        double maxXbushels;
        double minYbushels;
        double minXbushels;

        double maxYpeople;
        double maxXpeople;
        double minYpeople;
        double minXpeople;

        double maxYacres;
        double maxXacres;
        double minYacres;
        double minXacres;

        int startIndex;

        public static int finalScore;

        public highscores()
        {
            InitializeComponent();

            this.chart1.ChartAreas[0].AxisX.LineColor = Color.FromArgb(50, 50, 50);
            this.chart1.ChartAreas[0].AxisY.LineColor = Color.FromArgb(50, 50, 50);
            this.chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(50, 50, 50);
            this.chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(50, 50, 50);
            this.chart1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            this.chart1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

            this.chart2.ChartAreas[0].AxisX.LineColor = Color.FromArgb(50, 50, 50);
            this.chart2.ChartAreas[0].AxisY.LineColor = Color.FromArgb(50, 50, 50);
            this.chart2.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(50, 50, 50);
            this.chart2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(50, 50, 50);
            this.chart2.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            this.chart2.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

            this.chart3.ChartAreas[0].AxisX.LineColor = Color.FromArgb(50, 50, 50);
            this.chart3.ChartAreas[0].AxisY.LineColor = Color.FromArgb(50, 50, 50);
            this.chart3.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(50, 50, 50);
            this.chart3.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(50, 50, 50);
            this.chart3.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            this.chart3.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

            scoreValueBushels = 0;
            scoreValuePopulation = 0;

            DataTable dt = new DataTable();
            dt.Columns.Add("X_Years", typeof(double));
            dt.Columns.Add("Y_Acres", typeof(double));
            dt.Columns.Add("Y_Population", typeof(double));
            dt.Columns.Add("Y_Bushels", typeof(double));
            dt.Columns.Add("Y_totalbushelsharvested", typeof(double));
            dt.Columns.Add("Y_totaldeathplague", typeof(double));
            dt.Columns.Add("Y_totaldeathstarving", typeof(double));
            dt.Columns.Add("Y_totalelephantdamage", typeof(double));
            dt.Columns.Add("Y_totalnewpopultion", typeof(double));
            dt.Columns.Add("Y_totalratseaten", typeof(double));
            dt.Columns.Add("Y_lastyrratseaten", typeof(double));
            dt.Columns.Add("Y_lastyrelephantdamage", typeof(double));


            //fetch data. each value is seprated by ,
            StreamReader sr = new StreamReader(@"Data/Hammurabi_ScoreBuildUp.dat");
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] strarr = line.Split(',');
                dt.Rows.Add(strarr[0], strarr[1], strarr[2], strarr[3], strarr[4], strarr[5], strarr[6], strarr[7], strarr[8], strarr[9], strarr[10], strarr[11]);
                //dt.Rows.Add(year[0], land[1], population[2], bushels[3], totalbushelsharvested[4], totaldeathplague[5], [totaldeathstarving[6], totalelephantdamage[7], totalnewpopulation[8], totalratseaten[9]), lastYrRatsEaten[10], lastYrElephantDamage[11];


                //Get Max, Min, average values
                var Yearsinpower = dt.AsEnumerable().Max(row => row["X_Years"]);
                var Bushelmin = dt.AsEnumerable().Min(row => row["Y_Bushels"]);
                var Bushelmax = dt.AsEnumerable().Max(row => row["Y_Bushels"]);
                var Populationmin = dt.AsEnumerable().Min(row => row["Y_Population"]);
                var Populationmax = dt.AsEnumerable().Max(row => row["Y_Population"]);
                var Acresmin = dt.AsEnumerable().Min(row => row["Y_Acres"]);
                var Acresnmax = dt.AsEnumerable().Max(row => row["Y_Acres"]);
                var totalbushelsharvested = dt.AsEnumerable().Max(row => row["Y_totalbushelsharvested"]);
                var deathplaguetotal = dt.AsEnumerable().Max(row => row["Y_totaldeathplague"]);
                var deathstarvingtotal = dt.AsEnumerable().Max(row => row["Y_totaldeathstarving"]);
                var elephantdamagetotal = dt.AsEnumerable().Max(row => row["Y_totalelephantdamage"]);
                var Populationtotal = dt.AsEnumerable().Max(row => row["Y_totalnewpopultion"]);
                var ratseatentotal = dt.AsEnumerable().Max(row => row["Y_totalratseaten"]);

                //populate labels
                lblyearsofficereport.Text = ("Your " + Yearsinpower + " Years of Office Report");
                lblmaxbushel.Text = ( "Highest amount of bushels owned:");
                lblmaxbushelvalue.Text = ("" + Bushelmax + "");
                lblminbushel.Text = ( "Lowest amount of bushels owned:");
                lblminbushelvalue.Text = ("" + Bushelmin + "");
                lbltotalharvest.Text = ("Total amount of bushels harvested:");
                lbltotalharvestvalue.Text = ("" + totalbushelsharvested + "");
                lblmaxpopulation.Text = ("Highest amount of people:");
                lblmaxpopulationvalue.Text = ("" + Populationmax + "");
                lblminpopulation.Text = ("Lowest amount of people:");
                lblminpopulationvalue.Text = ("" + Populationmin + "");
                lbltotaldeathplague.Text = ("Total death from the plague:");
                lbltotaldeathplaguevalue.Text = ("" + deathplaguetotal + "");
                lbltotaldeathstarving.Text = ("Total death starvation:");
                lbltotaldeathstarvingvalue.Text = ("" + deathstarvingtotal + "");
                lbltotalnewpopulation.Text = ("Total new people that came to the city:");
                lbltotalnewpopulationvalue.Text = ("" + Populationtotal + "");
                lblmaxacres.Text = ("Highest amount of acres owned:");
                lblmaxacresvalue.Text = ("" + Acresnmax + "");
                lblminacres.Text = ("Lowest amount of acres owned:");
                lblminacresvalue.Text = ("" + Acresmin + "");
                lbltotalelephantdamage.Text = ("Total damage caused by elephants:");
                lbltotalelephantdamagevalue.Text = ("" + elephantdamagetotal + "");
                lbltotalratseaten.Text = ("Total amount of bushels eaten by rats:");
                lbltotalratseatenvalue.Text = ("" + ratseatentotal + "");
         
                var averagebushels = dt.AsEnumerable().Average(row => row.Field<double>("Y_Bushels"));
                var averagepopulation = dt.AsEnumerable().Average(row => row.Field<double>("Y_Population"));
                var averageacres = dt.AsEnumerable().Average(row => row.Field<double>("Y_Acres"));

                lblaveragebushel.Text = ("Average amount of bushels owned:");
                lblaveragebushelvalue.Text = ("" + Math.Round(averagebushels, 2, MidpointRounding.AwayFromZero) + "");
                lblaveragepopulation.Text = ("Average amount of people:");
                lblaveragepopulationvalue.Text = ("" + Math.Round(averagepopulation, 2, MidpointRounding.AwayFromZero) + "");
                lblaverageacres.Text = ("Average amount of acres owned:");
                lblaverageacresvalue.Text = ("" + Math.Round(averageacres, 2, MidpointRounding.AwayFromZero) + "");

                int tenyears;
                decimal averagebushelsscore;
                decimal averagepopulationscore;
                decimal averageacresscore;
                int bushelsharvestedscore;
                int finalelephantdamage;
                int finalplaguedamage;
                int finalstarvationscore;
                int finalratseatenscore;
                decimal.TryParse(averagebushels.ToString(), out averagebushelsscore);
                decimal.TryParse(averagepopulation.ToString(), out averagepopulationscore);
                decimal.TryParse(averageacres.ToString(), out averageacresscore);
                int.TryParse(totalbushelsharvested.ToString(), out bushelsharvestedscore);
                int.TryParse(Yearsinpower.ToString(), out tenyears);
                int.TryParse(elephantdamagetotal.ToString(), out finalelephantdamage);
                int.TryParse(deathplaguetotal.ToString(), out finalplaguedamage);
                int.TryParse(deathstarvingtotal.ToString(), out finalstarvationscore);
                int.TryParse(ratseatentotal.ToString(), out finalratseatenscore);
                tenyearsCheck = tenyears;
                scoreValueBushels = (int)averagebushelsscore + bushelsharvestedscore - finalratseatenscore;
                scoreValuePopulation = (int)averagepopulationscore - finalplaguedamage - finalstarvationscore;
                scoreValueAcres = (int)averageacresscore - finalelephantdamage;

                //calculate final score from averages from all 10 years
                acresPerCitizen = (int)averageacresscore / (int)averagepopulationscore;

                finalScore = acresPerCitizen;

                //start preparing data for charts
                chart1.DataSource = dt;
                chart2.DataSource = dt;
                chart3.DataSource = dt;

                chart1.Series["Bushels"].XValueMember = "X_Years";
                chart1.Series["Bushels"].YValueMembers = "Y_Bushels";
                chart1.Series["Bushels Eaten"].XValueMember = "X_Years";
                chart1.Series["Bushels Eaten"].YValueMembers = "Y_totalratseaten";

                chart2.Series["People"].XValueMember = "X_Years";
                chart2.Series["People"].YValueMembers = "Y_Population";
                chart2.Series["Starved"].XValueMember = "X_Years";
                chart2.Series["Starved"].YValueMembers = "Y_totaldeathstarving";

                chart3.Series["Acres"].XValueMember = "X_Years";
                chart3.Series["Acres"].YValueMembers = "Y_Acres";
                chart3.Series["Acres Damaged"].XValueMember = "X_Years";
                chart3.Series["Acres Damaged"].YValueMembers = "Y_totalelephantdamage";

                //without this max/min data points wont work in chart!!!
                chart1.DataBind();
                chart2.DataBind();
                chart3.DataBind();

                int points_bushel = chart1.Series["Bushels"].Points.Count;
                if (points_bushel > 1)
                {
                    DataPoint maxDP = chart1.Series["Bushels"].Points.FindMaxByValue("Y1", startIndex);
                    DataPoint minDP = chart1.Series["Bushels"].Points.FindMinByValue("Y1", startIndex);

                    double maxYValue = maxDP.YValues[0];
                    double maxXValue = maxDP.XValue;

                    double minYValue = minDP.YValues[0];
                    double minXValue = minDP.XValue;

                    maxYbushels = maxYValue;
                    maxXbushels = maxXValue;

                    minYbushels = minYValue;
                    minXbushels = minXValue;
                }

                int points_people = chart2.Series["People"].Points.Count;
                if (points_people > 1)
                {
                    DataPoint maxDP2 = chart2.Series["People"].Points.FindMaxByValue("Y1", startIndex);
                    DataPoint minDP2 = chart2.Series["People"].Points.FindMinByValue("Y1", startIndex);

                    double maxYValue2 = maxDP2.YValues[0];
                    double maxXValue2 = maxDP2.XValue;

                    double minYValue2 = minDP2.YValues[0];
                    double minXValue2 = minDP2.XValue;

                    maxYpeople = maxYValue2;
                    maxXpeople = maxXValue2;

                    minYpeople = minYValue2;
                    minXpeople = minXValue2;
                }

                int points_acres = chart3.Series["Acres"].Points.Count;
                if (points_acres > 1)
                {
                    DataPoint maxDP3 = chart3.Series["Acres"].Points.FindMaxByValue("Y1", startIndex);
                    DataPoint minDP3 = chart3.Series["Acres"].Points.FindMinByValue("Y1", startIndex);

                    double maxYValue3 = maxDP3.YValues[0];
                    double maxXValue3 = maxDP3.XValue;

                    double minYValue3 = minDP3.YValues[0];
                    double minXValue3 = minDP3.XValue;

                    maxYacres = maxYValue3;
                    maxXacres = maxXValue3;

                    minYacres = minYValue3;
                    minXacres = minXValue3;
                }
            }

            chart1.Series["maxBushel"].Points.AddXY(maxXbushels, maxYbushels);
            chart1.Series["maxBushel"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["maxBushel"].MarkerColor = Color.Green;
            chart1.Series["maxBushel"].MarkerSize = 8;

            chart1.Series["minBushel"].Points.AddXY(minXbushels, minYbushels);
            chart1.Series["minBushel"].MarkerStyle = MarkerStyle.Circle;
            chart1.Series["minBushel"].MarkerColor = Color.Red;
            chart1.Series["minBushel"].MarkerSize = 8;

            chart2.Series["maxPeople"].Points.AddXY(maxXpeople, maxYpeople);
            chart2.Series["maxPeople"].MarkerStyle = MarkerStyle.Circle;
            chart2.Series["maxPeople"].MarkerColor = Color.Green;
            chart2.Series["maxPeople"].MarkerSize = 8;

            chart2.Series["minPeople"].Points.AddXY(minXpeople, minYpeople);
            chart2.Series["minPeople"].MarkerStyle = MarkerStyle.Circle;
            chart2.Series["minPeople"].MarkerColor = Color.Red;
            chart2.Series["minPeople"].MarkerSize = 8;

            chart3.Series["maxAcres"].Points.AddXY(maxXacres, maxYacres);
            chart3.Series["maxAcres"].MarkerStyle = MarkerStyle.Circle;
            chart3.Series["maxAcres"].MarkerColor = Color.Green;
            chart3.Series["maxAcres"].MarkerSize = 8;

            chart3.Series["minAcres"].Points.AddXY(minXacres, minYacres);
            chart3.Series["minAcres"].MarkerStyle = MarkerStyle.Circle;
            chart3.Series["minAcres"].MarkerColor = Color.Red;
            chart3.Series["minAcres"].MarkerSize = 8;

            if (sr != null) sr.Close();
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

        public void nextbtn2_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            this.Hide();

            if (tenyearsCheck == 10)
            {
                this.Hide();
                nameinput frminput = new nameinput();
                frminput.ShowDialog();
            }
            else
            {
                if (MessageBox.Show("Hammurabi, we will not honor you as you didn't reach 10 years in office!" + "\n" + "Click Yes if you would like to play again or No to go back to the main menu.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {                                   
                    maingame maingame = new maingame();
                    this.Hide();
                    maingame.ShowDialog();
                }
                else
                {                   
                    mainmenu mainmenu = new mainmenu();
                    this.Hide();
                    mainmenu.ShowDialog();
                }
            }
        }

        private void nextbtn2_MouseHover(object sender, EventArgs e)
        {
            this.nextbtn2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.proceed_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void nextbtn2_MouseLeave(object sender, EventArgs e)
        {
            this.nextbtn2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.proceed));
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
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

        private void btnexit3_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            if (MessageBox.Show("Hammurabi, are you sure you want to close this game?" + "\n" + "Click Yes to close Hammurabi.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                foreach (var process in Process.GetProcessesByName("Hammurabi"))
                {
                    process.Kill();
                }
            }
            else
            {
                //Nothing
            }
        }

        private void btnminimize2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnminimize2_MouseHover(object sender, EventArgs e)
        {
            this.btnminimize2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.minimize_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btnminimize2_MouseLeave(object sender, EventArgs e)
        {
            this.btnminimize2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.minimize));
        }

        private void btnexit3_MouseLeave(object sender, EventArgs e)
        {
            this.btnexit3.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.close));
        }

        private void btnexit3_MouseHover(object sender, EventArgs e)
        {
            this.btnexit3.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.close_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
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

        private void tableLayoutPanel2_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
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

        private void tableLayoutPanel3_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
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

        private void btngoback_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btngoback_MouseHover(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
            this.btngoback.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.goback_highlighted));
        }

        private void btngoback_MouseLeave(object sender, EventArgs e)
        {
            this.btngoback.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.goback));
        }
    }
}
