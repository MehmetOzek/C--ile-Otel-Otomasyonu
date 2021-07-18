using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasarim4.Fromss
{
    class MKategori
    {
        private int _KategoriID;
        private string _Kategori;
        private string _Aciklama;

        public int KategoriID
        {
            get
            {
                return _KategoriID;
            }

            set
            {
                _KategoriID = value;
            }
        }

        public string Kategori
        {
            get
            {
                return _Kategori;
            }

            set
            {
                _Kategori = value;
            }
        }

        public string Aciklama
        {
            get
            {
                return _Aciklama;
            }

            set
            {
                _Aciklama = value;
            }
        }
        public static SqlDataReader KategoriGetir(ListView lst)
        {
            lst.Items.Clear();
            PersonelVeritbnn.baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from Kategori", PersonelVeritbnn.baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = dr[0].ToString();
                ekle.SubItems.Add(dr[1].ToString());
                ekle.SubItems.Add(dr[2].ToString());
                lst.Items.Add(ekle);
            }
            PersonelVeritbnn.baglanti.Close();
            return dr;
        }
    }

}

