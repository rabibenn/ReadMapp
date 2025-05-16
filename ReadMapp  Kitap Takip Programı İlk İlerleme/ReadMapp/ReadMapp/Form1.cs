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

namespace ReadMapp
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }

        private void Giriş_Click(object sender, EventArgs e)
        {
            string girkullaniciadi = textBox1.Text;
            string girsifre = sifregiris.Text;

            if (Person.kayitlikullanici == null)
            {
                label8.Text = "Lütfen önce hesap oluşturun!"; 
                return;
            }

            if (textBox1.Text == Person.kayitlikullanici.KullaniciAdi && sifregiris.Text == Person.kayitlikullanici.Sifre)
            {
                label8.Text = "Giriş başarılı!";  
            }
            else if (textBox1.Text != Person.kayitlikullanici.KullaniciAdi && sifregiris.Text == Person.kayitlikullanici.Sifre)
            {
                label8.Text = "Kullanıcı adınız hatalı.";
            }
            else if (textBox1.Text == Person.kayitlikullanici.KullaniciAdi && sifregiris.Text != Person.kayitlikullanici.Sifre)
            {
                label8.Text = "Şifreniz Hatalı";
            }
            else
            {
                label8.Text = " Hatalı kullanıcı adı veya şifre.";
            }


            secimekrani secimekrani = new secimekrani();
            secimekrani.Show();
            this.Hide();
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
