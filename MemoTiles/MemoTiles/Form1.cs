using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoTiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length == 0) //Edge case: Player didn't write down their name
            {
                MessageBox.Show(
                                "Please enter player name!",
                                "Houston we have a problem!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                                 );
            }
            else
            {
                if(comboBox1.SelectedIndex == -1) //Edge case: Player didn't select a level
                {
                    MessageBox.Show(
                                    "Please select a level!",
                                    "Houston we have a problem!",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                     );
                }
                else
                {
                    
                    if( textBox2.Text.Trim().Length == 0 || textBox3.Text.Trim().Length == 0 || 
                        textBox4.Text.Trim().Length == 0 || textBox5.Text.Trim().Length == 0) //Empty form message
                    {
                        MessageBox.Show(
                                   "Please fill the form!",
                                   "Houston we have a problem!",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error
                                    );
                    }
                    
                    if((Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox2.Text)) <
                        Convert.ToInt32(textBox4.Text))  // In case the player chose too mate tiles
                    {
                        MessageBox.Show( 
                                   "Number of tiles are more than given board!",
                                   "Houston we have a problem!",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error
                                    );
                    }

                    if (Convert.ToInt32(textBox3.Text) < 1)  // In case the player chooses to have 0 lives or less
                    {
                        MessageBox.Show(
                                   "You can't have negative lives!",
                                   "Houston we have a problem!",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error
                                    );
                    }

                    else
                    {
                        GameData gameData = new GameData();
                        gameData.playerName = textBox1.Text;
                        gameData.boardSize = Convert.ToInt32(textBox2.Text);
                        gameData.lives = Convert.ToInt32(textBox3.Text) - 1;
                        gameData.showTime = Convert.ToInt32(textBox5.Text);
                        gameData.numberTiles = Convert.ToInt32(textBox4.Text);
                        if (Convert.ToInt32(textBox4.Text) < 1)
                        {
                            MessageBox.Show(
                                   "Number of tiles should over than 1!",
                                   "Houston we have a problem!",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error
                                    );
                            
                        }
                        else {
                            Data.GameDictionary.Clear();
                            Data.GameDictionary.Add("GmDic", gameData);
                            Form2 f2 = new Form2();
                            f2.Show();
                            this.Hide();
                        }
                     
                     
                        
                    }
                }
            }
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 3)
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox5.Text = "";
                textBox4.Text = "";
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;

                if (comboBox1.SelectedIndex == 0)
                {
                    textBox2.Text = "4";
                    textBox3.Text = "3";
                    textBox5.Text = "4";
                    textBox4.Text = "5";
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    textBox2.Text = "6";
                    textBox3.Text = "2";
                    textBox5.Text = "3";
                    textBox4.Text = "7";
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    textBox2.Text = "9";
                    textBox3.Text = "2";
                    textBox5.Text = "3";
                    textBox4.Text = "11";
                }
            }
            
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
