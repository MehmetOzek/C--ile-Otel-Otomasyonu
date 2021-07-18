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
    public partial class UrunEkleme : Form
    {
        public UrunEkleme()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3C0HC8S\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            Kategori kategori = new Kategori();
            kategori.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Marka marka = new Marka();
            marka.ShowDialog();
        }

        bool durum;
        private void UrunNoKontrol()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Mutfak", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox1.Text==read["UrunNo"].ToString()||textBox1.Text=="")
                {
                    durum = false;

                }
            }
            baglanti.Close();
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
        private void Mutfak_Load(object sender, EventArgs e)
        {
            KategoriGetir();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Marka where Kategori='"+comboBox1.SelectedItem+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox2.Items.Add(read["Marka"].ToString());

            }
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UrunNoKontrol();
            if(durum == true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Mutfak(UrunNo, Kategori, Marka, UrunAdi, Miktari, AlisFiyati,Tarih) values(@UrunNo, @Kategori, @Marka, @UrunAdi, @Miktari, @AlisFiyati, @Tarih)", baglanti);
                komut.Parameters.AddWithValue("@UrunNo", textBox1.Text);
                komut.Parameters.AddWithValue("@Kategori", comboBox1.Text);
                komut.Parameters.AddWithValue("@Marka", comboBox2.Text);
                komut.Parameters.AddWithValue("@UrunAdi", textBox2.Text);
                komut.Parameters.AddWithValue("@Miktari", int.Parse(textBox3.Text));
                komut.Parameters.AddWithValue("@AlisFiyati", double.Parse(textBox4.Text));
                komut.Parameters.AddWithValue("@Tarih", DateTime.Now.ToString("yyyy-MM-dd"));
                komut.ExecuteNonQuery(); 
                baglanti.Close();
                MessageBox.Show("İşlem Barıyla Tamamlandı");
            }
            else
            {
                MessageBox.Show("Böyle Bir Ürün Numarası Var", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
            comboBox2.Items.Clear();
            foreach(Control item in groupBox1.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";

                }
                else if(item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                lblMiktari.Text = "";
                foreach (Control item in groupBox2.Controls)
                {
                    if(item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }


            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Mutfak where UrunNo like '" + textBox5.Text + "'",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox6.Text = read["Kategori"].ToString();
                textBox7.Text = read["Marka"].ToString();
                textBox8.Text = read["UrunAdi"].ToString();
                lblMiktari.Text = read["Miktari"].ToString();
                textBox10.Text = read["AlisFiyati"].ToString();

            }
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Mutfak set Miktari=Miktari+'"+int.Parse(textBox9.Text)+"' where UrunNo='"+textBox5.Text+"'",baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            MessageBox.Show("işlem Başarıyla TAmamlandı");

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
