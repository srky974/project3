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
    public partial class frmsalonekle : Form
    {
        public frmsalonekle()
        {
            InitializeComponent();
        }

        private void frmsalonekle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.ShowDialog();
        }
        sinemaTableAdapters.salonBilgileriTableAdapter salon = new sinemaTableAdapters.salonBilgileriTableAdapter();
        private void btnekle_Click(object sender, EventArgs e)
        {
            try
            {
                salon.salonekleme(txtsalonadi.Text);
                MessageBox.Show("salon eklendi", "kayit");
            }
            catch (Exception )
            {
                MessageBox.Show("Aynı salonu daha önce eklediz!","Uyarı");
            }
            txtsalonadi.Text = "";
        }
    }
}
