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
    public partial class Form1 : Form
    {

        private Button currentButton;
        private Random random;
        private int tempIndex;
        
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            custumizeDesign();
        }


        private void custumizeDesign()
        {
            MusteriPanel.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;

        }

        private void hideMenu()
        {
            if (MusteriPanel.Visible == true)
            {
                MusteriPanel.Visible = false;
            }

            else if (panel5.Visible == true)
            {
                panel5.Visible = false;
                // button6.BackColor = Color.FromArgb(70, 70, 90);
            }
            else if (panel6.Visible == true)
            {
                panel6.Visible = false;

            }
            else if (panel7.Visible == true)
            {
                panel7.Visible = false;

            }

        }

        
        private void showMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
    
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                    panel1.BackColor = color;
                    panel3.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                }
            }

        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panel2.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
                }
            }
        }
        private Form activeForm=null;
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel4.Controls.Add(childForm);
            panel4.Tag = childForm;
            /*this.panel4.Controls.Add(childForm);
            this.panel4.Tag = childForm;*/
            childForm.BringToFront();
            childForm.Show();
            label1.Text = childForm.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            showMenu(panel7);
            // OpenChildForm(new Fromss.Mutfak(), sender);
            //hideMenu();
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            showMenu(MusteriPanel);

            

        }
        private void btnBireysel_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fromss.Bireysel(), sender);
            hideMenu();
        }
        private void btnKurumsal_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fromss.Kurumsal(), sender);
            hideMenu();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            showMenu(panel6);
            /*OpenChildForm(new Fromss.Form4(), sender);
            hideMenu();*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            showMenu(panel5);
        }



        private void button5_Click_1(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            label1.Text = "ANA SAYFA";
            panel3.BackColor = Color.FromArgb(0, 150, 136);
            panel2.BackColor = Color.FromArgb(51, 51, 76);
            MusteriPanel.BackColor = Color.FromArgb(70, 70, 90);
            panel5.BackColor = Color.FromArgb(70, 70, 90);
            
            currentButton = null;
            //button5.Visible = false;


        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            timer1.Interval = 1;
            timer1.Enabled = true;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToLongTimeString();
            label3.Text = DateTime.Now.ToShortDateString();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Fromss.OdaBireysel(), sender);
            hideMenu();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Fromss.deneme(), sender);
            hideMenu();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fromss.DepartmanFrm(), sender);
            hideMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fromss.PersonelEkleme(), sender);
            hideMenu();
        }
       
        private void button10_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fromss.PersonelListeleme(), sender);
            hideMenu();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            frmKullanici k = new frmKullanici();
            k.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fromss.UrunEkleme(), sender);
            hideMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Fromss.UrunListeleme(), sender);
            hideMenu();
        }
    }
}
