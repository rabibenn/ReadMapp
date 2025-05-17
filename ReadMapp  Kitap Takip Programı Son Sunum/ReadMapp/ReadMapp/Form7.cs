using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace ReadMapp
{
    public partial class Form7 : Form
    {
        public static class kitapps
        {
            public static List<Book> Kaydettiklerim = new List<Book>();
            public static List<Book> Favorilerim = new List<Book>();
            public static List<Book> Okuduklarim = new List<Book>();
        }

        public class Book
        {
            public string KitapIsmi { get; set; }
            public string Yazar { get; set; }
            public string SayfaSayisi { get; set; }
            public string Tur { get; set; }
            public string Gorus { get; set; }

            public Book(string kitapismi, string yazar, string sayfasayisi, string tur, string gorus)
            {
                KitapIsmi = kitapismi;
                Yazar = yazar;
                SayfaSayisi = sayfasayisi;
                Tur = tur;
                Gorus = gorus;
            }
        }
        public Form7()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            string[] liste = { "Kaydettiklerim", "Favorilerim", "Okuduklarım" };
            comboBox1.Items.AddRange(liste);
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            string kitapismi = textBox1.Text;
            string yazar = textBox2.Text;
            string sayfasayisi = textBox3.Text;
            string tur = textBox4.Text;
            string gorus = textBox5.Text;

            // Kullanıcı adını dinamik alalım
            string kullaniciAdi = Session.AktifKullaniciAdi; // Örnek: Ayşe

            // Dosya adı kullanıcının adıyla oluşturulacak
            string dosyaFavoriler = $"{kullaniciAdi}_Favorilerim.txt";
            string dosyaOkuduklarim = $"{kullaniciAdi}_Okuduklarim.txt";
            string dosyaKaydettiklerim = $"{kullaniciAdi}_Kaydettiklerim.txt";

            // Kitap nesnesi oluşturuluyor
            Book yeniKitap = new Book(kitapismi, yazar, sayfasayisi, tur, gorus);

            // Seçilen kategoriye göre dosyaya yazma işlemi
            if (comboBox1.SelectedItem.ToString() == "Favorilerim")
            {
                File.AppendAllText(dosyaFavoriler, $"Favorilerim;{kitapismi};{yazar};{sayfasayisi};{tur};{gorus}\n");
            }
            else if (comboBox1.SelectedItem.ToString() == "Okuduklarım")
            {
                File.AppendAllText(dosyaOkuduklarim, $"Okuduklarım;{kitapismi};{yazar};{sayfasayisi};{tur};{gorus}\n");
            }
            else if (comboBox1.SelectedItem.ToString() == "Kaydettiklerim")
            {
                File.AppendAllText(dosyaKaydettiklerim, $"Kaydettiklerim;{kitapismi};{yazar};{sayfasayisi};{tur};{gorus}\n");
            }

            // Kullanıcıya başarı mesajı göster
            label6.Text = "Başarıyla Kaydedildi.";

            SaveBooksToFile();
        }

        // Kitapları dosyaya kaydetme işlemi
        private void SaveBooksToFile()
        {
            string filePath = "kitaplar.txt";
            List<string> allBooks = new List<string>();

            // Kaydettiklerim, Favorilerim ve Okuduklarım kategorilerindeki kitapları dosyaya yazıyoruz
            foreach (var kitap in kitapps.Kaydettiklerim)
                allBooks.Add($"Kaydettiklerim;{kitap.KitapIsmi};{kitap.Yazar};{kitap.SayfaSayisi};{kitap.Tur};{kitap.Gorus}");
            foreach (var kitap in kitapps.Favorilerim)
                allBooks.Add($"Favorilerim;{kitap.KitapIsmi};{kitap.Yazar};{kitap.SayfaSayisi};{kitap.Tur};{kitap.Gorus}");
            foreach (var kitap in kitapps.Okuduklarim)
                allBooks.Add($"Okuduklarım;{kitap.KitapIsmi};{kitap.Yazar};{kitap.SayfaSayisi};{kitap.Tur};{kitap.Gorus}");

            // Dosyaya yazıyoruz
            File.WriteAllLines(filePath, allBooks);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            secimekrani secimekrani = new secimekrani();
            secimekrani.Show();
            this.Hide();
        }

        private void kaydettiklerim_Click(object sender, EventArgs e)
        {

        }
    }
}
