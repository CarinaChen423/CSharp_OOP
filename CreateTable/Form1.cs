using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateTable
{
    public partial class Form1 : Form
    {
        int tbX=60, tbY=150;
        TextBox[,] allTextBoxes;
        int rowNum, columnNum;

        private void button2_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < rowNum; i++)
            {
                for(int j=0;j<columnNum; j+=2)
                {
                    string val1 = allTextBoxes[i, j].Text;
                    string val2 = allTextBoxes[i, j+1].Text;
                    allTextBoxes[i, j].Text = val2;
                    allTextBoxes[i, j+1].Text = val1;
                    //swap each two value
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int r = Convert.ToInt32(textBox1.Text);
            int c = Convert.ToInt32(textBox2.Text);
            
            if (c % 2 == 0)
            {
                rowNum = r;
                columnNum = c;
                allTextBoxes = new TextBox[r, c];
                for (int i = 1; i <= r; i++)
                {
                    for (int j = 1; j <= c; j++)
                    {
                        TextBox tb = new TextBox();
                        tb.Width = 60;
                        tb.Font = new Font("Arial", 10);
                        tb.Location = new Point(tbX, tbY);
                        tb.Name = $"tb{i}{j}";
                        tb.Text = "";
                        this.Controls.Add(tb);
                        allTextBoxes[i - 1, j - 1] = tb; 
                        tbX += 80;
                    }
                    tbX = 60;
                    tbY += 50;
                }
                Button btn=new Button();
                btn.Text = "Swap";
                btn.Font = new Font("Arial", 24);
                btn.Dock = DockStyle.Bottom;
                btn.Height = 50;
                btn.Click += button2_Click;
                //btn.Click += new EventHandler(button2_Click);
                this.Controls.Add(btn);
            }
            else
            {
                MessageBox.Show("Column should be even number!");
            }
        }
    }
}

