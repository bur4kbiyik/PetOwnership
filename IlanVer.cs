using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petilan.Sayfalar
{
    public partial class IlanVer : Form
    {
        public IlanVer()
        {
            InitializeComponent();
        }

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
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Resim eklenirken bir hata oluştu.");
            }
        }

        private void btIlanVer_Click(object sender, EventArgs e)
        {
            string resimKontrol = pbImageUpload.ImageLocation;

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
            else if (cbHayvanIrki.SelectedIndex != 1 && cbHayvanIrki.SelectedIndex != 2 &&
                    cbHayvanIrki.SelectedIndex != 3 && cbHayvanIrki.SelectedIndex != 4 &&
                    cbHayvanIrki.SelectedIndex != 5 && cbHayvanIrki.SelectedIndex != 6 &&
                    cbHayvanIrki.SelectedIndex != 7 && cbHayvanIrki.SelectedIndex != 8 &&
                    cbHayvanIrki.SelectedIndex != 9 && cbHayvanIrki.SelectedIndex != 10 &&
                    cbHayvanIrki.SelectedIndex != 11 && cbHayvanIrki.SelectedIndex != 12 &&
                    cbHayvanIrki.SelectedIndex != 14 && cbHayvanIrki.SelectedIndex != 15 &&
                    cbHayvanIrki.SelectedIndex != 16 && cbHayvanIrki.SelectedIndex != 17 &&
                    cbHayvanIrki.SelectedIndex != 18 && cbHayvanIrki.SelectedIndex != 19 &&
                    cbHayvanIrki.SelectedIndex != 20 && cbHayvanIrki.SelectedIndex != 21 &&
                    cbHayvanIrki.SelectedIndex != 22 && cbHayvanIrki.SelectedIndex != 23 &&
                    cbHayvanIrki.SelectedIndex != 24 && cbHayvanIrki.SelectedIndex != 26 &&
                    cbHayvanIrki.SelectedIndex != 27 && cbHayvanIrki.SelectedIndex != 28 &&
                    cbHayvanIrki.SelectedIndex != 29 && cbHayvanIrki.SelectedIndex != 30 &&
                    cbHayvanIrki.SelectedIndex != 32 && cbHayvanIrki.SelectedIndex != 33 &&
                    cbHayvanIrki.SelectedIndex != 34 && cbHayvanIrki.SelectedIndex != 35 &&
                    cbHayvanIrki.SelectedIndex != 37 && cbHayvanIrki.SelectedIndex != 38 &&
                    cbHayvanIrki.SelectedIndex != 39 && cbHayvanIrki.SelectedIndex != 40 &&
                    cbHayvanIrki.SelectedIndex != 42 && cbHayvanIrki.SelectedIndex != 43 &&
                    cbHayvanIrki.SelectedIndex != 44 && cbHayvanIrki.SelectedIndex != 45 &&
                    cbHayvanIrki.SelectedIndex != 46 && cbHayvanIrki.SelectedIndex != 47 &&
                    cbHayvanIrki.SelectedIndex != 48 && cbHayvanIrki.SelectedIndex != 49 &&
                    cbHayvanIrki.SelectedIndex != 50)
            {

                        MessageBox.Show("Hayvan Irkı seçmediniz tekrar kontrol ediniz.");

            }
            else if (cbHayvanYasi.SelectedIndex != 0 && cbHayvanYasi.SelectedIndex != 1 &&
                    cbHayvanYasi.SelectedIndex != 2 && cbHayvanYasi.SelectedIndex != 3 &&
                    cbHayvanYasi.SelectedIndex != 4)
            {
                MessageBox.Show("Hayvan Yaşı seçmediniz tekrar kontrol ediniz.");
            }
            else if (cbHayvanCinsiyeti.SelectedIndex != 0 && cbHayvanCinsiyeti.SelectedIndex != 1)
            {
                MessageBox.Show("Hayvan Cinsiyeti seçmediniz tekrar kontrol ediniz.");
            }
            else if (File.Exists(resimKontrol) == false)
            {
                MessageBox.Show("Resim eklemeyi unuttunuz tekrar kontrol ediniz.");
            }
        }
    }
}
