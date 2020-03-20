using Petilan.Sayfalar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Petilan
{
    
    public partial class Anasayfa : Form
    {
        PictureBox[] pictureBoxs = new PictureBox[6];
        Label[] rastgeleBasliklari = new Label[6];
        Label[] rastgeleTurleri = new Label[6];
        Label[] rastgeleIrklari = new Label[6];
        Label[] rastgeleYaslari = new Label[6];
        Label[] rastgeleCinsiyetleri = new Label[6];
        public Anasayfa()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btDegistir_Click(object sender, EventArgs e)
        {

        }

        private void btUyeOl_Click(object sender, EventArgs e)
        {
            this.Hide();
            UyeOl uyeOl = new UyeOl();
            uyeOl.ShowDialog();

        }

        private void tbAd_TextChanged(object sender, EventArgs e)
        {

        }
        public static int DegiskenId { get; set; } 
        public static string DegiskenResim { get; set; }
        public static string DegiskenBaslik { get; set; }
        public static string DegiskenTur { get; set; }
        public static string DegiskenIrk { get; set; }
        public static string DegiskenYas { get; set; }
        public static string DegiskenCinsiyet { get; set; }
        public static string KullaniciAdi { get; set; }
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            pictureBoxs[0] = pictureBox1;
            pictureBoxs[1] = pictureBox2;
            pictureBoxs[2] = pictureBox3;
            pictureBoxs[3] = pictureBox4;
            pictureBoxs[4] = pictureBox5;
            pictureBoxs[5] = pictureBox6;

            rastgeleBasliklari[0] = lbRastgeleBaslik1;
            rastgeleBasliklari[1] = lbRastgeleBaslik2;
            rastgeleBasliklari[2] = lbRastgeleBaslik3;
            rastgeleBasliklari[3] = lbRastgeleBaslik4;
            rastgeleBasliklari[4] = lbRastgeleBaslik5;
            rastgeleBasliklari[5] = lbRastgeleBaslik6;

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

        }
        SqlConnection baglanti;
        SqlCommand command;
        SqlDataReader dataReader;

        public static string SetValueForText1 = "";
        private void btGiris_Click(object sender, EventArgs e)
        {

          
            SetValueForText1 = tbKAdiAnasayfa.Text;
            Anasayfa.KullaniciAdi = SetValueForText1;
            
            baglanti = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            command = new SqlCommand();
            baglanti.Open();
            command.Connection = baglanti;
            command.CommandText = "SELECT * FROM tbl_Kullanici where KullaniciAdi='" + KullaniciAdi + "' AND Sifre='" + tbSifreAnasayfa.Text + "'";
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                int sayac = 0;

                baglanti = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
                SqlCommand com = new SqlCommand();
                baglanti.Open();
                com.Connection = baglanti;
                com.CommandText = "select Top(6) ResimKonumu,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet from tbl_Ilanlar where KullaniciNo not in (select KullaniciId from tbl_Kullanici where KullaniciAdi = '" + KullaniciAdi + "') order by IlanId desc";

                using (SqlDataReader dr = com.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var resimCek = dr.GetString(0);
                        string baslikCek = dr.GetString(1);
                        string turCek = dr.GetString(2);
                        string irkCek = dr.GetString(3);
                        string yasCek = dr.GetString(4);
                        string cinsiyetCek = dr.GetString(5);

                        pictureBoxs[sayac].ImageLocation = resimCek;
                        rastgeleBasliklari[sayac].Text = baslikCek;
                        rastgeleTurleri[sayac].Text = turCek;
                        rastgeleIrklari[sayac].Text = irkCek;
                        rastgeleYaslari[sayac].Text = yasCek;
                        rastgeleCinsiyetleri[sayac].Text = cinsiyetCek;

                        //MessageBox.Show(resimCek); // denemek için kullanıldı

                        sayac++;
                    }
                }
                baglanti.Close();

                tbKAdiAnasayfa.Hide();
                tbSifreAnasayfa.Hide();
                label1.Hide();
                label2.Hide();
                btUyeOl.Hide();
                btGiris.Hide();
                adminGiris.Hide();
                btHesap.Visible = true;
                btHesap.Text = tbKAdiAnasayfa.Text;

                //MessageBox.Show(KullaniciAdi); deneme amaçlı kullanıldı
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            baglanti.Close();


            for (int i = 0; i < pictureBoxs.Length; i++)
            {
                pictureBoxs[i].Visible = true;
            }
            for (int i = 0; i < rastgeleBasliklari.Length; i++)
            {
                rastgeleBasliklari[i].Visible = true;
            }
            for (int i = 0; i < rastgeleTurleri.Length; i++)
            {
                rastgeleTurleri[i].Visible = true;
            }
            for (int i = 0; i < rastgeleIrklari.Length; i++)
            {
                rastgeleIrklari[i].Visible = true;
            }
            for (int i = 0; i < rastgeleYaslari.Length; i++)
            {
                rastgeleYaslari[i].Visible = true;
            }
            for (int i = 0; i < rastgeleCinsiyetleri.Length; i++)
            {
                rastgeleCinsiyetleri[i].Visible = true;
            }
        }


        private void btHesap_Click(object sender, EventArgs e)
        {
            cmHesap.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void cmHesap_Opening(object sender, CancelEventArgs e)
        {

        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            tbKAdiAnasayfa.Visible = true;
            tbSifreAnasayfa.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            btUyeOl.Visible = true;
            btGiris.Visible = true;
            for (int i = 0; i < pictureBoxs.Length; i++)
            {
                pictureBoxs[i].Hide();
            }
            for (int i = 0; i < rastgeleBasliklari.Length; i++)
            {
                rastgeleBasliklari[i].Hide();
            }
            for (int i = 0; i < rastgeleTurleri.Length; i++)
            {
                rastgeleTurleri[i].Hide();
            }
            for (int i = 0; i < rastgeleIrklari.Length; i++)
            {
                rastgeleIrklari[i].Hide();
            }
            for (int i = 0; i < rastgeleYaslari.Length; i++)
            {
                rastgeleYaslari[i].Hide();
            }
            for (int i = 0; i < rastgeleCinsiyetleri.Length; i++)
            {
                rastgeleCinsiyetleri[i].Hide();
            }
            btHesap.Hide();
        }

        private void hesapAyarlari_Click(object sender, EventArgs e)
        {

        }

        private void adminGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminGiris adminGiris = new AdminGiris();
            adminGiris.ShowDialog();
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

        private void lbRastgeleBaslik1_Click(object sender, EventArgs e)
        {
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
            }
            this.Hide();
            Sahiplen sahiplen = new Sahiplen();
            sahiplen.ShowDialog();
        }

        private void lbRastgeleBaslik2_Click(object sender, EventArgs e)
        {
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
            }
            this.Hide();
            Sahiplen sahiplen = new Sahiplen();
            sahiplen.ShowDialog();
        }

        private void lbRastgeleBaslik3_Click(object sender, EventArgs e)
        {
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
            }
            this.Hide();
            Sahiplen sahiplen = new Sahiplen();
            sahiplen.ShowDialog();
        }

        private void lbRastgeleBaslik4_Click(object sender, EventArgs e)
        {
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
            }
            this.Hide();
            Sahiplen sahiplen = new Sahiplen();
            sahiplen.ShowDialog();
        }

        private void lbRastgeleBaslik5_Click(object sender, EventArgs e)
        {
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
            }
            this.Hide();
            Sahiplen sahiplen = new Sahiplen();
            sahiplen.ShowDialog();
        }

        private void lbRastgeleBaslik6_Click(object sender, EventArgs e)
        {
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
            }
            this.Hide();
            Sahiplen sahiplen = new Sahiplen();
            sahiplen.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
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
