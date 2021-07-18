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
    public partial class Bireysel : Form
    {
        
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3C0HC8S\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");


        public Bireysel()
        {
            InitializeComponent();
            
        }
        void listeleme()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "select * from Table_1";
                SqlDataAdapter adpr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adpr.Fill(ds, "Table_1");
                dataGridView1.DataSource = ds.Tables["Table_1"];
                dataGridView1.Columns[0].Visible = false;
                baglanti.Close();
            }
          
        }

        private void NewMethod(SqlCommand cmd)
        {
            cmd.CommandText = "INSERT INTO Table_1(tc,ad,soyad,telefon,kisisayisi,odano,giris,cikis,gunlukucret,fiyat) VALUES('" + maskedTextBox1.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            BosOdalar();

            listeleme();
        }

        private void BosOdalar()
        {
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select * from odadurumu2 WHERE durumu='BOŞ'", baglanti);
            SqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read["odano"].ToString());
            }
            baglanti.Close();
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                NewMethod(cmd);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                SqlCommand komut2 = new SqlCommand("update odadurumu2 set durumu='DOLU' where odano='" + comboBox1.SelectedItem + "'", baglanti);
                komut2.ExecuteNonQuery();

                
                
                baglanti.Close();
                listeleme();
                BosOdalar();
                MessageBox.Show("BAĞLANTI KAYDEDİLDİ");
                //BosOdalar();

            }
            comboBox1.Items.Clear();
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                else if (item is MaskedTextBox)
                {
                    item.Text = "";

                }
                else if (item is RichTextBox)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("SİLMEK İSTEDİĞİNİZDEN EMİNMİSİNİZ", "DİKKAT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "delete from Table_1 where id=@numara";
                    cmd.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();
                    MessageBox.Show("BİLGİLER SİLİNDİ");
                    listeleme();
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "update Table_1 set tc='" + maskedTextBox1.Text + "',ad='" + textBox1.Text + "',soyad='" + textBox2.Text + "',telefon='" + textBox4.Text + "',kisisayisi='" + textBox3.Text + "',odano='" + comboBox1.Text + "',giris='" + dateTimePicker1.Text + "',cikis='" + dateTimePicker2.Text + "',gunlukucret='" + textBox5.Text + "',fiyat='" + textBox6.Text + "' where id=@numara";
                cmd.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                baglanti.Close();
                listeleme();
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["ad"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["soyad"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["kisisayisi"].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["odano"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["giris"].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells["cikis"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["gunlukucret"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["fiyat"].Value.ToString();
        }

        private void btnhesapla_Click(object sender, EventArgs e)
        {
         
            int gunFarki;  // farkı almak için oluşturduğumuz değişken
            int a;
            if (dateTimePicker1.Value < dateTimePicker2.Value) // başlangıç tarihi bitişten küçükse…

            {

                TimeSpan tarihFarki = dateTimePicker2.Value - dateTimePicker1.Value; // tarih farkını almak için bitişten başlangıcı çıkar

                gunFarki = tarihFarki.Days; // gün farkı olarak da tarih farkına günü yaz

                label10.Text = gunFarki.ToString();
                int s = Convert.ToInt16(label10.Text);
                a = s * 80;
                textBox6.Text =( a.ToString()+"TL");
                

            }

            else  // başlangıç tarihi bitişten büyükse…

            {

                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz");

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MiniBar frmMiniBar = new MiniBar();
            frmMiniBar.Show();
        }

        private void btnhesapla_Click_1(object sender, EventArgs e)
        {
            int gunFarki;  // farkı almak için oluşturduğumuz değişken
            int a;
            int f;
            if (dateTimePicker1.Value < dateTimePicker2.Value) // başlangıç tarihi bitişten küçükse…

            {

                TimeSpan tarihFarki = (dateTimePicker2.Value - dateTimePicker1.Value); // tarih farkını almak için bitişten başlangıcı çıkar

                gunFarki = tarihFarki.Days; // gün farkı olarak da tarih farkına günü yaz
                gunFarki++;
                label12.Text = gunFarki.ToString();
                int s = Convert.ToInt16(label12.Text);
                a = Convert.ToInt16(textBox5.Text);
                textBox5.Text = (a.ToString() + " TL");
                f = s * a;
                textBox6.Text = (f.ToString() + " TL");


            }

            else  // başlangıç tarihi bitişten büyükse…

            {

                MessageBox.Show("Başlangıç tarihi bitiş tarihinden büyük olamaz");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            MusteriCikisiBireysel frmMusteriCikisi = new MusteriCikisiBireysel();
            frmMusteriCikisi.Show();
        }

        private void FaturaBtn_Click(object sender, EventArgs e)
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
                e.Graphics.DrawString("BİREYSEL FATURA", font, firca, 330, 75);
                e.Graphics.DrawLine(kalem, 50, 70, 780, 70);
                e.Graphics.DrawLine(kalem, 50, 110, 780, 110);
                e.Graphics.DrawLine(kalem, 50, 70, 50, 110);
                e.Graphics.DrawLine(kalem, 780, 70, 780, 110);

                e.Graphics.DrawString("***************************", font, firca, 320, 115);


                font = new Font("Arial", 15, FontStyle.Bold);
                e.Graphics.DrawString("TC Kimlik No:", font, firca, 50, 150);
                e.Graphics.DrawString("İsim:", font, firca, 50, 200);
                e.Graphics.DrawString("Soyisim:", font, firca, 50, 250);
                e.Graphics.DrawString("Telefon:", font, firca, 50, 300);
                e.Graphics.DrawString("Günlük Ücret:", font, firca, 50, 350);
                //

                e.Graphics.DrawLine(kalem, 50, 140, 780, 140);
                e.Graphics.DrawLine(kalem, 50, 400, 50, 140);
                e.Graphics.DrawLine(kalem, 50, 400, 780, 400);
                e.Graphics.DrawLine(kalem, 780, 140, 780, 400);


                font = new Font("Arial", 15);
                e.Graphics.DrawString(maskedTextBox1.Text, font, firca, 200, 150);
                e.Graphics.DrawString(textBox1.Text, font, firca, 200, 200);
                e.Graphics.DrawString(textBox2.Text, font, firca, 200, 250);
                e.Graphics.DrawString(textBox4.Text, font, firca, 200, 300);
                e.Graphics.DrawString(textBox5.Text, font, firca, 200, 350);
               

                font = new Font("Arial", 15, FontStyle.Bold);
                e.Graphics.DrawString("Toplam Ücret:", font, firca, 250, 450);


                font = new Font("Arial", 15);
                e.Graphics.DrawString(textBox6.Text, font, firca, 400, 450);
                //e.Graphics.DrawImage(Properties.Resources.logo, 700, 80);
            }
            catch (Exception)
            {

            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
