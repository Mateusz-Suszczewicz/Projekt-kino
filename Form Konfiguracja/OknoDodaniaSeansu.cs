using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_kino.Form_Konfiguracja
{
    public partial class OknoDodaniaSeansu : Form
    {
        Filmy film;
        seanse seans;
        public OknoDodaniaSeansu()
        {
            InitializeComponent();
        }

        public void ustawID(Filmy filmId, int seansID = 0)
        {
            film = filmId;
            label2.Text = film.Film_Title;

            #region ustawienie daty i czasu
            if (seansID == 0)
            {
                ustawienieDaty(false);

            }
            else
            {
                foreach (seanse i in film.seanses)
                {
                    if (i.SE_ID == seansID)
                    {
                        seans = i;
                        tb_dataRoz.Text = i.getDataEmisji();
                        tb_godzRoz.Text = i.getGodzinaEmisji();
                        ustawienieDaty();
                    }
                }
            }
            #endregion

            foreach ((int, string) i in Program.baza.pobranieListySal())
            {
                listBox1.Items.Add(i.Item2);
                if (seans != null && i.Item1 == seans.SE_SRID)
                {
                    listBox1.SelectedItem = i.Item2;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ustawienieDaty(bool pobranieDanych = true)
        {
            DateTime now;

            if (pobranieDanych)
            {
                string text = $"{tb_dataRoz.Text} {tb_godzRoz.Text}";
                now = DateTime.ParseExact(text, "dd.MM.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            }
            else
            {
                now = DateTime.Now;
            }

            DateTime temp = now.AddMinutes(film.Film_Duration);
            tb_dataRoz.Text = now.ToString("dd.MM.yyyy");
            tb_godzRoz.Text = now.ToString("HH:mm");
            tb_dataZak.Text = temp.ToString("dd.MM.yyyy");
            tb_godzZak.Text = temp.ToString("HH:mm");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = $"{tb_dataRoz.Text} {tb_godzRoz.Text}";
            seans.SE_DataEmisji = DateTime.ParseExact(text, "dd.MM.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

            text = $"{tb_dataZak.Text} {tb_godzZak.Text}";
            seans.SE_DataKonca = DateTime.ParseExact(text, "dd.MM.yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            seans.SE_SRID = Program.baza.getIdSali(int.Parse(listBox1.SelectedItem.ToString()));
            Program.baza.dodajSeans(seans);
        }
    }
}
