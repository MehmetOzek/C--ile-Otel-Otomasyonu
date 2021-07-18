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
    public partial class UrunListeleme : Form
    {
        public UrunListeleme()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3C0HC8S\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");
        DataSet daset = new DataSet();


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


        private void UrunListeleme_Load(object sender, EventArgs e)
        {
            UrunListele();
            KategoriGetir();
        }

        private void UrunListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Mutfak", baglanti);
            adtr.Fill(daset, "Mutfak");
            dataGridView1.DataSource = daset.Tables["Mutfak"];
            baglanti.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["UrunNo"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Kategori"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Marka"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["UrunAdi"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["Miktari"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["AlisFiyati"].Value.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Mutfak set UrunAdi=@UrunAdi, Miktari=@Miktari, AlisFiyati=@AlisFiyati where UrunNo=@UrunNo", baglanti);
            komut.Parameters.AddWithValue("@UrunNo", textBox1.Text);
            komut.Parameters.AddWithValue("@UrunAdi", textBox4.Text);
            komut.Parameters.AddWithValue("@Miktari",int.Parse(textBox5.Text));
            komut.Parameters.AddWithValue("@AlisFiyati", double.Parse(textBox6.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            
            MessageBox.Show("Güncelleme Başarıyla Gerçekleştirildi");
            daset.Tables["Mutfak"].Clear();
            UrunListele();
            foreach (Control item in this.Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("update Mutfak set Kategori=@Kategori, Marka=@Marka  where UrunNo=@UrunNo", baglanti);
                komut.Parameters.AddWithValue("@UrunNo", textBox1.Text);
                komut.Parameters.AddWithValue("@Kategori", comboBox1.Text);
                komut.Parameters.AddWithValue("@Marka", comboBox2.Text);

                komut.ExecuteNonQuery();
                baglanti.Close();
                
                MessageBox.Show("Güncelleme Başarıyla Gerçekleştirildi");
                daset.Tables["Mutfak"].Clear();
                UrunListele();
            }
            else
            {
                MessageBox.Show("Ürün Numarasını Girmediniz");
            }

            foreach (Control item in this.Controls)
            {
                if (item is ComboBox)
                {
                    item.Text = "";
                }
                else if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Marka where Kategori='" + comboBox1.SelectedItem + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboBox2.Items.Add(read["Marka"].ToString());

            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Mutfak where UrunNo='" + dataGridView1.CurrentRow.Cells["UrunNo"].Value.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            daset.Tables["Mutfak"].Clear();
            UrunListele();
            MessageBox.Show("Silme İşlmi Başarıyla Geçekleştirildi");
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Mutfak where UrunNo like '%" + textBox7.Text+ "%'",baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
