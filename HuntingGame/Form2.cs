using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace HuntingGame
{
    public partial class Form2 : Form
    {


        private int score = 0;
        private int level = 1;
        private int time = 0;
        private int rewardTime = 0;
        public string name;
        private int[] rewardPoints = new int[] { 10, 20, 30, 40, 50, 60};
        private int[] rewardTimeEasy = new int[] { 1, 3, 5 ,7, 9, 11};
        private int[] rewardTimeMedium = new int[] { 2, 4, 6,8, 10, 12 };
        private int[] rewardTimeDifficult = new int[] { 3, 5, 7 ,9, 11, 13};
        private Random random = new Random();

        List<string> imageNames = new List<string> { "emoji1", "emoji2", "emoji3", "emoji4", "emoji5" };

        public Form2()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
            label7.Visible = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

        }
        private void CheckScore(int score)
        {
            if (score == 60)
            {
                timer1.Stop();
                var result = MessageBox.Show("Do you want to continue?", "You won!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Please select a difficulty level!");
                return;
            }
            score = 0;
            level = 1;
            timer1.Interval = 1000;
            timer1.Enabled = true;
            button1.Enabled = false;
            label7.Visible = false;
            label5.Text = score.ToString();
            this.Size = new Size(909, 687);
            groupBox1.Enabled = false;

            Random rand = new Random();
            int randomIndex = rand.Next(0, imageNames.Count);
            string randomImageName = imageNames.ElementAt(randomIndex);
            pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(randomImageName);

            pictureBox1.Enabled = true;
            pictureBox1.Visible = true;

            pictureBox1.Location = new Point(random.Next(0, this.ClientSize.Width - pictureBox1.Size.Width), random.Next(0, this.ClientSize.Height - pictureBox1.Size.Height));
            Random rnd = new Random();
            int x = rnd.Next(0, this.ClientSize.Width - pictureBox1.Width);
            int y = rnd.Next(0, this.ClientSize.Height - pictureBox1.Height);

            if (x < 185) x = 185;
            if (y < 0) y = 0;
            if (x + pictureBox1.Width > this.ClientSize.Width) x = this.ClientSize.Width - splitter1.Width;
            if (y + pictureBox1.Height > this.ClientSize.Height) y = this.ClientSize.Height - splitter1.Height;

            pictureBox1.Location = new Point(x, y);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (radioButton1.Checked)
            {
                time = 15;
                rewardTime = rewardTimeEasy[level - 1];
            }
            button1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (radioButton2.Checked)
            {
                time = 12;
                rewardTime = rewardTimeMedium[level - 1];
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (radioButton3.Checked)
            {
                time = 10;
                rewardTime = rewardTimeDifficult[level - 1];
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            score++;
            label5.Text = score.ToString();

            if (score % rewardPoints[level - 1] == 0)
            {
                time += rewardTime;
                level++;
                Random rand = new Random();
                int randomIndex = rand.Next(0, imageNames.Count);
                string randomImageName = imageNames.ElementAt(randomIndex);
                switch (level)
                {

                    case 2:
                        pictureBox1.Size = new Size(95, 95);

                        this.Size = new Size(1009, 680);
                        break;
                    case 3:
                        pictureBox1.Size = new Size(80, 80);

                        this.Size = new Size(1109, 780);
                        break;
                    case 4:
                        pictureBox1.Size = new Size(70, 70);

                        this.Size = new Size(1209, 880);
                        break;
                    case 5:
                        pictureBox1.Size = new Size(60, 60);

                        this.Size = new Size(1309, 980);
                        break;

                }
                pictureBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(randomImageName);


            }
            pictureBox1.Location = new Point(random.Next(0, this.ClientSize.Width - pictureBox1.Size.Width), random.Next(0, this.ClientSize.Height - pictureBox1.Size.Height));
            Random rnd = new Random();
            int x = rnd.Next(0, this.ClientSize.Width - pictureBox1.Width);
            int y = rnd.Next(0, this.ClientSize.Height - pictureBox1.Height);

            if (x < 185) x = 185;
            if (y < 0) y = 0;
            if (x + pictureBox1.Width > this.ClientSize.Width) x = this.ClientSize.Width - splitter1.Width;
            if (y + pictureBox1.Height > this.ClientSize.Height) y = this.ClientSize.Height - splitter1.Height;

            pictureBox1.Location = new Point(x, y);
            CheckScore(score);


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            time--;
            label4.Text = time.ToString();
            label8.Text = "Level: " + level;
            if (time == 0)
            {
                timer1.Stop();
                pictureBox1.Visible = false;
                button1.Enabled = true;
                groupBox1.Enabled = true;
                label7.Visible = true;
                label7.Text = ("Game over!\nScore:" + score);

                if (radioButton1.Checked) { time = 15; }
                if (radioButton2.Checked) { time = 12; }
                if (radioButton3.Checked) { time = 10; }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {


        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label9.Text = name;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
