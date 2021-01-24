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
    public partial class frmsatislar : Form
    {
        public frmsatislar()
        {
            InitializeComponent();
        }
        sinemaTableAdapters.SatisBilgileriTableAdapter satislistele = new sinemaTableAdapters.SatisBilgileriTableAdapter();
        private void frmsatislar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satislistele.satisbilgisi2();
            toplamucretHesapla();
        }
        //selamun aleykumm
        private void toplamucretHesapla()
        {
            int toplam = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                toplam += Convert.ToInt32(dataGridView1.Rows[i].Cells["ucret"].Value);
            }
            label1.Text = "toplam satis=" + toplam + "TL";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satislistele.satisbilgisi2();
            toplamucretHesapla();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = satislistele.tarihegoreListele2(dateTimePicker1.Text);
            toplamucretHesapla();
        }
    }
}
