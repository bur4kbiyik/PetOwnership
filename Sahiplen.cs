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
        string tarihvesaat = DateTime.Now.ToString();
        public int IlanID { get; set; }
        public string KullaniciAdi { get; set; }
        public int DegiskenId { get; set; }
        public string DegiskenResim { get; set; }
        public string DegiskenBaslik { get; set; }
        public string DegiskenTur { get; set; }
        public string DegiskenIrk { get; set; }
        public string DegiskenYas { get; set; }
        public string DegiskenCinsiyet { get; set; }
        public string Yorum { get; set; }

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
        //bekle bi dk
        private void btSahiplenHesap_Click(object sender, EventArgs e)
        {
            cmHesap.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void Sahiplen_Load(object sender, EventArgs e)
        {
            string deneme = "sdf";

            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            //con.Open();
            //com.Connection = con;
            //com.CommandText = "select * from tbl_Mesajlar where IlanId = '" + IlanID + "' and Kimden ='" + KullaniciAdi + "'";
            //using (SqlDataReader dr = com.ExecuteReader())
            //{
            //    if (dr.Read())
            //    {

            //        string SahiplenecekMesaj = dr.GetString(1);
            //        string İlanSahibiMesaj = dr.GetString(2);
            //        string Mesajİcerik = dr.GetString(3);
            //        listBox1.Items.Add(KullaniciAdi + " : " + Mesajİcerik);
            //    }
            //    else
            //    {
            //        label5.Text = "Bu ilan sahibine bir mesajınız bulunmamakta.";
            //    }
            //    con.Close();
            //}



            //MessageBox.Show(tarihvesaat);

            KullaniciAdi = Anasayfa.KullaniciAdi;
            btSahiplenHesap.Text = KullaniciAdi;



            //SqlCommand com = new SqlCommand();
            //SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tbl_Kullanici where KullaniciAdi='" + KullaniciAdi + "'";
            using (SqlDataReader dr = com.ExecuteReader())
            {
                if (dr.Read())
                {
                    string veritabaniKullaniciAdi = dr.GetString(1);
                    string veritabaniSifre = dr.GetString(2);
                    string veritabaniAdi = dr.GetString(3);
                    string veritabaniSoyadi = dr.GetString(4);
                    string veritabaniMail = dr.GetString(5);
                    string veritabaniTelefon = dr.GetString(6);
                    KullaniciAdi = Anasayfa.KullaniciAdi;

                    tbSahiplenKadi.Text = veritabaniKullaniciAdi;
                    btSahiplenHesap.Text = KullaniciAdi;
                    tbSahiplenAdi.Text = veritabaniAdi;
                    tbSahiplenSoyadi.Text = veritabaniSoyadi;
                    tbTelNo.Text = veritabaniTelefon;
                }
                con.Close();
            }
            tbSahiplenKadi.Text = KullaniciAdi;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            tbSahiplenAdi.Visible = false;
            tbSahiplenSoyadi.Visible = false;
            tbTelNo.Visible = false;
            tbSahiplenKadi.Visible = false;
            //MessageBox.Show(DegiskenResim); // denemek için kullanılmıştır
            //MessageBox.Show(DegiskenBaslik);
            //MessageBox.Show(DegiskenTur);
            //MessageBox.Show(DegiskenIrk);
            //MessageBox.Show(DegiskenYas);
            //MessageBox.Show(DegiskenCinsiyet);
            //MessageBox.Show(DegiskenId.ToString());

            if (Anasayfa.Kontrol == "tiklandi")
            {
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

            if (Ilanlarim.Kontrol == "tiklandi")
            {
                DegiskenResim = Ilanlarim.DegiskenResim;
                DegiskenBaslik = Ilanlarim.DegiskenBaslik;
                DegiskenTur = Ilanlarim.DegiskenTur;
                DegiskenIrk = Ilanlarim.DegiskenIrk;
                DegiskenYas = Ilanlarim.DegiskenYas;
                DegiskenCinsiyet = Ilanlarim.DegiskenCinsiyet;
                DegiskenId = Ilanlarim.DegiskenId;

                pbSahiplenResim.ImageLocation = DegiskenResim;
                lbSahiplenBaslik.Text = DegiskenBaslik;
                lbSahiplenTur.Text = DegiskenTur;
                lbSahiplenIrk.Text = DegiskenIrk;
                lbSahiplenYas.Text = DegiskenYas;
                lbSahiplenCinsiyet.Text = DegiskenCinsiyet;
            }

            con.Open();
            com.Connection = con;
            com.CommandText = "select IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,IlanDurumu,ResimKonumu from tbl_Ilanlar where IlanBaslik = '" + lbSahiplenBaslik.Text + "' and HayvanTuru = '" + lbSahiplenTur.Text + "'and HayvanIrk = '" + lbSahiplenIrk.Text + "' and HayvanYas = '" + lbSahiplenYas.Text + "' and HayvanCinsiyet = '" + lbSahiplenCinsiyet.Text + "'and ResimKonumu = '" + pbSahiplenResim.ImageLocation + "'";
            using (SqlDataReader dr = com.ExecuteReader())
            {
                if (dr.Read())
                {
                    string ilanDurumu = dr.GetString(5);

                    if (Convert.ToChar(ilanDurumu) == 'P')
                    {
                        btSahiplen.Hide();
                        lbSahiplendirildi.Visible = true;
                    }
                }
                con.Close();
            }

            SqlCommand com2 = new SqlCommand();
            SqlConnection con2 = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            con2.Open();
            com2.Connection = con2;
            com2.CommandText = "select IlanId,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,IlanDurumu,ResimKonumu from tbl_Ilanlar where IlanBaslik = '" + lbSahiplenBaslik.Text + "' and HayvanTuru = '" + lbSahiplenTur.Text + "'and HayvanIrk = '" + lbSahiplenIrk.Text + "' and HayvanYas = '" + lbSahiplenYas.Text + "' and HayvanCinsiyet = '" + lbSahiplenCinsiyet.Text + "'and ResimKonumu = '" + pbSahiplenResim.ImageLocation + "'";
            using (SqlDataReader dr2 = com2.ExecuteReader())
            {


                if (dr2.Read())
                {
                    int ilanid = dr2.GetInt32(0);
                    IlanID = ilanid;
                    dr2.Close();

                    SqlCommand com3 = new SqlCommand();
                    com3.Connection = con2;
                    com3.CommandText = "select * from tbl_Mesajlar where IlanId in (select IlanId from tbl_Ilanlar where IlanId = " + ilanid + ")";
                    SqlDataReader dr3 = com3.ExecuteReader();
                    if (dr3.Read())
                    {
                        string kimden = dr3.GetString(1);
                        string kime = dr3.GetString(2);
                        string mesaj = dr3.GetString(3);



                        DateTime tarihvesaat = dr3.GetDateTime(4);
                        MessageBox.Show(tarihvesaat.ToString());
                        dr3.Close();
                    }
                }
                con2.Close();

            }

            // Kullanıcı Mesaj Gönderdiğinde eklenecek olan konsept > listBox1.Items.Add(KullaniciAdi+" : "+"a" + i);
            //SqlCommand com = new SqlCommand();
            //SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from tbl_Mesajlar where IlanId = '" + IlanID + "' and kimden='" + KullaniciAdi + " '  ";
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {


                    string SahiplenecekMesaj = dr.GetString(1);

                    string Mesajİcerik = dr.GetString(3);
                    string sahip = dr.GetString(2);
                    sahip = sahip.TrimEnd();
                    //İlan sahibi olmayan
                    listBox1.Items.Add(SahiplenecekMesaj + " : " + Mesajİcerik);



                    if (KullaniciAdi == sahip)
                    {
                        dr.Close();
                        con.Close();
                        con.Open();
                        com2.Connection = con;
                        com2.CommandText = "select * from tbl_Mesajlar where IlanId = '" + IlanID + "'  ";
                        using (SqlDataReader dr2 = com2.ExecuteReader())
                        {
                            while (dr2.Read())
                            {
                                SahiplenecekMesaj = dr2.GetString(1);

                                Mesajİcerik = dr2.GetString(3);
                                string sahip2 = dr2.GetString(2);
                                sahip = sahip2.TrimEnd();
                                //İlan Sahibi
                                listBox1.Items.Add(SahiplenecekMesaj + " : " + Mesajİcerik);

                            }
                        }
                        break;
                    }

                    else
                    {
                        MessageBox.Show("SEN BU İLANI HAK ETMİYORSUN");
                    }



                }
                //else
                //{
                //    label5.Text = "Bu ilan sahibine bir mesajınız bulunmamakta.";
                //}
                con.Close();
            }



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
                    com2.CommandText = "select * from tbl_Kullanici where KullaniciAdi = '" + KullaniciAdi + "' and Adi = '" + tbSahiplenAdi.Text + "' and Soyadi = '" + tbSahiplenSoyadi.Text + "' and TelefonNo = '" + tbTelNo.Text + "'";
                    SqlDataReader dr2 = com2.ExecuteReader();

                    if (dr2.Read())
                    {
                        SqlConnection con3 = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
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
                                    ilantur == lbSahiplenTur.Text && ilanirk == lbSahiplenIrk.Text && kullaniciadi == KullaniciAdi &&
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

        private void btYorumYap_Click(object sender, EventArgs e)
        {
            Yorum = tbYorumYap.Text;

            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            con.Open();
            com.Connection = con;
            com.CommandText = "select IlanId,ResimKonumu,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet from tbl_Ilanlar where ResimKonumu = '" + DegiskenResim + "' and IlanBaslik = '" + DegiskenBaslik + "' and HayvanTuru = '" + DegiskenTur + "' and HayvanIrk = '" + DegiskenIrk + "' and HayvanYas = '" + DegiskenYas + "' and HayvanCinsiyet = '" + DegiskenCinsiyet + "'";

            using (SqlDataReader dr = com.ExecuteReader())
            {
                if (dr.Read())
                {
                    int ilanId = dr.GetInt32(0);
                    //MessageBox.Show(ilanId.ToString()); // veri çekip çekmediğini kontrol ettim
                    //var resimKonum = dr.GetString(1);
                    //string ilanBaslik = dr.GetString(2);
                    //string hayvanTur = dr.GetString(3);
                    //string hayvanIrk = dr.GetString(4);
                    //string hayvanYas = dr.GetString(5);
                    //string hayvanCinsiyet = dr.GetString(6);
                    dr.Close();

                    SqlCommand com2 = new SqlCommand();
                    com2.Connection = con;
                    com2.CommandText = "select KullaniciAdi from tbl_Kullanici where KullaniciId in (select KullaniciNo from tbl_Ilanlar where ResimKonumu = '" + DegiskenResim + "' and IlanBaslik = '" + DegiskenBaslik + "' and HayvanTuru = '" + DegiskenTur + "' and HayvanIrk = '" + DegiskenIrk + "' and HayvanYas = '" + DegiskenYas + "' and HayvanCinsiyet = '" + DegiskenCinsiyet + "')";
                    SqlDataReader dr2 = com2.ExecuteReader();

                    if (dr2.Read())
                    {
                        string ilanSahibiKAdi = dr2.GetString(0).ToString();
                        //MessageBox.Show(ilanSahibiKAdi.ToString()); // veri çekip çekmediği kontrol edildi
                        dr2.Close();

                        SqlCommand com3 = new SqlCommand();// Kullanıcı adı (İlanı talep eden) -> Kimden  
                        com3.Connection = con;             // Kime (İlan sahibi ) -> ilanSahibiKAdi
                        com3.CommandText = "insert into tbl_Mesajlar (Kimden,Kime,Mesaj,MesajTarihiveSaati,IlanId) values ('" + KullaniciAdi + "','" + ilanSahibiKAdi + "','" + Yorum + "','" + tarihvesaat + "'," + ilanId + ")";
                        SqlDataAdapter da = new SqlDataAdapter();
                        com3.ExecuteNonQuery();

                        MessageBox.Show("Mesaj Gönderildi!");
                    }
                }
            }
            con.Close();
        }
    }
}
