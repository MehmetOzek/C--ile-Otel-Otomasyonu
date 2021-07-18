using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasarim4
{
    class Veritabani
    {
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-3C0HC8S\\SQLEXPRESS;Initial Catalog=Otel;Integrated Security=True");
        public static void ESG(SqlCommand cmd, string sql)
        {
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            baglanti.Close();
        }
        public static DataTable Listele_Ara(DataGridView gridview, string sql)
        {
            DataTable tbl = new DataTable();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter(sql, baglanti);
            adtr.Fill(tbl);
            gridview.DataSource = tbl;
            baglanti.Close();
            return tbl;
        }
    }
}
