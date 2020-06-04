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
    public partial class AramaSonuc : Form
    {
        PictureBox[] pictureBoxs = new PictureBox[6];
        Label[] ilanBasliklari = new Label[6];
        Label[] rastgeleTurleri = new Label[6];
        Label[] rastgeleIrklari = new Label[6];
        Label[] rastgeleYaslari = new Label[6];
        Label[] rastgeleCinsiyetleri = new Label[6];
        public string KullaniciAdi { get; set; }
        public static string AramaSonucTur { get; set; }
        public static string AramaSonucIrk { get; set; }
        public static string AramaSonucYas { get; set; }
        public static string AramaSonucCinsiyet { get; set; }
        public static int DegiskenId { get; set; }
        public static string DegiskenResim { get; set; }
        public static string DegiskenBaslik { get; set; }
        public static string DegiskenTur { get; set; }
        public static string DegiskenIrk { get; set; }
        public static string DegiskenYas { get; set; }
        public static string DegiskenCinsiyet { get; set; }
        public AramaSonuc()
        {
            InitializeComponent();
        }

        private void btHesap_Click(object sender, EventArgs e)
        {
            cmHesap.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void AramaSonuc_Load(object sender, EventArgs e)
        {
            KullaniciAdi = Anasayfa.KullaniciAdi;
            btHesap.Text = KullaniciAdi;

            AramaSonucTur = GelismisArama.AramaTur;
            AramaSonucIrk = GelismisArama.AramaIrk;
            AramaSonucYas = GelismisArama.AramaYas;
            AramaSonucCinsiyet = GelismisArama.AramaCinsiyet;

            pictureBoxs[0] = pictureBox1;
            pictureBoxs[1] = pictureBox2;
            pictureBoxs[2] = pictureBox3;
            pictureBoxs[3] = pictureBox4;
            pictureBoxs[4] = pictureBox5;
            pictureBoxs[5] = pictureBox6;

            ilanBasliklari[0] = lbRastgeleBaslik1;
            ilanBasliklari[1] = lbRastgeleBaslik2;
            ilanBasliklari[2] = lbRastgeleBaslik3;
            ilanBasliklari[3] = lbRastgeleBaslik4;
            ilanBasliklari[4] = lbRastgeleBaslik5;
            ilanBasliklari[5] = lbRastgeleBaslik6;

            rastgeleTurleri[0] = lbRastgeleTur1;
            rastgeleTurleri[1] = lbRastgeleTur2;
            rastgeleTurleri[2] = lbRastgeleTur3;
            rastgeleTurleri[3] = lbRastgeleTur4;
            rastgeleTurleri[4] = lbRastgeleTur5;
            rastgeleTurleri[5] = lbRastgeleTur6;

            rastgeleIrklari[0] = lbRastgeleIrk1;
            rastgeleIrklari[1] = lbRastgeleIrk2;
            rastgeleIrklari[2] = lbRastgeleIrk3;
            rastgeleIrklari[3] = lbRastgeleIrk4;
            rastgeleIrklari[4] = lbRastgeleIrk5;
            rastgeleIrklari[5] = lbRastgeleIrk6;

            rastgeleYaslari[0] = lbRastgeleYas1;
            rastgeleYaslari[1] = lbRastgeleYas2;
            rastgeleYaslari[2] = lbRastgeleYas3;
            rastgeleYaslari[3] = lbRastgeleYas4;
            rastgeleYaslari[4] = lbRastgeleYas5;
            rastgeleYaslari[5] = lbRastgeleYas6;

            rastgeleCinsiyetleri[0] = lbRastgeleCinsiyet1;
            rastgeleCinsiyetleri[1] = lbRastgeleCinsiyet2;
            rastgeleCinsiyetleri[2] = lbRastgeleCinsiyet3;
            rastgeleCinsiyetleri[3] = lbRastgeleCinsiyet4;
            rastgeleCinsiyetleri[4] = lbRastgeleCinsiyet5;
            rastgeleCinsiyetleri[5] = lbRastgeleCinsiyet6;
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            con.Open();
            com.CommandText = "select IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,ResimKonumu from tbl_Ilanlar where HayvanTuru like '%"+AramaSonucTur+"%' and HayvanIrk like '%"+AramaSonucIrk+"%' and HayvanYas like '%"+AramaSonucYas+"%' and HayvanCinsiyet like '%"+AramaSonucCinsiyet+ "%' and KullaniciNo not in (select KullaniciId from tbl_Kullanici where KullaniciAdi = '"+KullaniciAdi+"')";
            using (SqlDataReader dr = com.ExecuteReader())
            {
                int sayac = 0;
                while (dr.Read())
                {
                    if (AramaSonucTur != null)
                    {
                        string baslik = dr.GetString(0);
                        string tur = dr.GetString(1);
                        string irk = dr.GetString(2);
                        string yas = dr.GetString(3);
                        string cinsiyet = dr.GetString(4);
                        string resim = dr.GetString(5);

                        pictureBoxs[sayac].ImageLocation = resim;
                        ilanBasliklari[sayac].Text = baslik;
                        rastgeleTurleri[sayac].Text = tur;
                        rastgeleIrklari[sayac].Text = irk;
                        rastgeleYaslari[sayac].Text = yas;
                        rastgeleCinsiyetleri[sayac].Text = cinsiyet;

                        sayac++;
                    }
                    
                }
                dr.Close();
            }
            con.Close();
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
            anasayfa.lbGelismisArama.Hide();
            anasayfa.ShowDialog();
        }

        private void gelenIstekler_Click(object sender, EventArgs e)
        {
            this.Hide();
            GelenIstekler gi = new GelenIstekler();
            gi.ShowDialog();
        }

        private void ilanVer_Click(object sender, EventArgs e)
        {
            this.Hide();
            IlanVer ilanVerSayfa = new IlanVer();
            ilanVerSayfa.btHesapIlanVer.Text = btHesap.Text;
            ilanVerSayfa.ShowDialog();
        }

        private void ilanlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ilanlarim ilanlarim = new Ilanlarim();
            ilanlarim.ShowDialog();
        }
        public static string Kontrol { get; set; }
        string kontrol = "";
        private void lbRastgeleBaslik1_Click(object sender, EventArgs e)
        {
            kontrol = "tiklandi";
            Kontrol = kontrol;
            DegiskenResim = pictureBox1.ImageLocation;
            /*MessageBox.Show(DegiskenResim);*/ // denemek için kullanılmıştır
            DegiskenBaslik = lbRastgeleBaslik1.Text;
            DegiskenTur = lbRastgeleTur1.Text;
            DegiskenIrk = lbRastgeleIrk1.Text;
            DegiskenYas = lbRastgeleYas1.Text;
            DegiskenCinsiyet = lbRastgeleCinsiyet1.Text;

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
                    //MessageBox.Show(resimKonumu1); // denemek için kullanılmıştır
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

            Sahiplen sahiplen = new Sahiplen();
            this.Hide();
            sahiplen.ShowDialog();
        }
        private void lbRastgeleBaslik2_Click(object sender, EventArgs e)
        {
            kontrol = "tiklandi";
            Kontrol = kontrol;
            DegiskenResim = pictureBox2.ImageLocation;
            /*MessageBox.Show(DegiskenResim);*/ // denemek için kullanılmıştır
            DegiskenBaslik = lbRastgeleBaslik2.Text;
            DegiskenTur = lbRastgeleTur2.Text;
            DegiskenIrk = lbRastgeleIrk2.Text;
            DegiskenYas = lbRastgeleYas2.Text;
            DegiskenCinsiyet = lbRastgeleCinsiyet2.Text;

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
                    //MessageBox.Show(resimKonumu1); // denemek için kullanılmıştır
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

            Sahiplen sahiplen = new Sahiplen();
            this.Hide();
            sahiplen.ShowDialog();
        }

        private void lbRastgeleBaslik3_Click(object sender, EventArgs e)
        {
            kontrol = "tiklandi";
            Kontrol = kontrol;
            DegiskenResim = pictureBox3.ImageLocation;
            /*MessageBox.Show(DegiskenResim);*/ // denemek için kullanılmıştır
            DegiskenBaslik = lbRastgeleBaslik3.Text;
            DegiskenTur = lbRastgeleTur3.Text;
            DegiskenIrk = lbRastgeleIrk3.Text;
            DegiskenYas = lbRastgeleYas3.Text;
            DegiskenCinsiyet = lbRastgeleCinsiyet3.Text;

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
                    //MessageBox.Show(resimKonumu1); // denemek için kullanılmıştır
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

            Sahiplen sahiplen = new Sahiplen();
            this.Hide();
            sahiplen.ShowDialog();
        }
        private void lbRastgeleBaslik4_Click(object sender, EventArgs e)
        {
            kontrol = "tiklandi";
            Kontrol = kontrol;
            DegiskenResim = pictureBox4.ImageLocation;
            /*MessageBox.Show(DegiskenResim);*/ // denemek için kullanılmıştır
            DegiskenBaslik = lbRastgeleBaslik4.Text;
            DegiskenTur = lbRastgeleTur4.Text;
            DegiskenIrk = lbRastgeleIrk4.Text;
            DegiskenYas = lbRastgeleYas4.Text;
            DegiskenCinsiyet = lbRastgeleCinsiyet4.Text;

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
                    //MessageBox.Show(resimKonumu1); // denemek için kullanılmıştır
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

            Sahiplen sahiplen = new Sahiplen();
            this.Hide();
            sahiplen.ShowDialog();
        }
        private void lbRastgeleBaslik5_Click(object sender, EventArgs e)
        {
            kontrol = "tiklandi";
            Kontrol = kontrol;
            DegiskenResim = pictureBox5.ImageLocation;
            /*MessageBox.Show(DegiskenResim);*/ // denemek için kullanılmıştır
            DegiskenBaslik = lbRastgeleBaslik5.Text;
            DegiskenTur = lbRastgeleTur5.Text;
            DegiskenIrk = lbRastgeleIrk5.Text;
            DegiskenYas = lbRastgeleYas5.Text;
            DegiskenCinsiyet = lbRastgeleCinsiyet5.Text;

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
                    //MessageBox.Show(resimKonumu1); // denemek için kullanılmıştır
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

            Sahiplen sahiplen = new Sahiplen();
            this.Hide();
            sahiplen.ShowDialog();
        }

        private void lbRastgeleBaslik6_Click(object sender, EventArgs e)
        {
            kontrol = "tiklandi";
            Kontrol = kontrol;
            DegiskenResim = pictureBox6.ImageLocation;
            /*MessageBox.Show(DegiskenResim);*/ // denemek için kullanılmıştır
            DegiskenBaslik = lbRastgeleBaslik6.Text;
            DegiskenTur = lbRastgeleTur6.Text;
            DegiskenIrk = lbRastgeleIrk6.Text;
            DegiskenYas = lbRastgeleYas6.Text;
            DegiskenCinsiyet = lbRastgeleCinsiyet6.Text;

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
                    //MessageBox.Show(resimKonumu1); // denemek için kullanılmıştır
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

            Sahiplen sahiplen = new Sahiplen();
            this.Hide();
            sahiplen.ShowDialog();
        }
    }
}
