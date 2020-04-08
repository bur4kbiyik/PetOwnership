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
        public static int DegiskenId { get; set; }
        public static string DegiskenResim { get; set; }
        public static string DegiskenBaslik { get; set; }
        public static string DegiskenTur { get; set; }
        public static string DegiskenIrk { get; set; }
        public static string DegiskenYas { get; set; }
        public static string DegiskenCinsiyet { get; set; }
        public string KullaniciAdi { get; set; }
        public static string Kontrol { get; set; }

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
        string kontrol = "";
        private void lbIlanlarimBaslik1_Click(object sender, EventArgs e)
        {
            kontrol = "tiklandi";
            Kontrol = kontrol;

            DegiskenResim = pictureBox0.ImageLocation;
            DegiskenBaslik = lbIlanlarimBaslik1.Text;
            DegiskenTur = lbIlanlarimTur1.Text;
            DegiskenIrk = lbIlanlarimIrk1.Text;
            DegiskenYas = lbIlanlarimYas1.Text;
            DegiskenCinsiyet = lbIlanlarimCinsiyet1.Text;

            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            con.Open();
            com.Connection = con;
            com.CommandText = "select ResimKonumu,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,KullaniciNo from tbl_Ilanlar where ResimKonumu = '" + DegiskenResim + "' and IlanBaslik = '" + DegiskenBaslik + "' and HayvanTuru = '" + DegiskenTur + "' and HayvanIrk = '" + DegiskenIrk + "' and HayvanYas = '" + DegiskenYas + "' and HayvanCinsiyet = '" + DegiskenCinsiyet + "'";

            using (SqlDataReader dr = com.ExecuteReader())
            {
                if (dr.Read())
                {
                    var resimKonum1 = dr.GetString(0);
                    /*MessageBox.Show(resimKonum1);*/ // denemek için kullanılmıştır
                    string ilanBaslik1 = dr.GetString(1);
                    string ilanTur1 = dr.GetString(2);
                    string ilanIrk1 = dr.GetString(3);
                    string ilanYas1 = dr.GetString(4);
                    string ilanCinsiyet1 = dr.GetString(5);
                    DegiskenId = dr.GetInt32(6);
                    Sahiplen shpln = new Sahiplen();
                    shpln.pbSahiplenResim.ImageLocation = resimKonum1;
                    shpln.lbSahiplenBaslik.Text = ilanBaslik1;
                    shpln.lbSahiplenTur.Text = ilanTur1;
                    shpln.lbSahiplenIrk.Text = ilanIrk1;
                    shpln.lbSahiplenYas.Text = ilanYas1;
                    shpln.lbSahiplenCinsiyet.Text = ilanCinsiyet1;
                }
                con.Close();
            }
            this.Hide();
            Sahiplen sahiplen = new Sahiplen();
            sahiplen.btSahiplen.Hide();
            sahiplen.ShowDialog();
        }

        private void lbIlanlarimBaslik2_Click(object sender, EventArgs e)
        {
            kontrol = "tiklandi";
            Kontrol = kontrol;

            DegiskenResim = pictureBox1.ImageLocation;
            DegiskenBaslik = lbIlanlarimBaslik2.Text;
            DegiskenTur = lbIlanlarimTur2.Text;
            DegiskenIrk = lbIlanlarimIrk2.Text;
            DegiskenYas = lbIlanlarimYas2.Text;
            DegiskenCinsiyet = lbIlanlarimCinsiyet2.Text;

            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            con.Open();
            com.Connection = con;
            com.CommandText = "select ResimKonumu,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,KullaniciNo from tbl_Ilanlar where ResimKonumu = '" + DegiskenResim + "' and IlanBaslik = '" + DegiskenBaslik + "' and HayvanTuru = '" + DegiskenTur + "' and HayvanIrk = '" + DegiskenIrk + "' and HayvanYas = '" + DegiskenYas + "' and HayvanCinsiyet = '" + DegiskenCinsiyet + "'";

            using (SqlDataReader dr = com.ExecuteReader())
            {
                if (dr.Read())
                {
                    var resimKonum2 = dr.GetString(0);
                    /*MessageBox.Show(resimKonum1);*/ // denemek için kullanılmıştır
                    string ilanBaslik2 = dr.GetString(1);
                    string ilanTur2 = dr.GetString(2);
                    string ilanIrk2 = dr.GetString(3);
                    string ilanYas2 = dr.GetString(4);
                    string ilanCinsiyet2 = dr.GetString(5);
                    DegiskenId = dr.GetInt32(6);
                    Sahiplen shpln = new Sahiplen();
                    shpln.pbSahiplenResim.ImageLocation = resimKonum2;
                    shpln.lbSahiplenBaslik.Text = ilanBaslik2;
                    shpln.lbSahiplenTur.Text = ilanTur2;
                    shpln.lbSahiplenIrk.Text = ilanIrk2;
                    shpln.lbSahiplenYas.Text = ilanYas2;
                    shpln.lbSahiplenCinsiyet.Text = ilanCinsiyet2;
                }
                con.Close();
            }
            this.Hide();
            Sahiplen sahiplen = new Sahiplen();
            sahiplen.btSahiplen.Hide();
            sahiplen.ShowDialog();
        }

        private void lbIlanlarimBaslik3_Click(object sender, EventArgs e)
        {
            kontrol = "tiklandi";
            Kontrol = kontrol;

            DegiskenResim = pictureBox2.ImageLocation;
            DegiskenBaslik = lbIlanlarimBaslik3.Text;
            DegiskenTur = lbIlanlarimTur3.Text;
            DegiskenIrk = lbIlanlarimIrk3.Text;
            DegiskenYas = lbIlanlarimYas3.Text;
            DegiskenCinsiyet = lbIlanlarimCinsiyet3.Text;

            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            con.Open();
            com.Connection = con;
            com.CommandText = "select ResimKonumu,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,KullaniciNo from tbl_Ilanlar where ResimKonumu = '" + DegiskenResim + "' and IlanBaslik = '" + DegiskenBaslik + "' and HayvanTuru = '" + DegiskenTur + "' and HayvanIrk = '" + DegiskenIrk + "' and HayvanYas = '" + DegiskenYas + "' and HayvanCinsiyet = '" + DegiskenCinsiyet + "'";

            using (SqlDataReader dr = com.ExecuteReader())
            {
                if (dr.Read())
                {
                    var resimKonum3 = dr.GetString(0);
                    /*MessageBox.Show(resimKonum1);*/ // denemek için kullanılmıştır
                    string ilanBaslik3 = dr.GetString(1);
                    string ilanTur3 = dr.GetString(2);
                    string ilanIrk3 = dr.GetString(3);
                    string ilanYas3 = dr.GetString(4);
                    string ilanCinsiyet3 = dr.GetString(5);
                    DegiskenId = dr.GetInt32(6);
                    Sahiplen shpln = new Sahiplen();
                    shpln.pbSahiplenResim.ImageLocation = resimKonum3;
                    shpln.lbSahiplenBaslik.Text = ilanBaslik3;
                    shpln.lbSahiplenTur.Text = ilanTur3;
                    shpln.lbSahiplenIrk.Text = ilanIrk3;
                    shpln.lbSahiplenYas.Text = ilanYas3;
                    shpln.lbSahiplenCinsiyet.Text = ilanCinsiyet3;
                }
                con.Close();
            }
            this.Hide();
            Sahiplen sahiplen = new Sahiplen();
            sahiplen.btSahiplen.Hide();
            sahiplen.ShowDialog();
        }

        private void lbIlanlarimBaslik4_Click(object sender, EventArgs e)
        {
            kontrol = "tiklandi";
            Kontrol = kontrol;

            DegiskenResim = pictureBox3.ImageLocation;
            DegiskenBaslik = lbIlanlarimBaslik4.Text;
            DegiskenTur = lbIlanlarimTur4.Text;
            DegiskenIrk = lbIlanlarimIrk4.Text;
            DegiskenYas = lbIlanlarimYas4.Text;
            DegiskenCinsiyet = lbIlanlarimCinsiyet4.Text;

            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            con.Open();
            com.Connection = con;
            com.CommandText = "select ResimKonumu,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,KullaniciNo from tbl_Ilanlar where ResimKonumu = '" + DegiskenResim + "' and IlanBaslik = '" + DegiskenBaslik + "' and HayvanTuru = '" + DegiskenTur + "' and HayvanIrk = '" + DegiskenIrk + "' and HayvanYas = '" + DegiskenYas + "' and HayvanCinsiyet = '" + DegiskenCinsiyet + "'";

            using (SqlDataReader dr = com.ExecuteReader())
            {
                if (dr.Read())
                {
                    var resimKonum4 = dr.GetString(0);
                    /*MessageBox.Show(resimKonum1);*/ // denemek için kullanılmıştır
                    string ilanBaslik4 = dr.GetString(1);
                    string ilanTur4 = dr.GetString(2);
                    string ilanIrk4 = dr.GetString(3);
                    string ilanYas4 = dr.GetString(4);
                    string ilanCinsiyet4 = dr.GetString(5);
                    DegiskenId = dr.GetInt32(6);
                    Sahiplen shpln = new Sahiplen();
                    shpln.pbSahiplenResim.ImageLocation = resimKonum4;
                    shpln.lbSahiplenBaslik.Text = ilanBaslik4;
                    shpln.lbSahiplenTur.Text = ilanTur4;
                    shpln.lbSahiplenIrk.Text = ilanIrk4;
                    shpln.lbSahiplenYas.Text = ilanYas4;
                    shpln.lbSahiplenCinsiyet.Text = ilanCinsiyet4;
                }
                con.Close();
            }
            this.Hide();
            Sahiplen sahiplen = new Sahiplen();
            sahiplen.btSahiplen.Hide();
            sahiplen.ShowDialog();
        }

        private void lbIlanlarimBaslik5_Click(object sender, EventArgs e)
        {
            kontrol = "tiklandi";
            Kontrol = kontrol;

            DegiskenResim = pictureBox4.ImageLocation;
            DegiskenBaslik = lbIlanlarimBaslik5.Text;
            DegiskenTur = lbIlanlarimTur5.Text;
            DegiskenIrk = lbIlanlarimIrk5.Text;
            DegiskenYas = lbIlanlarimYas5.Text;
            DegiskenCinsiyet = lbIlanlarimCinsiyet5.Text;

            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            con.Open();
            com.Connection = con;
            com.CommandText = "select ResimKonumu,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,KullaniciNo from tbl_Ilanlar where ResimKonumu = '" + DegiskenResim + "' and IlanBaslik = '" + DegiskenBaslik + "' and HayvanTuru = '" + DegiskenTur + "' and HayvanIrk = '" + DegiskenIrk + "' and HayvanYas = '" + DegiskenYas + "' and HayvanCinsiyet = '" + DegiskenCinsiyet + "'";

            using (SqlDataReader dr = com.ExecuteReader())
            {
                if (dr.Read())
                {
                    var resimKonum5 = dr.GetString(0);
                    /*MessageBox.Show(resimKonum1);*/ // denemek için kullanılmıştır
                    string ilanBaslik5 = dr.GetString(1);
                    string ilanTur5 = dr.GetString(2);
                    string ilanIrk5 = dr.GetString(3);
                    string ilanYas5 = dr.GetString(4);
                    string ilanCinsiyet5 = dr.GetString(5);
                    DegiskenId = dr.GetInt32(6);
                    Sahiplen shpln = new Sahiplen();
                    shpln.pbSahiplenResim.ImageLocation = resimKonum5;
                    shpln.lbSahiplenBaslik.Text = ilanBaslik5;
                    shpln.lbSahiplenTur.Text = ilanTur5;
                    shpln.lbSahiplenIrk.Text = ilanIrk5;
                    shpln.lbSahiplenYas.Text = ilanYas5;
                    shpln.lbSahiplenCinsiyet.Text = ilanCinsiyet5;
                }
                con.Close();
            }
            this.Hide();
            Sahiplen sahiplen = new Sahiplen();
            sahiplen.btSahiplen.Hide();
            sahiplen.ShowDialog();
        }

        private void lbIlanlarimBaslik6_Click(object sender, EventArgs e)
        {
            kontrol = "tiklandi";
            Kontrol = kontrol;

            DegiskenResim = pictureBox5.ImageLocation;
            DegiskenBaslik = lbIlanlarimBaslik6.Text;
            DegiskenTur = lbIlanlarimTur6.Text;
            DegiskenIrk = lbIlanlarimIrk6.Text;
            DegiskenYas = lbIlanlarimYas6.Text;
            DegiskenCinsiyet = lbIlanlarimCinsiyet6.Text;

            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            con.Open();
            com.Connection = con;
            com.CommandText = "select ResimKonumu,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,KullaniciNo from tbl_Ilanlar where ResimKonumu = '" + DegiskenResim + "' and IlanBaslik = '" + DegiskenBaslik + "' and HayvanTuru = '" + DegiskenTur + "' and HayvanIrk = '" + DegiskenIrk + "' and HayvanYas = '" + DegiskenYas + "' and HayvanCinsiyet = '" + DegiskenCinsiyet + "'";

            using (SqlDataReader dr = com.ExecuteReader())
            {
                if (dr.Read())
                {
                    var resimKonum6 = dr.GetString(0);
                    /*MessageBox.Show(resimKonum1);*/ // denemek için kullanılmıştır
                    string ilanBaslik6 = dr.GetString(1);
                    string ilanTur6 = dr.GetString(2);
                    string ilanIrk6 = dr.GetString(3);
                    string ilanYas6 = dr.GetString(4);
                    string ilanCinsiyet6 = dr.GetString(5);
                    DegiskenId = dr.GetInt32(6);
                    Sahiplen shpln = new Sahiplen();
                    shpln.pbSahiplenResim.ImageLocation = resimKonum6;
                    shpln.lbSahiplenBaslik.Text = ilanBaslik6;
                    shpln.lbSahiplenTur.Text = ilanTur6;
                    shpln.lbSahiplenIrk.Text = ilanIrk6;
                    shpln.lbSahiplenYas.Text = ilanYas6;
                    shpln.lbSahiplenCinsiyet.Text = ilanCinsiyet6;
                }
                con.Close();
            }
            this.Hide();
            Sahiplen sahiplen = new Sahiplen();
            sahiplen.btSahiplen.Hide();
            sahiplen.ShowDialog();
        }
    }
}
