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

        private void kitapOnerisiYap()
        {
            string filePath = "advice.txt"; // Dosya yolu

            try
            {
                if (File.Exists(filePath))
                {
                    // Dosyadaki tüm satırları oku
                    string[] kitaplar = File.ReadAllLines(filePath);

                    // Kitaplar listesinden rastgele bir kitap seç
                    Random random = new Random();
                    int index = random.Next(kitaplar.Length); // Rastgele bir indeks seç

                    string selectedBook = kitaplar[index];
                    string[] kitapBilgileri = selectedBook.Split(',');

                    // Seçilen kitabın bilgilerini kullanıcıya göster
                    label2.Text = $"Kitap: {kitapBilgileri[0]}\n" +
                      $"Yazar: {kitapBilgileri[1]}\n" +
                      $"Tür: {kitapBilgileri[2]}\n" +
                      $"Açıklama: {kitapBilgileri[3]}";
                }
                else
                {
                    MessageBox.Show("Kitap önerileri dosyası bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }
    

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            secimekrani secimekrani = new secimekrani();
            secimekrani.Show();
            this.Hide();
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            kitapOnerisiYap();
        }
    }
}
