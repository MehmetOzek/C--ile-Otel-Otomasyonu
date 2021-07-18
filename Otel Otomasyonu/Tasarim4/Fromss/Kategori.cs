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
    public partial class Kategori : Form
    {
        public Kategori()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3C0HC8S\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");
        bool durum;
        private void KategoriEngelle()
        {
            durum = true;
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Kategori", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox1.Text == read["Kategori"].ToString() || textBox1.Text =="")
                {
                    durum = false;

                }
            }
            baglanti.Close();
        }
        
        private void Kategori_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KategoriEngelle();
            if (durum == true)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into Kategori(Kategori) values('" + textBox1.Text + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                
                MessageBox.Show("Kategori Eklendi");
            }
            else
            {
                MessageBox.Show("Böyle Bir Kategori Var","UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            textBox1.Text = "";

        }
    }
}
