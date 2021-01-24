using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project3
{
    public partial class frmfilmekle : Form
    {
        public frmfilmekle()
        {
            InitializeComponent();
        }
        // sinemaTableAdapters.filmBilgileriTableAdapter film = new sinemaTableAdapters.filmBilgileriTableAdapter();
        sinemaTableAdapters.filmBilgileriTableAdapter film = new sinemaTableAdapters.filmBilgileriTableAdapter();
        private void btnfilmekle_Click(object sender, EventArgs e)
        {
            try
            {
                // film.filmekleme(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text, pictureBox1.ImageLocation);
                film.filmekleme(textBox1.Text, textBox2.Text, comboBox1.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text, pictureBox1.ImageLocation);
                MessageBox.Show("film bilgileri eklendi", "kayit");
            }
            catch (Exception)
            {

                MessageBox.Show("Bu film daha önce eklendi!", "uyarı");
            }
            
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            comboBox1.Text = "";


           
        }

        private void btnafissec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;

        }
    }
}
