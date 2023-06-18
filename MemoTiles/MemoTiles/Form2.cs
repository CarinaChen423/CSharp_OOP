using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoTiles
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();

            
            //Loading the game data on the form getting initialized
            GameData gameData = Data.GameDictionary["GmDic"];
           
            label2.Text =$"{gameData.playerName}!";
            label4.Text = gameData.showTime.ToString();
            label5.Text = gameData.numberTiles.ToString();
            label7.Text = gameData.lives.ToString();
            boardSize = gameData.boardSize;
            showTime = gameData.showTime;
            numberTiles = gameData.numberTiles;
            lives = gameData.lives;


            // Choosing tilesize
            if(this.Width - 165 < this.Height)
            {
                tileSize = (this.Width -10) / boardSize;

            }
            else
            {
                tileSize = (this.Height-10) / boardSize;
            }

            marginsize = tileSize / 20; // margin between tiles ar 5% size of the button or at least 1px
            if(marginsize < 1)
            {
                marginsize = 1;
            }
           


            // Creating the games tiles (as buttons)
            allTiles = new Button[boardSize * boardSize];
            int x, y = marginsize;
            for (int i = 0; i < boardSize; i++)
            {
                x = 172;
                for (int j = 0; j < boardSize; j++)
                {
                    int fontSize = tileSize / 2;

                    if (numberTiles > 10)
                    {
                        fontSize = tileSize / 4;
                    }
                    
                    int buttonId = i * boardSize + j;
                    Button bt = new Button();
                    bt.Name = $"bt{buttonId}";
                    bt.ForeColor = Color.White;
                    bt.Text = "";
                    bt.TextAlign = ContentAlignment.MiddleCenter;
                    bt.Font = new Font("Yu Gothic UI", fontSize); // giving dynamic fontsize
                    bt.Location = new Point(x, y);
                    bt.Size = new Size(tileSize, tileSize);
                    x += bt.Width + marginsize;
                    bt.UseVisualStyleBackColor = true;
                    bt.Click += new EventHandler(button3_Click);    // adding an event to dynamic buttons

                    this.Controls.Add(bt);
                    allTiles[buttonId] = bt;


                }

                y += tileSize + marginsize;
            }

        }

        public int boardSize, lives, showTime, numberTiles;
        Button[] allTiles;
        int[] activeTiles;

        int buttonOrder, tileSize, marginsize;
        bool isItStarted= false;
       








        //Timer
        private void starttimer_Tick(object sender, EventArgs e)
        {
            showTime --;
            label4.Text = Math.Abs(showTime).ToString();
            if (showTime == 0)
            {
                for (int j = 0; j < numberTiles; j++)
                {
                    string idOfTile = allTiles[activeTiles[j]].Text;

                    allTiles[activeTiles[j]].BackColor = Color.White;
                    allTiles[activeTiles[j]].ForeColor = Color.White;

                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isItStarted && starttimer.Enabled && showTime < 1)
            {
                Button clickedButton = (Button)sender;

                switch (clickedButton.Text.Trim()) //We are using switch statements instead of if statemenets for readibility (It was learnt in the 1st sem)
                {
                    case var text when text == buttonOrder.ToString():
                        clickedButton.ForeColor = Color.LimeGreen;
                        clickedButton.BackColor = Color.White;
                        buttonOrder++;
                        label5.Text = (numberTiles - buttonOrder + 1).ToString();
                        break;
                    default:
                        clickedButton.ForeColor = Color.Red;
                        clickedButton.BackColor = Color.Red;
                        lives--;

                        if (lives >= 0)
                        {
                            label7.Text = lives.ToString();
                        }
                        break;
                }

                if (lives < 0)
                {
                    starttimer.Stop();

                    for (int j = 0; j < numberTiles; j++)
                    {
                        string idOfTile = allTiles[activeTiles[j]].Text;

                        allTiles[activeTiles[j]].ForeColor = Color.Black;

                    }

                    VoidMessages.VoidGameOver(showTime);

                    startbutton.Enabled = true;
                }

                if (buttonOrder - 1 == numberTiles)
                {
                    starttimer.Stop();
                    VoidMessages.VoidWon(showTime);

                    startbutton.Enabled = true;
                }
 
        }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            //Displays Form1 to the user
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            if (isItStarted)
            {
                GameData gameData = Data.GameDictionary["GmDic"];
                label4.Text = gameData.showTime.ToString();
                label5.Text = gameData.numberTiles.ToString();
                label7.Text = gameData.lives.ToString();
                boardSize = gameData.boardSize;
                showTime = gameData.showTime;
                numberTiles = gameData.numberTiles;
                lives = gameData.lives;
                isItStarted = false;

                

                for (int i = 0; i < boardSize * boardSize; i++)
                {
                    string idOfTile = allTiles[i].Text;

                    allTiles[i].Text = "";
                    allTiles[i].ForeColor = Color.White;
                    allTiles[i].BackColor = Color.White;


                }
            }

            // Selecting Random tiles

            activeTiles = new int[numberTiles];
            activeTiles = Randomizer.RandomTiles(numberTiles, boardSize);
            



            // Showing numbers -- Starting timer

            for (int j = 0; j < numberTiles; j++)
            {
                string idOfTile = allTiles[activeTiles[j]].Text;

                allTiles[activeTiles[j]].Text = Convert.ToString(j + 1);
                allTiles[activeTiles[j]].ForeColor = Color.LimeGreen;


            }


            // running the timer
            starttimer.Start();

            startbutton.Text = "PLAY AGAIN";

            buttonOrder = 1;

            isItStarted = true;

            startbutton.Enabled = false;







        }
    }
}
