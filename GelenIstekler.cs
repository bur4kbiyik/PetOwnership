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
    public partial class GelenIstekler : Form
    {

        public string KullaniciAdi { get; set; }
        public GelenIstekler()
        {
            InitializeComponent();
        }

        PictureBox[] pictureBoxs = new PictureBox[3];
        Label[] ilanBasliklari = new Label[3];
        Label[] ilanTurleri = new Label[3];
        Label[] ilanIrklari = new Label[3];
        Label[] ilanYaslari = new Label[3];
        Label[] ilanCinsiyetleri = new Label[3];
        Label[] ilanSahiplenmekIsteyenAd = new Label[3];
        Label[] ilanSahiplenmekIsteyenSoyad = new Label[3];
        Label[] ilanSahiplenmekIsteyenTelNo = new Label[3];
        private void btGelenIsteklerHesap_Click(object sender, EventArgs e)
        {
            cmHesap.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void ilanlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ilanlarim ilanlarim = new Ilanlarim();
            ilanlarim.ShowDialog();
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zaten gelen istekler sayfasındasınız.");
        }

        private void GelenIstekler_Load(object sender, EventArgs e)
        {
            pictureBoxs[0] = pictureBox0;
            pictureBoxs[1] = pictureBox1;
            pictureBoxs[2] = pictureBox2;

            ilanBasliklari[0] = lbGelenIsteklerBaslik1;
            ilanBasliklari[1] = lbGelenIsteklerBaslik2;
            ilanBasliklari[2] = lbGelenIsteklerBaslik3;

            ilanTurleri[0] = lbGelenIsteklerTur1;
            ilanTurleri[1] = lbGelenIsteklerTur2;
            ilanTurleri[1] = lbGelenIsteklerTur3;

            ilanIrklari[0] = lbGelenIsteklerIrk1;
            ilanIrklari[1] = lbGelenIsteklerIrk2;
            ilanIrklari[2] = lbGelenIsteklerIrk3;

            ilanYaslari[0] = lbGelenIsteklerYas1;
            ilanYaslari[1] = lbGelenIsteklerYas2;
            ilanYaslari[2] = lbGelenIsteklerYas3;

            ilanCinsiyetleri[0] = lbGelenIsteklerCinsiyet1;
            ilanCinsiyetleri[1] = lbGelenIsteklerCinsiyet2;
            ilanCinsiyetleri[2] = lbGelenIsteklerCinsiyet3;

            ilanSahiplenmekIsteyenTelNo[0] = lbIlanSahiniTel1;
            ilanSahiplenmekIsteyenTelNo[1] = lbIlanSahiniTel2;
            ilanSahiplenmekIsteyenTelNo[2] = lbIlanSahiniTel3;

            ilanSahiplenmekIsteyenAd[0] = lbIlanSahibiAd1;
            ilanSahiplenmekIsteyenAd[1] = lbIlanSahibiAd2;
            ilanSahiplenmekIsteyenAd[2] = lbIlanSahibiAd3;

            ilanSahiplenmekIsteyenSoyad[0] = lbIlanSahibiSoyad1;
            ilanSahiplenmekIsteyenSoyad[1] = lbIlanSahibiSoyad2;
            ilanSahiplenmekIsteyenSoyad[2] = lbIlanSahibiSoyad3;

            KullaniciAdi = Anasayfa.KullaniciAdi;
            btGelenIsteklerHesap.Text = KullaniciAdi;

            int sayac = 0;

            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            con.Open();
            com.Connection = con;
            com.CommandText = "select SahiplenecekAdi,SahiplenecekSoyadi,SahiplenecekTelNo,IlanBaslik,IlanTur,IlanIrk,IlanYas,IlanCinsiyet,ResimKonumu from tbl_Sahiplenecek where IlanSahibiId in (select KullaniciId from tbl_Kullanici where KullaniciAdi = '"+KullaniciAdi+"')";

            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    string sahiplenmekIsteyenAd = dr.GetString(0);
                    string sahiplenmekIsteyenSoyad = dr.GetString(1);
                    string sahiplenmekIsteyenTelNo = dr.GetString(2);
                    string ilanBasligi = dr.GetString(3);
                    string ilanTuru = dr.GetString(4);
                    string ilanIrki = dr.GetString(5);
                    string ilanYasi = dr.GetString(6);
                    string ilanCinsiyeti = dr.GetString(7);
                    var resimYolu = dr.GetString(8);

                    ilanSahiplenmekIsteyenAd[sayac].Text = sahiplenmekIsteyenAd;
                    ilanSahiplenmekIsteyenSoyad[sayac].Text = sahiplenmekIsteyenSoyad;
                    ilanSahiplenmekIsteyenTelNo[sayac].Text = sahiplenmekIsteyenTelNo;
                    ilanBasliklari[sayac].Text = ilanBasligi;
                    ilanTurleri[sayac].Text = ilanTuru;
                    ilanIrklari[sayac].Text = ilanIrki;
                    ilanYaslari[sayac].Text = ilanYasi;
                    ilanCinsiyetleri[sayac].Text = ilanCinsiyeti;
                    pictureBoxs[sayac].ImageLocation = resimYolu;

                    sayac++;
                }
            }
            con.Close();
        }
    }
}
