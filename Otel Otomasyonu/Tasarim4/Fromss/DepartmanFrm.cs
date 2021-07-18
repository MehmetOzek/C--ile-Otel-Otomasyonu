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
    public partial class DepartmanFrm : Form
    {
        public DepartmanFrm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       

        private void DepartmanFrm_Load(object sender, EventArgs e)
        {
           DepartmanClass.DepartmanGetir(listView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DepartmanClass d = new DepartmanClass();
            d.Departman = textBox2.Text;
            d.Aciklama = textBox3.Text;

            string sorgu = "insert into Departman values('" + d.Departman + "','" + d.Aciklama + "')";

            SqlCommand komut = new SqlCommand();
            PersonelVeritbnn.ESG(komut, sorgu);
            MessageBox.Show("İşlem Başarıyla Tamamlandı");
            DepartmanClass.DepartmanGetir(listView1);
        }


        private void button2_Click(object sender, EventArgs e)
        {


            DepartmanClass d = new DepartmanClass();
            d.DepartmanId1 = int.Parse(textBox1.Text);
            d.Departman = textBox2.Text;
            d.Aciklama = textBox3.Text;

            string sorgu = "update Departman set Departman='" + d.Departman + "',Aciklama='" + d.Aciklama + "' where DepartmanId='" + d.DepartmanId1 + "'";

            SqlCommand komut = new SqlCommand();
            PersonelVeritbnn.ESG(komut, sorgu);
            MessageBox.Show("İşlem Başarıyla Tamamlandı");
            DepartmanClass.DepartmanGetir(listView1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DepartmanClass d = new DepartmanClass();
                d.DepartmanId1 = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

                string sorgu = "delete from  Departman where DepartmanId='" + d.DepartmanId1 + "'";

                SqlCommand komut = new SqlCommand();
                PersonelVeritbnn.ESG(komut, sorgu);
                MessageBox.Show("İşlem Başarıyla Tamamlandı");
                DepartmanClass.DepartmanGetir(listView1);
            }
            else
            {
                MessageBox.Show("LÜtfen Bir Kayıt Seçin","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
        }
    }
}
