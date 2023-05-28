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
        public OknoDodaniaSeansu()
        {
            InitializeComponent();
        }

        public void ustawID(int filmId, int seansID = 0)
        {
            film = new Filmy(filmId, true);
            label2.Text = film.Film_Title;
            if (seansID == 0)
            {
                dtp_dataRoz.Text = DateTime.Now.ToString("d");
                dtp_godzRozp.Text = DateTime.Now.ToString("t");
                //DateTime temp = DateTime.Now.Minute + film.Film_Duration;

            }

        }


    }
}
