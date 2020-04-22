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
        public string KullaniciAdi { get; set; }
        public int DegiskenId { get; set; }
        public string DegiskenResim { get; set; }
        public string DegiskenBaslik { get; set; }
        public string DegiskenTur { get; set; }
        public string DegiskenIrk { get; set; }
        public string DegiskenYas { get; set; }
        public string DegiskenCinsiyet { get; set; }
        public string Yorum { get; set; }
        public int IlanId { get; set; }
        public string Kime { get; set; }
        public string Kimden { get; set; }
        public string MesajTarih { get; set; }
        public string Mesaj { get; set; }

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
            //MessageBox.Show(tarihvesaat);

            this.Refresh();

            KullaniciAdi = Anasayfa.KullaniciAdi;
            btSahiplenHesap.Text = KullaniciAdi;

            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");

            //MessageBox.Show(DegiskenResim); // denemek için kullanılmıştır
            //MessageBox.Show(DegiskenBaslik);
            //MessageBox.Show(DegiskenTur);
            //MessageBox.Show(DegiskenIrk);
            //MessageBox.Show(DegiskenYas);
            //MessageBox.Show(DegiskenCinsiyet);
            //MessageBox.Show(DegiskenId.ToString());

            if (Anasayfa.Kontrol2 == "tiklandi")
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

                SqlConnection con2 = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
                SqlCommand com2 = new SqlCommand();
                con2.Open();
                com2.Connection = con2;
                com2.CommandText = "select IlanId,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,IlanDurumu,ResimKonumu from tbl_Ilanlar where IlanBaslik = '" + lbSahiplenBaslik.Text + "' and HayvanTuru = '" + lbSahiplenTur.Text + "'and HayvanIrk = '" + lbSahiplenIrk.Text + "' and HayvanYas = '" + lbSahiplenYas.Text + "' and HayvanCinsiyet = '" + lbSahiplenCinsiyet.Text + "'and ResimKonumu = '" + pbSahiplenResim.ImageLocation + "'";
                SqlDataReader dr2 = com2.ExecuteReader();
                if (dr2.Read())
                {
                    int ilanid = dr2.GetInt32(0);
                    IlanId = ilanid;
                    //MessageBox.Show(IlanId.ToString());
                    dr2.Close();

                    SqlCommand com3 = new SqlCommand();
                    com3.Connection = con2;
                    com3.CommandText = "select * from tbl_Mesajlar";
                    SqlDataReader dr3 = com3.ExecuteReader();
                    while (dr3.Read())
                    {
                        string kimden = dr3.GetString(1);
                        string kime = dr3.GetString(2);
                        string mesaj = dr3.GetString(3);
                        string tarihvesaat = dr3.GetString(4);

                        Kimden = kimden;
                        Kime = kime;
                        Mesaj = mesaj;
                        MesajTarih = tarihvesaat;
                    }

                    dr3.Close();

                    SqlCommand com4satir = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter(com4satir);
                    com4satir.Connection = con2;
                    com4satir.CommandText = "select * from tbl_Mesajlar where IlanId = " + IlanId + " and Kimden = '" + KullaniciAdi + "' or Kimden = '" + Kime + "'";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int satir = dt.Rows.Count;

                    int sayac = 0;

                    SqlCommand com4 = new SqlCommand();
                    com4.Connection = con2;
                    com4.CommandText = "select * from tbl_Mesajlar where IlanId = " + IlanId + " and Kimden = '" + KullaniciAdi + "' or Kimden = '" + Kime + "'";
                    SqlDataReader dr4 = com4.ExecuteReader();
                    while (dr4.Read())
                    {
                        string ozelkimden = dr4.GetString(1);
                        string ozelmesaj = dr4.GetString(3);
                        string ozeltarih = dr4.GetString(4);
                        lbMesajlar.Items.Add(ozelkimden + " > " + ozelmesaj + " > " + ozeltarih);
                        if (satir == sayac)
                        {
                            break;
                        }
                        sayac++;
                    }
                }
                con2.Close();
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

                SqlConnection con2 = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
                SqlCommand com2 = new SqlCommand();
                con2.Open();
                com2.Connection = con2;
                com2.CommandText = "select IlanId,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,IlanDurumu,ResimKonumu from tbl_Ilanlar where IlanBaslik = '" + lbSahiplenBaslik.Text + "' and HayvanTuru = '" + lbSahiplenTur.Text + "'and HayvanIrk = '" + lbSahiplenIrk.Text + "' and HayvanYas = '" + lbSahiplenYas.Text + "' and HayvanCinsiyet = '" + lbSahiplenCinsiyet.Text + "'and ResimKonumu = '" + pbSahiplenResim.ImageLocation + "'";
                SqlDataReader dr2 = com2.ExecuteReader();
                if (dr2.Read())
                {
                    int ilanid = dr2.GetInt32(0);
                    IlanId = ilanid;
                    //MessageBox.Show(IlanId.ToString());
                    dr2.Close();

                    SqlCommand com3satir = new SqlCommand();
                    SqlDataAdapter da = new SqlDataAdapter(com3satir);
                    com3satir.Connection = con2;
                    com3satir.CommandText = "select * from tbl_Mesajlar where IlanId = " + IlanId + "";
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    int satir = dt.Rows.Count;
                    //MessageBox.Show(satir.ToString());

                    int sayac = 0;

                    SqlCommand com3 = new SqlCommand();
                    com3.Connection = con2;
                    com3.CommandText = "select * from tbl_Mesajlar where IlanId = " + IlanId + "";
                    using (SqlDataReader dr3 = com3.ExecuteReader()) 
                    {
                        while (dr3.Read())
                        {
                            string kimden = dr3.GetString(1);
                            string kime = dr3.GetString(2);
                            string mesaj = dr3.GetString(3);
                            string tarihvesaat = dr3.GetString(4);
                            lbMesajlar.Items.Add(kimden + " > " + mesaj + " > " + tarihvesaat);
                            if (sayac == satir)
                            {
                                break;
                            }
                            sayac++;
                        }
                        dr3.Close();
                    }
                }
                con2.Close();
            }
            con.Open();
            com.Connection = con;
            com.CommandText = "select IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,IlanDurumu,ResimKonumu from tbl_Ilanlar where IlanBaslik = '"+lbSahiplenBaslik.Text+"' and HayvanTuru = '"+lbSahiplenTur.Text+"'and HayvanIrk = '"+lbSahiplenIrk.Text+"' and HayvanYas = '"+lbSahiplenYas.Text+"' and HayvanCinsiyet = '"+lbSahiplenCinsiyet.Text+"'and ResimKonumu = '"+pbSahiplenResim.ImageLocation+"'";
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
            try
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
                        dr.Close();
                        //MessageBox.Show(ilanBaslik); // veriyi çekiyor mu diye kontrol ediyorum
                        //MessageBox.Show(ilanTuru);
                        //MessageBox.Show(ilanIrk);
                        //MessageBox.Show(ilanYas);
                        //MessageBox.Show(ilanCinsiyet);
                        //MessageBox.Show(resimKonumu);

                        SqlCommand com2 = new SqlCommand();
                        com2.Connection = con;
                        com2.CommandText = "select Adi,Soyadi,TelefonNo from tbl_Kullanici where KullaniciAdi = '" + KullaniciAdi + "'";
                        SqlDataReader dr2 = com2.ExecuteReader();
                        if (dr2.Read())
                        {
                            string sahiplenenadi = dr2.GetString(0);
                            string sahiplenensoyadi = dr2.GetString(1);
                            string sahiplenentelno = dr2.GetString(2);
                            dr2.Close();
                            //MessageBox.Show(sahiplenenkadi);
                            //MessageBox.Show(sahiplenenadi);
                            //MessageBox.Show(sahiplenensoyadi);
                            //MessageBox.Show(sahiplenentelno);

                            SqlCommand com3 = new SqlCommand();
                            com3.Connection = con;
                            com3.CommandText = "select SahiplenecekKadi,IlanBaslik,IlanTur,IlanIrk,IlanYas,IlanCinsiyet,ResimKonumu from tbl_Sahiplenecek";
                            SqlDataReader dr3 = com3.ExecuteReader();
                            if (dr3.Read())
                            {
                                string kullaniciadi = dr3.GetString(0);
                                string ilanbaslik = dr3.GetString(1);
                                string ilantur = dr3.GetString(2);
                                string ilanirk = dr3.GetString(3);
                                string ilanyas = dr3.GetString(4);
                                string ilancinsiyet = dr3.GetString(5);
                                var resimyol = dr3.GetString(6);

                                //MessageBox.Show(kullaniciadi);
                                //MessageBox.Show(ilanbaslik);
                                //MessageBox.Show(ilantur);
                                //MessageBox.Show(ilanirk);
                                //MessageBox.Show(ilanyas);
                                //MessageBox.Show(ilancinsiyet);
                                //MessageBox.Show(resimyol);
                                dr3.Close();

                                if (resimyol == pbSahiplenResim.ImageLocation && ilanbaslik == lbSahiplenBaslik.Text &&
                                    ilantur == lbSahiplenTur.Text && ilanirk == lbSahiplenIrk.Text && kullaniciadi == KullaniciAdi
                                    && ilanyas == lbSahiplenYas.Text && ilancinsiyet == lbSahiplenCinsiyet.Text)
                                {
                                    MessageBox.Show("Aynı ilana birden fazla kez talepte bulunamazsınız.");
                                }
                                else
                                {
                                    SqlCommand com4 = new SqlCommand();
                                    com4.Connection = con;
                                    com4.CommandText = "insert into tbl_Sahiplenecek (SahiplenecekKadi,SahiplenecekAdi,SahiplenecekSoyadi,SahiplenecekTelNo,IlanBaslik,IlanTur,IlanIrk,IlanYas,IlanCinsiyet,ResimKonumu,IlanSahibiId) values('" + KullaniciAdi + "','" + sahiplenenadi + "','" + sahiplenensoyadi + "','" + sahiplenentelno + "','" + DegiskenBaslik + "','" + DegiskenTur + "','" + DegiskenIrk + "','" + DegiskenYas + "','" + DegiskenCinsiyet + "','" + DegiskenResim + "','" + DegiskenId + "')";
                                    SqlDataAdapter da = new SqlDataAdapter();
                                    com4.ExecuteNonQuery();

                                    MessageBox.Show("Talep başarılı!");
                                }
                            }
                        }
                    }
                }
                con.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hatalı işlem yaptınız." + hata);
            }
            
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
            com.CommandText = "select IlanId,ResimKonumu,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet from tbl_Ilanlar where ResimKonumu = '"+DegiskenResim+"' and IlanBaslik = '"+DegiskenBaslik+"' and HayvanTuru = '"+DegiskenTur+"' and HayvanIrk = '"+DegiskenIrk+"' and HayvanYas = '"+DegiskenYas+"' and HayvanCinsiyet = '"+DegiskenCinsiyet+"'";

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
                        SqlCommand com3 = new SqlCommand();
                        com3.Connection = con;
                        com3.CommandText = "insert into tbl_Mesajlar (Kimden,Kime,Mesaj,MesajTarihiveSaati,IlanId) values ('"+KullaniciAdi+"','"+ilanSahibiKAdi+"','"+Yorum+"','"+ tarihvesaat+ "',"+ilanId+")";
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
