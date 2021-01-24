using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project3
{
    public partial class frmseansekle : Form
    {
        public frmseansekle()
        {
            InitializeComponent();
        }
        sinemaTableAdapters.seansBilgileriTableAdapter filmseansi = new sinemaTableAdapters.seansBilgileriTableAdapter();

        SqlConnection baglanti = new SqlConnection("Data Source=ALFA-BILGISAYAR;Initial Catalog=SinemaBileti;Integrated Security=True;MultipleActiveResultSets=true");
        private void frmseansekle_Load(object sender, EventArgs e)
        {
            filmSalonGoster(comboBox1, "select * from filmBilgileri", "filmad");

            filmSalonGoster(comboBox2, "select * from salonBilgileri", "salonad");
        }
        private void filmSalonGoster(ComboBox combo, string sql, string sql2)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sql, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read() == true)
            {
                combo.Items.Add(read[sql2].ToString());
            }
            baglanti.Close();
        }
        string seans = "";
        private void RadioButtonSeciliyse()
        {
            if (radioButton1.Checked == true) seans = radioButton1.Text;
            else if (radioButton2.Checked == true) seans = radioButton2.Text;
            else if (radioButton3.Checked == true) seans = radioButton3.Text;
            else if (radioButton4.Checked == true) seans = radioButton4.Text;
            else if (radioButton5.Checked == true) seans = radioButton5.Text;
            else if (radioButton6.Checked == true) seans = radioButton6.Text;
            else if (radioButton7.Checked == true) seans = radioButton7.Text;
            else if (radioButton8.Checked == true) seans = radioButton8.Text;
            else if (radioButton9.Checked == true) seans = radioButton9.Text;
            else if (radioButton10.Checked == true) seans = radioButton10.Text;
            else if (radioButton11.Checked == true) seans = radioButton11.Text;
            else if (radioButton12.Checked == true) seans = radioButton12.Text;

        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            RadioButtonSeciliyse();
            if (seans != "")
            {

                filmseansi.seansekleme(comboBox1.Text, comboBox2.Text, dateTimePicker1.Text, seans);
                MessageBox.Show("Seans ekleme işlemi yapildi", "kayıt");


            }
            else if (seans == "")
            {
                MessageBox.Show("Seans secimi yapmadınız!", "uyarı");
            }
            comboBox2.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            foreach (Control item3 in panel1.Controls)
            {
                item3.Enabled = true;
            }
            DateTime bugun = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime yeni = DateTime.Parse(dateTimePicker1.Text);
            if (yeni == bugun)
            {
                foreach (Control item in panel1.Controls)
                {
                    if (DateTime.Parse(DateTime.Now.ToShortTimeString()) > DateTime.Parse(item.Text))
                    {
                        item.Enabled = false;
                    }
                }
                tarihkarsilastir();

            }
            else if (yeni > bugun)
            {
                tarihkarsilastir();
            }
            else if (yeni < bugun)
            {
                MessageBox.Show("geriye dönük işlem yapılamaz", "uyarı");
                dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void tarihkarsilastir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from seansBilgileri where salonadi ='" + comboBox2.Text + "' and Tarih='" + dateTimePicker1.Text + "'", baglanti);

            SqlDataReader read = komut.ExecuteReader();
            while (read.Read()==true)
            {
                foreach (Control item2 in panel1.Controls)
                {
                    if (read["sean"].ToString()==item2.Text)
                    {
                        item2.Enabled = false;
                    }
                }
            }
            baglanti.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }
    }
}
