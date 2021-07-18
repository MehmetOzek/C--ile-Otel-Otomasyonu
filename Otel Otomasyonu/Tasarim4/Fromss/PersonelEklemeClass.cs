using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasarim4.Fromss
{
    class PersonelEklemeClass
    {
        private int _PersonelId;
        private string _Adi;
        private string _Soyadi;
        private string _Telefon;
        private string _Adres;
        private string _Email;
        private int _DepartmanId;
        private decimal _Maasi;
        private DateTime _GirisTarihi;
        private string _Aciklama;

        public int PersonelId
        {
            get
            {
                return _PersonelId;
            }

            set
            {
                _PersonelId = value;
            }
        }

        public string Adi
        {
            get
            {
                return _Adi;
            }

            set
            {
                _Adi = value;
            }
        }

        public string Soyadi
        {
            get
            {
                return _Soyadi;
            }

            set
            {
                _Soyadi = value;
            }
        }

        public string Telefon
        {
            get
            {
                return _Telefon;
            }

            set
            {
                _Telefon = value;
            }
        }

        public string Adres
        {
            get
            {
                return _Adres;
            }

            set
            {
                _Adres = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }

            set
            {
                _Email = value;
            }
        }

        public int DepartmanId
        {
            get
            {
                return _DepartmanId;
            }

            set
            {
                _DepartmanId = value;
            }
        }

        public decimal Maasi
        {
            get
            {
                return _Maasi;
            }

            set
            {
                _Maasi = value;
            }
        }

        public DateTime GirisTarihi
        {
            get
            {
                return _GirisTarihi;
            }

            set
            {
                _GirisTarihi = value;
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

        public static DataTable ComboyaDepartmanGetir(ComboBox combo)
        {

            DataTable tbl = new DataTable();
            PersonelVeritbnn.baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select *from Departman", PersonelVeritbnn.baglanti);
            adtr.Fill(tbl);
            combo.DataSource = tbl;
            combo.ValueMember = "DepartmanId";
            combo.DisplayMember = "Departman";
            PersonelVeritbnn.baglanti.Close();
            return tbl;
        }

        public static DataTable TariheGoreAra(DateTimePicker dt,DataGridView gridview)
        {
            DataTable tbl = new DataTable();
            PersonelVeritbnn.baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select p.PersonelId, p.Adi, p.Soyadi, p.Telefon, p.Adres, p.Email," +
             "d.Departman, p.Durumu, p.Maasi, p.GirisTarihi, p.Aciklama from PersonelEkleme p, Departman d where  p.DepartmanId = d.DepartmanId and GirisTarihi=@P1", PersonelVeritbnn.baglanti);
            adtr.SelectCommand.Parameters.Add("@P1", SqlDbType.Date).Value = dt.Value;
            adtr.Fill(tbl);
            gridview.DataSource = tbl;
            
            PersonelVeritbnn.baglanti.Close();
            return tbl;
        }
    }
}
