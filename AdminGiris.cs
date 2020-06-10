using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Petilan.Sayfalar
{
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btAdminGiris_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data Source=BURAK\\SQLEXPRESS;Initial Catalog=PETILAN_YDK;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            baglanti.Open();
            command.Connection = baglanti;
            command.CommandText = "SELECT * FROM tbl_Admin where AdminKAdi='" + tbAdminKAdi.Text + "' AND Sifre='" + tbAdminSifre.Text + "'";
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                MessageBox.Show("Giriş Başarılı!");
                lbAdminGirildi.Text = tbAdminKAdi.Text;
                lbAdminGirildi.Visible = true;
                label1.Hide();
                label2.Hide();
                tbAdminKAdi.Hide();
                tbAdminSifre.Hide();
                btAdminGiris.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            baglanti.Close();
        }
    }
}
