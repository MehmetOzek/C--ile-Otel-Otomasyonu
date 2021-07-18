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
    public partial class Marka : Form
    {
        public Marka()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3C0HC8S\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");

        bool durum;
        private void MarkaEngelle()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Marka", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (comboBox1.Text == read["Kategori"].ToString() && textBox1.Text == read["Marka"].ToString() || comboBox1.Text==""|| textBox1.Text == "")
                {
                    durum = false;

                }
            }
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MarkaEngelle();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Marka(Kategori,Marka) values('" + comboBox1.Text + "','" + textBox1.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Marka Eklendi");
            }
            else
            {
                MessageBox.Show("Böyle Bir Marka Veya Kategori Var", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            comboBox1.Text = "";
            textBox1.Text = "";
           

        }
        
        private void Marka_Load(object sender, EventArgs e)
        {
            KategoriGetir();
        }

        private void KategoriGetir()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Kategori", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["Kategori"].ToString());

            }
            baglanti.Close();
        }
    }
}
