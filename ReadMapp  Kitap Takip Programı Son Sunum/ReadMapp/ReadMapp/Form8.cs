using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ReadMapp
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Aşk");
            comboBox1.Items.Add("Bilim Kurgu");
            comboBox1.Items.Add("Polisiye");
            comboBox1.Items.Add("Felsefe");
            comboBox1.Items.Add("Tarih");
            comboBox1.Items.Add("Macera");
            comboBox1.Items.Add("Fantastik");
            comboBox1.Items.Add("Kişisel Gelişim");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            secimekrani secimekrani = new secimekrani();
            secimekrani.Show();
            this.Hide();
        }

        private void ekle_Click(object sender, EventArgs e)
        {

            string secilenTur = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(secilenTur))
            {
                MessageBox.Show("Lütfen bir kitap türü seçiniz.");
                return;
            }

            Dictionary<string, string> turDosyalari = new Dictionary<string, string>()
            {
                { "Aşk", "ask.txt" },
                { "Bilim Kurgu", "bilimkurgu.txt" },
                { "Polisiye", "polisiye.txt" },
                { "Felsefe", "felsefe.txt" },
                { "Tarih", "tarih.txt" },
                { "Macera", "macera.txt" },
                { "Fantastik", "fantastik.txt" },
                { "Kişisel Gelişim", "kisiselgelisim.txt" }
            };

            if (!turDosyalari.ContainsKey(secilenTur))
            {
                label2.Text = "Bu türe ait dosya tanımlı değil.";
                return;
            }

            string dosyaYolu = Path.Combine("bookadvice", turDosyalari[secilenTur]);

            try
            {
                if (File.Exists(dosyaYolu))
                {
                    string[] kitaplar = File.ReadAllLines(dosyaYolu);

                    if (kitaplar.Length > 0)
                    {
                        Random rnd = new Random();
                        int index = rnd.Next(kitaplar.Length);

                        string kitapSatiri = kitaplar[index];
                        string[] kitapBilgileri = kitapSatiri.Split(',');

                        if (kitapBilgileri.Length >= 3)
                        {
                            label2.Text = $"Kitap: {kitapBilgileri[0].Trim()}\n" +
                                          $"Yazar: {kitapBilgileri[1].Trim()}\n" +
                                          $"Açıklama: {kitapBilgileri[2].Trim()}";
                        }
                        else
                        {
                            label2.Text = "Seçilen kitap bilgisi eksik.";
                        }
                    }
                    else
                    {
                        label2.Text = "Bu türe ait kitap bulunamadı.";
                    }
                }
                else
                {
                    MessageBox.Show($"{dosyaYolu} dosyası bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
