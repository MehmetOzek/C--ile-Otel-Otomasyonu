using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasarim4
{
    public partial class frmKullanici : Form
    {
        public frmKullanici()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KullaniciClass.KullaniciGirisi(textBox1.Text, textBox2.Text);
            if (KullaniciClass.durum)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yalnış", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum frm = new SifremiUnuttum();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KayıtOl frm = new KayıtOl();
            frm.ShowDialog();
        }
    }
}
