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
    public partial class PersonelEkleme : Form
    {
        public PersonelEkleme()
        {
            InitializeComponent();
        }

        private void PersonelEkleme_Load(object sender, EventArgs e)
        {
            PersonelEklemeClass.ComboyaDepartmanGetir(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Temizle()
        {
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.Text = "";
            foreach(Control item in Controls)
            {
                if(item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            PersonelEklemeClass p = new PersonelEklemeClass();
            p.Adi = textBox1.Text;
            p.Soyadi = textBox2.Text;
            p.Telefon = textBox3.Text;
            p.Adres = textBox4.Text;
            p.Email = textBox5.Text;
            p.DepartmanId = (int)comboBox1.SelectedValue;
            p.Maasi = decimal.Parse(textBox6.Text);
            p.GirisTarihi = dateTimePicker1.Value;
            p.Aciklama = textBox7.Text;
            string sorgu = "insert into PersonelEkleme(Adi,Soyadi,Telefon,Adres,Email,DepartmanId,Maasi,GirisTarihi,Aciklama)  values('" + p.Adi + "','" + p.Soyadi + "','" + p.Telefon + "','" + p.Adres + "','" + p.Email + "','" + p.DepartmanId + "',@Maasi,@GirisTarihi,'" + p.Aciklama + "')";
            SqlCommand komut = new SqlCommand();
            komut.Parameters.Add("@Maasi", SqlDbType.Decimal).Value = p.Maasi;
            komut.Parameters.Add("@GirisTarihi", SqlDbType.Date).Value = p.GirisTarihi;

            PersonelVeritbnn.ESG(komut, sorgu);
            Temizle();
            MessageBox.Show("İşlem Başarıyla Tamamlandı", "KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
