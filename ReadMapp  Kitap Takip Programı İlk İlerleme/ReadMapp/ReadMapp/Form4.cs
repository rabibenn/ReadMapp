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
    public partial class favorilerim : Form
    {
        public favorilerim()
        {
            InitializeComponent();
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
            foreach (var kitap in kitapps.Favorilerim)
            {
                listBox1.Items.Add($"{kitap.KitapIsmi} - {kitap.Yazar} - {kitap.SayfaSayisi} - {kitap.Tur}");
            }
        }
    }
}
