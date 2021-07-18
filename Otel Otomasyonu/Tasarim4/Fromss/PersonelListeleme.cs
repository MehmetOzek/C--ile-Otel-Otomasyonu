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
    public partial class PersonelListeleme : Form
    {
        public PersonelListeleme()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void Temizle()
        {
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.Text = "";
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PersonelListeleme_Load(object sender, EventArgs e)
        {
            PersonelEklemeClass.ComboyaDepartmanGetir(comboBox1);
            YenileListele();

        }

        private void YenileListele()
        {
            PersonelVeritbnn.Listele_Ara(dataGridView1, "select p.PersonelId, p.Adi, p.Soyadi, p.Telefon, p.Adres, p.Email," +
             "d.Departman, p.Durumu, p.Maasi, p.GirisTarihi, p.Aciklama from PersonelEkleme p, Departman d where  p.DepartmanId = d.DepartmanId");
            lblToplamKayıt.Text = "Toplam " + (dataGridView1.Rows.Count - 1) + " Kayıt Listelendi.";
            decimal toplammaas=0;
            for(int i=0; i<dataGridView1.Rows.Count-1; i++)
            {
                toplammaas += decimal.Parse(dataGridView1.Rows[i].Cells["Maasi"].Value.ToString());
            }
            lblToplamMaas.Text = "Toplam Maaş Tutarı=" + toplammaas.ToString("0.00") + "TL";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonelEklemeClass p = new PersonelEklemeClass();
            p.PersonelId = int.Parse(textBox12.Text);
            p.Adi = textBox5.Text;
            p.Soyadi = textBox6.Text;
            p.Telefon = textBox7.Text;
            p.Adres = textBox8.Text;
            p.Email = textBox9.Text;
            p.DepartmanId = (int)comboBox1.SelectedValue;
            p.Maasi = decimal.Parse(textBox10.Text);
            p.GirisTarihi = dateTimePicker1.Value;
            p.Aciklama = textBox11.Text;
            string sorgu = "update PersonelEkleme set Adi='"+p.Adi+ "',Soyadi='" + p.Soyadi + "',Telefon='" + p.Telefon + "',Adres='" + p.Adres + "',Email='" + p.Email + "',DepartmanId='" + p.DepartmanId + "', Maasi=@Maasi, GirisTarihi=@GirisTarihi, Aciklama='" + p.Aciklama + "'  where PersonelId='" + p.PersonelId + "'";

            SqlCommand komut = new SqlCommand();
            komut.Parameters.Add("@Maasi", SqlDbType.Decimal).Value = p.Maasi;
            komut.Parameters.Add("@GirisTarihi", SqlDbType.Date).Value = p.GirisTarihi;
            PersonelVeritbnn.ESG(komut, sorgu);
            Temizle();
            MessageBox.Show("İşlem Başarıyla Tamamlandı", "GÜNCELLEME", MessageBoxButtons.OK, MessageBoxIcon.Information);
            YenileListele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            PersonelEklemeClass p = new PersonelEklemeClass();
            p.PersonelId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());

            string sorgu2 = "update PersonelEkleme set durumu='Pasif' where PersonelId='" + p.PersonelId + "'";
            SqlCommand komut2 = new SqlCommand();
            PersonelVeritbnn.ESG(komut2, sorgu2);
            /*string sorgu = "delete from PersonelEkleme where PersonelId='" + p.PersonelId + "'";
            SqlCommand komut = new SqlCommand();
            PersonelVeritbn.ESG(komut, sorgu);*/
            Temizle();
            MessageBox.Show("İşlem Başarıyla Tamamlandı", "SİLME", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            YenileListele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox12.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
           
            dateTimePicker1.Value =DateTime.Parse(dataGridView1.CurrentRow.Cells[9].Value.ToString());
            textBox11.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            PersonelVeritbnn.Listele_Ara(dataGridView1, "select p.PersonelId, p.Adi, p.Soyadi, p.Telefon, p.Adres, p.Email," +
             "d.Departman, p.Durumu, p.Maasi, p.GirisTarihi, p.Aciklama from PersonelEkleme p, Departman d where  p.DepartmanId = d.DepartmanId and PersonelId like '%"+textBox1.Text+"%'");
        }

       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            PersonelVeritbnn.Listele_Ara(dataGridView1, "select p.PersonelId, p.Adi, p.Soyadi, p.Telefon, p.Adres, p.Email," +
             "d.Departman, p.Durumu, p.Maasi, p.GirisTarihi, p.Aciklama from PersonelEkleme p, Departman d where  p.DepartmanId = d.DepartmanId and Adi like '%" + textBox2.Text + "%'");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            PersonelVeritbnn.Listele_Ara(dataGridView1, "select p.PersonelId, p.Adi, p.Soyadi, p.Telefon, p.Adres, p.Email," +
             "d.Departman, p.Durumu, p.Maasi, p.GirisTarihi, p.Aciklama from PersonelEkleme p, Departman d where  p.DepartmanId = d.DepartmanId and Soyadi like '%" + textBox3.Text + "%'");
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            PersonelVeritbnn.Listele_Ara(dataGridView1, "select p.PersonelId, p.Adi, p.Soyadi, p.Telefon, p.Adres, p.Email," +
             "d.Departman, p.Durumu, p.Maasi, p.GirisTarihi, p.Aciklama from PersonelEkleme p, Departman d where  p.DepartmanId = d.DepartmanId and Telefon like '%" + textBox4.Text + "%'");
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            PersonelEklemeClass.TariheGoreAra(dateTimePicker2, dataGridView1);
        }
    }
}
