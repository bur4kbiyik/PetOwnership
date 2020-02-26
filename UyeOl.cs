using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Petilan.Sayfalar
{
    public partial class UyeOl : Form
    {
        public UyeOl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbSifre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbSifreTekrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btUyeOl_Click(object sender, EventArgs e)
        {

            if (tbSifre.Text != tbSifreTekrar.Text)
            {
                MessageBox.Show("Şifre ve şifre tekrarı birbirleri ile aynı değil tekrar kontrol ediniz!");
            }
            else if (tbAdi.Text == "")
            {
                MessageBox.Show("Adı, kısmını boş bıraktınız tekrar kontrol ediniz.");
            }
            else if (tbSoyadi.Text == "")
            {
                MessageBox.Show("Soyadı, kısmını boş bıraktınız tekrar kontrol ediniz.");
            }
            else if (tbKAdi.Text == "")
            {
                MessageBox.Show("Kullanıcı Adı, kısmını boş bıraktınız tekrar kontrol ediniz.");
            }
            else if (tbSifre.Text == "")
            {
                MessageBox.Show("Şifre, kısmını boş bıraktınız tekrar kontrol ediniz.");
            }
            else if (tbSifreTekrar.Text == "")
            {
                MessageBox.Show("Şifre Tekrar, kısmını boş bıraktınız tekrar kontrol ediniz.");
            }
            else if (tbEMail.Text == "")
            {
                MessageBox.Show("E-Mail, kısmını boş bıraktınız tekrar kontrol ediniz.");

            }
            else if (cbCinsiyet.SelectedIndex != 0 && cbCinsiyet.SelectedIndex != 1)
            {
                MessageBox.Show("Cinsiyet, kısmını boş bıraktınız tekrar kontrol ediniz.");
            }
            else
            {
                try
                {

                    SqlConnection baglanti = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");

                    if (baglanti.State == ConnectionState.Closed)
                        baglanti.Open();


                    if (VarMi(tbKAdi.Text) != 0)
                    {
                        MessageBox.Show("Bu Kullanıcı Adı ile daha önce kayıt yapılmış.");
                    }
                    else if (VarMi(tbEMail.Text) != 0)
                    {
                        MessageBox.Show("Bu E-Mail ile daha önce kayıt yapılmış.");
                    }
                    else if (VarMi(tbTelNo.Text) != 0)
                    {
                        MessageBox.Show("Bu Telefon Numarası ile daha önce kayıt yapılmış.");
                    }
                    else
                    {

                        bool eMailKontrol = EmailKontrol(tbEMail.Text);

                        if (eMailKontrol) {

                            string kayit = "insert into tbl_Kullanici(KullaniciAdi,Sifre,Adi,Soyadi,Mail,TelefonNo,Cinsiyet) values ('" + tbKAdi.Text + "','" + tbSifre.Text + "','" + tbAdi.Text + "','" + tbSoyadi.Text + "','" + tbEMail.Text + "','" + tbTelNo.Text + "','" + cbCinsiyet.Text + "')";
                            SqlCommand command = new SqlCommand(kayit, baglanti);
                            command.ExecuteNonQuery();
                            MessageBox.Show("Kayıt işlemi başarılı.");

                            this.Hide();
                            Anasayfa anasayfa = new Anasayfa();
                            anasayfa.tbKAdiAnasayfa.Text = tbKAdi.Text;
                            anasayfa.tbSifreAnasayfa.Text = tbSifre.Text;
                            anasayfa.ShowDialog();
                        }

                        else
                        {
                            MessageBox.Show("Mail adresinizi kontrol ediniz.");
                            
                        }

                    }

                    baglanti.Close();

                }
                catch (Exception hata)
                {
                    MessageBox.Show("İşlem sırasında hata oluştu. " + hata.Message);
                }
            }
        }

        private bool EmailKontrol(string email)
        {
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
            + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
            + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
            + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
            + @"[a-zA-Z]{2,}))$";
            Regex reStrict = new Regex(patternStrict);
            bool isStrictMatch = reStrict.IsMatch(email);
            return isStrictMatch;
        }

        public int VarMi(string aranan)
        {
            int kAdiSonuc, mailSonuc, telNoSonuc;
            SqlConnection baglanti = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            string kullaniciadi = "Select COUNT(KullaniciAdi) from tbl_Kullanici WHERE KullaniciAdi='" + aranan + "'";
            string mail = "Select COUNT(Mail) from tbl_Kullanici WHERE Mail='" + aranan + "'";
            string telno = "Select COUNT(TelefonNo) from tbl_Kullanici WHERE TelefonNo='" + aranan + "'";

            SqlCommand kAdiCommand = new SqlCommand(kullaniciadi, baglanti);
            SqlCommand mailCommand = new SqlCommand(mail, baglanti);
            SqlCommand telNoCommand = new SqlCommand(telno, baglanti);

            baglanti.Open();

            kAdiSonuc = Convert.ToInt32(kAdiCommand.ExecuteScalar());
            mailSonuc = Convert.ToInt32(mailCommand.ExecuteScalar());
            telNoSonuc = Convert.ToInt32(telNoCommand.ExecuteScalar());

            baglanti.Close();

            return kAdiSonuc + mailSonuc + telNoSonuc;

        }
        private void tbTelNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.ShowDialog();
        }
    }
}
