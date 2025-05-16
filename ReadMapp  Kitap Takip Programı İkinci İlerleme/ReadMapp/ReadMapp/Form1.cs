using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ReadMapp.Form2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace ReadMapp
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private async void Giriş_Click(object sender, EventArgs e)
        {
            string girilenKullanici = textBox1.Text.Trim();
            string girilenSifre = sifregiris.Text.Trim();

            if (!File.Exists("users.txt"))
            {
                label8.Text = "Kullanıcı verisi bulunamadı.";
                return;
            }

            string[] satirlar = File.ReadAllLines("users.txt");

            bool dogruMu = satirlar.Any(satir =>
            {
                string[] bilgiler = satir.Split(';');
                return bilgiler.Length >= 2 &&
                       bilgiler[0] == girilenKullanici &&
                       bilgiler[1] == girilenSifre;
            });

            if (dogruMu)
            {
                Session.AktifKullaniciAdi = girilenKullanici;
                label8.Text = "Giriş başarılı.";
                await Task.Delay(1000); // 1 saniye beklet

                secimekrani secimekrani = new secimekrani();
                secimekrani.Show();
                this.Hide();
            }
            else
            {
                label8.Text = "Hatalı kullanıcı adı veya şifre.";
            }

          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void kayit_Load(object sender, EventArgs e)
        {
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Kayıt Ekranına Yönlendiriliyorsunuz... ");
            Form2 kayitFormu = new Form2();
            kayitFormu.Show();
        }

        private void sifregiris_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
