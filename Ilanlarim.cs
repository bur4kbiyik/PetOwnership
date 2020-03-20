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

namespace Petilan.Sayfalar
{
    public partial class Ilanlarim : Form
    {
        public Ilanlarim()
        {
            InitializeComponent();
        }
        public string KullaniciAdi { get; set; }
        PictureBox[] pictureBoxs = new PictureBox[6];
        Label[] ilanBasliklari = new Label[6];
        Label[] ilanTurleri = new Label[6];
        Label[] ilanIrklari = new Label[6];
        Label[] ilanYaslari = new Label[6];
        Label[] ilanCinsiyetleri = new Label[6];

        private void Ilanlarim_Load(object sender, EventArgs e)
        {
            KullaniciAdi = Anasayfa.KullaniciAdi;
            btIlanlarimHesap.Text = KullaniciAdi;
            int ilanSayisi = 0;
            SqlCommand command,command2;
             
            pictureBoxs[0] = pictureBox0; 
            pictureBoxs[1] = pictureBox1;
            pictureBoxs[2] = pictureBox2;
            pictureBoxs[3] = pictureBox3;
            pictureBoxs[4] = pictureBox4;
            pictureBoxs[5] = pictureBox5;
         
            ilanBasliklari[0] = lbIlanlarimBaslik1;
            ilanBasliklari[1] = lbIlanlarimBaslik2;
            ilanBasliklari[2] = lbIlanlarimBaslik3;
            ilanBasliklari[3] = lbIlanlarimBaslik4;
            ilanBasliklari[4] = lbIlanlarimBaslik5;
            ilanBasliklari[5] = lbIlanlarimBaslik6;

            ilanTurleri[0] = lbIlanlarimTur1;
            ilanTurleri[1] = lbIlanlarimTur2;
            ilanTurleri[2] = lbIlanlarimTur3;
            ilanTurleri[3] = lbIlanlarimTur4;
            ilanTurleri[4] = lbIlanlarimTur5;
            ilanTurleri[5] = lbIlanlarimTur6;

            ilanIrklari[0] = lbIlanlarimIrk1;
            ilanIrklari[1] = lbIlanlarimIrk2;
            ilanIrklari[2] = lbIlanlarimIrk3;
            ilanIrklari[3] = lbIlanlarimIrk4;
            ilanIrklari[4] = lbIlanlarimIrk5;
            ilanIrklari[5] = lbIlanlarimIrk6;

            ilanYaslari[0] = lbIlanlarimYas1;
            ilanYaslari[1] = lbIlanlarimYas2;
            ilanYaslari[2] = lbIlanlarimYas3;
            ilanYaslari[3] = lbIlanlarimYas4;
            ilanYaslari[4] = lbIlanlarimYas5;
            ilanYaslari[5] = lbIlanlarimYas6;

            ilanCinsiyetleri[0] = lbIlanlarimCinsiyet1;
            ilanCinsiyetleri[1] = lbIlanlarimCinsiyet2;
            ilanCinsiyetleri[2] = lbIlanlarimCinsiyet3;
            ilanCinsiyetleri[3] = lbIlanlarimCinsiyet4;
            ilanCinsiyetleri[4] = lbIlanlarimCinsiyet5;
            ilanCinsiyetleri[5] = lbIlanlarimCinsiyet6;

            SqlConnection baglanti = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");

            command = new SqlCommand();
            baglanti.Open();
            command.Connection = baglanti;
            command.CommandText = "select i.ResimKonumu from tbl_Ilanlar i where KullaniciNo in (select KullaniciId from tbl_Kullanici k where k.KullaniciAdi = '" + KullaniciAdi + "')";

                using (SqlDataReader rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var ResimYl = rdr.GetString(0); //0.kolonu alıyorum
                        pictureBoxs[ilanSayisi].ImageLocation = ResimYl; //aldığım data reader'ını picturebox'a aktarıyorum
                        ilanSayisi++;
                    }

                    ilanSay.Text = Convert.ToString(ilanSayisi); //İlan sayısı label'ına aktarıyorum
                }

            int hayvansayac = 0;
            command2 = new SqlCommand();
            command2.Connection = baglanti;
            command2.CommandText = "select IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet from tbl_Ilanlar where KullaniciNo in (select KullaniciId from tbl_Kullanici where KullaniciAdi = '"+ KullaniciAdi +"')";
            using (SqlDataReader dr = command2.ExecuteReader())
            {
                while (dr.Read())
                {
                    string ilanBaslik = dr.GetString(0);
                    string hayvanTuru = dr.GetString(1);
                    string hayvanIrki = dr.GetString(2);
                    string hayvanYasi = dr.GetString(3);
                    string hayvanCinsiyeti = dr.GetString(4);

                    ilanBasliklari[hayvansayac].Text = ilanBaslik;
                    ilanTurleri[hayvansayac].Text = hayvanTuru;
                    ilanIrklari[hayvansayac].Text = hayvanIrki;
                    ilanYaslari[hayvansayac].Text = hayvanYasi;
                    ilanCinsiyetleri[hayvansayac].Text = hayvanCinsiyeti;

                    hayvansayac++;
                }
            
            }
            baglanti.Close();
        }

        private void btIlanlarimHesap_Click(object sender, EventArgs e)
        {
            cmHesap.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void ilanVer_Click(object sender, EventArgs e)
        {
            this.Hide();
            IlanVer ilanVerSayfa = new IlanVer();
            ilanVerSayfa.ShowDialog();
        }

        private void cikisYap_Click(object sender, EventArgs e)
        {
            this.Hide();
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.tbKAdiAnasayfa.Visible = true;
            anasayfa.tbSifreAnasayfa.Visible = true;
            anasayfa.label1.Visible = true;
            anasayfa.label2.Visible = true;
            anasayfa.btUyeOl.Visible = true;
            anasayfa.btGiris.Visible = true;
            anasayfa.btHesap.Hide();
            anasayfa.ShowDialog();
        }

        private void ilanlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zaten ilanlarım sayfasındasınız.");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void ilanSay_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void gelenIstekler_Click(object sender, EventArgs e)
        {
            this.Hide();
            GelenIstekler gi = new GelenIstekler();
            gi.ShowDialog();
        }
    }
}
