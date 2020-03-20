using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Petilan.Sayfalar
{
    public partial class IlanVer : Form
    {
        public static string KullaniciAdi { get; set; }
        public void ilanKontrol()
        {

            string resimKontrol = pbImageUpload.ImageLocation;

            if (cbHayvanYasi.SelectedIndex != 0 && cbHayvanYasi.SelectedIndex != 1 &&
                    cbHayvanYasi.SelectedIndex != 2 && cbHayvanYasi.SelectedIndex != 3 &&
                    cbHayvanYasi.SelectedIndex != 4)
            {
                MessageBox.Show("Hayvan Yaşı seçmediniz tekrar kontrol ediniz.");
            }
            else
            {
                if (cbHayvanCinsiyeti.SelectedIndex != 0 && cbHayvanCinsiyeti.SelectedIndex != 1)
                {
                    MessageBox.Show("Hayvan Cinsiyeti seçmediniz tekrar kontrol ediniz.");
                }
                else
                {
                    if (cbIlanDurumu.SelectedIndex != 0)
                    {
                        MessageBox.Show("Lütfen ilan durumunu aktif olarak (A) işaretleyiniz.");
                    }
                    else
                    {
                        if (File.Exists(resimKontrol) == false)
                        {
                            MessageBox.Show("Resim eklemeyi unuttunuz tekrar kontrol ediniz.");
                        }
                        else
                        {
                            try
                            {
                                SqlConnection baglanti = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");

                                if (baglanti.State == ConnectionState.Closed)
                                    baglanti.Open();


                                string kullaniciNo = "select * from tbl_Kullanici where KullaniciAdi = '" + KullaniciAdi + "'";
                                SqlCommand command2 = new SqlCommand(kullaniciNo, baglanti);
                                SqlDataReader reader = command2.ExecuteReader();
                                var id = 0;
                                while (reader.Read())
                                {
                                    id = Convert.ToInt32(reader[0]);
                                }
                                reader.Close();

                                try
                                {
                                    string veriEkle = "insert into tbl_Ilanlar(IlanBaslik,HayvanAdi,HayvanTuru,HayvanIrk,HayvanYas,HayvanCinsiyet,IlanDurumu,KullaniciNo,ResimKonumu) values ('" + tbIlanBaslik.Text + "','" + tbHayvanIsmi.Text + "','" + cbHayvanTuru.Text + "','" + cbHayvanIrki.Text + "','" + cbHayvanYasi.Text + "','" + cbHayvanCinsiyeti.Text + "','" + cbIlanDurumu.Text + "','" + id + "','" + imageUplGlb + "')";
                                    SqlCommand command = new SqlCommand(veriEkle, baglanti);
                                    command.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }

                                MessageBox.Show("İlan yayınlama işlemi başarılı.");

                                baglanti.Close();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show("İşlem sırasında hata oluştu. " + ex);
                            }
                        }

                    }
                }
            }
        }
        public IlanVer()
        {
            InitializeComponent();
        }
        string imageUplGlb;
        private void btResimEkle_Click(object sender, EventArgs e)
        {
            String imageLocation = "";

            try
            {
                OpenFileDialog imageUpload = new OpenFileDialog();
                imageUpload.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if (imageUpload.ShowDialog() == DialogResult.OK)
                {
                    imageLocation = imageUpload.FileName;
                    pbImageUpload.ImageLocation = imageLocation;
                    imageUplGlb = imageLocation;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Resim eklenirken bir hata oluştu.");
            }
        }


        private void btIlanVer_Click(object sender, EventArgs e)
        {


            if (tbIlanBaslik.Text == "")
            {
                MessageBox.Show("İlan başlığını boş bıraktınız tekrar kontrol ediniz.");
            }
            else if (tbHayvanIsmi.Text == "")
            {
                MessageBox.Show("Evcil hayvanınızın ismini boş bıraktınız tekrar kontrol ediniz.");
            }
            else if (cbHayvanTuru.SelectedIndex != 0 && cbHayvanTuru.SelectedIndex != 1 &&
                    cbHayvanTuru.SelectedIndex != 2 && cbHayvanTuru.SelectedIndex != 3 &&
                    cbHayvanTuru.SelectedIndex != 4 && cbHayvanTuru.SelectedIndex != 5)
            {
                MessageBox.Show("Hayvan Türü seçmediniz tekrar kontrol ediniz.");
            }

            else if (cbHayvanIrki.SelectedIndex == 0 || cbHayvanIrki.SelectedIndex == 13
                    || cbHayvanIrki.SelectedIndex == 25 || cbHayvanIrki.SelectedIndex == 31
                    || cbHayvanIrki.SelectedIndex == 36 || cbHayvanIrki.SelectedIndex == 41)
            {
                MessageBox.Show("Hayvan Irkı seçiminde bir terslik var tekrar kontrol ediniz.");
            }
            else if (cbHayvanIrki.SelectedItem == null)
            {
                MessageBox.Show("Hayvan Irkı seçmediniz lütfen tekrar kontrol ediniz.");
            }
            else if (cbHayvanTuru.SelectedIndex == 0)
            {
                if (!(cbHayvanIrki.SelectedIndex >= 14 && cbHayvanIrki.SelectedIndex <= 24))
                {
                    MessageBox.Show("Lütfen bir kedi ırkı seçiniz.");
                }
                else
                {
                    ilanKontrol();
                }
            }
            else if (cbHayvanTuru.SelectedIndex == 1)
            {
                if (!(cbHayvanIrki.SelectedIndex >= 1 && cbHayvanIrki.SelectedIndex <= 12))
                {
                    MessageBox.Show("Lütfen bir köpek ırkı seçiniz.");
                }
                else
                {
                    ilanKontrol();
                }
            }
            else if (cbHayvanTuru.SelectedIndex == 2)
            {
                if (!(cbHayvanIrki.SelectedIndex >= 26 && cbHayvanIrki.SelectedIndex <= 30))
                {
                    MessageBox.Show("Lütfen bir kuş ırkı seçiniz.");
                }
                else
                {
                    ilanKontrol();
                }
            }
            else if (cbHayvanTuru.SelectedIndex == 3)
            {
                if (!(cbHayvanIrki.SelectedIndex >= 32 && cbHayvanIrki.SelectedIndex <= 35))
                {
                    MessageBox.Show("Lütfen bir sürüngen ırkı seçiniz.");
                }
                else
                {
                    ilanKontrol();
                }
            }
            else if (cbHayvanTuru.SelectedIndex == 4)
            {
                if (!(cbHayvanIrki.SelectedIndex >= 37 && cbHayvanIrki.SelectedIndex <= 40))
                {
                    MessageBox.Show("Lütfen bir kemirgen ırkı seçiniz.");
                }
                else
                {
                    ilanKontrol();
                }
            }
            else if (cbHayvanTuru.SelectedIndex == 5)
            {
                if (!(cbHayvanIrki.SelectedIndex >= 42 && cbHayvanIrki.SelectedIndex <= 50))
                {
                    MessageBox.Show("Lütfen bir su canlısı ırkı seçiniz.");
                }
                else
                {
                    ilanKontrol();
                }
            }
        }

        private void pbPetIlanLogo_Click(object sender, EventArgs e)
        {

        }

        private void btHesapIlanVer_Click(object sender, EventArgs e)
        {
            cmHesap.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void cmHesap_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Zaten İlan Ver sayfasındasınız.");
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
            this.Hide();
            Ilanlarim ilanlarim = new Ilanlarim();
            ilanlarim.btIlanlarimHesap.Text = btHesapIlanVer.Text;
            ilanlarim.ShowDialog();
        }

        private void IlanVer_Load(object sender, EventArgs e)
        {
            KullaniciAdi = Anasayfa.KullaniciAdi;
            btHesapIlanVer.Text = KullaniciAdi;
        }

        private void gelenIstekler_Click(object sender, EventArgs e)
        {
            this.Hide();
            GelenIstekler gi = new GelenIstekler();
            gi.ShowDialog();
        }
    }
}
