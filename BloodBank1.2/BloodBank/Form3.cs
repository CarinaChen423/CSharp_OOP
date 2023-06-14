using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBank
{
    public partial class Form3 : Form
    {
        private List<string[]> donorData;
        private int currentIndex;

        public Form3()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            donorData = Donor.GetAllDonors();

            if (donorData.Count > 0)
            {
                currentIndex = 0;
                DisplayDonorData(currentIndex);
                UpdateIndexLabel();
            }
            else
            {
                DisableNavigationButtons();
            }
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                DisplayDonorData(currentIndex);
                buttonRight.Enabled = true;
                UpdateIndexLabel();
            }

            if (currentIndex == 0)
            {
                buttonLeft.Enabled = false;
            }
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (currentIndex < donorData.Count - 1)
            {
                currentIndex++;
                DisplayDonorData(currentIndex);
                buttonLeft.Enabled = true;
                UpdateIndexLabel();
            }

            if (currentIndex == donorData.Count - 1)
            {
                buttonRight.Enabled = false;
            }
        }
        
        private void DisplayDonorData(int index)
        {
            string[] data = donorData[index];
            if (data.Length >= 9)
            {
                labelUniqID.Text = data[0];
                labelName.Text = data[1];
                labelSurName.Text = data[2];
                labelSocialID.Text = data[3];
                labelPhone.Text = data[4];
                labelEmail.Text = data[5];
                labelBlood.Text = data[6];
                labelDateTime.Text = data[7];

                string imagePath = Path.Combine(@"..\..\Resources\", data[8]);

                if (File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(@"..\..\Resources\default1.jpg");
                }
            }
        }


        private void DisableNavigationButtons()
        {
            buttonLeft.Enabled = false;
            buttonRight.Enabled = false;
        }

        private void UpdateIndexLabel()
        {
            int totalDonors = donorData.Count;
            int currentDonor = currentIndex + 1;
            label18.Text = $"{currentDonor} of {totalDonors}";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DialogResult deleteResult = MessageBox.Show("Are you sure you want to delete this donor?", "Delete Donor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (deleteResult == DialogResult.Yes)
            {
               Donor.RemoveDonor(currentIndex);
                donorData = Donor.GetAllDonors();

                if (donorData.Count > 0)
                {
                    if (currentIndex >= donorData.Count)
                    {
                        currentIndex = donorData.Count - 1;
                    }
                    DisplayDonorData(currentIndex);
                    UpdateIndexLabel();
                }
                else
                {
                    ClearDonorData();
                    DisableNavigationButtons();
                }

                DialogResult viewResult = MessageBox.Show("Do you want to view the file?", "View File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (viewResult == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(DataStorage.fileOfDonors);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to open the file: " + ex.Message);
                    }
                }
            }
        }
        private void ClearDonorData()
        {
            labelUniqID.Text = "";
            labelName.Text = "";
            labelSurName.Text = "";
            labelSocialID.Text = "";
            labelPhone.Text = "";
            labelEmail.Text = "";
            labelBlood.Text = "";
            labelDateTime.Text = "";
            pictureBox1.Image = null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}