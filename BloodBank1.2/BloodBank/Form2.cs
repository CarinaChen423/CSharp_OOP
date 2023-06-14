using BloodBank.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            timer1.Enabled = true;
            comboBox1.Items.Add("...");
            comboBox1.Items.Add("A+");
            comboBox1.Items.Add("A-");
            comboBox1.Items.Add("B+");
            comboBox1.Items.Add("B-");
            comboBox1.Items.Add("AB+");
            comboBox1.Items.Add("AB-");
            comboBox1.Items.Add("O+");
            comboBox1.Items.Add("O-");
            comboBox1.SelectedIndex = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();

        }
        public string savedFilePath;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.png)|*.jpg;*.png";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                pictureBox1.ImageLocation = openFileDialog.FileName;
                string fileName = Path.GetFileName(openFileDialog.FileName);
                string savedFilePath = Path.Combine(@"..\..\Resources\", fileName);
                File.Copy(openFileDialog.FileName, savedFilePath, true);
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            label9.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Random random = new Random();
            string randomNumber = random.Next(10000, 99999).ToString();
            string currentDate = DateTime.Now.ToString("fffssmm");
            string timeToSave1 = DateTime.Now.ToString("dd/MM/yy");
            string timeToSave2 = DateTime.Now.ToString("HH:mm:ss");
            string IdOfDonor = randomNumber + "" + currentDate;
            string name = textBox1.Text;           
            string surname = textBox2.Text;
            string socialId = textBox3.Text;
            string phoneNumber = textBox4.Text;
            string email = textBox5.Text;
            string bloodType = comboBox1.SelectedItem.ToString();
            string pictureName = Path.GetFileName(pictureBox1.ImageLocation);
            string fileOfDonors = Path.GetFullPath(@"..\..\Resources\File of Donors.txt");

            if (File.Exists(fileOfDonors))
            {
                using (StreamWriter writer = File.AppendText(fileOfDonors))
                {
                    writer.WriteLine(IdOfDonor + ";" + name + ";" + surname + ";"
                        + socialId + ";" + phoneNumber + ";" + email + ";" + bloodType
                        + ";" + timeToSave2 + "/" + timeToSave1 + ";" + pictureName);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(fileOfDonors))
                {
                    writer.WriteLine(IdOfDonor + ";" + name + ";" + surname + ";"
                        + socialId + ";" + phoneNumber + ";" + email + ";" + bloodType
                        + ";" + timeToSave2 + "/" + timeToSave1 + ";" + pictureName);
                }
            }

            MessageBox.Show("Data saved successfully.");
    
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            string relativePath = @"..\..\Resources\default1.jpg";

            string imagePath = Path.GetFullPath(relativePath);

            pictureBox1.Image = Image.FromFile(imagePath);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
