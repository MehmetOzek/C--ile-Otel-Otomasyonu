using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tasarim4.Fromss
{
    public partial class MiniBar : Form
    {
        public MiniBar()
        {
            InitializeComponent();
        }

        private void chkKola_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKola.Checked == true)
            {
                textBox1.Enabled = true;
            }
            if (chkKola.Checked == false)
            {
                textBox1.Enabled = false;
                textBox1.Text = "0";
            }
            if (chkKola.Checked == true)
            {
                textBox15.Enabled = true;
            }
            if (chkKola.Checked == false)
            {
                textBox15.Enabled = false;
                //textBox15.Text = "0";
            }
        }

        private void txtKola_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }
        private void txtkola_Click(object sender, EventArgs e)
        {
            textBox15.Text = "";
            textBox15.Focus();
        }

        private void chkFanta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFanta.Checked == true)
            {
                textBox2.Enabled = true;
            }
            if (chkFanta.Checked == false)
            {
                textBox2.Enabled = false;
                textBox2.Text = "0";
            }
            if (chkFanta.Checked == true)
            {
                textBox16.Enabled = true;
                
            }
            if (chkFanta.Checked == false)
            {
                textBox16.Enabled = false;
                //textBox16.Text = "0";
            }
        }

        private void txtFanta_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox2.Focus();
        }
        private void txtfanta_Click(object sender, EventArgs e)
        {
            textBox16.Text = "";
            textBox16.Focus();
        }

        private void chkGazoz_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGazoz.Checked == true)
            {
                textBox3.Enabled = true;
            }
            if (chkGazoz.Checked == false)
            {
                textBox3.Enabled = false;
                textBox3.Text = "0";
            }
            if (chkGazoz.Checked == true)
            {
                textBox17.Enabled = true;
            }
            if (chkGazoz.Checked == false)
            {
                textBox17.Enabled = false;
                //textBox17.Text = "0";
            }
        }

        private void txtGazoz_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            textBox3.Focus();
        }
        private void txtgazoz_Click(object sender, EventArgs e)
        {
            textBox17.Text = "";
            textBox17.Focus();
        }


        private void chkSu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSu.Checked == true)
            {
                textBox4.Enabled = true;
            }
            if (chkSu.Checked == false)
            {
                textBox4.Enabled = false;
                textBox4.Text = "0";
            }
            if (chkSu.Checked == true)
            {
                textBox18.Enabled = true;
            }
            if (chkSu.Checked == false)
            {
                textBox18.Enabled = false;
               // textBox18.Text = "0";
            }
        }


        private void txtSu_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            textBox4.Focus();
        }
        private void txtsu_Click(object sender, EventArgs e)
        {
            textBox18.Text = "";
            textBox18.Focus();
        }

        private void chkMeyveSuyu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMeyveSuyu.Checked == true)
            {
                textBox5.Enabled = true;
            }
            if (chkMeyveSuyu.Checked == false)
            {
                textBox5.Enabled = false;
                textBox5.Text = "0";
            }
            if (chkMeyveSuyu.Checked == true)
            {
                textBox19.Enabled = true;
            }
            if (chkMeyveSuyu.Checked == false)
            {
                textBox19.Enabled = false;
               // textBox19.Text = "0";
            }
        }

        private void txtMeyveSuyu_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";
            textBox5.Focus();
        }
        private void txtmeyvesuyu_Click(object sender, EventArgs e)
        {
            textBox19.Text = "";
            textBox19.Focus();
        }

        private void chkMadenSuyu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMadenSuyu.Checked == true)
            {
                textBox6.Enabled = true;
            }
            if (chkMadenSuyu.Checked == false)
            {
                textBox6.Enabled = false;
                textBox6.Text = "0";
            }
            if (chkMadenSuyu.Checked == true)
            {
                textBox20.Enabled = true;
            }
            if (chkMadenSuyu.Checked == false)
            {
                textBox20.Enabled = false;
               // textBox20.Text = "0";
            }
        }


        private void txtMadenSuyu_Click(object sender, EventArgs e)
        {
            textBox6.Text = "";
            textBox6.Focus();
        }
        private void txtmadensuyu_Click(object sender, EventArgs e)
        {
            textBox20.Text = "";
            textBox20.Focus();
        }

        private void chkSalgam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSalgam.Checked == true)
            {
                textBox7.Enabled = true;
            }
            if (chkSalgam.Checked == false)
            {
                textBox7.Enabled = false;
                textBox7.Text = "0";
            }
            if (chkSalgam.Checked == true)
            {
                textBox21.Enabled = true;
            }
            if (chkSalgam.Checked == false)
            {
                textBox21.Enabled = false;
               // textBox21.Text = "0";
            }
        }

        private void txtSalgam_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox7.Focus();
        }
        private void txtsalgam_Click(object sender, EventArgs e)
        {
            textBox21.Text = "";
            textBox21.Focus();
        }


        private void chkKraker_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKraker.Checked == true)
            {
                textBox8.Enabled = true;
            }
            if (chkKraker.Checked == false)
            {
                textBox8.Enabled = false;
                textBox8.Text = "0";
            }
            if (chkKraker.Checked == true)
            {
                textBox22.Enabled = true;
            }
            if (chkKraker.Checked == false)
            {
                textBox22.Enabled = false;
               // textBox22.Text = "0";
            }
        }
        private void txtKraker_Click(object sender, EventArgs e)
        {
            textBox8.Text = "";
            textBox8.Focus();
        }
        private void txtkraker_Click(object sender, EventArgs e)
        {
            textBox22.Text = "";
            textBox22.Focus();
        }

        private void chkCips_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCips.Checked == true)
            {
                textBox9.Enabled = true;
            }
            if (chkCips.Checked == false)
            {
                textBox9.Enabled = false;
                textBox9.Text = "0";
            }
            if (chkCips.Checked == true)
            {
                textBox23.Enabled = true;
            }
            if (chkCips.Checked == false)
            {
                textBox23.Enabled = false;
               // textBox23.Text = "0";
            }
        }

        private void txtCips_Click(object sender, EventArgs e)
        {
            textBox9.Text = "";
            textBox9.Focus();
        }
        private void txtcips_Click(object sender, EventArgs e)
        {
            textBox23.Text = "";
            textBox23.Focus();
        }

        private void chkKek_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKek.Checked == true)
            {
                textBox10.Enabled = true;
            }
            if (chkKek.Checked == false)
            {
                textBox10.Enabled = false;
                textBox10.Text = "0";
            }
            if (chkKek.Checked == true)
            {
                textBox24.Enabled = true;
            }
            if (chkKek.Checked == false)
            {
                textBox24.Enabled = false;
                //textBox24.Text = "0";
            }
        }

        private void txtKek_Click(object sender, EventArgs e)
        {
            textBox10.Text = "";
            textBox10.Focus();
        }
        private void txtkek_Click(object sender, EventArgs e)
        {
            textBox24.Text = "";
            textBox24.Focus();
        }



        private void chkProteinBar_CheckedChanged(object sender, EventArgs e)
        {

            if (chkProteinBar.Checked == true)
            {
                textBox11.Enabled = true;
            }
            if (chkProteinBar.Checked == false)
            {
                textBox11.Enabled = false;
                textBox11.Text = "0";
            }
            if (chkProteinBar.Checked == true)
            {
                textBox25.Enabled = true;
            }
            if (chkProteinBar.Checked == false)
            {
                textBox25.Enabled = false;
                //textBox25.Text = "0";
            }
        }

        private void txtProteinBar_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox11.Focus();
        }
        private void txtproteinbar_Click(object sender, EventArgs e)
        {
            textBox25.Text = "";
            textBox25.Focus();
        }

        private void chkCikolata_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCikolata.Checked == true)
            {
                textBox12.Enabled = true;
            }
            if (chkCikolata.Checked == false)
            {
                textBox12.Enabled = false;
                textBox12.Text = "0";
            }
            if (chkCikolata.Checked == true)
            {
                textBox26.Enabled = true;
            }
            if (chkCikolata.Checked == false)
            {
                textBox26.Enabled = false;
               // textBox26.Text = "0";
            }
        }

        private void txtCikolata_Click(object sender, EventArgs e)
        {
            textBox12.Text = "";
            textBox12.Focus();
        }
        private void txtcikolata_Click(object sender, EventArgs e)
        {
            textBox26.Text = "";
            textBox26.Focus();
        }


        private void chkCerex_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCerex.Checked == true)
            {
                textBox13.Enabled = true;
            }
            if (chkCerex.Checked == false)
            {
                textBox13.Enabled = false;
                textBox13.Text = "0";
            }
            if (chkCerex.Checked == true)
            {
                textBox27.Enabled = true;
            }
            if (chkCerex.Checked == false)
            {
                textBox27.Enabled = false;
                //textBox27.Text = "0";
            }
        }

        private void txtCerex_Click(object sender, EventArgs e)
        {
            textBox13.Text = "";
            textBox13.Focus();
        }
        private void txtcerex_Click(object sender, EventArgs e)
        {
            textBox27.Text = "";
            textBox27.Focus();
        }
        private void chkCikolataBar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCikolataBar.Checked == true)
            {
                textBox14.Enabled = true;
            }
            if (chkCikolataBar.Checked == false)
            {
                textBox14.Enabled = false;
                textBox14.Text = "0";
            }
            if (chkCikolataBar.Checked == true)
            {
                textBox28.Enabled = true;
            }
            if (chkCikolataBar.Checked == false)
            {
                textBox28.Enabled = false;
               // textBox28.Text = "0";
            }
        }
        private void txtCikolataBar_Click(object sender, EventArgs e)
        {
            textBox14.Text = "";
            textBox14.Focus();
        }
        private void txtcikolatabar_Click(object sender, EventArgs e)
        {
            textBox28.Text = "";
            textBox28.Focus();
        }

        private void btnTopla_Click(object sender, EventArgs e)
        {
            double Kola = Convert.ToDouble(textBox15.Text);
            double kola = Convert.ToDouble(textBox1.Text);
            double Fanta = Convert.ToDouble(textBox16.Text);
            double fanta = Convert.ToDouble(textBox2.Text);
            double gazoz = Convert.ToDouble(textBox3.Text);
            double Gazoz = Convert.ToDouble(textBox17.Text);
            double su = Convert.ToDouble(textBox4.Text);
            double Su = Convert.ToDouble(textBox18.Text);
            double maden_suyu = Convert.ToDouble(textBox6.Text);
            double MadenSuyu = Convert.ToDouble(textBox19.Text);
            double meyve_suyu = Convert.ToDouble(textBox5.Text);
            double MeyveSuyu = Convert.ToDouble(textBox20.Text);
            double salgam = Convert.ToDouble(textBox7.Text);
            double Salgam = Convert.ToDouble(textBox21.Text);



            double Kraker = Convert.ToDouble(textBox22.Text);
            double kraker = Convert.ToDouble(textBox8.Text);
            double Cips = Convert.ToDouble(textBox23.Text);
            double cips = Convert.ToDouble(textBox9.Text);
            double Kek = Convert.ToDouble(textBox24.Text);
            double kek = Convert.ToDouble(textBox10.Text);
            double ProteinBar = Convert.ToDouble(textBox25.Text);
            double protein_bar = Convert.ToDouble(textBox11.Text);
            double Cikolata = Convert.ToDouble(textBox26.Text);
            double cikolata = Convert.ToDouble(textBox12.Text);
            double Cerez = Convert.ToDouble(textBox27.Text);
            double cerez = Convert.ToDouble(textBox13.Text);
            double CikolataBar = Convert.ToDouble(textBox28.Text);
            double cikolata_bar = Convert.ToDouble(textBox14.Text);




            İcecek eat_in_Coffee = new İcecek(kola, fanta, gazoz, su, maden_suyu, meyve_suyu,
            salgam, kraker, cips, kek, protein_bar, cikolata, cikolata_bar, cerez);



            double iceceklerin_maliyeti = (kola * Kola) + (fanta * Fanta) + (gazoz * Gazoz) + (su * Su)
            + (maden_suyu * MadenSuyu) + (meyve_suyu * MeyveSuyu) + (salgam * Salgam);
            lblİcecek.Text = Convert.ToString(iceceklerin_maliyeti);


            double gidalarin_maliyeti = (kraker * Kraker) + (cips * Cips) + (kek * Kek) + (protein_bar * ProteinBar)
            + (cikolata * Cikolata) + (cikolata_bar * CikolataBar) + (cerez * Cerez);
            lblGıda.Text = Convert.ToString(gidalarin_maliyeti);


            lblToplamFiyat.Text = Convert.ToString(gidalarin_maliyeti + iceceklerin_maliyeti);


            lblGıda.Text = String.Format("{0:C}", gidalarin_maliyeti);
            lblİcecek.Text = String.Format("{0:C}", iceceklerin_maliyeti);


            lblToplamFiyat.Text = String.Format("{0:C}", (gidalarin_maliyeti + iceceklerin_maliyeti));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rtfReceipt.Clear();

            rtfReceipt.AppendText(Environment.NewLine);
            rtfReceipt.AppendText("\t\t" + "MİNİ BAR HESAP " + Environment.NewLine);
            rtfReceipt.AppendText("-----------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("Kola \t\t\t\t" + textBox1.Text + Environment.NewLine);
            rtfReceipt.AppendText("Fanta \t\t\t\t" + textBox2.Text + Environment.NewLine);
            rtfReceipt.AppendText("Gazoz \t\t\t\t" + textBox3.Text + Environment.NewLine);
            rtfReceipt.AppendText("Su \t\t\t\t\t" + textBox4.Text + Environment.NewLine);
            rtfReceipt.AppendText("Meyve Suyu \t\t\t" + textBox5.Text + Environment.NewLine);
            rtfReceipt.AppendText("Maden Suyu \t\t\t" + textBox6.Text + Environment.NewLine);
            rtfReceipt.AppendText("Şalgam \t\t\t\t" + textBox7.Text + Environment.NewLine);
            rtfReceipt.AppendText("Kraker \t\t\t\t" + textBox8.Text + Environment.NewLine);
            rtfReceipt.AppendText("Cips \t\t\t\t\t" + textBox9.Text + Environment.NewLine);
            rtfReceipt.AppendText("Kek \t\t\t\t\t" + textBox10.Text + Environment.NewLine);
            rtfReceipt.AppendText("Protein Bar \t\t\t\t" + textBox11.Text + Environment.NewLine);
            rtfReceipt.AppendText("Çikolata \t\t\t\t" + textBox12.Text + Environment.NewLine);
            rtfReceipt.AppendText("Çerez \t\t\t\t" + textBox13.Text + Environment.NewLine);
            rtfReceipt.AppendText("Çikolata Bar \t\t\t" + textBox14.Text + Environment.NewLine);
            rtfReceipt.AppendText("-------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText("Toplam Fiyat \t\t\t\t" + lblToplamFiyat.Text + Environment.NewLine);
            rtfReceipt.AppendText("--------------------------------------------------" + Environment.NewLine);
            rtfReceipt.AppendText(lblTime.Text + "\t" + lblDate.Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox13.Text = "0";
            textBox14.Text = "0";
            //textBox15.Text = "0";
            //textBox16.Text = "0";
           // textBox17.Text = "0";
            //textBox18.Text = "0";
           // textBox19.Text = "0";
           // textBox20.Text = "0";
           // textBox21.Text = "0";
            //textBox22.Text = "0";
           // textBox23.Text = "0";
           // textBox24.Text = "0";
           // textBox25.Text = "0";
          //  textBox26.Text = "0";
           // textBox27.Text = "0";
           // textBox28.Text = "0";
            lblGıda.Text = "0";
            lblİcecek.Text = "0";
            lblToplamFiyat.Text = "0";



            chkKola.Checked = false;
            chkFanta.Checked = false;
            chkGazoz.Checked = false;
            chkSu.Checked = false;
            chkMadenSuyu.Checked = false;
            chkMeyveSuyu.Checked = false;
            chkSalgam.Checked = false;
            chkKraker.Checked = false;
            chkCips.Checked = false;
            chkKek.Checked = false;
            chkCikolata.Checked = false;
            chkProteinBar.Checked = false;
            chkCerex.Checked = false;
            chkCikolataBar.Checked = false;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.FileName = "Notepad Text";
            saveFile.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFile.FileName))
                    sw.WriteLine(rtfReceipt.Text);
            }
        }
        

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtfReceipt.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, 120, 120);
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void MiniBar_Load(object sender, EventArgs e)
        {
            
            lblDate.Text = DateTime.Now.ToLongDateString();
            Timer1.Start();

            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            textBox9.Text = "0";
            textBox10.Text = "0";
            textBox11.Text = "0";
            textBox12.Text = "0";
            textBox13.Text = "0";
            textBox14.Text = "0";
            //textBox15.Text = "0";
            //textBox16.Text = "0";
            //textBox17.Text = "0";
            //textBox18.Text = "0";
           // textBox19.Text = "0";
            //textBox20.Text = "0";
           // textBox21.Text = "0";
           // textBox22.Text = "0";
          //  textBox23.Text = "0";
          //  textBox24.Text = "0";
          //  textBox25.Text = "0";
          //  textBox26.Text = "0";
         //   textBox27.Text = "0";
          //  textBox28.Text = "0";
            lblGıda.Text = "0";
            lblİcecek.Text = "0";
            lblToplamFiyat.Text = "0";

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox13.Enabled = false;
            textBox14.Enabled = false;
            textBox15.Enabled = false;
            textBox16.Enabled = false;
            textBox17.Enabled = false;
            textBox18.Enabled = false;
            textBox19.Enabled = false;
            textBox20.Enabled = false;
            textBox21.Enabled = false;
            textBox22.Enabled = false;
            textBox23.Enabled = false;
            textBox24.Enabled = false;
            textBox25.Enabled = false;
            textBox26.Enabled = false;
            textBox27.Enabled = false;
            textBox28.Enabled = false;
            



            chkKola.Checked = false;
            chkFanta.Checked = false;
            chkGazoz.Checked = false;
            chkSu.Checked = false;
            chkMadenSuyu.Checked = false;
            chkMeyveSuyu.Checked = false;
            chkSalgam.Checked = false;
            chkKraker.Checked = false;
            chkCips.Checked = false;
            chkKek.Checked = false;
            chkCikolata.Checked = false;
            chkProteinBar.Checked = false;
            chkCerex.Checked = false;
            chkCikolataBar.Checked = false;
            textBox15.Text = Properties.Settings.Default.textbox;
            textBox16.Text = Properties.Settings.Default.textboxa;
            textBox17.Text = Properties.Settings.Default.textboxb;
            textBox18.Text = Properties.Settings.Default.textboxc;
            textBox19.Text = Properties.Settings.Default.textboxd;
            textBox20.Text = Properties.Settings.Default.textboxe;
            textBox21.Text = Properties.Settings.Default.textboxf;
            textBox22.Text = Properties.Settings.Default.textboxg;
            textBox23.Text = Properties.Settings.Default.textboxh;
            textBox24.Text = Properties.Settings.Default.textboxi;
            textBox25.Text = Properties.Settings.Default.textboxk;
            textBox26.Text = Properties.Settings.Default.textboxl;
            textBox27.Text = Properties.Settings.Default.textboxm;
            textBox28.Text = Properties.Settings.Default.textboxn;
            
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
           
        
            lblTime.Text = DateTime.Now.ToLongTimeString();
        
       }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(rtfReceipt.Text, new Font("Arial", 14, FontStyle.Regular), Brushes.Black, 120, 120);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            rtfReceipt.Clear();
        }

        private void MiniBar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.textbox = textBox15.Text;
            Properties.Settings.Default.textboxa = textBox16.Text;
            Properties.Settings.Default.textboxb = textBox17.Text;
            Properties.Settings.Default.textboxc = textBox18.Text;
            Properties.Settings.Default.textboxd = textBox19.Text;
            Properties.Settings.Default.textboxe = textBox20.Text;
            Properties.Settings.Default.textboxf = textBox21.Text;
            Properties.Settings.Default.textboxg = textBox22.Text;
            Properties.Settings.Default.textboxh = textBox23.Text;
            Properties.Settings.Default.textboxi = textBox24.Text;
            Properties.Settings.Default.textboxk = textBox25.Text;
            Properties.Settings.Default.textboxl = textBox26.Text;
            Properties.Settings.Default.textboxm = textBox27.Text;
            Properties.Settings.Default.textboxn = textBox28.Text;
            Properties.Settings.Default.Save();
        }
    }
}
