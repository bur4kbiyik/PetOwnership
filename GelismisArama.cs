using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Petilan.Sayfalar
{
    public partial class GelismisArama : Form
    {
        public string KullaniciAdi { get; set; }
        public static string AramaTur { get; set; }
        public static string AramaIrk { get; set; }
        public static string AramaYas { get; set; }
        public static string AramaCinsiyet { get; set; }
        public GelismisArama()
        {
            InitializeComponent();
        }
        public void aramaYapma()
        {
            AramaTur = cbAramaTur.SelectedItem.ToString();
            AramaIrk = cbAramaIrk.SelectedItem.ToString();
            AramaYas = cbAramaYas.SelectedItem.ToString();
            AramaCinsiyet = cbAramaCinsiyet.SelectedItem.ToString();

            //MessageBox.Show(AramaTur);
            //MessageBox.Show(AramaIrk);
            //MessageBox.Show(AramaYas);
            //MessageBox.Show(AramaCinsiyet);

            AramaSonuc.AramaSonucTur = AramaTur;
            AramaSonuc.AramaSonucIrk = AramaIrk;
            AramaSonuc.AramaSonucYas = AramaYas;
            AramaSonuc.AramaSonucCinsiyet = AramaCinsiyet;
            AramaSonuc aramasonuc = new AramaSonuc();
            this.Hide();
            aramasonuc.Show();
        }

        private void btAramaYap_Click(object sender, EventArgs e)
        {

            if (cbAramaIrk.SelectedItem == null && cbAramaYas.SelectedItem == null &&
                    cbAramaCinsiyet.SelectedItem == null && cbAramaTur.SelectedItem == null)
            {
                MessageBox.Show("Herhangi bir filtreleme yapmadınız lütfen tekrar kontrol ediniz.");
            }
           
            else
            {
                if (cbAramaTur.SelectedItem != null)
                {
                    AramaTur = cbAramaTur.SelectedItem.ToString();
                }
                if (cbAramaIrk.SelectedItem != null)
                {
                    AramaIrk = cbAramaIrk.SelectedItem.ToString();
                }
                if (cbAramaYas.SelectedItem != null)
                {
                    AramaYas = cbAramaYas.SelectedItem.ToString();
                }
                if (cbAramaCinsiyet.SelectedItem != null)
                {
                    AramaCinsiyet = cbAramaCinsiyet.SelectedItem.ToString();
                }

                //MessageBox.Show(AramaTur);
                //MessageBox.Show(AramaIrk);
                //MessageBox.Show(AramaYas);
                //MessageBox.Show(AramaCinsiyet);

                AramaSonuc aramaSonuc = new AramaSonuc();
                AramaSonuc.AramaSonucTur = AramaTur;
                AramaSonuc.AramaSonucIrk = AramaIrk;
                AramaSonuc.AramaSonucYas = AramaYas;
                AramaSonuc.AramaSonucCinsiyet = AramaCinsiyet;
                this.Hide();
                aramaSonuc.ShowDialog();
            }

        }

        private void GelismisArama_Load(object sender, EventArgs e)
        {

            KullaniciAdi = Anasayfa.KullaniciAdi;
            btHesap.Text = KullaniciAdi;
        }

        private void btHesap_Click(object sender, EventArgs e)
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
            ilanVerSayfa.btHesapIlanVer.Text = btHesap.Text;
            ilanVerSayfa.ShowDialog();
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
            anasayfa.ShowDialog();
        }

        private void btAnasayfa_Click(object sender, EventArgs e)
        {
            AnasayfaListele.KullaniciAdi = KullaniciAdi;
            this.Hide();
            AnasayfaListele ansyflst = new AnasayfaListele();
            ansyflst.ShowDialog();
        }
    }
}
