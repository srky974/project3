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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ALFA-BILGISAYAR;Initial Catalog=SinemaBileti;Integrated Security=True;MultipleActiveResultSets=true");
        private void btnsalonekle_Click(object sender, EventArgs e)
        {
            frmsalonekle ekle = new frmsalonekle();
            ekle.ShowDialog();

        }

        private void btnfilmekle_Click(object sender, EventArgs e)
        {
            frmfilmekle ekle = new frmfilmekle();
            ekle.ShowDialog();
        }

        private void btnseansekle_Click(object sender, EventArgs e)
        {
            frmseansekle ekle = new frmseansekle();
            ekle.ShowDialog();
        }

        private void btnseanslistele_Click(object sender, EventArgs e)
        {
            frmseanlistele ekle = new frmseanlistele();
            ekle.ShowDialog();
        }

        private void btnsatislar_Click(object sender, EventArgs e)
        {
            frmsatislar ekle = new frmsatislar();
            ekle.ShowDialog();
        }

        int sayac = 0;
        private void filmvesalongetir(ComboBox combo, string sql1, string sql2)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(sql1, baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                combo.Items.Add(read[sql2].ToString());
            }
            baglanti.Close();
        }
        private void filmafisiGoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from filmBilgileri where filmad='" + combofilmadi.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                pictureBox1.ImageLocation = read["resim"].ToString();
            }
            baglanti.Close();
        }
        private void veritabaniDolukoltuklar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from satisBilgileri where filmadi='" + combofilmadi.SelectedItem + "'  and salonadi='" + combosalonadi.Text + "' and tarih='" + combofilmtarih.SelectedItem + "' and saat='" + combofilmseans.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item in panel2.Controls)
                {
                    if (item is Button)
                    {
                        if (read["koltukno"].ToString()==item.Text)
                        {
                            item.BackColor = Color.Red;
                        }
                        
                    }
                }
            }
            baglanti.Close();

        }
        private void yenidenRenklendir()
        {
            foreach (Control item in panel1.Controls)
            {
                if (item is Button)
                {
                    item.BackColor = Color.White;
                }
            }
        }
        private void combodoluKoltuklar()
        {
            combokoltukno.Items.Clear();
            combokoltukno.Text = "";
            foreach (Control item in panel2.Controls)
            {
                if (item is Button)
                {
                    if (item.BackColor == Color.Red)
                    {
                        combokoltukno.Items.Add(item.Text);

                    }
                }

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bosKoltuklar();
            filmvesalongetir(combofilmadi, "select *from filmBilgileri", "filmad");
            filmvesalongetir(combosalonadi, "select *from salonBilgileri", "salonad");


        }

        private void bosKoltuklar()
        {
            sayac = 1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(30, 30);
                    btn.BackColor = Color.White;
                    btn.Location = new Point(j * 30 + 20, i * 30 + 30);
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    if (j == 4)
                    {
                        continue;
                    }
                    sayac++;
                    this.panel2.Controls.Add(btn);
                    btn.Click += Btn_Click;

                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.BackColor == Color.White)
            {
                txtkoltukno.Text = b.Text;
                
            }
        }



        private void combofilmadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            combofilmseans.Items.Clear();
            combofilmtarih.Items.Clear();
            combofilmseans.Text = "";
            combofilmtarih.Text = "";
            combosalonadi.Text = "";
            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            filmafisiGoster();
            yenidenRenklendir();
            combodoluKoltuklar();
        }
        sinemaTableAdapters.SatisBilgileriTableAdapter satis = new sinemaTableAdapters.SatisBilgileriTableAdapter();

        private void btnbiletal_Click(object sender, EventArgs e)
        {
            if (txtkoltukno.Text!="")
            {
                try
                {
                    satis.satisyap(txtkoltukno.Text,combosalonadi.Text,combofilmadi.Text,combofilmtarih.Text,combofilmseans.Text,txtad.Text,txtsoyad.Text,comboucret.Text, DateTime.Now.ToString());
                    foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
                    yenidenRenklendir();
                    veritabaniDolukoltuklar();
                    combodoluKoltuklar();
                }
                catch (Exception hata)
                {

                    MessageBox.Show("hata oluştu"+hata.Message, "uyarı");
                }
               
            }
            else
            {
                MessageBox.Show("Koltuk secimi yapmadınız!", "uyarı");
            }
        }
        private void filmTarihiGetir()
        {
            combofilmtarih.Text = "";
            combofilmseans.Text = "";
            combofilmtarih.Items.Clear();
            combofilmseans.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from seansBilgileri where filmadi='" + combofilmadi.SelectedItem + "'and salonadi='" + combosalonadi.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                //combofilmtarih.Items.Add(read["Tarih"].ToString());

                if (DateTime.Parse(read["Tarih"].ToString()) >= DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    //combofilmtarih.Items.Add(read["Tarih"].ToString());
                    if (!combofilmtarih.Items.Contains(read["Tarih"].ToString()))
                    {
                        combofilmtarih.Items.Add(read["Tarih"].ToString());
                    }
                }
            }

            baglanti.Close();
        }

        private void combosalonadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            filmTarihiGetir();
        }
        private void filmseansigetir()
        {
            combofilmseans.Text = "";
            combofilmseans.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from seansBilgileri where filmadi='" + combofilmadi.SelectedItem + "'and salonadi='" + combosalonadi.SelectedItem + "' and tarih='" + combofilmtarih.SelectedItem + "' ", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {

                if (DateTime.Parse(read["tarih"].ToString()) == DateTime.Parse(DateTime.Now.ToShortDateString()))
                {
                    if (DateTime.Parse(read["sean"].ToString()) > DateTime.Parse(DateTime.Now.ToShortTimeString()))
                    {
                        combofilmseans.Items.Add(read["sean"].ToString());
                    }

                }
                else if (DateTime.Parse(read["tarih"].ToString()) > DateTime.Parse(DateTime.Now.ToShortDateString()))
                {

                    combofilmseans.Items.Add(read["sean"].ToString());

                }
            }
            baglanti.Close();
        }

        private void combofilmtarih_SelectedIndexChanged(object sender, EventArgs e)
        {
            filmseansigetir();
        }

        private void combofilmseans_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            yenidenRenklendir();
            veritabaniDolukoltuklar();
            combodoluKoltuklar();
        }

        private void btnbiletiptal_Click(object sender, EventArgs e)
        {
            if (combokoltukno.Text!="")
            {
                try
                {
                    satis.Satisiptal(combofilmadi.Text, combosalonadi.Text, combofilmtarih.Text, combofilmseans.Text, combokoltukno.Text);
                    yenidenRenklendir();
                    veritabaniDolukoltuklar();
                    combodoluKoltuklar();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("hata olustu"+hata.Message, "uyarı");

                }
            
            }
            else
            {
                MessageBox.Show("koltuk secimi yapmadınız!", "uyarı");
            }
        }
    }
}


