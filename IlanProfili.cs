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
    public partial class IlanProfili : Form
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
        public string IlanSahibi { get; set; }
        public string SecilenKullanici { get; set; }
        public IlanProfili()
        {
            InitializeComponent();
        }

        private void IlanProfili_Load(object sender, EventArgs e)
        {
            KullaniciAdi = Anasayfa.KullaniciAdi;
            btSahiplenHesap.Text = KullaniciAdi;

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


            SqlCommand com = new SqlCommand();
            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
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
                        lbSahiplendirildi.Visible = true;
                    }
                }
                con.Close();
            }

            SqlCommand com4 = new SqlCommand();
            con.Open();
            com4.Connection = con;
            com4.CommandText = "select distinct Kimden from tbl_Mesajlar where not Kimden = '" + KullaniciAdi + "'";
            using (SqlDataReader dr4 = com4.ExecuteReader())
            {
                while (dr4.Read())
                {
                    string comboBoxKimden = dr4.GetString(0);
                    cbKime.Items.Add(comboBoxKimden);
                }
                dr4.Close();
            }
            con.Close();

            SqlCommand com2 = new SqlCommand();
            con.Open();
            com2.Connection = con;
            com2.CommandText = "select IlanId,IlanBaslik,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,IlanDurumu,ResimKonumu from tbl_Ilanlar where IlanBaslik = '" + lbSahiplenBaslik.Text + "' and HayvanTuru = '" + lbSahiplenTur.Text + "'and HayvanIrk = '" + lbSahiplenIrk.Text + "' and HayvanYas = '" + lbSahiplenYas.Text + "' and HayvanCinsiyet = '" + lbSahiplenCinsiyet.Text + "'and ResimKonumu = '" + pbSahiplenResim.ImageLocation + "'";
            using (SqlDataReader dr2 = com2.ExecuteReader())
            {
                if (dr2.Read())
                {
                    int ilanId = dr2.GetInt32(0);
                    IlanId = ilanId;
                    //MessageBox.Show(IlanId.ToString());
                    dr2.Close();
                }
            }
            con.Close();

            //SqlCommand com3 = new SqlCommand();
            //con.Open();
            //com3.Connection = con;
            //com3.CommandText = "select Kimden,Kime,Mesaj,MesajTarihiveSaati from tbl_Mesajlar where IlanId = " + IlanId + "";
            //using (SqlDataReader dr3 = com3.ExecuteReader())
            //{
            //    while (dr3.Read())
            //    {

            //        string kimden = dr3.GetString(0);
            //        string kime = dr3.GetString(1);
            //        string mesaj = dr3.GetString(2);
            //        string tarihvesaatdegisken = dr3.GetString(3);
            //        lbMesajlar.Items.Add(kimden+" > "+mesaj+" > "+tarihvesaatdegisken);
            //    }
            //    dr3.Close();
            //}
            //con.Close();
        }

        private void btSahiplenHesap_Click(object sender, EventArgs e)
        {
            cmHesap.Show(Cursor.Position.X, Cursor.Position.Y);
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

        private void gelenIstekler_Click(object sender, EventArgs e)
        {
            this.Hide();
            GelenIstekler gi = new GelenIstekler();
            gi.ShowDialog();
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
                        com3.CommandText = "insert into tbl_Mesajlar (Kimden,Kime,Mesaj,MesajTarihiveSaati,IlanId) values ('"+KullaniciAdi+"','"+cbKime.SelectedItem+"','"+Yorum+"','"+ tarihvesaat+ "',"+ilanId+")";
                        SqlDataAdapter da = new SqlDataAdapter();
                        com3.ExecuteNonQuery();

                        MessageBox.Show("Mesaj Gönderildi!");
                    }
                }
            }
            con.Close();
        }

        private void cbKime_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbMesajlar.Items.Clear();

            //MessageBox.Show(cbKime.SelectedItem.ToString());
            SecilenKullanici = cbKime.SelectedItem.ToString();


            SqlConnection con = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");

            SqlCommand com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "select KullaniciAdi from tbl_Kullanici where KullaniciId in (select KullaniciNo from tbl_Ilanlar where IlanId in (select IlanId from tbl_Mesajlar where IlanId = " + IlanId + "))";
            using (SqlDataReader dr = com.ExecuteReader())
            {
                while (dr.Read())
                {
                    string ilanSahibiKullaniciAdi = dr.GetString(0);
                    IlanSahibi = ilanSahibiKullaniciAdi;
                }
                dr.Close();
                SqlCommand com2 = new SqlCommand();
                com2.Connection = con;
                com2.CommandText = "select Kimden,Kime,Mesaj,MesajTarihiveSaati from tbl_Mesajlar where (IlanId = "+IlanId+" and Kimden = '"+SecilenKullanici+"' and Kime = '"+ IlanSahibi+ "') or (IlanId = " + IlanId + " and Kimden = '" + IlanSahibi + "' and Kime = '" + SecilenKullanici + "')";
                using (SqlDataReader dr2 = com2.ExecuteReader())
                {
                    while (dr2.Read())
                    {
                         string ozelkimden = dr2.GetString(0);
                         string ozelkime = dr2.GetString(1);
                         string ozelmesaj = dr2.GetString(2);
                         string ozeltarih = dr2.GetString(3);

                         //MessageBox.Show(ozelkimden);
                         //MessageBox.Show(ozelkime);
                         //MessageBox.Show(ozelmesaj);
                         //MessageBox.Show(ozeltarih);

                         lbMesajlar.Items.Add(ozelkimden + " > " + ozelmesaj + " > " + ozeltarih);
                    }
                    dr2.Close();
                }
            }
            con.Close();
        }
    }
}
