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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            // Kullanıcı adı dinamik alınır
            string kullaniciAdi = Session.AktifKullaniciAdi; // Örnek: Ayşe

            // Okuduklarım dosyasının yolu
            string dosyaOkuduklarim = $"{kullaniciAdi}_Okuduklarim.txt";

            // Okuduklarım dosyasını yükleyelim
            LoadBooksToListBox(dosyaOkuduklarim, "Okuduklarım");
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
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            secimekrani secimekrani = new secimekrani();
            secimekrani.Show();
            this.Hide();
        }
    }
}
