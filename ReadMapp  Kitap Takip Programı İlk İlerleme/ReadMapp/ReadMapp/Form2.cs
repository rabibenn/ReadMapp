using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace ReadMapp
{
    public partial class Form2 : Form
    {
        public class Person
        {
            public string Email { get; set; }
            public string KullaniciAdi { get; set; }
            public string Sifre { get; set; }
            public string SifreDogrula { get; set; }
            public string DogumTarihi { get; set; }

            public Person(string email, string kullaniciadi, string sifre, string sifredogrula, string dogumtarihi)
            {
                Email = email;
                KullaniciAdi = kullaniciadi;
                Sifre = sifre;
                SifreDogrula = sifredogrula;
                DogumTarihi = dogumtarihi;
            }

            public static Person kayitlikullanici { get; set; }
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void kayitol2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string kullaniciadi = textBox2.Text;
            string sifre = textBox3.Text;
            string sifredogrula = textBox4.Text;
            string dogumtarihi = dateTimePicker1.Value.ToString("dd.MM.yyyy");

            int yas = DateTime.Now.Year - dateTimePicker1.Value.Year;

            if (sifre != sifredogrula)
            {
                label9.Text = "";
                label9.Text = "Şifreler uyuşmuyor!";
                return;
            }
            else if (email == "")
            {
                label9.Text = "";
                label9.Text = "Lütfen bir e-mail hesabı girin!";
            }
            else if (kullaniciadi == "")
            {
                label9.Text = "";
                label9.Text = "Lütfen bir kullanıcı adı girin!";
            }
            else if (sifre == "")
            {
                label9.Text = "";
                label9.Text = "Lütfen bir şifre girin!";
            }
            else if (sifredogrula == "")
            {
                label9.Text = "";
                label9.Text = "Lütfen şifrenizi tekrar girin!";
            }
            else if (!kadin.Checked && !erkek.Checked && !radioButton3.Checked)
            {
                label9.Text = "";
                label9.Text = "Lütfen bir cinsiyet seçin!";
            }
            else if (yas < 1)
            {
                label9.Text = "Lütfen geçerli bir doğum tarihi seçiniz!";
            }
            else
            {
                label9.Text = "";
                label8.Text = "Kayıt Başarılı...";
                await Task.Delay(2000);

                this.Close();
            }

            Person.kayitlikullanici = new Person(email, kullaniciadi, sifre, sifredogrula, dogumtarihi);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
