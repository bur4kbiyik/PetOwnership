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
        
        public Anasayfa()
        {
            InitializeComponent();
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
        
        public static string KullaniciAdi { get; set; }
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            KullaniciAdi = tbKAdiAnasayfa.Text;
        }
        SqlConnection baglanti;
        SqlCommand command;
        SqlDataReader dataReader;

        public static string SetValueForText1 = "";
        private void btGiris_Click(object sender, EventArgs e)
        {
            KullaniciAdi = tbKAdiAnasayfa.Text;
            AnasayfaListele.KullaniciAdi = KullaniciAdi;
            
            baglanti = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            command = new SqlCommand();
            baglanti.Open();
            command.Connection = baglanti;
            command.CommandText = "SELECT * FROM tbl_Kullanici where KullaniciAdi='" + KullaniciAdi + "' AND Sifre='" + tbSifreAnasayfa.Text + "'";
            dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                AnasayfaListele ansyfliste = new AnasayfaListele();
                this.Hide();
                ansyfliste.ShowDialog();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            baglanti.Close();
        }
        private void adminGiris_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminGiris adminGiris = new AdminGiris();
            adminGiris.ShowDialog();
        }

        private void btGiris_BackColorChanged(object sender, EventArgs e)
        {
           
        }

        private void btGiris_StyleChanged(object sender, EventArgs e)
        {
            
        }
    }
}
