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

namespace ReadMapp
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            foreach (var kitap in kitapps.Kaydettiklerim)
            {
                listBox1.Items.Add($"{kitap.KitapIsmi} - {kitap.Yazar} - {kitap.SayfaSayisi} - {kitap.Tur}");
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
