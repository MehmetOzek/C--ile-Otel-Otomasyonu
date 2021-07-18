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
    public partial class KayıtOl : Form
    {
        public KayıtOl()
        {
            InitializeComponent();
        }

        private void KayıtOl_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Temizle()
        {

            comboBox1.Text = "";
            foreach(Control item in Controls)
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
            k.KullaniciAdi = textBox1.Text;
            k.Sifre = textBox2.Text;
            k.AdiSoyadi = textBox4.Text;
            k.Soru = comboBox1.Text;
            k.Cevap = textBox5.Text;
            k.Aciklama = textBox6.Text;
            k.Tarih = DateTime.Now;
            if (textBox2.Text==textBox3.Text)
            {
                string sql = "insert into Kullanicilar values('" + k.KullaniciAdi + "','" + k.Sifre + "','" + k.AdiSoyadi + "','" + k.Soru + "','" + k.Cevap + "',@Tarih,'" + k.Aciklama + "')";
                SqlCommand komut = new SqlCommand();
                komut.Parameters.Add("@Tarih", SqlDbType.Date).Value = k.Tarih;
                Veritabani.ESG(komut, sql);
                MessageBox.Show("Yeni Kullanıcı Eklendi", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                this.Close(); 
            }
            else
            {
                MessageBox.Show("Şifreler Birbiriyle Uyuşmuyor", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

       
    }
}
