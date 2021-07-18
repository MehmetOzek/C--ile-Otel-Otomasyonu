using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasarim4
{
    class KullaniciClass
    {
        private int _KullaniciID;
        private string _KullaniciAdi;
        private string _Sifre;
        private string _AdiSoyadi;
        private string _Soru;
        private string _Cevap;
        private string _Aciklama;
        private DateTime _Tarih;


        public int KullaniciID
        {
            get
            {
                return _KullaniciID;
            }

            set
            {
                _KullaniciID = value;
            }
        }

        public string KullaniciAdi
        {
            get
            {
                return _KullaniciAdi;
            }

            set
            {
                _KullaniciAdi = value;
            }
        }

        public string Sifre
        {
            get
            {
                return _Sifre;
            }

            set
            {
                _Sifre = value;
            }
        }

        public string AdiSoyadi
        {
            get
            {
                return _AdiSoyadi;
            }

            set
            {
                _AdiSoyadi = value;
            }
        }

        public string Soru
        {
            get
            {
                return _Soru;
            }

            set
            {
                _Soru = value;
            }
        }

        public string Cevap
        {
            get
            {
                return _Cevap;
            }

            set
            {
                _Cevap = value;
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

        public DateTime Tarih
        {
            get
            {
                return _Tarih;
            }

            set
            {
                _Tarih = value;
            }
        }

        public static bool durum = false;
        public static SqlDataReader KullaniciGirisi(string kullaniciadi, string sifre)
        {
            KullaniciClass k = new KullaniciClass();
            k._KullaniciAdi = kullaniciadi;
            k._Sifre = sifre;
            Veritabani.baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from Kullanicilar where KullaniciAdi='" + k._KullaniciAdi + "' and Sifre='" + k._Sifre + "'",Veritabani.baglanti);
            
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                durum = true;
                k.KullaniciID = int.Parse(dr[0].ToString());
            }
            else
            {
                durum = false;
            }
            dr.Close();
            Veritabani.baglanti.Close();
            return dr;
        }
    }
}
