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
    public partial class frmseanlistele : Form
    {
        public frmseanlistele()
        {
            InitializeComponent();
        }


        SqlConnection baglanti = new SqlConnection("Data Source=ALFA-BILGISAYAR;Initial Catalog=SinemaBileti;Integrated Security=True;MultipleActiveResultSets=true");
        DataTable tablo = new DataTable();
        private void seanslistesi(string sql)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter(sql, baglanti);
                adtr.Fill(tablo);
                dataGridView1.DataSource = tablo;

            }
            else {
                baglanti.Close();
            }

        }
        private void frmseanlistele_Load(object sender, EventArgs e)
        {
            tablo.Clear();
            string sorgu = "select * from seansBilgileri where tarih '" + dateTimePicker1.Text + "'";
            seanslistesi(sorgu);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            tablo.Clear();
            string sorgu = "select * from seansBilgileri where tarih '" + dateTimePicker1.Text + "'";
            seanslistesi(sorgu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from seansBilgileri";
            seanslistesi(sorgu);
        }
    }
}
