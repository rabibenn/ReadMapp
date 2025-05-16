using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.IO;

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
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private async void kayitol2_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string kullaniciadi = textBox2.Text.Trim();
            string sifre = textBox3.Text;
            string sifredogrula = textBox4.Text;
            string dogumtarihi = dateTimePicker1.Value.ToString("dd.MM.yyyy");
            int yas = DateTime.Now.Year - dateTimePicker1.Value.Year;

            string cinsiyet = "";
            if (kadin.Checked)
                cinsiyet = "Kadın";
            else if (erkek.Checked)
                cinsiyet = "Erkek";
            else if (radioButton3.Checked)
                cinsiyet = "Belirtmek istemiyorum";

            // --- Giriş Doğrulamaları ---
            if (string.IsNullOrWhiteSpace(kullaniciadi) || string.IsNullOrWhiteSpace(sifre) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(sifredogrula))
            {
                label9.Text = "Lütfen tüm alanları doldurun.";
                return;
            }

            if (!IsValidEmail(email))
            {
                label9.Text = "Geçerli bir e-posta adresi girin.";
                return;
            }

            if (sifre != sifredogrula)
            {
                label9.Text = "Şifreler uyuşmuyor!";
                return;
            }

            if (!kadin.Checked && !erkek.Checked && !radioButton3.Checked)
            {
                label9.Text = "Lütfen bir cinsiyet seçin!";
                return;
            }

            if (yas < 1)
            {
                label9.Text = "Lütfen geçerli bir doğum tarihi seçiniz!";
                return;
            }

            // --- Dosyaya Yaz ---
            string userLine = $"{kullaniciadi};{sifre};{email};{dogumtarihi};{cinsiyet}";
            File.AppendAllText("users.txt", userLine + Environment.NewLine);

            // --- Başarılı Kayıt ---
            label9.Text = "";
            label8.Text = "Kayıt Başarılı...";
            Person.kayitlikullanici = new Person(email, kullaniciadi, sifre, sifredogrula, dogumtarihi);

            await Task.Delay(2000);
            this.Close();
        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}
