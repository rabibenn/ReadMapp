using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ReadMapp.Form7;
using System.IO;

namespace ReadMapp
{
    public partial class favorilerim : Form
    {
        public favorilerim()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            secimekrani secimekrani = new secimekrani();
            secimekrani.Show();
            this.Hide();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void favorilerim_Load(object sender, EventArgs e)
        {
            // Kullanıcı adı dinamik alınır
            string kullaniciAdi = Session.AktifKullaniciAdi; // Örnek: Ayşe

            // Kaydettiklerim dosyasının yolu
            string dosyaFavorilerim = $"{kullaniciAdi}_Favorilerim.txt";

            // Kaydettiklerim dosyasını yükleyelim
            LoadBooksToListBox(dosyaFavorilerim, "Favorilerim");
        }

        private void LoadBooksToListBox(string dosya, string kategori)
        {
            // Eğer dosya varsa, dosyayı oku
            if (File.Exists(dosya))
            {
                string[] satirlar = File.ReadAllLines(dosya);
                foreach (string satir in satirlar)
                {
                    // Kitap bilgilerini al
                    string[] bilgiler = satir.Split(';');
                    if (bilgiler.Length >= 6)
                    {
                        string kitapIsmi = bilgiler[1];
                        string yazar = bilgiler[2];
                        string sayfaSayisi = bilgiler[3];
                        string tur = bilgiler[4];
                        string gorus = bilgiler[5];

                        listBox1.Items.Add($"{kategori}: {kitapIsmi} - {yazar} - {sayfaSayisi} sayfa - {tur} - Görüşlerim: {gorus}");

                    }
                }
            }
        }
    }
}
