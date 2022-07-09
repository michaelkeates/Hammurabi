//Rule 1: 10 Rounds to be played a round is quivalent to 1 year
//Rule 2: 2800 bushels are available at the start of the game along with 100 people and 1000 acres
//Rule 3: Each person needs 20 bushels of grain each year to live and can till at most 10 acres of land
//Rule 4: Each acre of land requires one bushel of grain to plant seeds
//Rule 5: The price of each acre of land fluctuates from 17 bushels per acre to 26 bushels
//Rule 6: If the conditions in your country ever become bad enough, the people will overthrow you and you won't finish your 10 year term
//Rule 7: If you make it to the 11th year, your rule will be evaluated and you'll be ranked against other players' scores
//Rule 8: Elephants depending on percentage and size can cause fluctuating damage to acres of land.
//Rule 9: Rats depending on percentage can eat bushels
//Rule 10: A plague can occur if the percentage of population is above a certain number and in result deaths can occur

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
    public partial class maingame : Form
    {
        private bool mouseDown;
        private Point lastLocation;

        static Random rnd = new Random();

        int yearNumber = 1;
        int yearsLeft = 9;
        int lastYrDeath = 0;
        int lastYrHarvestNumber = rnd.Next(1, 8);
        int lastYrPriceOfLand = rnd.Next(17, 27);
        int lastYrPlagePopulation = 0;
        int lastYrNewPopulation = 0;
        int lastYrRatsEaten = 0;
        int totalDeathStarving;
        int totalDeathPlage;
        int totalNewPopulation;
        int totalBushelsHarvested;
        int land = 1000;
        int priceOfLand = rnd.Next(17, 27);
        int userLandSell;
        int userLandBuy;
        int userLandBuySell;
        int userLandPlant;
        int userBushelsGive;
        int bushels = 2800;
        int bushelsFromSelling;
        int bushelsForBuying;
        int population = 100;
        int eatenPopulation;
        int newPopulation;
        int deadPopulation;
        int plagePercent = rnd.Next(0, 100);
        int plagePopulation = rnd.Next(4, 56);
        int harvest;
        int harvestNumber = rnd.Next(1, 8);
        int sellLoop = 0;
        int buyLoop = 0;
        int plantLoop = 0;
        int feedingLoop = 0;
        int gameOverLoop = 0;
        int ratsPercent = rnd.Next(1, 11);
        int ratsEaten = rnd.Next(0, 5482);
        int acresPerCitizen = 0;
        int lastYrElephantDamage = 0;
        int totalElephantDamade;
        int totalRatsEaten;
        int elephantPercent = rnd.Next(1, 100);
        int elephantDamage = rnd.Next(3, 25);
        int bushelcost;

        int remainder1;
        int remainder2;
        int remainder3;
        int finalremainder;
        int negremainder;

        //Count for Switch Table Mute/Unute button to loop
        int count = 0;

        private const int CS_DROPSHADOW = 0x00020000;


        public maingame()
        {
            InitializeComponent();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            axHamMusic.URL = @"Data/Sounds/Tabuk Kevin MacLeod.wav";          
            axHamMusic.Ctlcontrols.play();

            //Clear text file
            File.WriteAllText("Data/Hammurabi_ScoreBuildUp.dat", string.Empty);

            //Following to allow label to be transparent when on top of picturebox
            lblyears.FlatStyle = FlatStyle.Standard;
            lblyears.Parent = pictureBox2;
            lblyears.BackColor = Color.Transparent;
            younowownlbl.FlatStyle = FlatStyle.Standard;
            younowownlbl.Parent = pictureBox2;
            younowownlbl.BackColor = Color.Transparent;
            lblbushelsinstore.FlatStyle = FlatStyle.Standard;
            lblbushelsinstore.Parent = pictureBox2;
            lblbushelsinstore.BackColor = Color.Transparent;
            lblpopulation.FlatStyle = FlatStyle.Standard;
            lblpopulation.Parent = pictureBox2;
            lblpopulation.BackColor = Color.Transparent;
            lblacres.FlatStyle = FlatStyle.Standard;
            lblacres.Parent = pictureBox2;
            lblacres.BackColor = Color.Transparent;
            lblpriceofland.FlatStyle = FlatStyle.Standard;
            lblpriceofland.Parent = pictureBox2;
            lblpriceofland.BackColor = Color.Transparent;
            lblarrivals.Parent = pictureBox2;
            lblarrivals.BackColor = Color.Transparent;
            lbldeaths.Parent = pictureBox2;
            lbldeaths.BackColor = Color.Transparent;

            disasterslbl.FlatStyle = FlatStyle.Standard;
            disasterslbl.Parent = pictureBox2;
            disasterslbl.BackColor = Color.Transparent;
            lbltutacre.FlatStyle = FlatStyle.Standard;
            lbltutacre.Parent = pictureBox2;
            lbltutacre.BackColor = Color.Transparent;
            lblacresremaining.FlatStyle = FlatStyle.Standard;
            lblacresremaining.Parent = pictureBox2;
            lblacresremaining.BackColor = Color.Transparent;
            lbltutplantbushels.FlatStyle = FlatStyle.Standard;
            lbltutplantbushels.Parent = pictureBox2;
            lbltutplantbushels.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Standard;
            label1.Parent = pictureBox2;
            label1.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Standard;
            label2.Parent = pictureBox2;
            label2.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Standard;
            label3.Parent = pictureBox2;
            label3.BackColor = Color.Transparent;
            label4.FlatStyle = FlatStyle.Standard;
            label4.Parent = pictureBox2;
            label4.BackColor = Color.Transparent;
            lblremainder.FlatStyle = FlatStyle.Standard;
            lblremainder.Parent = pictureBox2;
            lblremainder.BackColor = Color.Transparent;

            //Display Values in textboxes
            input1.Text = "0";
            input2.Text = "0";
            input3.Text = "0";

            //Fetch value for trackbars
            trackBar1.Value = 0;
            trackBar1.Maximum = land;
            trackBar1.Minimum = land * -1;
            trackBar2.Value = 0;
            trackBar2.Maximum = bushels;
            trackBar2.Minimum = 0;
            trackBar3.Value = 0;
            trackBar3.Maximum = bushels;
            trackBar3.Minimum = 0;

            yearNumber = 1;
            yearsLeft = 9;
            lastYrDeath = 0;
            lastYrHarvestNumber = rnd.Next(2, 8);
            lastYrPriceOfLand = rnd.Next(17, 27);
            lastYrNewPopulation = 0;
            lastYrRatsEaten = 0;
            totalDeathStarving = 0;
            totalDeathPlage = 0;
            totalNewPopulation = 0;
            totalBushelsHarvested = 0;
            land = 1000;
            priceOfLand = rnd.Next(17, 27);
            bushels = 2800;
            bushelsFromSelling = 0;
            bushelsForBuying = 0;
            population = 100;
            plagePercent = rnd.Next(0, 100);
            plagePopulation = rnd.Next(4, 56);
            harvest = 0;
            harvestNumber = rnd.Next(2, 8);
            sellLoop = 0;
            buyLoop = 0;
            plantLoop = 0;
            feedingLoop = 0;
            gameOverLoop = 0;
            ratsPercent = rnd.Next(1, 11);
            ratsEaten = rnd.Next(0, 5482);
            lastYrElephantDamage = 0;
            totalElephantDamade = 0;
            totalRatsEaten = 0;
            elephantPercent = rnd.Next(1, 100);
            elephantDamage = rnd.Next(3, 25);
            bushelcost = 0;

            gameReport();

        }

        private void gameReport()
        {
            if (yearNumber <= 10) // && yearsLeft == 0)
            {
                lblremainder.Text = ("Bushels Remaining: " + bushels);
                lblacresremaining.Text = ("Acres Remaining: " + land);

                using (StreamWriter stream = new StreamWriter("Data/Hammurabi_ScoreBuildUp.dat", true))
                stream.WriteLine(yearNumber + "," + land + "," + population + "," + bushels + "," + totalBushelsHarvested + "," + totalDeathPlage + "," + totalDeathStarving + "," + totalElephantDamade + "," + totalNewPopulation + "," + totalRatsEaten + "," + lastYrRatsEaten + "," + lastYrElephantDamage);

                IsItGameOver();
                bushelsremaining();
                acresremaining();

                //Display Values in textboxes
                //trackBar1.Value = 0;
                //trackBar2.Value = 0;
                //trackBar3.Value = 0;

                //resetting values
                bushels = bushels + harvest;
                sellLoop = 0;
                buyLoop = 0;
                plantLoop = 0;
                feedingLoop = 0;
                harvest = 0;

                //Normal Game Mode
                newPopulation = rnd.Next(0, 64);
                harvestNumber = rnd.Next(2, 8);
                plagePercent = rnd.Next(0, 90);
                ratsPercent = rnd.Next(0, 11);
                ratsEaten = rnd.Next(0, 5482);
                elephantPercent = rnd.Next(1, 100);
                elephantDamage = rnd.Next(3, 25);

                //cheat mode :) to debug
                //newPopulation = rnd.Next(16, 1000);
                //harvestNumber = rnd.Next(8, 1000);
                //plagePercent = rnd.Next(0, 0);
                //ratsPercent = rnd.Next(0, 0);
                //ratsEaten = rnd.Next(0, 0);
                //elephantPercent = rnd.Next(0, 0);
                //elephantDamage = rnd.Next(0, 0);

                trackBar1.Value = userLandBuySell;
                trackBar2.Value = userBushelsGive;
                trackBar3.Value = userLandPlant;

                if (harvestNumber > 5)
                {
                    priceOfLand = rnd.Next(21, 27);
                }
                else if (harvestNumber <= 5)
                {
                    priceOfLand = rnd.Next(17, 21);
                }

                lblremainder.Text = ("Bushels Remaining: " + (bushels - remainder3 - remainder2 - (remainder1 * priceOfLand)) + "");

                if ((remainder1 * priceOfLand) + remainder2 + remainder3 > bushels)
                {
                    input1.Enabled = false;
                    input2.Enabled = false;
                    input3.Enabled = false;
                }

                acresremaining();
                bushelsremaining();

                if (lastYrRatsEaten > 0 && lastYrElephantDamage > 0 && lastYrPlagePopulation > 0)
                {
                    lblyears.Text = ("Hammurabi, I beg to report to you that in the year " + yearNumber + ".  Its been a dark year! A plauge has struck " + lastYrPlagePopulation + " citizens have died! Elephants have destroyed " + lastYrElephantDamage + " acres of land and the population is now " + population + " inhabitants. Last year " + lastYrDeath + " died and " + lastYrNewPopulation + " came to the Great City of Sumeria. Sumeria now owns " + land + " acres of land.The current price is " + priceOfLand + " bushels per acre. You now have " + bushels + " bushels in store. Last year harvest was " + lastYrHarvestNumber + " bushels per acre. Rats ate " + lastYrRatsEaten + " bushels. There are " + yearsLeft + " years left.");
                    lblpopulation.Text = ("" + population + " people");
                    lblpriceofland.Text = ("" + priceOfLand + " bushels per acre");
                    lblbushelsinstore.Text = ("" + bushels + " bushels");
                    lblacres.Text = ("" + land + " acres of land");
                    lblarrivals.Text = ("" + lastYrNewPopulation + " arrivals");
                    lbldeaths.Text = ("" + lastYrDeath + " deaths");
                }
                else if (lastYrPlagePopulation > 0 && lastYrElephantDamage > 0 && lastYrRatsEaten == 0)
                {
                    lblyears.Text = ("Hammurabi, I beg to report to you that in the year " + yearNumber + ". Its been a dark year! Elephants have destroyed " + lastYrElephantDamage + " acres of land and a plauge has struck " + lastYrPlagePopulation + " citizens have died! We must pray to the lost King Nahire. Population is now " + population + " inhabitants. Last year " + lastYrDeath + " died and " + lastYrNewPopulation + " came to the Great City of Sumeria. Sumeria now owns " + land + " acres of land.The current price is " + priceOfLand + " bushels per acre. You now have " + bushels + " bushels in store. Last year harvest was " + lastYrHarvestNumber + " bushels per acre. There are " + yearsLeft + " years left");
                    //lblyears.Text = ("Hammurabi, I beg to report to you that in the year " + yearNumber + " . Population is now " + population + " inhabitants. Last year " + lastYrDeath + " died and " + lastYrNewPopulation + " came to the Great City of Sumeria. Sumeria now owns " + land + " acres of land. The current price is " + priceOfLand + " bushels per acre. You now have " + bushels + " bushels in store. Last year harvest was " + lastYrHarvestNumber + " bushels per acre, rats ate " + lastYrRatsEaten + " bushels. There are " + yearsLeft + " years left");
                    lblpopulation.Text = ("" + population + " people");
                    lblpriceofland.Text = ("" + priceOfLand + " bushels per acre");
                    lblbushelsinstore.Text = ("" + bushels + " bushels");
                    lblacres.Text = ("" + land + " acres of land");
                    lblarrivals.Text = ("" + lastYrNewPopulation + " arrivals");
                    lbldeaths.Text = ("" + lastYrDeath + " deaths");
                }
                else if (lastYrRatsEaten > 0 && lastYrElephantDamage > 0 && lastYrPlagePopulation == 0)
                {
                    lblyears.Text = ("Hammurabi, I beg to report to you that in the year " + yearNumber + ". Its been a dark year! Elephants have destroyed " + lastYrElephantDamage + " acres of land and the population is now " + population + " inhabitants. Last year " + lastYrDeath + " died and " + lastYrNewPopulation + " came to the Great City of Sumeria. Sumeria now owns " + land + " acres of land.The current price is " + priceOfLand + " bushels per acre. You now have " + bushels + " bushels in store. Last year harvest was " + lastYrHarvestNumber + " bushels per acre. Rats ate " + lastYrRatsEaten + " bushels. There are " + yearsLeft + " years left.");
                    lblpopulation.Text = ("" + population + " people");
                    lblpriceofland.Text = ("" + priceOfLand + " bushels per acre");
                    lblbushelsinstore.Text = ("" + bushels + " bushels");
                    lblacres.Text = ("" + land + " acres of land");
                    lblarrivals.Text = ("" + lastYrNewPopulation + " arrivals");
                    lbldeaths.Text = ("" + lastYrDeath + " deaths");
                }
                else if (lastYrRatsEaten > 0 && lastYrPlagePopulation > 0 && lastYrElephantDamage == 0)
                {
                    lblyears.Text = ("Hammurabi, I beg to report to you that in the year " + yearNumber + ". Its been a dark year! A plauge has struck " + lastYrPlagePopulation + " citizens have died! Elephants have destroyed " + lastYrElephantDamage + " acres of land and the population is now " + population + " inhabitants. Last year " + lastYrDeath + " died and " + lastYrNewPopulation + " came to the Great City of Sumeria. Sumeria now owns " + land + " acres of land.The current price is " + priceOfLand + " bushels per acre. You now have " + bushels + " bushels in store. Last year harvest was " + lastYrHarvestNumber + " bushels per acre. Rats ate " + lastYrRatsEaten + " bushels. There are " + yearsLeft + " years left.");
                    lblpopulation.Text = ("" + population + " people");
                    lblpriceofland.Text = ("" + priceOfLand + " bushels per acre");
                    lblbushelsinstore.Text = ("" + bushels + " bushels");
                    lblacres.Text = ("" + land + " acres of land");
                    lblarrivals.Text = ("" + lastYrNewPopulation + " arrivals");
                    lbldeaths.Text = ("" + lastYrDeath + " deaths");
                }
                else if (lastYrPlagePopulation > 0 && lastYrRatsEaten == 0 && lastYrElephantDamage == 0)
                {
                    lblyears.Text = ("Hammurabi, I beg to report to you that in the year " + yearNumber + ". Its been a dark year! A plauge has struck " + lastYrPlagePopulation + " citizens have died! Population is now " + population + " inhabitants.Last year " + lastYrDeath + " died and " + lastYrNewPopulation + " came to the Great City of Sumeria. Sumeria now owns " + land + " acres of land. The current price is " + priceOfLand + " bushels per acre. You now have " + bushels + " bushels in store. Last year harvest was " + lastYrHarvestNumber + " bushels per acre. There are " + yearsLeft + " years left.");
                    //lblyears.Text = ("Hammurabi, I beg to report to you that in the year " + yearNumber + " . Population is now " + population + " inhabitants. Last year " + lastYrDeath + " died and " + lastYrNewPopulation + " came to the Great City of Sumeria. Sumeria now owns " + land + " acres of land. The current price is " + priceOfLand + " bushels per acre. You now have " + bushels + " bushels in store. Last year harvest was " + lastYrHarvestNumber + " bushels per acre, rats ate " + lastYrRatsEaten + " bushels. There are " + yearsLeft + " years left");
                    lblpopulation.Text = ("" + population + " people");
                    lblpriceofland.Text = ("" + priceOfLand + " bushels per acre");
                    lblbushelsinstore.Text = ("" + bushels + " bushels");
                    lblacres.Text = ("" + land + " acres of land");
                    lblarrivals.Text = ("" + lastYrNewPopulation + " arrivals");
                    lbldeaths.Text = ("" + lastYrDeath + " deaths");
                }
                else if (lastYrElephantDamage > 0 && lastYrRatsEaten == 0 && lastYrPlagePopulation == 0)
                {
                    lblyears.Text = ("Hammurabi, I beg to report to you that in the year " + yearNumber + ".  Elephants have destroyed " + lastYrElephantDamage + " acres of land and the population is now " + population + " inhabitants. Last year " + lastYrDeath + " died and " + lastYrNewPopulation + " came to the Great City of Sumeria. Sumeria now owns " + land + " acres of land. The current price is " + priceOfLand + " bushels per acre. You now have " + bushels + " bushels in store. Last year harvest was " + lastYrHarvestNumber + " bushels per acre. There are " + yearsLeft + " years left.");
                    //lblyears.Text = ("Hammurabi, I beg to report to you that in the year " + yearNumber + " . Population is now " + population + " inhabitants. Last year " + lastYrDeath + " died and " + lastYrNewPopulation + " came to the Great City of Sumeria. Sumeria now owns " + land + " acres of land. The current price is " + priceOfLand + " bushels per acre. You now have " + bushels + " bushels in store. Last year harvest was " + lastYrHarvestNumber + " bushels per acre, rats ate " + lastYrRatsEaten + " bushels. There are " + yearsLeft + " years left");
                    lblpopulation.Text = ("" + population + " people");
                    lblpriceofland.Text = ("" + priceOfLand + " bushels per acre");
                    lblbushelsinstore.Text = ("" + bushels + " bushels");
                    lblacres.Text = ("" + land + " acres of land");
                    lblarrivals.Text = ("" + lastYrNewPopulation + " arrivals");
                    lbldeaths.Text = ("" + lastYrDeath + " deaths");
                }
                else if (lastYrRatsEaten > 0 && lastYrElephantDamage == 0 && lastYrPlagePopulation == 0)
                {
                    lblyears.Text = ("Hammurabi, I beg to report to you that in the year " + yearNumber + ". Population is now " + population + " inhabitants. Last year " + lastYrDeath + " died and " + lastYrNewPopulation + " came to the Great City of Sumeria. Sumeria now owns " + land + " acres of land. The current price is " + priceOfLand + " bushels per acre. You now have " + bushels + " bushels in store. Last year harvest was " + lastYrHarvestNumber + " bushels per acre. Rats ate " + lastYrRatsEaten + " bushels. There are " + yearsLeft + " years left.");
                    lblpopulation.Text = ("" + population + " people");
                    lblpriceofland.Text = ("" + priceOfLand + " bushels per acre");
                    lblbushelsinstore.Text = ("" + bushels + " bushels");
                    lblacres.Text = ("" + land + " acres of land");
                    lblarrivals.Text = ("" + lastYrNewPopulation + " arrivals");
                    lbldeaths.Text = ("" + lastYrDeath + " deaths");
                }
                else if (lastYrRatsEaten == 0 && lastYrElephantDamage == 0 && lastYrPlagePopulation == 0)
                {
                    lblyears.Text = ("Hammurabi, I beg to report to you that in the year " + yearNumber + " . Population is now " + population + " inhabitants. Last year " + lastYrDeath + " died and " + lastYrNewPopulation + " came to the Great City of Sumeria. Sumeria now owns " + land + " acres of land. The current price is " + priceOfLand + " bushels per acre. You now have " + bushels + " bushels in store. Last year harvest was " + lastYrHarvestNumber + " bushels per acre. There are " + yearsLeft + " years left.");
                    lblpopulation.Text = ("" + population + " people");
                    lblpriceofland.Text = ("" + priceOfLand + " bushels per acre");
                    lblbushelsinstore.Text = ("" + bushels + " bushels");
                    lblacres.Text = ("" + land + " acres of land");
                    lblarrivals.Text = ("" + lastYrNewPopulation + " arrivals");
                    lbldeaths.Text = ("" + lastYrDeath + " deaths");
                }
            }
            else //if (yearNumber == 10)
            {
                if (MessageBox.Show("Hammurabi, I am delighted to inform you that you have survived 10 years term of office!" + "\n" + "Click Yes to view your report or click No to replay the game.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    axHamMusic.Ctlcontrols.stop();
                    this.Hide();
                    highscores highscores = new highscores();
                    highscores.btngoback.Visible = false;
                    highscores.ShowDialog();
                }
                else
                {
                    axHamMusic.Ctlcontrols.stop();
                    maingame m = new maingame();
                    this.Close();
                    m.Show();
                }
            }
        }


        private void playgamebtn_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();

            int.TryParse(input1.Text, out userLandBuySell);
            int.TryParse(input2.Text, out userBushelsGive);
            int.TryParse(input3.Text, out userLandPlant);

            //bushelcost = userLandBuySell

            //reset disaster indicators
            ratsicon.Image = Properties.Resources.rats;
            elephanticon.Image = Properties.Resources.elephant;
            plagueicon.Image = Properties.Resources.plague;

            //validation and to determine if user is either buying or selling acres
            if (userLandBuySell <= -1)
            {
                if (Math.Abs(userLandBuySell) > land)
                {
                    MessageBox.Show("You can't do that you only have " + land + " acres of land.");
                }
                else if ((userBushelsGive > bushels) || (userLandPlant > bushels || ((userBushelsGive + userLandPlant) > bushels)))
                {
                    MessageBox.Show("You can't do that you only have " + bushels + " to feed.");
                }
                else if ((population * 10) < userLandPlant)
                {
                    MessageBox.Show("You can't do that as the population is only " + population + "");
                }
                //if (userLandBuySell * priceOfLand + userBushelsGive + userLandPlant < bushels) || (Math.Abs(userLandBuySell) > land);
                else if ((userLandBuySell * priceOfLand + userBushelsGive + userLandPlant <= bushels) && (Math.Abs(userLandBuySell) <= land))
                {
                    bushelcost = userBushelsGive + userLandPlant;
                    if (MessageBox.Show("Would you like to sell " + input1.Text.Remove(0, 1) + " acres for " + (Math.Abs(userLandBuySell * priceOfLand)) + " bushels, plant " + input2.Text + " bushels and feed " + input3.Text + " bushels for your people? This will cost a total of " + bushelcost + " bushels" + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        yearsLeft = yearsLeft - 1;
                        yearNumber = yearNumber + 1;

                        progressbar.Width += 64;

                        lastYrElephantDamage = 0;
                        lastYrRatsEaten = 0;
                        lastYrPlagePopulation = 0;

                        //reset disaster indicators
                        ratsicon.Image = Properties.Resources.rats;
                        elephanticon.Image = Properties.Resources.elephant;
                        plagueicon.Image = Properties.Resources.plague;

                        AcresToSell();
                        BushelsForPlanting();
                        FeedingPopulation();

                        Rats();
                        Elephants();
                        Plague();

                        bushelsremaining();
                        acresremaining();

                        gameReport();
                    }
                    else
                    {
                        //Do Nothing
                    }
                }
            }
            else if (userLandBuySell >= 0)
            {
                if (((priceOfLand * userLandBuySell) > bushels)) //|| (bushelcost > bushels))
                {
                    MessageBox.Show("You can't do that you only have " + bushels + " to spend");
                }
                else if ((userBushelsGive > bushels) || (userLandPlant > bushels || ((userBushelsGive + userLandPlant) > bushels)))
                {
                    MessageBox.Show("You can't do that you only have " + bushels + " to give away.");
                }
                else if ((population * 10) < userLandPlant)
                {
                    MessageBox.Show("You can't do that as the population is only " + population + "");
                }
                else if (userLandBuySell * priceOfLand + userBushelsGive + userLandPlant <= bushels)
                {
                    //bushelcost = priceOfLand * userLandBuy + userBushelsGive + userLandPlant;
                    //bushelcost = userLandBuySell * priceOfLand + userBushelsGive + userLandPlant;
                    bushelcost = userLandBuySell * priceOfLand + userBushelsGive + userLandPlant;
                    if (MessageBox.Show("Would you like to buy " + input1.Text + " acres for " + (userLandBuySell * priceOfLand) + " bushels, plant " + input2.Text + " bushels and feed " + input3.Text + " bushels for your people? This will cost a total of " + bushelcost + " bushels." + "\n" + "Do you want to Continue ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        yearsLeft = yearsLeft - 1;
                        yearNumber = yearNumber + 1;

                        progressbar.Width += 64;

                        lastYrElephantDamage = 0;
                        lastYrRatsEaten = 0;
                        lastYrPlagePopulation = 0;

                        AcresToBuy();
                        BushelsForPlanting();
                        FeedingPopulation();

                        NewPopulation();

                        Rats();
                        Elephants();
                        Plague();

                        bushelsremaining();
                        acresremaining();

                        gameReport();
                    }
                    else
                    {
                        //Do Nothing
                    }
                }
            }
        }

        private void AcresToBuy()
        {
            while (buyLoop < 1)
            {
                if (int.TryParse(input1.Text, out userLandBuy))
                {
                    // Logic
                    //if (userLandBuy > 0 && trackBar1.Value >= 1)
                    if (userLandBuy > 0)
                    {
                        land = land + userLandBuy;
                        bushelsForBuying = userLandBuy * priceOfLand;
                        bushels = bushels - bushelsForBuying;
                        //MessageBox.Show("You now have " + land + " Acres");
                        //MessageBox.Show("You now have " + bushels + " Bushels");
                        //lblacres.Text = ("The city owns " + land + " acres");
                        buyLoop++;
                    }
                    else
                    {
                        buyLoop++;
                    }
                }
            }
        }


        private void AcresToSell()
        {
            while (sellLoop < 1)
            {
                if (int.TryParse(input1.Text, out userLandSell))
                {
                    // Logic
                    //else if (userLandSell > 0 && userLandSell <= 1 && trackBar1.Value < 0)
                    //if (userLandSell < 0 && trackBar1.Value <= -1)
                    if (userLandSell <= -1)
                    {
                        userLandSell = Math.Abs(userLandSell); //Convert negative value to positive. Thanks Chris!!
                        land = land - userLandSell;
                        bushelsFromSelling = userLandSell * priceOfLand;
                        bushels = bushels + bushelsFromSelling;
                        //MessageBox.Show("You now have " + land + " Acres");
                        //MessageBox.Show("You now have " + bushels + " Bushels");
                        //lblacres.Text = ("The city owns " + land + " acres");
                        //lblremainder.Text = ("Bushels Remaining: " + bushels);
                        sellLoop++;
                    }
                    else
                    {
                        sellLoop++;
                    }
                }
            }
        }

        private void BushelsForPlanting()
        {
            while (plantLoop < 1)
            {
                int userLandPlant;
                if (int.TryParse(input2.Text, out userLandPlant))
                {
                    if (userLandPlant <= trackBar2.Maximum)
                    {
                        //trackBar2.Value = userLandPlant;
                        bushels = bushels - userLandPlant;
                        harvest = harvestNumber * userLandPlant;
                        totalBushelsHarvested = totalBushelsHarvested + harvest;
                        lastYrHarvestNumber = harvestNumber;
                        //lblbushelsinstore.Text = ("You have " + bushels + " bushels in store");
                        //lblremainder.Text = ("Bushels Remaining: " + bushels);
                        plantLoop++;
                    }
                }
            }
        }

        private void FeedingPopulation()
        // User selecting how many BUSHELS they would like to feed POPULATION
        // 100% Working
        {
            while (feedingLoop < 1)
            {
                int userBushelsGive;
                if (int.TryParse(input3.Text, out userBushelsGive))
                {
                    eatenPopulation = userBushelsGive / 20;
                    // if statment bellow is shortcut to fix bug that 
                    // increased population if you gave more than 20 per populant
                    if (eatenPopulation > population)
                    {
                        eatenPopulation = population;
                    }
                    deadPopulation = population - eatenPopulation;
                    totalDeathStarving = totalDeathStarving + deadPopulation;
                    lastYrDeath = deadPopulation;
                    population = population - deadPopulation;
                    bushels = bushels - userBushelsGive;
                    //MessageBox.Show("You now have " + bushels + " Bushels");
                    //lblbushelsinstore.Text = ("You have " + bushels + " bushels in store");
                    //lblpopulation.Text = ("Population is now " + population);
                    //lblacres.Text = ("The city owns " + land + " acres");
                    //lblremainder.Text = ("Bushels Remaining: " + bushels);
                    feedingLoop++;
                }
            }
        }

        private void Rats()
        {
            if (harvestNumber > 5 && harvest > ratsEaten)
            {
                //MessageBox.Show("Rat infestation!");
                harvest = harvest - ratsEaten;
                lastYrRatsEaten = ratsEaten;
                totalRatsEaten = totalRatsEaten + ratsEaten;
                ratsicon.Image = Properties.Resources.rats_enabled;
                axRats.URL = @"Data/Sounds/rats.wav";
                axRats.Ctlcontrols.play();
                lblbushelsinstore.Text = ("" + bushels + " bushels");
                toolTip13.Show("rats have ate " + ratsEaten + " bushels!", ratsicon);
            }
            else
            {
                lastYrRatsEaten = 0;
            }
        }

        private void Elephants()
        // Instead of tornadoes/floods, acres can be destroyed by elephants :)
        {
            if (elephantPercent > 45 && land > elephantDamage)
            {
                //MessageBox.Show("Elephants have damaged the land!");
                land = land - elephantDamage;
                lastYrElephantDamage = elephantDamage;
                totalElephantDamade = totalElephantDamade + elephantDamage;
                elephanticon.Image = Properties.Resources.elephant_enabled;
                axElephants.URL = @"Data/Sounds/elephant.wav";             
                axElephants.Ctlcontrols.play();
                lblbushelsinstore.Text = ("" + bushels + " bushels");
                //toolTip12.Show("Elephants have caused " + elephantDamage + " damage!", elephanticon);
            }
            else
            {
                lastYrElephantDamage = 0;
                //toolTip12.Show("No reports of elephants!", elephanticon);
            }
        }

        private void Plague()
        // Game determinig if a plauge will accour
        // A plauge accours when plage% is > 60 and the pop is > plagePop
        {
            if (plagePercent > 80 && population > plagePopulation)
            {
                //MessageBox.Show("Plague has struck!");
                population = population - plagePercent;
                lastYrPlagePopulation = plagePopulation;
                totalDeathPlage = totalDeathPlage + plagePopulation;
                plagueicon.Image = Properties.Resources.plague_enabled;
                axPlague.URL = @"Data/Sounds/plague.wav";
                axPlague.Ctlcontrols.play();
                toolTip11.Show("Plague has struck!", plagueicon);
            }
            else
            {
                lastYrPlagePopulation = 0;
            }
        }

        private void NewPopulation()
        // Game determining if new population will occur
        // New Population will accour when no one dies that year or when harvest is <= 5 
        {
            if (deadPopulation + plagePopulation == 0 || harvestNumber <= 5)
            {
                population = population + newPopulation;
                lastYrNewPopulation = newPopulation;
                totalNewPopulation = totalNewPopulation + newPopulation;
                lblpopulation.Text = ("" + population + " people");
            }
            else
            {
                lastYrNewPopulation = 0;
            }
        }

        private void IsItGameOver()
        // Game determining if user decions have lost the game
        // No need to white box test this method as messageboxes confirm working as expected
        {
            if (population <= 0 || deadPopulation > 90)
            {
                while (gameOverLoop < 1)
                    if (deadPopulation > 90 || population <= 0)
                    {
                        axHamMusic.Ctlcontrols.stop();
                        MessageBox.Show("You starved " + deadPopulation + " people in one year! Due to this extreme mismanagement you have not only been impeached and thrown out of office but you have also been declared national fink!!!!");
                        this.Hide();
                        highscores highscores = new highscores();
                        highscores.btngoback.Visible = false;
                        highscores.nextbtn2.Visible = true;
                        highscores.ShowDialog();
                    }
            }
            else if (deadPopulation > 0 && deadPopulation <= 7)
            {
                MessageBox.Show("Maybe they just died of old age...?");
            }
            else if (deadPopulation > 7 && deadPopulation <= 90)
            {
                MessageBox.Show("What are you doing we need to eat!\nKing Nahire would not have allowed this to happen!");
            }
        }         

        private void nextbtn1_MouseHover_1(object sender, EventArgs e)
        {
            this.nextbtn1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.proceed_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void nextbtn1_MouseLeave_1(object sender, EventArgs e)
        {
            this.nextbtn1.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.proceed));
        }

        private void btnexit2_Click(object sender, EventArgs e)
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

        private void btnexit2_MouseHover(object sender, EventArgs e)
        {
            this.btnexit2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.close_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btnexit2_MouseLeave(object sender, EventArgs e)
        {
            this.btnexit2.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.close));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
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
            {
                if (mouseDown)
                {
                    this.Location = new Point(
                        (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                    this.Update();
                }
            }
        }

        private void lblpopulation_Click(object sender, EventArgs e)
        {

        }

        private void lblyears_Click(object sender, EventArgs e)
        {

        }

        private void input1_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(input1.Text, "[^0-9-]"))
            {
                MessageBox.Show("Please enter only numbers.");
                //input1.Text = input1.Text.Remove(input1.Text.Length - 1);
                input1.Text = "0";
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            input2.Text = trackBar2.Value.ToString();
            bushelsremaining();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            input1.Text = trackBar1.Value.ToString();
            acresremaining();
            bushelsremaining();
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            input3.Text = trackBar3.Value.ToString();
            bushelsremaining();
        }

        private void bushelsremaining()
        {
            //No white box testing needed as visually can see its working with maths

            int value1;
            int value2;
            int value3;
            int.TryParse(input1.Text.ToString(), out value1);
            int.TryParse(input2.Text.ToString(), out value2);
            int.TryParse(input3.Text.ToString(), out value3);

            //Math.Abs
            negremainder = Math.Abs((value1 * priceOfLand));
            finalremainder = (value3 + value2 + (value1 * priceOfLand));
            //finalremainder = (value3 + value2);
            lblremainder.Text = ("Bushels Remaining: " + (bushels - value3 - value2 - (value1 * priceOfLand)) + "");
            //if (bushels - value2 - value3 - (value1 * priceOfLand) < -1) //To let user know that there is not enough bushels when font color turns red
            //if (finalremainder < -1)
            if ((finalremainder) > bushels)
            {
                lblremainder.ForeColor = Color.Red;
                input1.Enabled = false;
                input2.Enabled = false;
                input3.Enabled = false;
            }
            else
            {
                lblremainder.ForeColor = Color.Gainsboro;
                input1.Enabled = true;
                input2.Enabled = true;
                input3.Enabled = true;
            }
        }

        private void acresremaining()
        {
            //No white box testing needed as visually can see its working with maths

            int value1;
            int increase;
            int.TryParse(trackBar1.Value.ToString(), out value1);
            int.TryParse(input1.Text.ToString(), out increase);
            lblacresremaining.Text = ("Acres Remaining: " + (land + increase) + "");

            if (increase >= trackBar1.Maximum)
            {
                //input1.Enabled = false;
                trackBar1.Maximum = increase;
            }
            else if (increase <= land)
            {
                trackBar1.Maximum = land;
            }
        }

        private void btnincrease1_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            int userLandBuy;
            int.TryParse(input1.Text, out userLandBuy);


            //if (trackBar1.Value >= trackBar1.Maximum)
            //{
                //trackBar1.Maximum = userLandBuy + 60;
            //    trackBar1.Value = userLandBuy + 50;
            //}
            //else
            //{
            //    trackBar1.Maximum = userLandBuy;
            //    trackBar1.Value = userLandBuy + 50;
            //}


            //input1.Text = (userLandBuy + 50).ToString();
            //acresremaining();
            //bushelsremaining();

            if (userLandBuy < trackBar1.Maximum)
            {
                trackBar1.Value = userLandBuy + 50;
                input1.Text = (userLandBuy + 50).ToString();
                acresremaining();
                bushelsremaining();
            }
            else
            {
                MessageBox.Show("You can only buy a maximum of " + trackBar1.Maximum + " acres");
                input1.Text = ("" + trackBar1.Maximum + "");
                trackBar1.Value = trackBar1.Maximum;
            }
        }

        private void btndecrease1_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            int userSellLand;
            int.TryParse(input1.Text, out userSellLand);

            if (userSellLand > trackBar1.Minimum)
            {
                trackBar1.Value = userSellLand - 50;
                input1.Text = (userSellLand - 50).ToString();
                acresremaining();
                bushelsremaining();

            }
            else
            {
                MessageBox.Show("You can only sell a maximum of " + Math.Abs(trackBar1.Minimum) + " acres");
                input1.Text = ("" + trackBar1.Minimum + "");
            }
        }

        private void btnincrease2_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            int userLandPlant;
            if (int.TryParse(input2.Text, out userLandPlant))
            {
                if (userLandPlant < trackBar2.Maximum)
                {
                    trackBar2.Value = userLandPlant;
                    input2.Text = (userLandPlant + 50).ToString();
                    bushelsremaining();
                }
                else
                {
                    MessageBox.Show("You only have " + trackBar2.Maximum + " bushels to plant.");
                    input2.Text = ("" + trackBar2.Maximum + "");
                }
            }
            else
            {
                MessageBox.Show("Can only accept digits!");
            }
        }

        private void btndecrease2_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            int userLandPlant;
            if (int.TryParse(input2.Text, out userLandPlant))
            {
                if (userLandPlant > trackBar2.Minimum)
                {
                    trackBar2.Value = userLandPlant;
                    input2.Text = (userLandPlant - 50).ToString();                  
                    bushelsremaining();
                }
                else
                {
                    MessageBox.Show("You cannot plant less than " + trackBar3.Minimum + " bushels.");
                    input2.Text = ("" + trackBar2.Minimum + "");
                }
            }
            else
            {
                MessageBox.Show("Can only accept digits!");
            }
        }

        private void btnincrease3_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            int userInputBushelsGive;
            if (int.TryParse(input3.Text, out userInputBushelsGive))
            {
                if (userInputBushelsGive < trackBar3.Maximum)
                {
                    trackBar3.Value = userInputBushelsGive;
                    input3.Text = (userInputBushelsGive + 50).ToString();                
                    bushelsremaining();
                }
                else
                {
                    MessageBox.Show("You only have " + trackBar3.Maximum + " bushels of grain to feed your people.");
                    input3.Text = ("" + trackBar3.Maximum + "");
                }
            }
            else
            {
                MessageBox.Show("Can only accept digits!");
            }
        }

        private void btndecrease3_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            int userInputBushelsGive;
            if (int.TryParse(input3.Text, out userInputBushelsGive))
            {
                if (userInputBushelsGive > trackBar3.Minimum)
                {
                    trackBar3.Value = userInputBushelsGive;
                    input3.Text = (userInputBushelsGive - 50).ToString();                  
                    bushelsremaining();
                }
                else
                {
                    MessageBox.Show("You cannot feed less than " + trackBar3.Minimum + " bushels.");
                    input3.Text = ("" + trackBar3.Minimum + "");
                }
            }
            else
            {
                MessageBox.Show("Can only accept digits!");
            }
        }

        private void iquitbtn_MouseHover(object sender, EventArgs e)
        {
            this.iquitbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.iquit_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void iquitbtn_MouseLeave(object sender, EventArgs e)
        {
            this.iquitbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.iquit));
        }

        private void iquitbtn_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            if (MessageBox.Show("Hammurabi, are you sure you want to quit?" + "\n" + "Click Yes to quit and to go back to the main menu.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                axHamMusic.Ctlcontrols.stop();
                this.Hide();
                mainmenu mainmenu = new mainmenu();
                mainmenu.ShowDialog();
            }
            else
            {
                //Nothing
            }
        }

        private void btnminimize_MouseHover(object sender, EventArgs e)
        {
            this.btnminimize.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.minimize_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btnminimize_MouseLeave(object sender, EventArgs e)
        {
            this.btnminimize.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.minimize));
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void restartbtn_MouseHover(object sender, EventArgs e)
        {
            this.restartbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.restart_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void restartbtn_MouseLeave(object sender, EventArgs e)
        {
            this.restartbtn.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.restart));
        }

        private void restartbtn_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            if (MessageBox.Show("Hammurabi, are you sure you want to restart?" + "\n" + "Click Yes to Restart.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {           
                axHamMusic.Ctlcontrols.stop();
                maingame m = new maingame();
                this.Close();
                //gameReport();
                m.Show();
            }
            else
            {
                //Nothing
            }
        }

        private void input1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Enter a negative amount to sell acres or enter a positive amount to buy acres", input1);
        }

        private void input2_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("Each acre takes one bushel", input2);
        }

        private void input3_MouseHover(object sender, EventArgs e)
        {
            toolTip3.Show("Each citizen needs at least 20 bushels a year", input3);
        }

        private void ratsicon_MouseHover(object sender, EventArgs e)
        {
            //toolTip1.Show("No rat disaster to report", ratsicon);
        }

        private void elephanticon_MouseHover(object sender, EventArgs e)
        {
            //if (elephantPercent > 45 && land > elephantDamage)
            //{
            //    toolTip12.Show("Elephants have caused " + elephantDamage + " damage!", elephanticon);
            //}
            //else
            //{
            //    toolTip12.Show("No report of elephants!", elephanticon);
            //}
        }

        private void plagueicon_MouseHover(object sender, EventArgs e)
        {
            //toolTip1.Show("No plague disaster to report", plagueicon);
        }

        private void input2_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(input2.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                //input2.Text = input2.Text.Remove(input2.Text.Length - 1);
                input2.Text = "0";
            }
        }

        private void input3_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(input3.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                //input3.Text = input3.Text.Remove(input3.Text.Length - 1);
                input3.Text = "0";
            }
        }

        private void input1_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.RemoveAll();
        }

        private void input2_MouseLeave(object sender, EventArgs e)
        {
            toolTip2.RemoveAll();
        }

        private void input3_MouseLeave(object sender, EventArgs e)
        {
            toolTip3.RemoveAll();
        }

        public void reportbtn_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();           
            highscores highscores = new highscores();
            highscores.nextbtn2.Visible = false;
            highscores.Show();
        }

        private void btnsound_MouseHover(object sender, EventArgs e)
        {
            this.btnsound.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.sound_highlighted));
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btnsound_MouseLeave(object sender, EventArgs e)
        {
            this.btnsound.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.sound));
        }

        private void btnsound_Click(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.switch1);
            audio.Play();
            {
            //A switch table to toggle between mute/unmute buttons an to pause/mute background music.
            Start:
                count++;
                switch (count)
                {
                    case 1:
                        this.btnsound.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.sound_mute));
                        axHamMusic.Ctlcontrols.pause();
                        break;
                    case 2:
                        this.btnsound.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.sound));
                        axHamMusic.Ctlcontrols.play();
                        break;
                    default:
                        count = 0;
                        goto Start;
                }
            }
        }

        private void btnincrease1_MouseHover(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btnincrease2_MouseHover(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btnincrease3_MouseHover(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btndecrease1_MouseHover(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btndecrease2_MouseHover(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void btndecrease3_MouseHover(object sender, EventArgs e)
        {
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void reportbtn_MouseHover(object sender, EventArgs e)
        {
            toolTip4.Show("Look at a more detailed report", reportbtn);
            SoundPlayer audio = new SoundPlayer(Properties.Resources.click1);
            audio.Play();
        }

        private void input1_Leave(object sender, EventArgs e)
        {
            int value1;
            int.TryParse(input1.Text.ToString(), out value1);
            remainder1 = value1;

            lblacresremaining.Text = ("Acres Remaining: " + (land + remainder1) + "");
            lblremainder.Text = ("Bushels Remaining: " + (bushels - remainder2 - remainder3 - (remainder1 * priceOfLand)) + "");

            acresremaining();
            bushelsremaining();

            //if (bushels - (remainder1 * priceOfLand) < -0)
            if (remainder1 > trackBar1.Maximum)
            {
                //trackBar1.Value = trackBar1.Maximum;
                //input1.Text = "" + trackBar1.Maximum + "";
                acresremaining();
                bushelsremaining();
            }
            else if (remainder1 < trackBar1.Minimum)
            {
                trackBar1.Value = trackBar1.Minimum;
                input1.Text = "" + trackBar1.Minimum + "";
                acresremaining();
                bushelsremaining();
            }
            else if ((remainder1 * priceOfLand) + remainder2 + remainder3 > bushels)
            {
                trackBar1.Value = remainder1;
                input1.Enabled = false;
                input2.Enabled = false;
                input3.Enabled = false;
            }
            else
            {
                trackBar1.Value = value1;
            }        


            //if (value1 > land)
            //{
            //    input1.Enabled = false;
            //}
            //else
            //{
            //    input1.Enabled = true;
            //}
        }

        private void input2_Leave(object sender, EventArgs e)
        {
            int value2;
            int.TryParse(input2.Text.ToString(), out value2);
            remainder2 = value2;

            lblremainder.Text = ("Bushels Remaining: " + (bushels - remainder2 - remainder3 - (remainder1 * priceOfLand)) + "");

            acresremaining();
            bushelsremaining();

            if (remainder2 > trackBar2.Maximum)
            {
                trackBar2.Value = trackBar2.Maximum;
                input2.Text = "" + trackBar2.Maximum + "";
                acresremaining();
                bushelsremaining();
            }
            else if (remainder2 < trackBar2.Minimum)
            {
                trackBar2.Value = trackBar2.Minimum;
                input2.Text = "" + trackBar2.Minimum + "";
                acresremaining();
                bushelsremaining();
            }
            else if ((remainder1 * priceOfLand) + remainder2 + remainder3 > bushels)
            {
                trackBar2.Value = remainder2;
                input1.Enabled = false;
                input2.Enabled = false;
                input3.Enabled = false;
            }
            else
            {
                trackBar2.Value = value2;
            }
        }

        private void input3_Leave(object sender, EventArgs e)
        {
            int value3;
            int.TryParse(input3.Text.ToString(), out value3);
            remainder3 = value3;

            lblremainder.Text = ("Bushels Remaining: " + (bushels - remainder3 - remainder2 - (remainder1 * priceOfLand)) + "");

            acresremaining();
            bushelsremaining();

            if (remainder3 > trackBar3.Maximum)
            {
                trackBar3.Value = trackBar3.Maximum;
                input3.Text = "" + trackBar3.Maximum + "";
                acresremaining();
                bushelsremaining();
            }
            else if (remainder3 < trackBar3.Minimum)
            {
                trackBar3.Value = trackBar3.Minimum;
                input3.Text = "" + trackBar3.Minimum + "";
                acresremaining();
                bushelsremaining();
            }
            else if ((remainder1 * priceOfLand) + remainder2 + remainder3 > bushels)
            {
                trackBar3.Value = remainder3;
                input1.Enabled = false;
                input2.Enabled = false;
                input3.Enabled = false;
            }
            else
            {
                trackBar3.Value = value3;
            }
        }

        private void reportbtn_MouseLeave(object sender, EventArgs e)
        {
            toolTip4.RemoveAll();
        }

        private void acresicon_MouseHover(object sender, EventArgs e)
        {
            toolTip5.Show("You own " + land + " acres", acresicon);
        }

        private void acresicon_MouseLeave(object sender, EventArgs e)
        {
            toolTip5.RemoveAll();
        }

        private void bushelsicon_MouseHover(object sender, EventArgs e)
        {
            toolTip6.Show("You have " + bushels + " bushels in store", bushelsicon);
        }

        private void bushelsicon_MouseLeave(object sender, EventArgs e)
        {
            toolTip6.RemoveAll();
        }

        private void populationicon_MouseHover(object sender, EventArgs e)
        {
            toolTip7.Show("There are " + population + " people", populationicon);
        }

        private void populationicon_MouseLeave(object sender, EventArgs e)
        {
            toolTip7.RemoveAll();
        }

        private void tradepriceicon_MouseHover(object sender, EventArgs e)
        {
            toolTip8.Show("The trading price is " + priceOfLand + " per acre", tradepriceicon);
        }

        private void tradepriceicon_MouseLeave(object sender, EventArgs e)
        {
            toolTip8.RemoveAll();
        }

        private void arrivalsicon_MouseHover(object sender, EventArgs e)
        {
            toolTip9.Show("" + lastYrNewPopulation + " new people arrived", arrivalsicon);
        }

        private void arrivalsicon_MouseLeave(object sender, EventArgs e)
        {
            toolTip9.RemoveAll();
        }

        private void deathsicon_MouseHover(object sender, EventArgs e)
        {
            toolTip10.Show("" + lastYrDeath + " people have died", deathsicon);
        }

        private void deathsicon_MouseLeave(object sender, EventArgs e)
        {
            toolTip10.RemoveAll();
        }

        private void elephanticon_MouseLeave(object sender, EventArgs e)
        {
            toolTip12.RemoveAll();
        }
    }
}
