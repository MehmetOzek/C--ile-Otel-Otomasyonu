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

namespace Tasarim4.Fromss
{
    public partial class OdaBireysel : Form
    {
        public OdaBireysel()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3C0HC8S\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");

        private void OdaBireysel_Load(object sender, EventArgs e)
        {
            OdaGetir();
            BosOdalar();
            DoluOdalar();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Table_1", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item in Controls)
                {
                    if (item is Button)
                    {
                        if (item.Text == read["odano"].ToString())
                        {
                            item.Text = read["tc"].ToString();
                        }
                    }
                }

            }




            baglanti.Close();

        }
        private void OdaGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from odadurumu2", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["odano"].ToString());

            }
            baglanti.Close();
        }

        private void DoluOdalar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from odadurumu2", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                foreach (Control item in Controls)
                {
                    if (item is Button)
                    {
                        if (item.Text == read["odano"].ToString() && read["durumu"].ToString() == "DOLU")
                        {
                            item.BackColor = Color.Red;
                        }
                    }
                }

            }
            baglanti.Close();
        }

        private void BosOdalar()
        {
            int sayac = 1;

            foreach (Control item in Controls)
            {
                if (item is Button)
                {
                    item.Text = "B-" + sayac;
                    item.Name = "B-" + sayac;
                    sayac++;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {

                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }


            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from odadurumu2 where odano like '" + comboBox1.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["cephe"].ToString();
                textBox2.Text = read["banyosayisi"].ToString();
                textBox3.Text = read["yataksayisi"].ToString();
                textBox4.Text = read["odatipi"].ToString();


            }
            baglanti.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("update odadurumu2 set cephe='" + textBox1.Text + "', banyosayisi='" + textBox2.Text + "',yataksayisi='" + textBox3.Text + "',odatipi='" + textBox4.Text + "'where odano='" + comboBox1.SelectedItem + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Güncellendi");
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";

                }
                else if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }
    }
}
