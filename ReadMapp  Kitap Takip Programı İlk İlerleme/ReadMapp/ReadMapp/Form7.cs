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

            public Book(string kitapismi, string yazar, string sayfasayisi, string tur)
            {
                KitapIsmi = kitapismi;
                Yazar = yazar;
                SayfaSayisi = sayfasayisi;
                Tur = tur;
            }
        }
        public Form7()
        {
            InitializeComponent();
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
            string liste = comboBox1.Text;

            Book yeniKitap = new Book(kitapismi, yazar, sayfasayisi, tur);

            switch (liste)
            {
                case "Kaydettiklerim":
                    kitapps.Kaydettiklerim.Add(yeniKitap);
                    break;
                case "Favorilerim":
                    kitapps.Favorilerim.Add(yeniKitap);
                    break;
                case "Okuduklarım":
                    kitapps.Okuduklarim.Add(yeniKitap);
                    break;
                default:
                    label6.Text = "Lütfen bir kategori seçin!";
                    return;
            }

            label6.Text = "Başarıyla Kaydedildi.";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            secimekrani secimekrani = new secimekrani();
            secimekrani.Show();
            this.Hide();
        }
    }
}
