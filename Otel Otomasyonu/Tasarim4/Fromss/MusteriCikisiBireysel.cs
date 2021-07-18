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
    public partial class MusteriCikisiBireysel : Form
    {
        public MusteriCikisiBireysel()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3C0HC8S\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");

        private void MusteriCikisiBireysel_Load(object sender, EventArgs e)
        {
            DoluYerler();
            //baglanti.Open();
            TcNumaralari();
        }



        private void TcNumaralari()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Table_1", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["tc"].ToString());

            }
            baglanti.Close();
        }

        private void DoluYerler()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from odadurumu2 where durumu= 'DOLU'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox2.Items.Add(read["odano"].ToString());

            }
            baglanti.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Table_1 where tc='" + comboBox1.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox1.Text = read["odano"].ToString();
            }
            baglanti.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Table_1 where odano='" + comboBox2.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox2.Text = read["odano"].ToString();
                textBox3.Text = read["ad"].ToString();
                textBox4.Text = read["soyad"].ToString();
                textBox5.Text = read["telefon"].ToString();
                //richTextBox1.Text = read["adres"].ToString();
                textBox6.Text = read["kisisayisi"].ToString();
                textBox7.Text = read["tc"].ToString();
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Table_1 where tc='" + textBox7.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand("update  odadurumu2 set durumu='BOŞ' where odano='" + textBox2.Text + "'", baglanti);
            komut2.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("MÜŞTERİ ÇIKIŞI YAPILDI");
            foreach (Control Item in groupBox2.Controls)
            {
                if (Item is TextBox)
                {
                    Item.Text = "";
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
                else if (Item is RichTextBox)
                {
                    Item.Text = "";

                }
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();


                DoluYerler();

                TcNumaralari();
            }
        }
    }

}
