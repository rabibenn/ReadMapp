using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadMapp
{
    public partial class secimekrani : Form
    {
        public secimekrani()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void kitapekle_Click(object sender, EventArgs e)
        {
            Form7 kitapekle = new Form7();
            kitapekle.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void favori_Click(object sender, EventArgs e)
        {

        }

        private void favori_Click_1(object sender, EventArgs e)
        {
            favorilerim favorilerim = new favorilerim();
            favorilerim.Show();
            this.Hide();
        }

        private void kaydettiklerim_Click(object sender, EventArgs e)
        {
            Form5 kaydettiklerim = new Form5();
            kaydettiklerim.Show();
            this.Hide();
        }

        private void okuduklarim_Click(object sender, EventArgs e)
        {
            Form6 okuduklarim = new Form6();
            okuduklarim.Show();
            this.Hide();
        }

        private void neokusam_Click(object sender, EventArgs e)
        {
            Form8 neokusam = new Form8();
            neokusam.Show();
            this.Hide();
        }

        private void secimekrani_Load(object sender, EventArgs e)
        {
        }
    }
}
