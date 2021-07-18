using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tasarim4.Fromss
{
    public partial class Kurumsal : Form
    {
      
        public Kurumsal()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3C0HC8S\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");


        void listeleme()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "select * from mkurum";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "mkurum");
                dataGridView1.DataSource = ds.Tables["mkurum"];
                dataGridView1.Columns[0].Visible = false;
                baglanti.Close();
            }

        }

        private void NewMethod(SqlCommand cmd)
        {
            cmd.CommandText = "INSERT INTO Table_1(vergino, kurumisim, kurumturu, email, adres, kisisayisi, odano, giris, cikis, gunlukucret, fiyat) VALUES('" + maskedTextBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + richTextBox1.Text + "','" + textBox4.Text + "','" + comboxkurum.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker1.Text + "','" + textBox6.Text + "','" + textBox5.Text + "')";
        }

        private void Kurumsal_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            string Select = "select *from mkurum";
            SqlDataAdapter da = new SqlDataAdapter(Select, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
            BosOdalar();
            listeleme();
            
        }

        private void BosOdalar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from odadurumu WHERE durumu='BOŞ'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboxkurum.Items.Add(read["odano"].ToString());
            }
            baglanti.Close();
        }
       /* private void DoluOdalar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from odadurumu WHERE durumu='DOLU'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                comboxkurum.Items.Add(read["odano"].ToString());
            }
            baglanti.Close();
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into mkurum(vergino, kurumisim, kurumturu, email, adres, kisisayisi, odano, giris, cikis, gunlukucret, fiyat) values(@vergino, @kurumisim, @kurumturu, @email, @adres, @kisisayisi, @odano, @giris, @cikis, @gunlukucret, @fiyat)", baglanti);
            komut.Parameters.AddWithValue("@vergino", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@kurumisim", textBox1.Text);
            komut.Parameters.AddWithValue("@kurumturu", textBox2.Text);
            komut.Parameters.AddWithValue("@email", textBox3.Text);
            komut.Parameters.AddWithValue("@adres", richTextBox1.Text);
            komut.Parameters.AddWithValue("@kisisayisi", textBox4.Text);
            komut.Parameters.AddWithValue("@odano", comboxkurum.Text);
            komut.Parameters.AddWithValue("@giris", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@cikis", dateTimePicker2.Text);
            komut.Parameters.AddWithValue("@gunlukucret", textBox6.Text);
            komut.Parameters.AddWithValue("@fiyat", textBox5.Text);
            komut.ExecuteNonQuery();
            komut.Dispose();
            SqlCommand komut2 = new SqlCommand("update odadurumu set durumu='DOLU' where odano='" + comboxkurum.SelectedItem + "'", baglanti);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Yapıldı");

            comboxkurum.Items.Clear();
            BosOdalar();
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                else if(item is MaskedTextBox)
                {
                    item.Text = "";

                }
                else if(item is RichTextBox)
                {
                    item.Text = "";
                }
            }
            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                else if (item is DateTimePicker)
                {
                    item.Text = "";

                }

                else if (item is Label)
                {
                    item.Text = "";

                }
                else if (item is ComboBox)
                {
                    item.Text = "";

                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //baglanti.Open();

            if (MessageBox.Show("SİLMEK İSTEDİĞİNİZDEN EMİNMİSİNİZ", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "delete from mkurum where kurumId=@numara";
                    cmd.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    SqlCommand komut2 = new SqlCommand("update odadurumu set durumu='BOŞ' where odano='" + comboxkurum.SelectedItem + "'", baglanti);
                    komut2.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("BİLGİLER SİLİNDİ");
                    listeleme();
                   
                }
            }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["vergino"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["kurumisim"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["kurumturu"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
            richTextBox1.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["kisisayisi"].Value.ToString();
            comboxkurum.Text = dataGridView1.CurrentRow.Cells["odano"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["giris"].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells["cikis"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["gunlukucret"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["fiyat"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int gunFarki;  // farkı almak için oluşturduğumuz değişken
            int a;
            int f;
            if (dateTimePicker1.Value < dateTimePicker2.Value) // başlangıç tarihi bitişten küçükse…

            {

                TimeSpan tarihFarki = (dateTimePicker2.Value - dateTimePicker1.Value); // tarih farkını almak için bitişten başlangıcı çıkar

                gunFarki = tarihFarki.Days; // gün farkı olarak da tarih farkına günü yaz
                gunFarki++;
                label11.Text = gunFarki.ToString();
                int s = Convert.ToInt16(label11.Text);
                a = Convert.ToInt16(textBox6.Text);
                f= s * a;
                textBox5.Text = (f.ToString() + "TL");


            }

            else  // başlangıç tarihi bitişten büyükse…

            {

                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "update mkurum set vergino='" + maskedTextBox1.Text + "',kurumisim='" + textBox1.Text + "',kurumturu='" + textBox2.Text + "',email='" + textBox3.Text + "',adres='" + richTextBox1.Text + "',kisisayisi='" + textBox4.Text + "',odano='" + comboxkurum.Text + "',giris='" + dateTimePicker1.Text + "',cikis='" + dateTimePicker2.Text + "',gunlukucret='" + textBox6.Text + "',fiyat='" + textBox5.Text + "' where kurumId=@numara";
                cmd.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                listeleme();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MusteriCikisKurumsal frmcheckout = new MusteriCikisKurumsal();
            frmcheckout.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MiniBar frmMiniBar = new MiniBar();
            frmMiniBar.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font font = new Font("Arial", 14);
                SolidBrush firca = new SolidBrush(Color.Black);
                Pen kalem = new Pen(Color.Black);
                e.Graphics.DrawString($"Tarih={DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}", font, firca, 60, 25);


                font = new Font("Arial", 20, FontStyle.Bold);
                e.Graphics.DrawString("KURUMSAL MÜŞTERİ FATURASI", font, firca, 230, 75);
                e.Graphics.DrawLine(kalem, 50, 70, 780, 70);
                e.Graphics.DrawLine(kalem, 50, 110, 780, 110);
                e.Graphics.DrawLine(kalem, 50, 70, 50, 110);
                e.Graphics.DrawLine(kalem, 780, 70, 780, 110);

                e.Graphics.DrawString("***************************", font, firca, 320, 115);


                font = new Font("Arial", 15, FontStyle.Bold);
                e.Graphics.DrawString("Vergi Numarası:", font, firca, 50, 150);
                e.Graphics.DrawString("Kurum İsmi:", font, firca, 50, 200);
                e.Graphics.DrawString("Kurum Türü:", font, firca, 50, 250);
                e.Graphics.DrawString("Email:", font, firca, 50, 300);
                e.Graphics.DrawString("Adres:", font, firca, 50, 350);
                e.Graphics.DrawString("Günlük Ücret:", font, firca, 50, 450);
                //

                e.Graphics.DrawLine(kalem, 50, 140, 780, 140);
                e.Graphics.DrawLine(kalem, 50, 500, 50, 140);
                e.Graphics.DrawLine(kalem, 50, 500, 780, 500);
                e.Graphics.DrawLine(kalem, 780, 140, 780, 500);


                font = new Font("Arial", 15);
                e.Graphics.DrawString(maskedTextBox1.Text, font, firca, 215, 150);
                e.Graphics.DrawString(textBox1.Text, font, firca, 215, 200);
                e.Graphics.DrawString(textBox2.Text, font, firca, 215, 250);
                e.Graphics.DrawString(textBox3.Text, font, firca, 215, 300);
                e.Graphics.DrawString(richTextBox1.Text, font, firca, 215, 350);
                e.Graphics.DrawString(textBox6.Text, font, firca, 215, 450);


                font = new Font("Arial", 15, FontStyle.Bold);
                e.Graphics.DrawString("Toplam Ücret:", font, firca, 250, 550);


                font = new Font("Arial", 15);
                e.Graphics.DrawString(textBox5.Text, font, firca, 400, 550);
                //e.Graphics.DrawImage(Properties.Resources.logo, 700, 80);
            }
            catch (Exception)
            {

            }
        }
    }
}
