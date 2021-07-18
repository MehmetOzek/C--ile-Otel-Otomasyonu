using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasarim4.Fromss
{
    class DepartmanClass
    {
        private int DepartmanId;
        private string _Departman;
        private string _Aciklama;

        public int DepartmanId1
        {
            get
            {
                return DepartmanId;
            }

            set
            {
                DepartmanId = value;
            }
        }

        public string Departman
        {
            get
            {
                return _Departman;
            }

            set
            {
                _Departman = value;
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


        public static SqlDataReader DepartmanGetir(ListView lst)
        {
            lst.Items.Clear();
            PersonelVeritbnn.baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *from Departman", PersonelVeritbnn.baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
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
