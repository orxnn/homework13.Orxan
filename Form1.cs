using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace homework13.Orxan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int xal = 0;
        int bombaIndex = 0;
        Random rnd = new Random();
        PictureBox[] qutular;

        private void Form1_Load(object sender, EventArgs e)
        {

            qutular = new PictureBox[] { pictureBox1, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11 };


            foreach (var qutu in qutular)
            {
                qutu.Click += Qutu_Click;
            }

            YeniOyunBaslat();
        }

        private void YeniOyunBaslat()
        {
            xal = 0;
            label1.Text = "Xal: " + xal;


            bombaIndex = rnd.Next(0, 6);


            foreach (var qutu in qutular)
            {
                qutu.ImageLocation = @"C:\Users\USER\OneDrive\Bilder\Screenshots\Ekran şəkli 2026-11-05 213751.png"; 
                qutu.Enabled = true;
            }
        }

        private void Qutu_Click(object sender, EventArgs e)
        {
            PictureBox secilenQutu = (PictureBox)sender;
            int indeks = Array.IndexOf(qutular, secilenQutu);


            if (indeks == bombaIndex)
            {
                secilenQutu.ImageLocation = @"C:\Users\USER\Downloads\bomba.png";
                SystemSounds.Hand.Play(); 


                foreach (var qutu in qutular) qutu.Enabled = false;

                MessageBox.Show("Oyun bitdi", "Məğlubiyyət", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                secilenQutu.ImageLocation = @"C:\Users\USER\Downloads\cat.png"; 
                secilenQutu.Enabled = false; 

                xal++;
                label1.Text = "Xal: " + xal;


                if (xal == 5)
                {

                    foreach (var qutu in qutular) qutu.Enabled = false;

                    DialogResult dr = MessageBox.Show("Oyunu qazandınız, Yeni oyun üçün ok düyməsinə basın", "Təbriklər", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (dr == DialogResult.OK)
                    {
                        YeniOyunBaslat(); 
                    }
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            YeniOyunBaslat();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Oyundan çıxış edilsinmi?", "Sual", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}