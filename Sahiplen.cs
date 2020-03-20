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
    public partial class Sahiplen : Form
    {
        public int DegiskenId { get; set; }
        public string KullaniciAdi { get; set; }
        public string DegiskenResim { get; set; }
        public string DegiskenBaslik { get; set; }
        public string DegiskenTur { get; set; }
        public string DegiskenIrk { get; set; }
        public string DegiskenYas { get; set; }
        public string DegiskenCinsiyet { get; set; }
        public Sahiplen()
        {
            InitializeComponent();
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

        private void btSahiplenHesap_Click(object sender, EventArgs e)
        {
            cmHesap.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void Sahiplen_Load(object sender, EventArgs e)
        {
            KullaniciAdi = Anasayfa.KullaniciAdi;
            btSahiplenHesap.Text = KullaniciAdi;

            //MessageBox.Show(DegiskenResim); // denemek için kullanılmıştır
            //MessageBox.Show(DegiskenBaslik);
            //MessageBox.Show(DegiskenTur);
            //MessageBox.Show(DegiskenIrk);
            //MessageBox.Show(DegiskenYas);
            //MessageBox.Show(DegiskenCinsiyet);
            //MessageBox.Show(DegiskenId.ToString());

            DegiskenResim = Anasayfa.DegiskenResim;
            DegiskenBaslik = Anasayfa.DegiskenBaslik;
            DegiskenTur = Anasayfa.DegiskenTur;
            DegiskenIrk = Anasayfa.DegiskenIrk;
            DegiskenYas = Anasayfa.DegiskenYas;
            DegiskenCinsiyet = Anasayfa.DegiskenCinsiyet;
            DegiskenId = Anasayfa.DegiskenId;

            pbSahiplenResim.ImageLocation = DegiskenResim;
            lbSahiplenBaslik.Text = DegiskenBaslik;
            lbSahiplenTur.Text = DegiskenTur;
            lbSahiplenIrk.Text = DegiskenIrk;
            lbSahiplenYas.Text = DegiskenYas;
            lbSahiplenCinsiyet.Text = DegiskenCinsiyet; 
        }

        private void ilanVer_Click(object sender, EventArgs e)
        {
            this.Hide();
            IlanVer ilanVerSayfa = new IlanVer();
            ilanVerSayfa.ShowDialog();
        }

        private void ilanlarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ilanlarim ilanlarim = new Ilanlarim();
            ilanlarim.ShowDialog();
        }

        private void btSahiplen_Click(object sender, EventArgs e)
        {

            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            con.Open();
            com.Connection = con;
            com.CommandText = "select ResimKonumu,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet from tbl_Ilanlar where ResimKonumu = '" + DegiskenResim + "' and IlanBaslik = '" + DegiskenBaslik + "' and HayvanTuru = '" + DegiskenTur + "' and HayvanIrk = '" + DegiskenIrk + "' and HayvanYas = '" + DegiskenYas + "' and HayvanCinsiyet = '" + DegiskenCinsiyet + "'";

            using (SqlDataReader dr = com.ExecuteReader())
            {
                if (dr.Read())
                {
                    var resimKonumu = dr.GetString(0); //yazdığım sorgunun çıktısında ki 0. (yani 1.) kolonu değişkene atıyorum
                    string ilanBaslik = dr.GetString(1);
                    string ilanTuru = dr.GetString(2);
                    string ilanIrk = dr.GetString(3);
                    string ilanYas = dr.GetString(4);
                    string ilanCinsiyet = dr.GetString(5);

                    //MessageBox.Show(ilanBaslik); // veriyi çekiyor mu diye kontrol ediyorum
                    //MessageBox.Show(ilanTuru);
                    //MessageBox.Show(ilanIrk);
                    //MessageBox.Show(ilanYas);
                    //MessageBox.Show(ilanCinsiyet);
                    //MessageBox.Show(resimKonumu);

                    SqlCommand com2 = new SqlCommand();
                    SqlConnection con2 = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
                    con2.Open();
                    com2.Connection = con2;
                    com2.CommandText = "select * from tbl_Kullanici where KullaniciAdi = '" + tbSahiplenKadi.Text + "' and Adi = '" + tbSahiplenAdi.Text + "' and Soyadi = '" + tbSahiplenSoyadi.Text + "' and TelefonNo = '" + tbTelNo.Text + "'";
                    SqlDataReader dr2 = com2.ExecuteReader();

                        if (dr2.Read())
                        {
                        SqlConnection con3= new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
                        con3.Open();

                        string karsilastirma = "select SahiplenecekKadi,IlanBaslik,IlanTur,IlanIrk,IlanYas,IlanCinsiyet,ResimKonumu from tbl_Sahiplenecek";
                        SqlCommand com3 = new SqlCommand(karsilastirma, con3);
                        SqlDataReader reader = com3.ExecuteReader();
                        if (reader.Read())
                        {
                            string kullaniciadi = reader.GetString(0);
                            string ilanbaslik = reader.GetString(1);
                            string ilantur = reader.GetString(2);
                            string ilanirk = reader.GetString(3);
                            string ilanyas = reader.GetString(4);
                            string ilancinsiyet = reader.GetString(5);
                            var resimyol = reader.GetString(6);
                            reader.Close();

                            try
                            {
                                 if (resimyol == pbSahiplenResim.ImageLocation && ilanbaslik == lbSahiplenBaslik.Text &&
                                     ilantur == lbSahiplenTur.Text && ilanirk == lbSahiplenIrk.Text && kullaniciadi == tbSahiplenKadi.Text &&
                                     ilanyas == lbSahiplenYas.Text && ilancinsiyet == lbSahiplenCinsiyet.Text)
                                 {
                                     MessageBox.Show("Aynı ilana birden fazla kez talepte bulunamazsınız.");
                                 }
                                 else
                                 {
                                     string veriEkle = "insert into tbl_Sahiplenecek (SahiplenecekKadi,SahiplenecekAdi,SahiplenecekSoyadi,SahiplenecekTelNo,IlanBaslik,IlanTur,IlanIrk,IlanYas,IlanCinsiyet,ResimKonumu,IlanSahibiId) values('" + tbSahiplenKadi.Text + "','" + tbSahiplenAdi.Text + "','" + tbSahiplenSoyadi.Text + "','" + tbTelNo.Text + "','" + DegiskenBaslik + "','" + DegiskenTur + "','" + DegiskenIrk + "','" + DegiskenYas + "','" + DegiskenCinsiyet + "','" + DegiskenResim + "','" + DegiskenId + "')";
                                     SqlCommand com4 = new SqlCommand(veriEkle, con3);
                                     com4.ExecuteNonQuery();
                                     MessageBox.Show("Talep başarılı!");
                                 }
                            }
                            catch (Exception hata)
                            {
                                MessageBox.Show("Hatalı işlem yaptınız." + hata);
                            }
                            con3.Close();
                        }
                        }
                        else
                        {
                            MessageBox.Show("Bu kullanıcı adına, isime veya numaraya ait kayıtlı kullanıcı bulunmuyor.");
                        }
                    con2.Close();
                }
            }
            con.Close();
        }

        private void gelenIstekler_Click(object sender, EventArgs e)
        {
            this.Hide();
            GelenIstekler gi = new GelenIstekler();
            gi.ShowDialog();
        }

        private void tbTelNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
