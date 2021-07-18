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

namespace Tasarim4
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Temizle()
        {

            comboBox1.Text = "";
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            KullaniciClass k = new KullaniciClass();
            //k.KullaniciID = int.Parse(textBox1.Text);
            k.KullaniciAdi = textBox2.Text;
            k.Sifre = textBox3.Text;
            k.AdiSoyadi = textBox5.Text;
            k.Soru = comboBox1.Text;
            k.Cevap = textBox6.Text;
            k.Aciklama = textBox7.Text;
            k.Tarih = DateTime.Now;

            if (textBox3.Text==textBox4.Text)
            {
                string sql = "update Kullanicilar set  Sifre='" + k.Sifre + "', AdiSoyadi='" + k.AdiSoyadi + "', Soru='" + k.Soru + "', Cevap='" + k.Cevap + "', Tarih=@Tarih, Aciklama='" + k.Aciklama + "' where KullaniciAdi='" + k.KullaniciAdi + "' ";
                SqlCommand komut = new SqlCommand();
                komut.Parameters.Add("@Tarih", SqlDbType.Date).Value = k.Tarih;
                Veritabani.ESG(komut, sql);
                MessageBox.Show("Şifre BAşarıyla Güncellendi", "GÜNCELLEME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle(); 
            }
            else
            {
                MessageBox.Show("Şifreler Birbiriyle Uyuşmuyor", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void SifremiUnuttum_Load(object sender, EventArgs e)
        {

        }
    }
}
